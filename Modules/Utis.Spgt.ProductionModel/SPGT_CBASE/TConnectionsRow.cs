//--------------------------------------------------------------------------------------------------
// (C) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TConnectionsRow – Соединения, установленные с базой данных. База данных. DTO.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Spgt
{
    #region Using
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion Using

    [Description("Соединения, установленные с базой данных")]
    [Table("connections")]
    public class TConnectionsRow
    {
        /// <summary> Идентификатор соединения.</summary>
        [DisplayName("Идентификатор соединения")]
        [Column("id", TypeName = "int")]
        public int Id { get; set; }

        /// <summary> Имя пользователя.</summary>
        [DisplayName("Имя пользователя")]
        [Column("username", TypeName = "nvarchar")]
        public string Username { get; set; }

        /// <summary> Роль пользователя.</summary>
        [DisplayName("Роль пользователя")]
        [Column("rolename", TypeName = "nvarchar")]
        public string Rolename { get; set; }

        /// <summary> Ip адрес, с которого установлено соединение.</summary>
        [DisplayName("Ip адрес, с которого установлено соединение")]
        [Column("ip", TypeName = "nvarchar")]
        public string Ip { get; set; }

        /// <summary> Идентификатор процесса в системе пользователя.</summary>
        [DisplayName("Идентификатор процесса в системе пользователя")]
        [Column("pid", TypeName = "int")]
        public int Pid { get; set; }

        /// <summary> Полный путь к файлу процесса, установившего соединение.</summary>
        [DisplayName("Полный путь к файлу процесса, установившего соединение")]
        [Column("process_name", TypeName = "nvarchar")]
        public string ProcessName { get; set; }

        /// <summary> Дата и время установления соединения.</summary>
        [DisplayName("Дата и время установления соединения")]
        [Column("connection_datetime", TypeName = "datetime")]
        public DateTime ConnectionDatetime { get; set; }

        /// <summary> Дата и время обновления (для отслеживания живых соединений).</summary>
        [DisplayName("Дата и время обновления (для отслеживания живых соединений)")]
        [Column("update_datetime", TypeName = "datetime")]
        public DateTime UpdateDatetime { get; set; }
        public string HostName { get; set; }
    }
}
