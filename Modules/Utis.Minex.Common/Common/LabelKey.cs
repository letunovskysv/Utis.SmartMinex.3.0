using System;

namespace Utis.Minex.Common
{
        using Utis.Minex.Common.Enum;

    /// <summary>
    /// Метка.
    /// </summary>
    [System.Diagnostics.DebuggerDisplay("{Type} {Label}")]
    [DisplayName("Метка")]
    public struct LabelKey : IEquatable<LabelKey>, IComparable<LabelKey>,  ICloneable
    {
        #region Constructors

        public LabelKey(int label, RfidDeviceType type)
        {
            Label = label;
            Type  = type;
        }

        public LabelKey(int label, MobileDeviceType type)
        {
            Label = label;
            Type  = (RfidDeviceType)type;
        }

        public LabelKey(int label, IndividualDeviceType type)
        {
            Label = label;
            Type  = (RfidDeviceType)type;
        }

        #endregion

        #region Fields

        /// <summary>
        /// Номер метки.
        /// </summary>
        public int Label { get; }

        //Дублируем эти поля в пропертях для корректного биндинга.
        //Оставил проперти на месте, т.к. их пытаются получить через рефлекшн кое-где еще
        // Марк Б. UMS-1574
        public int LabelProperty { get => Label; }

        /// <summary>
        /// Типы (класс) устройства позиционирования.
        /// </summary>
        public RfidDeviceType Type { get; }

        public RfidDeviceType TypeProperty { get => Type; }

        #endregion

        #region Equals

        public bool Equals(LabelKey other)
        {
            return Label == other.Label && Type == other.Type;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return
                Equals((LabelKey)obj);
        }

        public override int GetHashCode()
        {
            int hash = 17;

            hash = hash * 23 + Label.GetHashCode();
            hash = hash * 23 + Type.GetHashCode();

            return 
                hash;
        }

        public static bool operator ==(LabelKey e1, LabelKey e2)
        {
            return
                e1.Equals(e2);
        }

        public static bool operator !=(LabelKey e1, LabelKey e2)
        {
            return
                !e1.Equals(e2);
        }

        public int CompareTo(LabelKey other)
        {
            if (other.Type == this.Type)
                return other.Label.CompareTo(this.Label);

            return other.Type.CompareTo(this.Type);
        }
        #endregion

        #region Clone

        public object Clone()
        {
            return
                MemberwiseClone();
        }

        #endregion

        #region ToString

        public override string ToString()
        {
            return $"{Type.GetEnumDisplayName()} {Label}";
        }

        #endregion
    }
}