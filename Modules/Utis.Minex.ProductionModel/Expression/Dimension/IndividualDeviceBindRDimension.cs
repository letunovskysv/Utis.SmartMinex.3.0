using System;
using System.Linq.Expressions;

namespace Utis.Minex.ProductionModel.Expression.Dimension
{
    #region Using
    
    using Utis.Minex.ProductionModel.Devices;
    using Utis.Minex.ProductionModel.Register.Dimension.Bind;

        #endregion

    /// <summary>
    /// Выражения для поиска срезов регистра привязок индивидуальных устройств и персонала.
    /// </summary>
    public static class IndividualDeviceBindRDimensionExpression
    {
        /// <summary>
        /// Выражения для поиска срезов регистра привязок индивидуальных устройств и персонала по устройству.
        /// </summary>
        public static Expression<Func<IndividualDeviceBindRDimension, bool>> IndividualDevice(IndividualDevice device, bool deleted = false)
        {
            return CommonExpression.AppendDeletedCondition<IndividualDeviceBindRDimension>
                (x => x.IndividualDevice == device, deleted);
        }

        /// <summary>
        /// Выражения для поиска срезов регистра привязок индивидуальных устройств и персонала с не пустым устройством.
        /// </summary>
        public static Expression<Func<IndividualDeviceBindRDimension, bool>> NotEmptyIndividualDevice(bool deleted = false)
        {
            return CommonExpression.AppendDeletedCondition<IndividualDeviceBindRDimension>
                (x => x.IndividualDevice != null, deleted);
        }
    }
}