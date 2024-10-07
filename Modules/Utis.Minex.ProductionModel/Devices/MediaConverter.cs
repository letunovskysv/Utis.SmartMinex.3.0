//--------------------------------------------------------------------------------------------------
// (C) 2018 ООО «УралТехИс». ПТК «Горный диспетчер». Все права защищены.
// Описание: Класс, описывающий справочник медиаконвертеров.
//--------------------------------------------------------------------------------------------------
using Utis.Minex.Common;
using Utis.Minex.Common.Enum;

namespace Utis.Minex.ProductionModel.Devices
{
    using Interfaces;

    /// <summary>
    /// Справочник медиаконвертеров
    /// </summary>
    [DisplayName("Медиаконвертеры")]
    [Description("Справочник медиаконвертеров")]
    public class MediaConverter : Device, IPoweredDevice, IMediaConverter
    {
        /// <summary>Тип входа</summary>
        [DisplayName("Вход")]
        [Description("Тип входа")]
        public virtual ConverterMediaType MediaIn { get; set; }

        /// <summary>Тип выхода</summary>
        [DisplayName("Выход")]
        [Description("Тип выхода")]
        public virtual ConverterMediaType MediaOut { get; set; }

        /// <summary>Входное напряжение, В</summary>
        [DisplayName("Входное напряжение, В")]
        [Description("Входное напряжение, В")]
        public virtual int PowerIn { get; set; }
    }
}