//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: UtisDataExporter – Экспортёр данных в файл различных форматов.
//--------------------------------------------------------------------------------------------------
#region Using
using System.Data;
using System.Text;
using Newtonsoft.Json;
using Utis.SmartMinex.Runtime;
#endregion Using

namespace Utis.SmartMinex.Archestra;

internal class UtisDataExporter
{
    public static Stream? ExportToXml(IDispatcher dsp, long objid) => UseDataTable(dsp, objid, (obj, data) =>
    {
        data.DataSet.DataSetName = obj.Source;
        data.TableName = "row";
        using var sw = new StringWriter();
        data.WriteXml(sw, XmlWriteMode.IgnoreSchema, false);
        return new MemoryStream(Encoding.UTF8.GetBytes(sw.ToString()));
    });

    public static Stream? ExportToJson(IDispatcher dsp, long objid)
    {
        var ent = dsp.GetObject(objid);
        if (ent?.Type == TType.Scheme)
            return new MemoryStream(Encoding.UTF8.GetBytes(TSerializator.SerializeText(ent)));

        return UseDataTable(dsp, objid, (obj, data) =>
            new MemoryStream(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data, Formatting.Indented))));
    }

    static Stream? UseDataTable(IDispatcher dsp, long objid, Func<TObject, DataTable, Stream?>? converter)
    {
        if (dsp.TryGetObject<TObject>(objid, out var obj))
            try
            {
                var data = dsp.Select(obj, null, obj.Attributes.KeyField?.Source);
                if (data != null)
                    return converter?.Invoke(obj, data);
            }
            catch { }

        return null;
    }
}
