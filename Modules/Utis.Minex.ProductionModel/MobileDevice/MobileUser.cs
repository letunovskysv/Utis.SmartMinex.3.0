
namespace Utis.Minex.ProductionModel.MobileDevice
{
    #region Using

    using Utis.Minex.Common;
    using Utis.Minex.ProductionModel.Catalog.Organize;

    #endregion

    /// <summary>
    /// Пользователь для аутентификации на АРМ мобильного устройства.
    /// </summary>
    [DisplayName("Пользователь АРМ МУ")]
    [Description("Пользователь для аутентификации на АРМ мобильного устройства")]
    public class MobileUser : CatalogBase
    {
        /// <summary>
        /// Пароль пользователя мобильного устройства.
        /// </summary>
        [DisplayName("Пароль")]
        [Description("Пароль пользователя мобильного устройства")]
        public virtual string Password 
        { get; set; }

        /// <summary>
        /// Сотрудник, пользователь мобильного устройства.
        /// </summary>
        [DisplayName("Сотрудник")]
        [Description("Сотрудник, пользователь мобильного устройства")]
        public virtual Person Person 
        { get; set; }
    }
}