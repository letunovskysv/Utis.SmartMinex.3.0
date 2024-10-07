
namespace Utis.Minex.ProductionModel.Common
{
    using Utis.Minex.Common;

    /// <summary>
    /// Регистрация поставщика данных по типу поставщика.
    /// </summary>
    /// <remarks>Для каждого типа поставщика предусматривается логин/пароль для авторизации подключения.</remarks>
    [DisplayName("Регистрация ПД")]
    [Description("Регистрация поставщика данных по типу")]
    public class DataProviderRegistration : VersionObjectBase
    {
        /// <summary>
        /// Тип поставщика данных
        /// </summary>
        [UniqueKey]
        public virtual string DataProviderTypeFullName 
        { get; set; }

        /// <summary>
        /// Имя пользователя для авторизации подключения UTProto.
        /// </summary>
        [DisplayName("Пользователь")]
        [Description("Имя системного пользователя")]
        public virtual string Username 
        { get; set; }

        /// <summary>
        /// Пароль.
        /// </summary>
        [DisplayName("Пароль")]
        public virtual string Password 
        { get; set; }
    }
}