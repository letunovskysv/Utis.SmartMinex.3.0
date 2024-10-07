using System;
using System.Configuration;
using System.Text.RegularExpressions;

namespace Utis.Minex.Common.Helpers
{
    using Utis.Minex.Common.Enum;

    public static class DatabaseTypeHelper
    {
        /// <summary>
        /// Определение типа СУБД по имени строки соединения.
        /// </summary>
        public static DBMSType GetDBMSType(string connstringsettings)
        {

            //throw new ArgumentNullException("Тип СУБД строки соединения не определён. Укажите ProviderName в атрибуте XML");

            return DBMSType.Undefined;
        }

        /// <summary>
        /// Определение типа СУБД по имени строки соединения.
        /// </summary>
        public static string GetServerHost(string connstringsettings, DBMSType type)
        {
            switch (type)
            {
                case DBMSType.Postgresql:
                {
                    var regex = 
                        Regex.Match(
                            connstringsettings,
                            @"(?<=Server(\s)*=(\s)*)[\w\d.-]*(?=(\s)*(;|$))",
                            RegexOptions.IgnoreCase
                            );

                    if (regex.Success)
                    {
                        return regex.Value;
                    }
                    else
                    {
                        throw new Exception($"Не удалось определить server в строке подключения к БД: {connstringsettings}");
                    }
                }

                case DBMSType.MSSQLServer:
                {
                    var regex = 
                        Regex.Match(
                            connstringsettings,
                            @"(?<=data(\s)+source(\s)*=(\s)*)[\w\d.-]*(?=(\s)*(;|$))",
                            RegexOptions.IgnoreCase
                            );

                    if (regex.Success)
                    {
                        return regex.Value;
                    }
                    else
                    {
                        throw new Exception(
                            $"Не удалось определить data source в строке подключения к БД: {connstringsettings}");
                    }
                }

                default:
                {
                    throw new Exception();
                }
            }
        }
    }
}
