using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
using Utis.Minex.Common.Enum;
using Utis.Minex.Common.Helpers;
using Utis.Minex.Common.Interfaces;

namespace Utis.Minex.Common.DistanceLocalCache
{
    public class DistanceLocalCache : IDistanceLocalCache
    {
        private readonly string _directoryPath;
        private const string FileExtension = ".distCache";
        private const string Prefix = "Distances";
        private const string DirectoryName = "Cache";
        private const string Delimitter = "_";

        private readonly bool _isEnabled = false;
        private readonly object _lock = new object();

        public DistanceLocalCache(IDistanceLocalCacheSettings settings,
            IServerInputOutput console = null, IPureLogger logger = null)
        {
            if (console == null && logger == null)
            {
                throw new ArgumentNullException("Нужен хотя бы 1 логгер");
            }
            _serverInputOutput = console;
            _logger = logger;
            _settings = settings;
            _isEnabled = settings.SaveDistanceLocalCache;
            _directoryPath = $@"{Path.GetPathRoot(Environment.SystemDirectory)}\Users\Public\UtisMinex\{_settings.ApplicationName}\{DirectoryName}\";
        }

        private long _cachedBranchId;
        private long _cachedSchemeId;

        #region InlandDepends
        private readonly IServerInputOutput _serverInputOutput;
        private readonly IDistanceLocalCacheSettings _settings;
        private readonly IPureLogger _logger;
        #endregion

        public bool IsEnabled => _isEnabled;

        public void WriteShortestPathToFileAsync(long schemeId, long branchId, Dictionary<long, Dictionary<long, float>> shortestDistances)
        {
            if (!_isEnabled)
            {
                return;
            }

            lock (_lock)
            {
                DeleteCacheFile();

                var sw = Stopwatch.StartNew();

                var fullPath = GetFullPath(schemeId, branchId);

                using (StreamWriter fs = new StreamWriter(fullPath, false))
                {
                    WriteLog($"Старт записи кеша дистанций между вершинами графа {schemeId}");

                    try
                    {
                        var fileSerializationStarted = sw.ElapsedMilliseconds;

                        QueueHandler<string> writeQueue = null;

                        Exception exception = null;

                        var action = (string str) =>
                        {
                            try
                            {
                                fs.WriteLine(str);
                            }
                            catch (Exception ex)
                            {
                                exception = ex;
                                throw exception;
                            }
                        };

                        var queueName = $"{nameof(writeQueue)} в {nameof(DistanceLocalCache)}";

                        writeQueue = _serverInputOutput == null ? new QueueHandler<string>(action, _logger, queueName) :
                                                              new QueueHandler<string>(action, _serverInputOutput, queueName);

                        writeQueue.Start();

                        foreach (var keyValue in shortestDistances)
                        {
                            writeQueue.Add(JsonSerializer.Serialize(keyValue));
                        }

                        writeQueue.Stop(false);
                        writeQueue.Dispose();
                        action = null;

                        if (exception != null)
                        {
                            throw exception;
                        }

                        _cachedBranchId = branchId;
                        _cachedSchemeId = schemeId;

                        WriteLog($"Конец записи кеша {schemeId} затраченное время {(sw.Elapsed.TotalMilliseconds - fileSerializationStarted) / 1000d:N} с");
                    }
                    catch (Exception)
                    {
                        WriteLog($"Ошибка при записи в файл кеша");
                        DeleteCacheFile();
                    }
                }
            }
        }

        public bool TryReadShortestPathFromFile(long schemeId, long branchId, out Dictionary<long, Dictionary<long, float>> shortedDistances)
        {
            shortedDistances = null;
            if (!_isEnabled)
            {
                return false;
            }

            lock (_lock)
            {
                if (!TryGetStoredFileInfo(out var fileInfo, out var filePath)) return false;

                if (!IsStoredFileValid(schemeId, branchId)) return false;

                var shortedDistancesLocal = new Dictionary<long, Dictionary<long, float>>();

                var sw = Stopwatch.StartNew();

                WriteLog($"Старт чтения кеша дистанций между вершинами графа {schemeId}");

                var fileSerializationStarted = sw.ElapsedMilliseconds;

                var isException = false;

                using (StreamReader fs = new StreamReader(filePath))
                {
                    QueueHandlersWrapperKeyless<string> deserializeQueues = null;

                    var action = (string str) =>
                        {
                            try
                            {
                                var keyValuePair = JsonSerializer.Deserialize<KeyValuePair<long, Dictionary<long, float>>>(str);
                                shortedDistancesLocal.Add(keyValuePair.Key, keyValuePair.Value);
                            }
                            catch (Exception)
                            {
                                isException = true;
                                throw;
                            }
                        };

                    deserializeQueues = _serverInputOutput == null ?
                                        new QueueHandlersWrapperKeyless<string>(nameof(deserializeQueues), nameof(DistanceLocalCache), action, _logger) :
                                        new QueueHandlersWrapperKeyless<string>(nameof(deserializeQueues), nameof(DistanceLocalCache), action, _serverInputOutput);

                    deserializeQueues.Start();

                    while (!fs.EndOfStream)
                    {
                        deserializeQueues.Add(fs.ReadLine());
                    }

                    deserializeQueues.Stop();
                    deserializeQueues.Dispose();

                    action = null;
                }

                if (isException)
                {
                    DeleteCacheFile();
                    WriteLog("Ошибка чтения файла кеша");
                    return false;
                }

                shortedDistances = shortedDistancesLocal;

                WriteLog($"Конец чтения кеша {schemeId}, затраченное время {(sw.Elapsed.TotalMilliseconds - fileSerializationStarted) / 1000d:N} с");

                return true;
            }
        }

        private void DeleteCacheFile()
        {
            if (TryGetStoredFilesPath(out var filesPath))
            {
                foreach (var path in filesPath)
                {
                    TryCatchLog(() => File.Delete(path));
                }
            }
        }

        private bool TryGetStoredFileInfo(out (long schemeId, long branchId) result, out string filePath)
        {
            result = default;
            filePath = default;

            if (!TryGetStoredFileName(out var lastFileName, out filePath)) return false;

            result = GetInfoFromFileName(lastFileName);
            _cachedBranchId = result.branchId;
            _cachedSchemeId = result.schemeId;
            return true;
        }

        private bool TryGetStoredFilesPath(out string[] filesPath)
        {
            filesPath = null;

            if (!Directory.Exists(_directoryPath))
            {
                TryCatchLog(() => Directory.CreateDirectory(_directoryPath));
                return false;
            }

            string[] files = null;
            TryCatchLog(() => files = Directory.GetFiles(_directoryPath, $"*{FileExtension}"));

            if (files == null || files?.Length == 0)
            {
                WriteLog("Не удалось найти файл локального кеша");
                return false;
            }

            filesPath = files;
            return true;
        }

        private bool TryGetStoredFileName(out string fileName, out string filePath)
        {
            fileName = null;
            filePath = null;

            if (!TryGetStoredFilesPath(out string[] filesPath))
            {
                return false;
            }

            if (filesPath.Length > 1)
            {
                WriteLog("В папке содержится не 1 файл с кешем");
                return false;
            }

            filePath = filesPath.First();

            fileName = Path.GetFileNameWithoutExtension(filePath);
            return true;
        }

        private bool IsStoredFileValid(long schemeId, long branchId) =>
            _cachedSchemeId == schemeId && _cachedBranchId == branchId;

        private (long schemeId, long branchId) GetInfoFromFileName(string fileNameWithouExt)
        {
            var data = fileNameWithouExt.Split(Delimitter);
            if (data.Length != 3 || data[1].IsNullOrEmpty() || data[2].IsNullOrEmpty() ||
                !long.TryParse(data[1], out var branchId) ||
                !long.TryParse(data[2], out var schemeId))
            {
                WriteLog("Неизвестный формат имени файла");
                return default;
            }
            return (schemeId, branchId);
        }

        private static string GetFileName(long schemeId, long branchId) =>
            $"{Prefix}{Delimitter}{branchId}{Delimitter}{schemeId}{FileExtension}";

        private string GetFullPath(long schemeId, long branchId)
        {
            return Path.GetFullPath(Path.Combine(_directoryPath, GetFileName(schemeId, branchId)));
        }

        private void WriteLog(string message, LogMessageType logMessageType = LogMessageType.Info)
        {
            if (_serverInputOutput != null)
            {
                _serverInputOutput.WriteLine($"{nameof(DistanceLocalCache)}:{message}", logMessageType);
                return;
            }
            _logger?.WriteLine($"{nameof(DistanceLocalCache)}:{message}", logMessageType);
        }

        private void WriteLog(Exception ex)
        {
            if (_serverInputOutput != null)
            {
                _serverInputOutput.WriteLine(ex);
                return;
            }
            _logger?.WriteException(ex);
        }

        private void TryCatchLog(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                WriteLog(new Exception($"Ошибка в {nameof(DistanceLocalCache)}", ex));
            }
        }

    }
}
