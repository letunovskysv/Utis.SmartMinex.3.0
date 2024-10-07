namespace Utis.Minex.ProductionModel.Interfaces
{
    #region using
    using System;
    #endregion

    /// <summary>
    /// Устройство учёта
    /// </summary>
    public interface IAccountDevice
    {
        /// <summary>
        /// Дата начала эксплуатации
        /// </summary>
        DateTime? BeginDate { get; set; }

        /// <summary>
        /// Дата окончания эксплуатации
        /// </summary>
        DateTime? EndDate { get; set; }

        /// <summary>
        /// Дата окончания гарантийного срока
        /// </summary>
        DateTime? EndWarranty { get; set; }

        /// <summary>
        /// Дата окончания жиз
        /// </summary>
        DateTime? EndLifetime { get; set; }
    }
}