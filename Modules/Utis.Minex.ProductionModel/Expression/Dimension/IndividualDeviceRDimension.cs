using System;
using System.Linq.Expressions;
using Utis.Minex.ProductionModel.Devices;
using EntityIndividualDeviceRDimension = Utis.Minex.ProductionModel.Register.Dimension.State.IndividualDeviceRDimension;

namespace Utis.Minex.ProductionModel.Expression.Dimension
{
    /// <summary>
    /// Выражения для поиска срезов регистра выдачи/сдачи индивидуальных устройств персоналу
    /// </summary>
    public static class IndividualDeviceRDimensionExpression
    {
        public static Expression<Func<EntityIndividualDeviceRDimension, bool>> IndividualDevice(IndividualDevice device, bool deleted = false)
        {
            return CommonExpression.AppendDeletedCondition<EntityIndividualDeviceRDimension>
                (x => x.IndividualDevice == device, deleted);
        }
    }
}