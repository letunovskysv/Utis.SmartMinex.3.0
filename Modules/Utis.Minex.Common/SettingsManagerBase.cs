using System;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Text;
using System.Linq;
using System.Reflection;
using System.Globalization;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Utis.Minex.Common
{
    using System.Collections;
    using System.Collections.Concurrent;
    #region Using
    
    using Utis.Minex.Common.Settings;

        #endregion

    public abstract partial class SettingsManagerBase : ISettingsManagerBase
    {
        #region ApplicationName

        /// <summary>
        /// Имя папки которая создастся по умолчанию в ProgramData.
        /// </summary>
        public abstract string ApplicationName 
        { get; }

        /// <summary>
        /// Префикс лог файлов
        /// </summary>
        public abstract string ApplicationLogPrefix
        { get; }

        #endregion

        #region SettingsFileName

        /// <summary>
        /// Имя файла настроек без расширения.
        /// </summary>
        public virtual string SettingsFileName
            => $"{ApplicationName}Settings";

        #endregion

        #region LogFolders

        /// <summary>
        /// Путь к папке логирования.
        /// </summary>
        [Setting("")]
        public virtual string LogFolderPath
        {
            get => Read<string>();
            set => Save(value);
        }

        /// <summary>
        /// Путь к папке сохранения архива логов.
        /// </summary>
        [Setting("")]
        public virtual string CollectLogFolderPath
        {
            get => Read<string>();
            set => Save(value);
        }

        /// <summary>
        /// Путь к папке логирования исключений.
        /// </summary>
        [Setting("")]
        public virtual string ExceptionsLogFolderPath
        {
            get => Read<string>();
            set => Save(value);
        }

        /// <summary>
        /// Путь к папке сохранения архива исключений.
        /// </summary>
        [Setting("")]
        public virtual string CollectExceptionsLogFolderPath
        {
            get => Read<string>();
            set => Save(value);
        }

        #endregion

        #region PrmsGrpc

        /// <summary>
        /// Уровень сжатия данных gRPC.
        /// 0 - No compression.
        /// 1 - Low compression.
        /// 2 - Medium compression.
        /// 3 - High compression.
        /// </summary>
        [DisplayName("Уровень сжатия данных gRPC")]
        [Setting("0")]
        public virtual int GrpcCompressionLevel
        {
            get => Read<int>();
            set => Save(value);
        }

        /// <summary>
        /// Детализация логгирования gRPC.
        /// </summary>
        [DisplayName("Детализация логгирования gRPC")]
        [Setting("channel,http,connectivity_state")]
        public virtual string GRPC_TRACE
        {
            get => Read<string>();
            set => Save(value);
        }

        /// <summary>
        /// Уровень логгирования gRPC.
        /// DEBUG - log all gRPC messages
        /// INFO  - log INFO and ERROR message
        /// ERROR - log only errors (default)
        /// NONE  - won't log any
        /// </summary>
        [DisplayName("Уровень логгирования gRPC")]
        [Setting("DEBUG")]
        public virtual string GRPC_VERBOSITY
        {
            get => Read<string>();
            set => Save(value);
        }

        /// <summary>
        /// Уровень логгирования FUZZER gRPC.
        /// </summary>
        [DisplayName("Уровень логгирования FUZZER gRPC")]
        [Setting("DEBUG")]
        public virtual string GRPC_TRACE_FUZZER
        {
            get => Read<string>();
            set => Save(value);
        }

        /// <summary>
        /// Уровень логгирования трассировки стека (stacktrace gRPC).
        /// Один из DEBUG, INFO, ERROR или NONE.
        /// </summary>
        [DisplayName("Уровень логгирования stacktrace gRPC")]
        [Setting("DEBUG")]
        public virtual string GRPC_STACKTRACE_MINLOGLEVEL
        {
            get => Read<string>();
            set => Save(value);
        }

        #endregion

        private string _destinationPath;

        protected string _configPatch;

        private readonly object _lockobject = new object();

        public bool IsCreatedDefaultSettings { get; private set; }
        public string SettingsPath => _configPatch;

        private readonly ConcurrentDictionary<string, Settings> _settings = new();

        protected SettingsManagerBase(string customFileConfig = null)
        {
            if (!string.IsNullOrEmpty(customFileConfig))
            {
                if (Path.GetExtension(customFileConfig).ToLower() == ".xml")
                    _configPatch = customFileConfig;
            }

            if (!_settings.Any())
            {
                var propertyInfos = this.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);

                foreach (var propertyInfo in propertyInfos)
                {
                    var settingAtribute = propertyInfo.GetCustomAttribute<SettingAttribute>();

                    if (settingAtribute == null)
                        continue;

                    _settings.TryAdd(propertyInfo.Name, new Settings(propertyInfo.Name, settingAtribute.DefalutValue, settingAtribute.MinValue, settingAtribute.MaxValue));
                }
            }
        }

        /// <summary>
        /// Загрузить настройки.
        /// </summary>
        public virtual void LoadSettings()
        {
            _destinationPath = string.Empty;
            if (string.IsNullOrEmpty(_configPatch))
            {
                _destinationPath = Path.GetFullPath($@"{Path.GetPathRoot(Environment.SystemDirectory)}\Users\Public\UtisMinex\{ApplicationName}\");
                _configPatch =
                    $"{_destinationPath}{SettingsFileName}.xml";
            }
            else
            {
                _destinationPath = Path.GetDirectoryName(_configPatch);
            }

            //cоздает все каталоги и подкаталоги для указанного имени файла
            if (!Directory.Exists(_destinationPath))
                Directory.CreateDirectory(_destinationPath);

            if (!File.Exists(_configPatch))
            {
                CreateSetttings(_configPatch);
            }
            else if (!CheckSettingsFileAndFill(_configPatch, _destinationPath))
            {
                CreateDefaultSettings();
            }
        }

        public void CreateDefaultSettings()
        {
            IsCreatedDefaultSettings = true;

            //Сохраняем рядом некорректные настройки и создаём дефолтные
            if (!File.Exists($"{_destinationPath}{ApplicationName}SettingsIncorrect.xml"))
                File.Copy(_configPatch, $"{_destinationPath}{ApplicationName}SettingsIncorrect.xml");
            else
            {
                int i = 1;
                while (File.Exists($"{_destinationPath}{ApplicationName}SettingsIncorrect({i}).xml"))
                    i++;
                File.Copy(_configPatch, $"{_destinationPath}{ApplicationName}SettingsIncorrect({i}).xml");
            }
            CreateSetttings(_configPatch);
        }

        /// <summary>
        /// Создать файл настроек с настройками по умолчанию.
        /// </summary>
        public virtual void CreateOrUpdateSetttingsJson()
        {
            return;
        }

        /// <summary>
        /// Создать файл настроек с настройками по умолчанию.
        /// </summary>
        protected void CreateSetttings(string patchFile)
        {
            var xmlDoc = new XmlDocument();
            var appSettingsNode = xmlDoc.CreateElement("appSettings");
            xmlDoc.AppendChild(appSettingsNode);

            foreach (var settings in _settings.Values)
            {
                XmlNode settingsNode = xmlDoc.CreateElement("Settings");

                var keyAttribute = xmlDoc.CreateAttribute("Key");
                keyAttribute.Value = settings.Name;
                settingsNode.Attributes?.Append(keyAttribute);

                var valueAttribute = xmlDoc.CreateAttribute("Value");
                valueAttribute.Value = settings.DefaultValue;
                settingsNode.Attributes?.Append(valueAttribute);

                appSettingsNode.AppendChild(settingsNode);
            }

            xmlDoc.Save(patchFile);
        }

        /// <summary>
        /// Проверить файл настроек на соответствие и добавить недостающие настройки, заполнив по умолчанию/удалив устаревшие.
        /// </summary>
        /// <returns>
        /// true - успешно загружен xml и добавлены недостающие настройки/удалены устаревшие; 
        /// false - ошибка открытия файла или добавления/удаления настроек.
        /// </returns>
        private bool CheckSettingsFileAndFill(string patchFile, string destinationPath)
        {
            var schema = new XmlSchema();

            var settings = new XmlSchemaElement {Name = "Settings"};
            var settingsType = new XmlSchemaComplexType();
            
            var keyAttribute = new XmlSchemaAttribute {Name = "Key" };
            settingsType.Attributes.Add(keyAttribute);

            var valueAttribute = new XmlSchemaAttribute { Name = "Value" };
            settingsType.Attributes.Add(valueAttribute);

            settings.SchemaType = settingsType;
            
            XmlSchemaSequence sequence = new XmlSchemaSequence();
            sequence.MinOccurs = 0;
            sequence.MaxOccursString = "unbounded";
            sequence.Items.Add(settings);
            
            var settingsElement = new XmlSchemaElement {Name = "appSettings"};
            var appSettingsType = new XmlSchemaComplexType {Particle = sequence};
            settingsElement.SchemaType = appSettingsType;

            schema.Items.Add(settingsElement);

            var settingsReader = new XmlReaderSettings();
            settingsReader.Schemas.Add(schema);
            settingsReader.ValidationType = ValidationType.Schema;


            var xmlDoc = new XmlDocument();

            try
            {
                using (var reader = XmlReader.Create(patchFile, settingsReader))
                {
                    xmlDoc.Load(reader);
                }
            }
            catch (Exception)
            {
                //не соответствует схеме
                return false;
            }

            var settingsNodes = new List<XmlNode>();

            for (int i = 0; i < xmlDoc.DocumentElement.ChildNodes.Count; i++)
            {
                settingsNodes.Add(xmlDoc.DocumentElement.ChildNodes[i]);
            }

            var actualSettings = _settings.Values.ToList();

            var needSave = false;

            //удаляем не актуальные настройки
            foreach (XmlNode node in settingsNodes)
            {
                var sett = actualSettings.FirstOrDefault(wh => wh.Name.Equals(node.Attributes["Key"].Value));

                if (sett == null)
                {
                    xmlDoc.DocumentElement.RemoveChild(node);
                    needSave = true;
                }
                else
                {
                    actualSettings.Remove(sett);
                }
            }

            //добавляем недостающие настройки
            foreach (var actualSetting in actualSettings)
            {
                XmlNode settingsNode = xmlDoc.CreateElement("Settings");

                var keyAttributeDoc = xmlDoc.CreateAttribute("Key");
                keyAttributeDoc.Value = actualSetting.Name;
                settingsNode.Attributes?.Append(keyAttributeDoc);

                var valueAttributeDoc = xmlDoc.CreateAttribute("Value");
                valueAttributeDoc.Value = actualSetting.DefaultValue;
                settingsNode.Attributes?.Append(valueAttributeDoc);

                xmlDoc.DocumentElement.AppendChild(settingsNode);
                needSave = true;
            }

            if (needSave)
            {
                xmlDoc.Save(patchFile);
            }

            return true;
        }

        public T Read<T>([CallerMemberName]string key = null) where T : IComparable
        {
            string temp;

            lock (_lockobject)
            {
                var xmlDoc = new XmlDocument();
                
                xmlDoc.Load(_configPatch);
                
                temp = xmlDoc.SelectSingleNode($"//appSettings/Settings[@Key='{key}']")?.Attributes["Value"]?.Value ?? String.Empty;
            }

            var setting = _settings[key];
            var value = setting.GetActualValue<T>(temp);

            return value;
        }

        public void Save<T>(T value, [CallerMemberName]string key = null) where T : IComparable
        {
            var valueToSave = value?.ToString() ?? string.Empty;

            if (typeof(T) == typeof(float))
            {
                var nfi = new NumberFormatInfo {NumberDecimalSeparator = ","};
                valueToSave = ((float)(object)value).ToString(nfi);
            }
            else
            if (typeof(T) != typeof(string) && typeof(System.Collections.IEnumerable).IsAssignableFrom(typeof(T)))
            {
                var sb = new StringBuilder();
                foreach (var item in value as System.Collections.IEnumerable)
                {
                    sb.Append(sb.Length > 0 ? $";{item}" : item.ToString());
                }
                valueToSave = sb.ToString();
            }
            else 
            if (typeof(T) == typeof(DateTime))
            {
                valueToSave = ((DateTime)(object)value).ToString("yyyyMMdd HH:mm:ss.fff", CultureInfo.InvariantCulture);
            }

            lock (_lockobject)
            {
                var xmlDoc = new XmlDocument();
                xmlDoc.Load(_configPatch);
                xmlDoc.SelectSingleNode($"//appSettings/Settings[@Key='{key}']").Attributes["Value"].Value = valueToSave;
                xmlDoc.Save(_configPatch);
            }
        }
    }

    public abstract partial class SettingsManagerBase
    {
        #region InterposedClasses

        private class Settings
        {
            public string Name { get; } 

            public string DefaultValue { get; }

            public string MaxValue { get; }

            public string MinValue { get; }

            public Settings(string name, string defaultValue, string minValue, string maxValue)
            {
                Name         = name;
                DefaultValue = defaultValue;
                MinValue = minValue;
                MaxValue = maxValue;
            }

            internal T GetActualValue<T>(string sValue) where T : IComparable
            {
                var value = ConvertFromString<T>(sValue);

                if (!string.IsNullOrEmpty(MaxValue))
                {
                    T maxValue = ConvertFromString<T>(MaxValue);
                    if (value.CompareTo(maxValue) > 0)
                        value = maxValue;
                }

                if (!string.IsNullOrEmpty(MinValue))
                {
                    T minValue = ConvertFromString<T>(MinValue);
                    if (value.CompareTo(minValue) < 0)
                        value = minValue;
                }

                return value;
            }

            protected T ConvertFromString<T>(string str)
            {
                if (string.IsNullOrEmpty(str))
                    return default;

                object value = default;

                if (typeof(T) == typeof(DateTime))
                {
                    value = (T)(object)DateTime.ParseExact(str, "yyyyMMdd HH:mm:ss.fff", CultureInfo.InvariantCulture);
                }
                else
                if (typeof(T) == typeof(float))
                {
                    float res = 0;
                    try
                    {
                        var invariantValue = str.Replace(',', '.');
                        res = Convert.ToSingle(invariantValue, CultureInfo.InvariantCulture);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    value = res;
                }
                else
                if (typeof(System.Collections.IList).IsAssignableFrom(typeof(T)))
                {
                    var t = typeof(T).GenericTypeArguments.FirstOrDefault();

                    if (t != null)
                    {
                    }
                }
                else
                if (typeof(T) != typeof(string))
                {
                    var converter = TypeDescriptor.GetConverter(typeof(T));
                    value = (T)converter.ConvertFromString(null, CultureInfo.InvariantCulture, str);
                }
                else
                {
                    value = (T)(object)str;
                }

                return (T)value;
            }

        }

        #endregion
    }
}