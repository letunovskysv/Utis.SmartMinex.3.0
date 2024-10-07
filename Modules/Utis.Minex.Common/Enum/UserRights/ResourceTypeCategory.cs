namespace Utis.Minex.Common
{
    /// <summary>
    /// Категория ресурса (раздел меню)
    /// </summary>
    public enum ResourceCategory
    {
        /// <summary>
        /// Все
        /// </summary>
        Any = 0,
        /// <summary>
        /// Для доступа к управлению зонами
        /// </summary>
        [DisplayName("Управлению зонами")]
        ZoneControl = 1,

        /// <summary>
        /// Справочники и журналы
        /// </summary>
        [DisplayName("Справочники и журналы")]
        CatalogsAndJournals = 2,

        /// <summary>
        /// Пользователи и доступ
        /// </summary>
        [DisplayName("Пользователи и доступ")]
        UsersAndAccess = 3,

        /// <summary>
        /// Администрирование
        /// </summary>
        [DisplayName("Администрирование")]
        Administration = 4,

        /// <summary>
        /// Графика
        /// </summary>
        [DisplayName("Графика")]
        Graphics = 5,

        /// <summary>
        /// Транспорт
        /// </summary>
        [DisplayName("Управление транспортом")]
        Transport = 6,

        /// <summary>
        /// Отчеты
        /// </summary>
        [DisplayName("Отчеты")]
        Reports = 7,

        /// <summary>
        /// Помощь
        /// </summary>
        [DisplayName("Помощь")]
        Help
    }
}
