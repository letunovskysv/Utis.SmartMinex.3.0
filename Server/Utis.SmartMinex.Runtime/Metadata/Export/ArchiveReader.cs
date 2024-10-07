//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: ArchiveReader –
//--------------------------------------------------------------------------------------------------
#region Using
using System.IO.Compression;
using System.Text;
using System.Text.RegularExpressions;
#endregion Using

namespace Utis.SmartMinex.Runtime;

public class ArchiveReader : IDisposable
{
    FileStream? _file;
    ZipArchive _arch;

    public ArchiveReader(string filename)
    {
        _file = new FileStream(filename, FileMode.Open);
        _arch = new ZipArchive(_file);
    }

    public ArchiveReader(Stream stream) =>
        _arch = new ZipArchive(stream);

    public string[] GetFiles(string path, string searchPattern)
    {
        searchPattern = searchPattern.Replace("*", @"[^\\]*") + "$";
        return _arch.Entries
            .Where(f => Path.GetDirectoryName(f.FullName).StartsWith(path) && Regex.IsMatch(Path.GetFileName(f.FullName), searchPattern))
            .Select(f => f.FullName).ToArray();
    }

    public bool Exists(string filename) =>
        _arch.GetEntry(filename) != null;

    public byte[] ReadAllBytes(string filename) =>
        _arch.ReadArchiveBin(filename);

    public string ReadAllText(string filename) =>
        _arch.ReadArchive(filename);

    public string ReadAllText(string filename, Encoding encoding) =>
        encoding.GetString(_arch.ReadArchiveBin(filename));

    public void Dispose()
    {
        _arch.Dispose();
        _file?.Close();
        _file?.Dispose();
        GC.SuppressFinalize(this);
    }
}
