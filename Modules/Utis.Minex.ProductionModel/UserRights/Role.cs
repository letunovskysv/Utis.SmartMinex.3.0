namespace Utis.Minex.ProductionModel
{
        using Utis.Minex.Common;

    /// <summary>
    /// Роли.
    /// </summary>
    [DisplayName("Роли")]
    [Description("Поддерживаемые роли для пользователей")]
    //включение регистрации изменений
    [RegisterChanges(true)]
    public class Role : CatalogBase
    {
        //Involved NamedObjectBase.Name
        //[DisplayName("Наименование роли")]
        //public virtual string RoleName
        //{ get; set; }

        /// <summary>
        /// Описание роли.
        /// </summary>
        [DisplayName("Описание роли")]
        public virtual string RoleDescr
        { get; set; }
    }
}