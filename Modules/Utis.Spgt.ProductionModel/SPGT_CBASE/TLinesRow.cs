//--------------------------------------------------------------------------------------------------
// (C) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TLinesRow – Линии связи. База данных. DTO.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Spgt
{
    #region Using
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion Using

    [Description("Линии связи")]
    [Table("lines")]
    public class TLinesRow
    {
        /// <summary> Номер линии.</summary>
        [DisplayName("Номер линии")]
        [Column("nom", TypeName = "int")]
        public int Nom { get; set; }

        /// <summary> Обыв кольцевой линии: 0-линия целая; 1-линия оборвана.</summary>
        [DisplayName("Обыв кольцевой линии: 0-линия целая; 1-линия оборвана")]
        [Column("broken", TypeName = "int")]
        public int Broken { get; set; }

        /// <summary> Состояние преобразователя порта 1: null-отсутствует, 0-отказ, 1-работает.</summary>
        [DisplayName("Состояние преобразователя порта 1: null-отсутствует, 0-отказ, 1-работает")]
        [Column("port1_state", TypeName = "int")]
        public int Port1State { get; set; }

        /// <summary> Состояние преобразователя порта 2: null-отсутствует, 0-отказ, 1-работает.</summary>
        [DisplayName("Состояние преобразователя порта 2: null-отсутствует, 0-отказ, 1-работает")]
        [Column("port2_state", TypeName = "int")]
        public int Port2State { get; set; }
    }
}
