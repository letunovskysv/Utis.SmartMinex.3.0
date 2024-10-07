using System.Collections.Generic;
using System.Linq;
using System;

namespace Utis.Minex.Common.Graphic
{
    /// <summary>
    /// Данные для расчёта токена
    /// </summary>

    [DisplayName("Данные для расчёта токена")]
    public class TokenSource
    {
        /// <summary>
        /// Расстояние
        /// </summary>
        
        [Description("Расстояние")]
        [DisplayName("Расстояние")]
        public float Distance { get; set; }

        /// <summary>
        /// Идентификатор источника
        /// </summary>
        
        [Description("Идентификатор")]
        [DisplayName("Идентификатор")]
        public long SourceId { get; set; }

        /// <summary>
        /// Номер антенны
        /// </summary>
        
        [Description("Антенна")]
        [DisplayName("Антенна")]
        public byte Antenna { get; set; }


        public TokenSource()
        { 
        }

        public TokenSource(float distance, long sourceId, byte antenna)
        {
            Distance = distance;
            SourceId = sourceId;
            Antenna = antenna;
        }

        private static byte[] ToByteArray(TokenSource source)
        {
            var b = new byte[13];
            b[0] = source.Antenna;
            BitConverter.GetBytes(source.Distance).CopyTo(b, 1);
            BitConverter.GetBytes(source.SourceId).CopyTo(b, 5);
            return b;
        }
        private static TokenSource FromBytes(byte[] bytes, int index)
        {
            var source = new TokenSource();
            source.Antenna = bytes[index];
            source.Distance = BitConverter.ToSingle(bytes, index + 1);
            source.SourceId = BitConverter.ToInt64(bytes, index + 5);
            return source;
        }

        public static byte[] ToByteArray(IEnumerable<TokenSource> sources)
        {
            return sources.SelectMany(ToByteArray).ToArray();
        }

        public static IEnumerable<TokenSource> FromByteArray(byte[] bytes)
        {
            if (bytes is null || !bytes.Any())
                return new List<TokenSource>();

            if (bytes.Length % 13 != 0)
            {
                throw new Exception("Попытка преобразовать в TokenSource массив байт не кратный 13-и");
            }

            var sources = new List<TokenSource>(bytes.Length / 13);
            for (int index = 0; index < bytes.Length; index += 13)
            {
                sources.Add(FromBytes(bytes, index));
            }
            return sources;
        }
    }
}