//--------------------------------------------------------------------------------------------------
// (C) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TReaderStatesRow – Справочник состояний считывателя. База данных. DTO.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Spgt
{
    #region Using
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion Using

    [Description("Справочник состояний считывателя")]
    [Table("reader_states")]
    public class TReaderStatesRow
    {
        /// <summary> Состояние считывателя: 0=Ок; 1=Отказ; 2=Считыватель только что добавили, требует синхронизации времени; 3=Считыватель выключен из опроса.</summary>
        [DisplayName("Состояние считывателя: 0=Ок; 1=Отказ; 2=Считыватель только что добавили, требует синхронизации времени; 3=Считыватель выключен из опроса")]
        [Column("code", TypeName = "int")]
        public int Code { get; set; }

        /// <summary> Название состояние считывателя.</summary>
        [DisplayName("Название состояние считывателя")]
        [Column("name", TypeName = "nvarchar")]
        public string Name { get; set; }
    }
}
