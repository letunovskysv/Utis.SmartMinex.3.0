//--------------------------------------------------------------------------------------------------
// (C) 2018 ООО «УралТехИс». ПТК «Горный диспетчер». Все права защищены.
// Описание: Класс, описывающий справочник медиаконвертеров Ethernet.
//--------------------------------------------------------------------------------------------------

using Utis.Minex.Common;
using Utis.Minex.Common.Enum;

namespace Utis.Minex.ProductionModel.Devices
{
    #region Using
    using Common;
    using Interfaces;
    #endregion Using


    /// <summary>
    /// Медиаконвертер Ethernet
    /// </summary>
    [DisplayName("Справочник медиаконвертеров Ethernet")]
    public class MediaConverterEthernet : MediaConverter, IIPDevice
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public MediaConverterEthernet()
        {
            MediaOut = ConverterMediaType.Ethernet;
        }

        /// <summary>
        /// Тип соединения
        /// </summary>
        public override ConverterMediaType MediaOut => base.MediaOut;

        /// <summary>
        /// Ip-адрес
        /// </summary>
        [DisplayName("Ip")]
        [Description("Ip-адрес")]
        public virtual string Ip { get; set; }

        /// <summary>ССД, к которому относится медиаконвертер</summary>
        [DisplayName("ССД")]
        [Description("ССД, к которому относится медиаконвертер")]
        public virtual DAServer DAServer { get; set; }
    }
}