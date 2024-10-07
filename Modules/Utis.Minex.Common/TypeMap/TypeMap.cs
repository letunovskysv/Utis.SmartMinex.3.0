namespace Utis.Minex.Common.TypeMap
{
    #region Using
    using System;

    #endregion Using

    /// <summary>Пара типов</summary>
    public class TypeMap
    {
        /// <summary>Входной тип</summary>
        public Type TypeIn { get; set; }

        /// <summary>Выходной тип</summary>
        public Type TypeOut { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="typeIn">Входной тип</param>
        /// <param name="typeOut">Выходной тип</param>
        public TypeMap(Type typeIn, Type typeOut)
        {
            TypeIn = typeIn;
            TypeOut = typeOut;
        }
    }
}
