using System;
using Utis.Minex.Common;
using Utis.Minex.ProductionModel.Interfaces;

namespace Utis.Minex.ProductionModel.Devices
{
    /// <summary>
    /// Радиостанция
    /// </summary>
    [DisplayName("Радиостанция")]
    [Description("Радиостанция")]
    public class Radio : Device, IAccountDevice
    {
        /// <summary>
        /// Номер радиостанции
        /// </summary>
        [DisplayName("Номер радиостанции")] 
        public virtual int Number { get; set; }

        /// <summary>
        /// Дата начала эксплуатации
        /// </summary>
        [DisplayName("Дата начала эксплуатации")]
        public virtual DateTime? BeginDate { get; set; }

        /// <summary>
        /// Дата окончания эксплуатации
        /// </summary>
        [DisplayName("Дата окончания эксплуатации")]
        public virtual DateTime? EndDate { get; set; }

        /// <summary>
        /// Дата окончания гарантийного срока
        /// </summary>
        [DisplayName("Дата окончания гарантийного срока")]
        public virtual DateTime? EndWarranty { get; set; }

        /// <summary>
        /// Дата списания
        /// </summary>
        [DisplayName("Дата списания")]
        public virtual DateTime? EndLifetime { get; set; }

    }
}
