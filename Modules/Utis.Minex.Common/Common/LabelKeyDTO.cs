using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Utis.Minex.Common
{
    using Utis.Minex.Common.Enum;

    /// <summary>
    /// Класс, дублирующий структуру LabelKey, создан для обмена между клиентом и сервером
    /// </summary>
    public class LabelKeyDTO
    {
        #region Constructors

        public LabelKeyDTO()
        {

        }

        #endregion

        #region Fields

        /// <summary>
        /// Номер метки.
        /// </summary>
        public int Label { get; set; }

        /// <summary>
        /// Типы (класс) устройства позиционирования.
        /// </summary>
        public RfidDeviceType Type { get; set; }

        #endregion

        #region Methods

        public bool Equals(LabelKeyDTO other)
        {
            if (other is null)
                return false;

            return Label == other.Label && Type == other.Type;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return
                Equals((LabelKeyDTO)obj);
        }

        public override int GetHashCode()
        {
            int hash = 17;

            hash = hash * 23 + Label.GetHashCode();
            hash = hash * 23 + Type.GetHashCode();

            return
                hash;
        }

        public static bool operator ==(LabelKeyDTO e1, LabelKeyDTO e2)
        {
            if(e1 is null || e2 is null)
            {
                return e1 is null && e2 is null;
            }
            return
                e1.Equals(e2);
        }

        public static bool operator !=(LabelKeyDTO e1, LabelKeyDTO e2)
        {
            return !(e1 == e2);
        }

        public object Clone()
        {
            return
                MemberwiseClone();
        }


        public override string ToString()
        {
            return $"{Type} {Label}";
        }

        #endregion
    }
}
