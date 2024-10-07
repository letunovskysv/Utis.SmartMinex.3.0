namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Тип телеметрии передаваемой из Modbus
    /// </summary>
    public enum ModbusTelemetryTypes
    {
        DEFAULT = 0,
        Firmware = 3,
        SerialNumber = 4,
        HardwareSet = 5,
        Subclass = 6,
        Voltage = 64,
        RFTime = 65,
        rCSR = 66,
        WorkDays = 67,
    }
}
