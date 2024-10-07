using System;
using System.IO;
using System.Security.Cryptography;

namespace Utis.Minex.Common.Helpers
{
    public static class FileHelper
    {
        /// <summary>
        /// Получить хэш-сумму файла
        /// </summary>
        /// <param name="pathFile"></param>
        /// <returns></returns>
        public static string GetHash(string pathFile)
        {

            string strHash = string.Empty;

            using (var fileStream = File.OpenRead(pathFile))
            {
                using (var md5 = MD5.Create())
                {
                    var hash = md5.ComputeHash(fileStream);
                    strHash = BitConverter.ToString(hash).Replace("-", string.Empty).ToLowerInvariant();
                }
            }

            return strHash;
        }
    }
}
