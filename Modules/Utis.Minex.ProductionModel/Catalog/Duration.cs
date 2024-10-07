using Utis.Minex.Common;
using Utis.Minex.Common.Enum;

namespace Utis.Minex.ProductionModel.Catalog
{
    #region using
    using System;
    #endregion

    /// <summary>
    /// Период
    /// </summary>
    [DisplayName("Период")]
    public class Duration : CatalogBase
    {
        /// <summary>
        /// Значение
        /// </summary>
        [DisplayName("Значение")]
        [UniqueKey]
        public virtual int Value
        {
            get => _value;
            set => _value = value;
        }
        private int _value = 1;

        /// <summary>
        /// Единица измерения
        /// </summary>
        [DisplayName("Единица измерения")]
        [Description("Единица измерения периода")]
        [UniqueKey]
        public virtual DurationType DurationType
        {
            get => _durationType;
            set => _durationType = value;
        }
        private DurationType _durationType = DurationType.minute;

        /// <summary>
        /// Добавляет к указанной дате временной интервал, содержащийся в объекте
        /// </summary>
        /// <param name="datetime">Дата/время, к которому нужно прибавить временной интервал</param>
        /// <returns>Дата/время с прибавленным интервалом, на котором вызван метод</returns>
        public virtual DateTime AddThisDuration(DateTime datetime)
        {
            switch (DurationType)
            {
                case DurationType.second:
                    return datetime.AddSeconds(Value);
                case DurationType.minute:
                    return datetime.AddMinutes(Value);
                case DurationType.hour:
                    return datetime.AddHours(Value);
                case DurationType.day:
                    return datetime.AddDays(Value);
                case DurationType.week:
                    return datetime.AddDays(Value * 7);
                case DurationType.Decade:
                    return datetime.AddDays(Value * 10);
                case DurationType.Month:
                    return datetime.AddMonths(Value);
                case DurationType.quarter:
                    return datetime.AddMonths(Value * 3);
                case DurationType.year:
                    return datetime.AddYears(Value);
                default:
                    return datetime;
            }
        }
    }
}