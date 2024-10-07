namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Type of database managment system.
    /// </summary>
    [DisplayName("Type of database managment system")]
    public enum DBMSType
    {
        [DisplayName("Not defined")]
        Undefined = 0,

        [DisplayName("MS SQL Server")]
        MSSQLServer = 1,

        [DisplayName("PostgreSQL")]
        Postgresql = 2,
    }
}