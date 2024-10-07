using System;

namespace Utis.Minex.ProductionModel.Positioning
{
    #region Using

    using Utis.Minex.Common;
    using Utis.Minex.Common.Enum;

    #endregion

    /// <summary>
    /// Токен.
    /// </summary>
    [DisplayName("Токен")]
    public class Token : VersionObjectBase
    {
        /// <summary>
        /// Координата X.
        /// </summary>
        [DisplayName("X")]
        public virtual float X
        { get; set; }

        /// <summary>
        /// Координата Y.
        /// </summary>
        [DisplayName("Y")]
        public virtual float Y 
        { get; set; }

        /// <summary>
        /// Координата Z.
        /// </summary>
        [DisplayName("Z")]
        public virtual float Z
        { get; set; }

        /// <summary>
        /// Источник данных для вычисления координат.
        /// </summary>
        [DisplayName("Данные от оборудования")]
        public virtual byte[] Sources { get; set; }
        
        /// <summary>
        /// Метка.
        /// </summary>
        [DisplayName("Метка")]
        public virtual int Label 
        { get; set; }

        /// <summary>
        /// Тип устройства.
        /// </summary>
        [DisplayName("Тип устройства")]
        public virtual MobileDeviceType DeviceType 
        { get; set; }

        /// <summary>
        /// Идентификатор схемы.
        /// </summary>
        [DisplayName("Идентификатор схемы")]
        public virtual long SchemeId 
        { get; set; }

        /// <summary>
        /// Скорость.
        /// </summary>
        [DisplayName("Скорость")]
        public virtual float Speed 
        { get; set; }

        /// <summary>
        /// Метка времени.
        /// </summary>
        [DisplayName("Время")]
        public virtual DateTime DateTime
        { get; set; }
    }
}