using System;
using System.Linq.Expressions;

namespace Utis.Minex.ProductionModel.Expression.Catalog
{
    #region Using
        
    using Utis.Minex.Common.Enum;
    using Utis.Minex.ProductionModel.Devices;

        #endregion

    /// <summary>
    /// Выражения для поиска устройств с меткой Rfid.
    /// </summary>
    public static class DeviceWithRfidExpression
    {
        /// <summary>
        /// Получение устройства по rfid-метке.
        /// </summary>
        public static Expression<Func<TWithRfid, bool>> Rfid<TWithRfid>(long rfid, bool deleted = false)
            where TWithRfid : DeviceWithRfid
        {
            return CommonExpression.AppendDeletedCondition<TWithRfid>
                (x => x.RfidDevice != null && x.RfidDevice.Rfid == rfid, deleted);
        }

        /// <summary>
        /// Получение устройства по rfid-метке и типу.
        /// </summary>
        public static Expression<Func<TWithRfid, bool>> RfidAndType<TWithRfid>(long rfid, RfidDeviceType type, bool deleted = false)
            where TWithRfid : DeviceWithRfid
        {
            return CommonExpression.AppendDeletedCondition<TWithRfid>
            (x => x.RfidDevice != null && x.RfidDevice.Rfid == rfid && x.RfidDevice.RfidDeviceType == type,
                deleted);
        }
    }
}