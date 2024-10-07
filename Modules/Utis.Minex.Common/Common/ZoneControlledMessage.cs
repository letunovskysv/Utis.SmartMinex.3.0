namespace Utis.Minex.Common
{
    /// <summary>
    /// Сообщение для отправки с клиента на сервер о состоянии контролирования зоны
    /// </summary>
    public class ZoneControlledMessage: ZoneMessage
    {
        public ZoneControlledMessage()
        {
            IsControlled = true;
        }
    }

    public class ZoneUnControlledMessage : ZoneMessage
    {
        public ZoneUnControlledMessage() {
            IsControlled = false;
        }
    }

    public class ZoneMessage
    {
        public long ZoneId { get; set; }

        public long JournalId { get; set; }

        public bool IsControlled { get; set; }

        public long UserId { get; set; }

        public override string ToString()
        {
            return $"ZoneId:{ZoneId}; IsControlled:{IsControlled}";
        }
    }
}
