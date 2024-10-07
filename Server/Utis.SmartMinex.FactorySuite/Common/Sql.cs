//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: Sql –
//--------------------------------------------------------------------------------------------------
using System;

namespace Utis.SmartMinex.Data;

public class Sql
{
    #region Constants

    static readonly string SQLDATEFORMAT = "yyyy-MM-ddTHH:mm:ss.fffZ";
    static readonly DateTime SQLMINDATETIME = new(1900, 1, 1);

    #endregion Constants

    public static string AsSqlValue(object? value)
    {
        if (value == null || value == DBNull.Value)
            return "NULL";

        switch (value)
        {
            case DateTime dt:
                return dt < SQLMINDATETIME
                    ? "'19000101'"
                    : "'" + dt.ToString(SQLDATEFORMAT) + "'";

            case TimeSpan ts:
                return "'" + ts.ToString() + "'";

            case string str:
                return string.Concat("N'", str.Replace("'", "''"), "'");

            case bool bval:
                return bval ? "true" : "false";

            case byte:
            case short:
                return string.Concat(value.ToString(), "::smallint");

            case float fval:
                return float.IsNaN(fval) ? "NULL" : fval.ToString(System.Globalization.CultureInfo.InvariantCulture);

            case double dval:
                return double.IsNaN(dval) ? "NULL" : dval.ToString(System.Globalization.CultureInfo.InvariantCulture);

            case decimal dec:
                return dec.ToString(System.Globalization.CultureInfo.InvariantCulture);

            case byte[] arr:
                return string.Concat("'\\x", string.Join(null, arr.Select(b => b.ToString("X2")).ToArray()), "'");
        }
        if (!value.GetType().IsPrimitive)
            return value.ToString();

        return value.ToString().Replace(',', '.');
    }
}
