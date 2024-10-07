//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: MapDataHelper – Загрузчик компонентов схем, карт, горизонтов и информационных слоёв.
//--------------------------------------------------------------------------------------------------
#region Using
using Utis.SmartMinex.Data;
using Utis.SmartMinex.Graphics;
using Utis.SmartMinex.Runtime;
#endregion Using

namespace Utis.SmartMinex.Helpers;

class MapDataHelper(IMetadata md) : EntityDataHelper(md)
{
    public override object? Read(object? data)
    {
        if (data is ZObject zobj)
            switch (zobj.Type)
            {
                case TType.Scheme:
                    return TSerializator.Deserialize<ZScheme>(zobj.Definition) is ZScheme sch ? sch : null;

                case TType.Level:
                    return TSerializator.Deserialize<ZLevel>(zobj.Definition) is ZLevel lev ? lev : null;

                case TType.Layer:
                    return TSerializator.Deserialize<ZLayer>(zobj.Definition) is ZLayer lay ? lay : null;
            }

        return null;
    }
}
