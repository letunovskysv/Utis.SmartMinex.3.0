using System;
using System.Linq.Expressions;
using EntityZoneDefineDevice = Utis.Minex.ProductionModel.Devices.ZoneDefineDevice;

namespace Utis.Minex.ProductionModel.Expression.Catalog
{
    /// <summary>
    /// Выражения для поиска устройств, определяющих границы зоны
    /// </summary>
    public static class ZoneDefineDeviceExpression
    {
        /// <summary>
        /// Получение устройства признаку нахождения под землей
        /// </summary>
        public static Expression<Func<TZoneDefineDevice, bool>> IsMine<TZoneDefineDevice>(bool isMine = false, bool deleted = false)
            where TZoneDefineDevice : EntityZoneDefineDevice
        {
            return CommonExpression.AppendDeletedCondition<TZoneDefineDevice>
                (x => x.Horizon != null && x.Horizon.IsMine == isMine, deleted);
        }
    }
}