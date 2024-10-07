
namespace Utis.Minex.ProductionModel.Journals
{
    #region Using

    using Utis.Minex.Common;
    using Utis.Minex.Common.Enum;
    using Utis.Minex.ProductionModel.Catalog;
    using Utis.Minex.ProductionModel.Catalog.Organize;
    using Utis.Minex.ProductionModel.Devices;

    #endregion

    public class AnticollisionJournal : Journal
    {
        /// <summary>
        /// Мобильное устройство регистрации.
        /// </summary>
        [DisplayName("Мобильное устройство регистрации")]
        public virtual MobileRegDevice MobileRegDevice 
        { get; set; }

        /// <summary>
        /// Транспорт.
        /// </summary>
        [DisplayName("Транспорт")]
        public virtual Transport Transport 
        { get; set; }

        /// <summary>
        /// Сотрудник или гость.
        /// </summary>
        [DisplayName("Человек")]
        public virtual Person Person 
        { get; set; }

        /// <summary>
        /// Индивидуальное устройство.
        /// </summary>
        [DisplayName("Индивидуальное устройство")]
        public virtual IndividualDevice IndividualDevice 
        { get; set; }

        /// <summary>
        /// Тип события антинаезда.
        /// </summary>
        [DisplayName("Тип события антинаезда")]
        public virtual ListRankType ListRankType 
        { get; set; }

        /// <summary>
        /// Направление регистрации антенн МУРа.
        /// </summary>
        [DisplayName("Антенна МУРа")]
        [Description("Направление регистрации антенн МУРа (1я антенна - 1, 2я антенна - 2, 3я антенна - 4, 4я антенна - 8)")]
        public virtual byte Direction 
        { get; set; }
    }
}