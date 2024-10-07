using System;
using System.Linq.Expressions;
using Utis.Minex.ProductionModel.Catalog.Organize;
using EntityIndividualDeviceBindRValue = Utis.Minex.ProductionModel.Register.Value.Bind.IndividualDeviceBindRValue;

namespace Utis.Minex.ProductionModel.Expression.Value
{
    /// <summary>
    /// Выражения для поиска значений регистра постоянных привязок индивидуальных устройств
    /// </summary>
    public static class IndividualDeviceBindRValueExpression
    {
        /// <summary>
        /// Выражение для поиска значений регистра постоянных привязок индивидуальных устройств по сотруднику
        /// </summary>
        public static Expression<Func<EntityIndividualDeviceBindRValue, bool>> Person(Person person, bool deleted = false)
        {
            return CommonExpression.AppendDeletedCondition<EntityIndividualDeviceBindRValue>
                (x => x.Person == person, deleted);
        }
    }
}