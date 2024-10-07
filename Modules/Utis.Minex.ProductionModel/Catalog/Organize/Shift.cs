//--------------------------------------------------------------------------------------------------
// (C) 2018 ООО «УралТехИс». ПТК «Горный диспетчер». Все права защищены.
// Описание: Класс, описывающий справочник смен.
//--------------------------------------------------------------------------------------------------
using System;
using Utis.Minex.Common;

namespace Utis.Minex.ProductionModel.Catalog.Organize
{
    /// <summary>
    /// Справочник смен
    /// </summary>
    [DisplayName("Справочник смен")]
    public class Shift : CatalogBase
    {
        /// <summary>
        /// Номер смены
        /// </summary>
        [DisplayName("Номер смены")]
        public virtual byte Number { get; set; }

        /// <summary>
        /// Длительность смены
        /// </summary>
        [DisplayName("Режим сменности")]
        public virtual ShiftMode ShiftMode { get; set; }

        /// <summary>
        /// Длительность смены
        /// </summary>
        [DisplayName("Длительность смены")]
        public virtual double Duration { get; set; }


        private DateTime? _lampGiveOutBegin;
        /// <summary>
        /// Начало выдачи светильников
        /// </summary>
        [DisplayName("Начало выдачи светильников")]
        public virtual DateTime? LampGiveOutBegin 
        {   
            get => _lampGiveOutBegin;
            set => _lampGiveOutBegin = value.HasValue ? new DateTime(1900, 1, 1, value.Value.Hour, value.Value.Minute, value.Value.Second) : 
                null;
        }


        private DateTime? _mineEnterBegin;
        /// <summary>
        /// Начало спуска
        /// </summary>
        [DisplayName("Начало спуска")]
        public virtual DateTime? MineEnterBegin 
        {
            get => _mineEnterBegin;
            set => _mineEnterBegin = value.HasValue ? new DateTime(1900, 1, 1, value.Value.Hour, value.Value.Minute, value.Value.Second) :
                null; 
        }


        private DateTime? _mineEnterEnd;
        /// <summary>
        /// Окончание спуска
        /// </summary>
        [DisplayName("Окончание спуска")]
        public virtual DateTime? MineEnterEnd
        {
            get => _mineEnterEnd;
            set => _mineEnterEnd = value.HasValue ? new DateTime(1900, 1, 1, value.Value.Hour, value.Value.Minute, value.Value.Second) :
                null;
        }

        private  DateTime? _shiftBegin;
        /// <summary>
        /// Окончание спуска
        /// </summary>
        [DisplayName("Начало смены")]
        public virtual DateTime? ShiftBegin
        {
            get => _shiftBegin;
            set => _shiftBegin = value.HasValue ? new DateTime(1900, 1, 1, value.Value.Hour, value.Value.Minute, value.Value.Second) :
                null;
        }

        private DateTime? _shiftEnd;
        /// <summary>
        /// Окончание спуска
        /// </summary>
        [DisplayName("Окончание смены")]
        public virtual DateTime? ShiftEnd
        {
            get => _shiftEnd;
            set => _shiftEnd = value.HasValue ? new DateTime(1900, 1, 1, value.Value.Hour, value.Value.Minute, value.Value.Second) :
                null;
        }


        private DateTime? _mineLeaveBegin;
        /// <summary>
        /// Начало подъема
        /// </summary>
        [DisplayName("Начало подъема")]
        public virtual DateTime? MineLeaveBegin
        {
            get => _mineLeaveBegin;
            set => _mineLeaveBegin = value.HasValue ? new DateTime(1900, 1, 1, value.Value.Hour, value.Value.Minute, value.Value.Second) :
                null;
        }

        private DateTime? _mineLeaveEnd;
        /// <summary>
        /// Окончание подъема
        /// </summary>
        [DisplayName("Окончание подъема")]
        public virtual DateTime? MineLeaveEnd
        {
            get => _mineLeaveEnd;
            set => _mineLeaveEnd = value.HasValue ? new DateTime(1900, 1, 1, value.Value.Hour, value.Value.Minute, value.Value.Second) :
                null;
        }

        private DateTime? _lampTurnInEnd;
        /// <summary>
        /// Контрольное время сдачи светильников
        /// </summary>
        [DisplayName("Контрольное время сдачи светильников")]
        public virtual DateTime? LampTurnInEnd
        {
            get => _lampTurnInEnd;
            set => _lampTurnInEnd = value.HasValue ? new DateTime(1900, 1, 1, value.Value.Hour, value.Value.Minute, value.Value.Second) :
                null;
        }
        
    }
}