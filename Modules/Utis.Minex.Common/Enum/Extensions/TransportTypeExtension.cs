namespace Utis.Minex.Common.Enum
{
    public static class TransportTypeExtension
    {
        public static bool IsDowntimeTransport(this TransportType transportType)
        {
            //  этот extension лучше не удалять,
            // так как требования могут изменится,
            // и снова придется фильтровать транспорт для которого регистрируются простои.
            return true;
        }
    }
}
