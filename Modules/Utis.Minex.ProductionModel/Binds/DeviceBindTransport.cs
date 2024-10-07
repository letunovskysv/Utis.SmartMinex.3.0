using System;

namespace Utis.Minex.ProductionModel.Binds
{
    #region Using
    
    using Utis.Minex.Common;
    using Utis.Minex.ProductionModel.Catalog;
    using Utis.Minex.ProductionModel.Devices;

        #endregion

    /// <summary>
    /// Привязки транспорта к устройствам.
    /// </summary>
    public class DeviceBindTransport : VersionObjectBase
    {
        /// <summary>
        /// Устройство.
        /// </summary>
        [DisplayName("Устройство")]
        public virtual DeviceWithRfid Device 
        { get; set; }

        /// <summary>
        /// Транспорт.
        /// </summary>
        [DisplayName("Транспорт")]
        public virtual Transport Transport 
        { get; set; }

        /// <summary>
        /// Дата/время начала привязки.
        /// </summary>
        [DisplayName("Дата/время начала привязки")]
        public virtual DateTime DateIn
        { get; set; }

        /// <summary>
        /// Дата/время окончания привязки.
        /// </summary>
        [DisplayName("Дата/время окончания привязки")]
        public virtual DateTime? DateOut
        { get; set; }


        /// <summary>
        /// Резервное устройство.
        /// </summary>
        [DisplayName("Резервное устройство")]
        public bool IsReserveDevice
        { get; set; }

        /// <summary>
        /// Устройство установлено в хвосте.
        /// </summary>
        [DisplayName("Устройство установлено в хвосте")]
        public bool IsTailDevice
        { get; set; }
    }
}