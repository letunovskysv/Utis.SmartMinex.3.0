//--------------------------------------------------------------------------------------------------
// (C) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TPeoplePhotosRow – . База данных. DTO.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Spgt
{
    #region Using
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion Using

    [Description("")]
    [Table("people_photos")]
    public class TPeoplePhotosRow
    {
        /// <summary> Идентификатор сотрудника.</summary>
        [DisplayName("Идентификатор сотрудника")]
        [Column("person_id", TypeName = "int")]
        public int PersonId { get; set; }

        /// <summary> Путь к файлу с фото.</summary>
        [DisplayName("Путь к файлу с фото")]
        [Column("url", TypeName = "nvarchar")]
        public string Url { get; set; }

        /// <summary> Фото.</summary>
        [DisplayName("Фото")]
        [Column("photo", TypeName = "varbinary")]
        public byte[] Photo { get; set; }

        /// <summary> Время изменения.</summary>
        [DisplayName("Время изменения")]
        [Column("changed_datetime", TypeName = "datetime")]
        public DateTime ChangedDatetime { get; set; }
    }
}
