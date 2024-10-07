//--------------------------------------------------------------------------------------------------
// (C) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TConnectionsHistoryRow – . База данных. DTO.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Spgt
{
    #region Using
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion Using

    [Description("")]
    [Table("connections_history")]
    public class TConnectionsHistoryRow
    {
        /// <summary> Идентификатор записи.</summary>
        [DisplayName("Идентификатор записи")]
        [Column("id", TypeName = "bigint")]
        public long Id { get; set; }

        /// <summary> IP адрес компьютера создавшего подключение.</summary>
        [DisplayName("IP адрес компьютера создавшего подключение")]
        [Column("ip", TypeName = "nvarchar")]
        public string Ip { get; set; }

        /// <summary> Имя компьютера создавшего подключение.</summary>
        [DisplayName("Имя компьютера создавшего подключение")]
        [Column("host_name", TypeName = "nvarchar")]
        public string HostName { get; set; }

        /// <summary> Имя компьютера создавшего подключение.</summary>
        [DisplayName("Имя компьютера создавшего подключение")]
        [Column("dt_begin", TypeName = "datetime")]
        public DateTime DtBegin { get; set; }

        /// <summary> Дата закрытия соединения.</summary>
        [DisplayName("Дата закрытия соединения")]
        [Column("dt_end", TypeName = "datetime")]
        public DateTime DtEnd { get; set; }

        /// <summary> Идентификатор установленного соединения с базой данных.</summary>
        [DisplayName("Идентификатор установленного соединения с базой данных")]
        [Column("connection_id", TypeName = "int")]
        public int ConnectionId { get; set; }
    }
}
