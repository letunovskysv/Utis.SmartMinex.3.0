using Utis.Minex.Common;

namespace Utis.Minex.ProductionModel
{
    using Common;

    /// <summary>
    /// Подписка на изменение объектов
    /// </summary>
    [DisplayName("Подписка на изменение объектов")]
    public class Subscription : CatalogBase
    {
        /// <summary>Подписчик</summary>
        [DisplayName("Подписчик")]
        public virtual DataProviderServer DataProvider { get; set; }

        /// <summary>Запрошенный тип данных DTO</summary>
        [DisplayName("Запрошенный тип данных DTO")]
        public virtual string DTOFullTypeName { get; set; }

        /// <summary>Запрошенный тип данных DBO</summary>
        [DisplayName("Запрошенный тип данных DTO")]
        public virtual string DBOFullTypeName { get; set; }

        /// <summary>Фильтр запроса подписки</summary>
        [DisplayName("Фильтр запроса подписки")]
        public virtual string Filter { get; set; }
    }
}