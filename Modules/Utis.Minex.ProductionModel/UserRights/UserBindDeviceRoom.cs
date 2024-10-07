using Utis.Minex.Common;
using Utis.Minex.ProductionModel.Positioning;

namespace Utis.Minex.ProductionModel.UserRights
{
    /// <summary>
    /// Доступ пользователей к ламповой
    /// </summary>
    [DisplayName("Доступ пользователей к ламповой")]
    [RegisterChanges(true)]
    public class UserBindDeviceRoom : CatalogBase
    {
        /// <summary>
        ///  Пользователь.
        /// </summary>
        [DisplayName("Пользователь")]
        [RegisterChangesOnCreate(true)]
        public virtual UserData UserData
        { get; set; }

        /// <summary>
        ///  Ламповая.
        /// </summary>
        [DisplayName("Ламповая")]
        [RegisterChangesOnCreate(true)]
        public virtual IndividualDevicesRoom IndividualDevicesRoom
        { get; set; }
    }
}
