//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: Cerberus – Подсистема безопасности, алгоритм хэширования SHA256.
//--------------------------------------------------------------------------------------------------
#region Using
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Utis.SmartMinex.Runtime;
#endregion Using

namespace Utis.SmartMinex.Security;

internal static class Cerberus
{
    /// <summary> Путь с учётом регистра, иначе Linux не поймёт!</summary>
    const string CERTIFICATE = @"certificate\Utis.SmartMinex.pfx";
    const string PEMPHRASE = "7HfpJnvthm!";
    const string SALT = "uxC6eq#kf!1cr9ry7t2";

    public static X509Certificate2 Certificate()
    {
        var filename = TPath.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), CERTIFICATE);
        if (!File.Exists(filename))
            throw new Exception("Не найден SSL-сертификат: " + filename);

        return new(filename, PEMPHRASE);
    }

    public static string LocalAddress()
    {
        var host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (var ip in host.AddressList)
            if (ip.AddressFamily == AddressFamily.InterNetwork)
                return ip.ToString();

        throw new Exception("No network adapters with an IPv4 address in the system!");
    }

    public static string HostName()
    {
        return Dns.GetHostEntry(Dns.GetHostName()).HostName;
    }

    public static string? GetBootstrapVersion()
    {
        string bootstrap = TPath.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"..\bootstrap\smbtstrp.exe");
        if (File.Exists(bootstrap))
            return FileVersionInfo.GetVersionInfo(bootstrap).FileVersion;

        return null;
    }

    public static string PasswordHash(string username, string password) =>
        Convert.ToBase64String(SHA256.HashData(Encoding.UTF8.GetBytes(string.Concat((username ?? string.Empty).ToUpperInvariant(), SALT, password))));
}
