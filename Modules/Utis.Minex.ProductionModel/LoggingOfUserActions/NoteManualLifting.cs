using System;

namespace Utis.Minex.ProductionModel.LoggingOfUserActions
{
    #region Using
    
    using Utis.Minex.Common;

    using Utis.Minex.ProductionModel.Devices;
    using Utis.Minex.ProductionModel.Catalog.Organize;

        #endregion

    /// <summary>
    /// Журнал ручных подъёмов персонала.
    /// </summary>
    [DisplayName("Журнал ручных подъёмов персонала")]
    public class NoteManualLifting : CatalogBase
    {
        /// <summary>
        /// Дата/время внесения записи.
        /// </summary>
        [DisplayName("Дата/время внесения записи")]
        public virtual DateTime DateTime
        { get; set; }

        /// <summary>
        /// Логин.
        /// </summary>
        [DisplayName("Логин")]
        public virtual string UserName
        { get; set; }

        /// <summary>
        /// Персона к которой относиться учетная запись.
        /// </summary>
        [DisplayName("Персона к которой относиться учетная запись")]
        public virtual Person UserPerson
        { get; set; }

        /// <summary>
        /// Роль.
        /// </summary>
        [DisplayName("Роль")]
        public virtual string UserRoleName
        { get; set; }

        /// <summary>
        /// Метка (для которой выполняем ручной подъем).
        /// </summary>
        [DisplayName("Метка")]
        public virtual RfidDevice RfidDevice
        { get; set; }

        /// <summary>
        /// Радиоблок (с данной меткой).
        /// </summary>
        [DisplayName("Радиоблок")]
        public virtual RFUnit RfUnit
        { get; set; }

        /// <summary>
        /// Сотрудник.
        /// </summary>
        [DisplayName("Сотрудник")]
        public virtual Person Person
        { get; set; }

        /// <summary>
        /// Подтверждение нахождения на поверхности.
        /// </summary>
        public virtual bool AckNotInMine
        { get; set; }

        /// <summary>
        /// Подтверждение сдачи светильника.
        /// </summary>
        public virtual bool AckLampReturn
        { get; set; }
    }
}
