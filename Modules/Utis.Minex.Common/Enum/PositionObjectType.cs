using System;

namespace Utis.Minex.Common.Enum
{
    public enum PositionObjectType : byte
    {
        Default = 0,
        
        Person = 1,

        // Поскольку это тот же транспорт (дизели на южной), то следует выпилить,
        // объединив в графике MobileMarkPointToken и TransportToken c добавлением
        // у вторых поддержку событий АТО и у всего транспорта поддержки событий по нескольким устройствам
        MobileMarkPoint = 2,

        TransportHead = 3,

        TransportTail = 4,

        MarkPointInMove = 5,
    }
}
