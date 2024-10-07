using System;
using System.Linq.Expressions;
using Utis.Minex.ProductionModel.Devices;
using Utis.Minex.ProductionModel.Register.Value.Bind;

namespace Utis.Minex.ProductionModel.Expression.Value
{
    /// <summary>
    /// Выражения для поиска значений регистра постоянных привязок ламп
    /// </summary>
    public static class LampDeviceBindRValueExpression
    {
        /// <summary>
        /// Выражение для поиска значений регистра постоянных привязок ламп по устройству
        /// </summary>
        public static Expression<Func<LampDeviceBindRValue, bool>> Device(Device device, bool deleted = false)
        {
            return CommonExpression.AppendDeletedCondition<LampDeviceBindRValue>
                (x => x.Device == device, deleted);
        }
    }
}