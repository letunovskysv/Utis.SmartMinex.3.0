using Utis.Minex.Common.Enum;

namespace Utis.Minex.Common
{
    /// <summary>
    /// Справочник медиаконвертеров
    /// </summary>
    [DisplayName("Медиаконвертеры")]
    [Description("Справочник медиаконвертеров")]
    public interface IMediaConverter : IDevice
    {
        /// <summary>Тип входа</summary>
        [DisplayName("Вход")]
        [Description("Тип входа")]
        ConverterMediaType MediaIn { get; set; }

        /// <summary>Тип выхода</summary>
        [DisplayName("Выход")]
        [Description("Тип выхода")]
        ConverterMediaType MediaOut { get; set; }

        /// <summary>Входное напряжение, В</summary>
        [DisplayName("Входное напряжение, В")]
        [Description("Входное напряжение, В")]
        int PowerIn { get; set; }
    }
}
