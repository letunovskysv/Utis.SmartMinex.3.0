//--------------------------------------------------------------------------------------------------
// (C) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TReaderTransitDataRow – Реестр задач (список заданий для сервера, журнал) передачи транзитных данных через считыватели.. База данных. DTO.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Spgt
{
    #region Using
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion Using

    [Description("Реестр задач (список заданий для сервера, журнал) передачи транзитных данных через считыватели.")]
    [Table("reader_transit_data")]
    public class TReaderTransitDataRow
    {
        /// <summary> primary key.</summary>
        [DisplayName("primary key")]
        [Column("id", TypeName = "bigint")]
        public long Id { get; set; }

        /// <summary> Ссылка на ID считывателя, через который передаются транзитные данные.</summary>
        [DisplayName("Ссылка на ID считывателя, через который передаются транзитные данные")]
        [Column("reader_id", TypeName = "int")]
        public int ReaderId { get; set; }

        /// <summary> Номер линии считывателя.</summary>
        [DisplayName("Номер линии считывателя")]
        [Column("line_no", TypeName = "int")]
        public int LineNo { get; set; }

        /// <summary> Адрес считывателя, через который передаются транзитные данные.</summary>
        [DisplayName("Адрес считывателя, через который передаются транзитные данные")]
        [Column("reader_addr", TypeName = "int")]
        public int ReaderAddr { get; set; }

        /// <summary> Код типа устройства абонента (класс устройства). Предназначено для организации проверки соответствия подразумеваемого типа устройства фактическому. Пока не заполняется из-за отсутствия необходимости передачи команд устройствам, отличным от БСР, и из-за отсутствия присвоенного класса устройства у БСР..</summary>
        [DisplayName("Код типа устройства абонента (класс устройства). Предназначено для организации проверки соответствия подразумеваемого типа устройства фактическому. Пока не заполняется из-за отсутствия необходимости передачи команд устройствам, отличным от БСР, и из-за отсутствия присвоенного класса устройства у БСР.")]
        [Column("subtype", TypeName = "int")]
        public int Subtype { get; set; }

        /// <summary> Субадрес абонента считывателя - получателя транзитных данных..</summary>
        [DisplayName("Субадрес абонента считывателя - получателя транзитных данных.")]
        [Column("subaddr", TypeName = "int")]
        public int Subaddr { get; set; }

        /// <summary> Бинарные данные..</summary>
        [DisplayName("Бинарные данные.")]
        [Column("data", TypeName = "varbinary")]
        public byte[] Data { get; set; }

        /// <summary> Время создания задания..</summary>
        [DisplayName("Время создания задания.")]
        [Column("task_created", TypeName = "datetime")]
        public DateTime TaskCreated { get; set; }

        /// <summary> Отметка времени завершения задачи..</summary>
        [DisplayName("Отметка времени завершения задачи.")]
        [Column("completed", TypeName = "datetime")]
        public DateTime Completed { get; set; }

        /// <summary> Код результата выполнения. NULL означает, что ещё не выполнена, либо, при COMPLETED не NULL - выполнено без замечаний. Значение NOT NULL - ссылка на справочник типов событий..</summary>
        [DisplayName("Код результата выполнения. NULL означает, что ещё не выполнена, либо, при COMPLETED не NULL - выполнено без замечаний. Значение NOT NULL - ссылка на справочник типов событий.")]
        [Column("res_code", TypeName = "int")]
        public int ResCode { get; set; }

        /// <summary> Ответ устройства-абонента в бинарном виде..</summary>
        [DisplayName("Ответ устройства-абонента в бинарном виде.")]
        [Column("reply_data", TypeName = "varbinary")]
        public byte[] ReplyData { get; set; }

        /// <summary> Код, указывающий на источник задания: 1 - АРМ Диспетчера транспорта..</summary>
        [DisplayName("Код, указывающий на источник задания: 1 - АРМ Диспетчера транспорта.")]
        [Column("task_source", TypeName = "int")]
        public int TaskSource { get; set; }

        /// <summary> Ссылка на учётную запись пользователя, инициировавшего создание задачи..</summary>
        [DisplayName("Ссылка на учётную запись пользователя, инициировавшего создание задачи.")]
        [Column("author_account", TypeName = "int")]
        public int AuthorAccount { get; set; }
    }
}
