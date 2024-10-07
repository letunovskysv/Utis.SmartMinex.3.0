using System;
using Utis.Minex.Common;
using Utis.Minex.Common.Enum;

namespace Utis.Minex.ProductionModel.Positioning
{
    /// <summary>
    /// Отброшенные позиции.
    /// </summary>
    [DisplayName("Отброшенные позиции")]
    public class DiscardedAccurateRfidEvent : VersionObjectBase
    {
        /// <summary>
        /// Тип метки
        /// </summary>
        [DisplayName("Номер метки")]
        public virtual int Label
        { get; set; }

        /// <summary>
        /// Тип метки
        /// </summary>
        [DisplayName("Тип метки")]
        public virtual RfidDeviceType RfidType
        { get; set; }

        /// <summary>
        /// Метка субъекта
        /// </summary>
        [DisplayName("Метка субъекта")]
        public virtual long SubjectLabel { get; set; }

        /// <summary>
        /// Тип регистрирующего субъекта
        /// </summary>
        [DisplayName("Тип субъекта")]
        public virtual RfidDeviceType SubjectType { get; set; }

        /// <summary>
        /// Антенна
        /// </summary>
        [DisplayName("Антенна")]
        public virtual int Antenna { get; set; }

        /// <summary>
        /// Идентификатор анкера
        /// </summary>
        [DisplayName("Идентификатор анкера")]
        public virtual long AnchorId { get; set; }

        /// <summary>
        /// Расстояние
        /// </summary>
        [DisplayName("Расстояние")]
        public virtual float Distance { get; set; }


        /// <summary>
        /// Антенна
        /// </summary>
        [DisplayName("Причина")]
        public virtual ReasonDiscardedAccurateRfidEvent Reason { get; set; }

        /// <summary>
        /// Дата, время поступления события из источника, фиксации в БД.
        /// </summary>
        [DisplayName("Зафиксировано")]
        [Description("Дата/время поступления события из источника, фиксации в БД")]
        public DateTime Datetime { get; set; }
    }
}