using System.ComponentModel;
using Utis.Minex.Common.Enum;

namespace Utis.Minex.Common
{
    /// <summary>
    /// Журнал приязок зон к оборудованию.
    /// </summary>
    [DisplayName("Журнал приязок зон к оборудованию")]
    public interface IZoneBindDeviceJournal : IJournalClose
    {
        /// <summary>
        /// Зона.
        /// </summary>
        [DisplayName("Зона")]
        [Description("Зона антенны устройства")]
        IZone Zone
        { get; set; }

        /// <summary>
        /// Номер антенны, указывающую на зону.
        /// </summary>
        [DisplayName("Номер антенны, указывающей на зону")]
        [Description("Номер антенны устройства, указывающую на зону")]
        int Antenna
        { get; set; }

        /// <summary>
        /// Стационарное оборудование позиционирования для привязки.
        /// </summary>
        [DisplayName("Стационарное оборудование позиционирования для привязки")]
        IZoneDefineDevice ZoneDefineDevice
        { get; set; }

        /// <summary>
        /// Вручную заданная привязка (за границей зоны)
        /// </summary>
        [DisplayName("Вручную заданная привязка")]
        [Description("Вручную заданная привязка (за границей зоны)")]
        bool IsManual
        { get; set; }

    }

    /// <summary>
    /// Устройство с радиометкой.
    /// </summary>
    [DisplayName("Устройство с радиометкой")]
    public interface IDeviceWithRfid : IDevice
    {
        /// <summary>
        /// Метка RFID.
        /// </summary>
        [DisplayName("Метка RFID")]
        [Description("Метка RFID")]
        IRfidDevice RfidDevice
        { get; set; }
    }

    /// <summary>
    /// Устройство, определяющее границы зоны.
    /// </summary>
    [DisplayName("Устройство, определяющее границы зоны")]
    public interface IZoneDefineDevice : IDeviceWithRfid
    {
        /// <summary>
        /// Территориальная принадлежность.
        /// </summary>
        [DisplayName("Размещение")]
        [Description("Территориальная принадлежность")]
        [ReadOnly(true)]
        IHorizon Horizon
        { get; set; }
    }

    /// <summary>
    /// Устройство инфраструктуры позиционирования.
    /// </summary>
    [DisplayName("Устройство инфраструктуры позиционирования")]
    public interface IDevice : IObjectNamed
    {
        /// <summary>
        /// Заводской номер.
        /// (Не использовать термин "Серийный номер" - везде печатается "Заводской номер").
        /// </summary>
        [DisplayName("Заводской номер")]
        long SerialNumber
        { get; set; }
    }


    /// <summary>
    /// Метка RFID.
    /// </summary>
    [DisplayName("Метка RFID устройства")]
    public interface IRfidDevice : IObjectNamed
    {
        /// <summary>
        /// Метка RFID.
        /// </summary>
        [UniqueKey("Rfid")]
        [DisplayName("Метка RFID")]
        int Rfid
        { get; set; }

        /// <summary>
        /// Тип метки (класс устройства).
        /// </summary>
        [UniqueKey("Rfid")]
        [DisplayName("Тип метки (класс устройства)")]
        RfidDeviceType RfidDeviceType
        { get; set; }
    }

    /// <summary>
    /// Справочник горизонтов.
    /// </summary>
    [DisplayName("Справочник горизонтов")]
    public interface IHorizon : IMineBase
    {
        /// <summary>
        /// Тип горизонта.
        /// </summary>
        [DisplayName("Тип горизонта")]
        HorizonType HorizonType
        { get; set; }

        /// <summary>
        /// Признак нахождения под землей.
        /// </summary>
        [DisplayName("Признак нахождения под землей")]
        bool IsMine
        { get; set; }

        /// <summary>
        /// Уровень.
        /// </summary>
        [DisplayName("Уровень")]
        int? Level
        { get; set; }
    }

    /// <summary>
    /// Базовый класс технологического объекта (рудник, шахта, горизонт, выработка).
    /// </summary>
    [DisplayName("Базовый класс модели рудника")]
    public interface IMineBase : IObjectNamed
    {
        /// <summary>
        /// Родитель элемента технологической модели.
        /// </summary>
        [DisplayName("Родитель элемента технологической модели")]
        IMineBase Parent
        { get; set; }

        /// <summary>
        /// Подразделение, за которым закреплён технологический объект.
        /// </summary>
        [DisplayName("Подразделение, за которым закреплён технологический объект")]
        IDivision Division
        { get; set; }
    }
}
