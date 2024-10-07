
namespace Utis.Minex.ProductionModel.Catalog.Organize
{
    #region Using

    using Utis.Minex.Common;
    using Utis.Minex.Common.Enum;

    #endregion

    /// <summary>
    /// Персональная карта сотрудника.
    /// </summary>
    [DisplayName("Персональная карта")]
    [Description("Персональная карта сотрудника")]
    public class PersonalCard : CatalogBase
    {
        /// <summary>
        /// Номер карты.
        /// </summary>
        [DisplayName("Номер карты")]
        public virtual byte[] Number 
        { get; set; }

        /// <summary>
        /// Формат номера персональной карты.
        /// </summary>
        [DisplayName("Формат номера персональной карты")]
        public virtual PersonalCardHandlerType HandlerType 
        { get; set; }

        /// <summary>
        /// Номер карты.
        /// </summary>
        [DisplayName("Номер карты")]
        public virtual string CardNumber
        { get; set; }

        /// <summary>
        /// Тип карты (Пропуск\...).
        /// </summary>
        [DisplayName("Тип карты")]
        public virtual string CardType 
        { get; set; }

        /// <summary>
        /// Статус карты (Исправна\Сломана\Утеряна\...).
        /// </summary>
        [DisplayName("Статус карты")]
        public virtual string CardStatus 
        { get; set; }
    }
}