//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TExporterExtensions –
//--------------------------------------------------------------------------------------------------
#region Using
using System.Xml.Linq;
using System.IO.Compression;
using System.Text;
#endregion Using

namespace Utis.SmartMinex.Runtime;

public static class ExporterExtensions
{
    public static string FileNameTemporary =>
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Templates), "sm" + (new Random().NextDouble() * 1000000000).ToString("#") + ".$$$");

    public static void AddContent(this ZipArchive archive, string filename, byte[] content)
    {
        ZipArchiveEntry file = archive.CreateEntry(filename);
        file.Open().Write(content, 0, content.Length);
    }

    public static void AddContent(this ZipArchive archive, string filename, XElement content, bool formatting = false)
    {
        XDocument xdoc = new XDocument(new XDeclaration("1.0", Encoding.UTF8.WebName, "yes"), content);
        TStringWriter xfile = new TStringWriter(Encoding.UTF8);
        xdoc.Save(xfile, formatting ? SaveOptions.OmitDuplicateNamespaces : SaveOptions.DisableFormatting);
        AddContent(archive, filename, Encoding.UTF8.GetBytes(xfile.ToString()));
    }

    public static string ReadArchive(this ZipArchive arch, string name)
    {
        ZipArchiveEntry file = arch.GetEntry(name + (string.IsNullOrEmpty(Path.GetExtension(name)) ? ".xml" : string.Empty));
        using var ms = new MemoryStream();
        file.Open().CopyTo(ms);
        var buf = ms.ToArray();
        int shift = buf[0..3].SequenceEqual(new byte[] { 239, 187, 191 }) ? 3 : 0;
        return Encoding.UTF8.GetString(buf, shift, buf.Length - shift);
    }

    public static byte[] ReadArchiveBin(this ZipArchive arch, string name)
    {
        ZipArchiveEntry file = arch.GetEntry(name + (string.IsNullOrEmpty(Path.GetExtension(name)) ? ".xml" : string.Empty));
        byte[] buf = new byte[file.Length];
        file.Open().Read(buf, 0, buf.Length);
        return buf;
    }
}
