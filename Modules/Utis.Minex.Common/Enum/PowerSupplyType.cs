namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Тип источника питания.
    /// </summary>
    [DisplayName("Тип источника питания")]
    public enum PowerSupplyType : byte
    {
        /// <summary>
        /// Питание от сети.
        /// </summary>
        [DisplayName("Питание от сети")]
        MainsSupply = 0,

        /// <summary>
        /// Питание от батареи.
        /// </summary>
        [DisplayName("Питание от батареи")]
        BatterySupply = 1,
    }
}