using System;
using System.Linq.Expressions;
using Utis.Minex.ProductionModel.Devices;
using EntityPersonMovementRDimension = Utis.Minex.ProductionModel.Register.Dimension.Movement.PersonMovementRDimension;

namespace Utis.Minex.ProductionModel.Expression.Dimension
{
    /// <summary>
    /// Выражения для поиска срезов регистра событий регистраций персонала
    /// </summary>
    public static class PersonMovementRDimensionExpression
    {
        /// <summary>
        /// Выражение для поиска срезов регистра событий регистраций персонала по индивидуальному устройству
        /// </summary>
        public static Expression<Func<EntityPersonMovementRDimension, bool>> IndividualDevice(IndividualDevice individualDevice, bool deleted = false)
        {
            return CommonExpression.AppendDeletedCondition<EntityPersonMovementRDimension>
                (x => x.IndividualDevice == individualDevice, deleted);
        }
    }
}