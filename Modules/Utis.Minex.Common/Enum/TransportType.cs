
namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Типы транспорта.
    /// </summary>
    [DisplayName("Типы транспорта")]
    public enum TransportType
    {
        /// <summary>
        /// Значение по умолчанию.
        /// </summary>
        [DisplayName("Не задано")]
        None = 0,

        /// <summary>
        /// ПДМ.
        /// </summary>
        [DisplayName("ПДМ")]
        PDM = 1,

        /// <summary>
        /// СБУ.
        /// </summary>
        [DisplayName("СБУ")]
        SBU = 2,

        /// <summary>
        /// ШАС.
        /// </summary>
        [DisplayName("ШАС")]
        SHAS = 3,

        /// <summary>
        /// ВСО.
        /// </summary>
        [DisplayName("ВСО")]
        VSO = 4,

        /// <summary>
        /// Бутовой БУТ.
        /// </summary>
        [DisplayName("БУТ")]
        BUT = 5,

        /// <summary>
        /// Анкероустановщик АНК.
        /// </summary>
        [DisplayName("АНК")]
        ANK = 6,

        /// <summary>
        /// Заправщик ГСМ.
        /// </summary>
        [DisplayName("ГСМ")]
        GSM = 7,

        /// <summary>
        /// Электровоз (неавтономный локомотив).
        /// </summary>
        [DisplayName("Электровоз")]
        LOCO = 8,
    }
}