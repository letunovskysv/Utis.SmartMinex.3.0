using System;

namespace Utis.Minex.ProductionModel.Register.Value.Bind
{    
    #region Using

    using Utis.Minex.Common;

    using Utis.Minex.ProductionModel.Catalog.Organize;
    using Utis.Minex.ProductionModel.Register.Dimension.Bind;

    #endregion

    /// <summary>
    /// Значение привязок карт к сотрудникам.
    /// </summary>
    [DisplayName("Значение привязок карт к сотрудникам")]
    public class PersonCardBindRValue : RBindValueBase<PersonCardBindRDimension>
    {
        /// <summary>
        /// Персональная карта сотрудника.
        /// </summary>
        [DisplayName("Карта")]
        [Description("Персональная карта сотрудника")]
        public virtual PersonalCard PersonalCard 
        { get; set; }

        /// <summary>
        /// Дата и время начала действия карты.
        /// </summary>
        [DisplayName("Дата начала действия карты")]
        public virtual DateTime? BeginDateTime 
        { get; set; }

        /// <summary>
        /// Дата и время окончания действия карты.
        /// </summary>
        [DisplayName("Дата окончания действия карты")]
        public virtual DateTime? EndDateTime 
        { get; set; }

        /// <summary>
        /// Активность карты.
        /// </summary>
        [DisplayName("Активность карты")]
        public virtual bool Activity 
        { get; set; }
    }
}