//--------------------------------------------------------------------------------------------------
// (C) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TStowawayRow – Идентфикация нарушителей передвигающихся на транспорте. База данных. DTO.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Spgt
{
    #region Using
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion Using

    [Description("Идентфикация нарушителей передвигающихся на транспорте")]
    [Table("stowaway")]
    public class TStowawayRow
    {
        /// <summary> Идентификатор таблицы генерица программно.</summary>
        [DisplayName("Идентификатор таблицы генерица программно")]
        [Column("source_id", TypeName = "int")]
        public int SourceId { get; set; }

        /// <summary> Идентификатор человека.</summary>
        [DisplayName("Идентификатор человека")]
        [Column("person_id", TypeName = "int")]
        public int PersonId { get; set; }

        /// <summary> Дата и время последней регистрации начала пути.</summary>
        [DisplayName("Дата и время последней регистрации начала пути")]
        [Column("datetime_from", TypeName = "datetime")]
        public DateTime DatetimeFrom { get; set; }

        /// <summary> Дата и время последней регистрации конца пути.</summary>
        [DisplayName("Дата и время последней регистрации конца пути")]
        [Column("datetime_to", TypeName = "datetime")]
        public DateTime DatetimeTo { get; set; }

        /// <summary> Идентификатор считывателя начала пути.</summary>
        [DisplayName("Идентификатор считывателя начала пути")]
        [Column("reader_from_id", TypeName = "int")]
        public int ReaderFromId { get; set; }

        /// <summary> Идентификатор считывателя конца пути.</summary>
        [DisplayName("Идентификатор считывателя конца пути")]
        [Column("reader_to_id", TypeName = "int")]
        public int ReaderToId { get; set; }

        /// <summary> Номер метки.</summary>
        [DisplayName("Номер метки")]
        [Column("met_nom", TypeName = "int")]
        public int MetNom { get; set; }

        /// <summary> Норматив в секундах прохождения человеком пути от одного считывателя до другого.</summary>
        [DisplayName("Норматив в секундах прохождения человеком пути от одного считывателя до другого")]
        [Column("norm", TypeName = "int")]
        public int Norm { get; set; }

        /// <summary> Номер машины на которой пердвигался нарушитель.</summary>
        [DisplayName("Номер машины на которой пердвигался нарушитель")]
        [Column("vhcl_number", TypeName = "nvarchar")]
        public string VhclNumber { get; set; }

        /// <summary> Название машины на которой пердвигался нарушитель.</summary>
        [DisplayName("Название машины на которой пердвигался нарушитель")]
        [Column("vhcl_name", TypeName = "nvarchar")]
        public string VhclName { get; set; }

        /// <summary> Дата и время последней регистрации начала пути СГШО.</summary>
        [DisplayName("Дата и время последней регистрации начала пути СГШО")]
        [Column("vhcl_datetime_from", TypeName = "datetime")]
        public DateTime VhclDatetimeFrom { get; set; }

        /// <summary> Дата и время последней регистрации конца пути СГШО.</summary>
        [DisplayName("Дата и время последней регистрации конца пути СГШО")]
        [Column("vhcl_datetime_to", TypeName = "datetime")]
        public DateTime VhclDatetimeTo { get; set; }

        /// <summary> Идентификатор машиниста.</summary>
        [DisplayName("Идентификатор машиниста")]
        [Column("driver_id", TypeName = "int")]
        public int DriverId { get; set; }

        /// <summary> Номер метки машиниста.</summary>
        [DisplayName("Номер метки машиниста")]
        [Column("driver_met_nom", TypeName = "int")]
        public int DriverMetNom { get; set; }
    }
}
