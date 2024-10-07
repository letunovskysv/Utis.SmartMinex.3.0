using System;

namespace Utis.Minex.ProductionModel.Devices
{
    #region Using
    
    using Utis.Minex.Common;
    using Utis.Minex.ProductionModel.Common;
    using Utis.Minex.ProductionModel.Interfaces;
    using Utis.Minex.ProductionModel.Positioning;

        #endregion
    
    /// <summary>
    /// Светильник.
    /// </summary>
    [DisplayName("Светильник")]
    public class Lamp : Device, IAccountDevice
    {
        /// <summary>
        /// Светильник №
        /// </summary>
        [DisplayName("Светильник №")]
        public virtual long Number 
        { get; set; }

        /// <summary>
        /// Тип светильника.
        /// </summary>
        [DisplayName("Тип светильника")]
        public virtual LampType LampType 
        { get; set; }
                
        /// <summary>
        /// Номер группы.
        /// </summary>
        [DisplayName("Номер группы")]
        public virtual int GroupNumber 
        { get; set; }
        
        /// <summary>
        /// Наличие проблескового маячка.
        /// </summary>
        [DisplayName("Наличие проблескового маячка")]
        public virtual bool HasFlashingBeacon
        { get; set; }

        /// <summary>
        /// Частота ГПС, Гц.
        /// </summary>
        [DisplayName("Частота ГПС, Гц")]
        public virtual int GlonFrequency 
        { get; set; }

        /// <summary>
        /// Дата начала эксплуатации.
        /// </summary>
        [DisplayName("Дата начала эксплуатации")]
        public virtual DateTime? BeginDate 
        { get; set; }

        /// <summary>
        /// Дата окончания эксплуатации.
        /// </summary>
        [DisplayName("Дата окончания эксплуатации")]
        public virtual DateTime? EndDate 
        { get; set; }

        /// <summary>
        /// Дата окончания гарантийного срока.
        /// </summary>
        [DisplayName("Дата окончания гарантийного срока")]
        public virtual DateTime? EndWarranty 
        { get; set; }

        /// <summary>
        /// Дата списания.
        /// </summary>
        [DisplayName("Дата списания")]
        public virtual DateTime? EndLifetime 
        { get; set; }

        /// <summary>
        /// Признак виртуальности светильника.
        /// </summary>
        //[DisplayName("Признак виртуальности")]
        public virtual bool IsVirtual
        { get; set; }

        /// <summary>
        /// Ламповая, к которой находится светильник.
        /// </summary>
        [DisplayName("Ламповая")]
        [Description("Ламповая, в которой находится светильник")]
        public virtual IndividualDevicesRoom Room 
        { get; set; }

        /// <summary>
        /// Ламповая, к которой относится светильник.
        /// </summary>
        [DisplayName("Подотчёт")]
        [Description("Ламповая, к которой относится светильник")]
        public virtual IndividualDevicesRoom OwnerRoom
        { get; set; }

        public override string ToString()
        {
            var strNumber = IsVirtual == true ? string.Concat('V', Number) : Number.ToString();
            return $@"Светильник №{strNumber}";
        }
    }
}