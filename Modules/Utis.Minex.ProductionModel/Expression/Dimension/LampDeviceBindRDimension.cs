using System;
using System.Linq.Expressions;

namespace Utis.Minex.ProductionModel.Expression.Dimension
{
    #region Using
    
    using Utis.Minex.ProductionModel.Devices;
    using Utis.Minex.ProductionModel.Register.Dimension.Bind;

        #endregion

    /// <summary>
    /// Выражения для поиска срезов регистра привязок индивидуальных устройств и ламп
    /// </summary>
    public static class LampDeviceBindRDimensionExpression
    {
        /// <summary>
        /// Выражения для поиска срезов регистра привязок индивидуальных устройств и ламп по лампе
        /// </summary>
        public static Expression<Func<LampDeviceBindRDimension, bool>> Lamp(Lamp lamp, bool deleted = false)
        {
            return CommonExpression.AppendDeletedCondition<LampDeviceBindRDimension>
                (x => x.Lamp == lamp, deleted);
        }

        /// <summary> Выражения для поиска срезов регистра привязок устройств и ламп с не пустой лампой </summary>
        public static Expression<Func<LampDeviceBindRDimension, bool>> NotEmptyDevice(bool deleted = false)
        {
            return CommonExpression.AppendDeletedCondition<LampDeviceBindRDimension>
                (x => x.Lamp != null, deleted);
        }
    }
}