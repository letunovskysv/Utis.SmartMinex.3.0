//--------------------------------------------------------------------------------------------------
// (C) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TReadersRow – Считыватели. База данных. DTO.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Spgt
{
    #region Using
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion Using

    [Description("Считыватели")]
    [Table("readers")]
    public class TReadersRow
    {
        /// <summary> Идентификатор считывателя.</summary>
        [DisplayName("Идентификатор считывателя")]
        [Column("id", TypeName = "int")]
        public int Id { get; set; }

        /// <summary> Номер линии.</summary>
        [DisplayName("Номер линии")]
        [Column("line_nom", TypeName = "int")]
        public int LineNom { get; set; }

        /// <summary> Номер считывателя на линии (modbus адрес).</summary>
        [DisplayName("Номер считывателя на линии (modbus адрес)")]
        [Column("reader_nom", TypeName = "int")]
        public int ReaderNom { get; set; }

        /// <summary> Название считывателя.</summary>
        [DisplayName("Название считывателя")]
        [Column("name", TypeName = "nvarchar")]
        public string Name { get; set; }

        /// <summary> Коментарий к считывателю.</summary>
        [DisplayName("Коментарий к считывателю")]
        [Column("note", TypeName = "nvarchar")]
        public string Note { get; set; }

        /// <summary> Горизонт.</summary>
        [DisplayName("Горизонт")]
        [Column("level_id", TypeName = "int")]
        public int LevelId { get; set; }

        /// <summary> Тип считывателя.</summary>
        [DisplayName("Тип считывателя")]
        [Column("reader_type", TypeName = "int")]
        public int ReaderType { get; set; }

        /// <summary> Состояние.</summary>
        [DisplayName("Состояние")]
        [Column("reader_state", TypeName = "int")]
        public int ReaderState { get; set; }

        /// <summary> Состояние крышки считывателя.</summary>
        [DisplayName("Состояние крышки считывателя")]
        [Column("cover_state", TypeName = "int")]
        public int CoverState { get; set; }

        /// <summary> Идентификатор источника питания.</summary>
        [DisplayName("Идентификатор источника питания")]
        [Column("power_id", TypeName = "int")]
        public int PowerId { get; set; }

        /// <summary> Идентификатор зоны для антенны 1.</summary>
        [DisplayName("Идентификатор зоны для антенны 1")]
        [Column("zone1_id", TypeName = "int")]
        public int Zone1Id { get; set; }

        /// <summary> Идентификатор зоны для антенны 2.</summary>
        [DisplayName("Идентификатор зоны для антенны 2")]
        [Column("zone2_id", TypeName = "int")]
        public int Zone2Id { get; set; }

        /// <summary> Идентификатор зоны для антенны 3.</summary>
        [DisplayName("Идентификатор зоны для антенны 3")]
        [Column("zone3_id", TypeName = "int")]
        public int Zone3Id { get; set; }

        /// <summary> Идентификатор зоны для антенны 4.</summary>
        [DisplayName("Идентификатор зоны для антенны 4")]
        [Column("zone4_id", TypeName = "int")]
        public int Zone4Id { get; set; }

        /// <summary> Состояние антенны 1.</summary>
        [DisplayName("Состояние антенны 1")]
        [Column("ant1_state", TypeName = "int")]
        public int Ant1State { get; set; }

        /// <summary> Состояние антенны 2.</summary>
        [DisplayName("Состояние антенны 2")]
        [Column("ant2_state", TypeName = "int")]
        public int Ant2State { get; set; }

        /// <summary> Состояние антенны 3.</summary>
        [DisplayName("Состояние антенны 3")]
        [Column("ant3_state", TypeName = "int")]
        public int Ant3State { get; set; }

        /// <summary> Состояние антенны 4.</summary>
        [DisplayName("Состояние антенны 4")]
        [Column("ant4_state", TypeName = "int")]
        public int Ant4State { get; set; }

        /// <summary> Идентификатор устройства по протоколу M2.</summary>
        [DisplayName("Идентификатор устройства по протоколу M2")]
        [Column("device_id", TypeName = "int")]
        public int DeviceId { get; set; }

        /// <summary> Идентификатор места расположения.</summary>
        [DisplayName("Идентификатор места расположения")]
        [Column("location_id", TypeName = "int")]
        public int LocationId { get; set; }

        /// <summary> конфигурация считывателя.</summary>
        [DisplayName("конфигурация считывателя")]
        [Column("config", TypeName = "varbinary")]
        public byte[] Config { get; set; }
    }
}
