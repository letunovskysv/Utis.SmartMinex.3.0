namespace Utis.Minex.Common.Enum
{
    public enum EntityActionType : byte
    {
        /// <summary>
        /// Удаление
        /// </summary>
        [DisplayName("Удаление")]
        Delete = 0,

        /// <summary>
        /// Редактирование
        /// </summary>
        [DisplayName("Редактирование")]
        Update = 1,

        /// <summary>
        /// Создание
        /// </summary>
        [DisplayName("Создание")]
        Create = 2
    }
}