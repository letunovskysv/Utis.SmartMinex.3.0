using System.Collections.Generic;

namespace Utis.Minex.Common
{
    public interface IReadersToLineEvents : IVersionObjectBase
    {
        /// <summary>
        /// Считыватели
        /// </summary>
        [DisplayName("Считыватели")]
        [Description("Считыватели привязанные к линии на момент события")]
        public IEnumerable<long> Readers
        { get; set; }

        /// <summary>
        /// id события Line Failure
        /// </summary>
        [DisplayName("id события Port State")]
        public long? PortStateId
        { get; set; }


        /// <summary>
        /// id события Line State
        /// </summary>
        [DisplayName("id события Line State")]
        public long? LineStateId
        { get; set; }

        /// <summary>
        /// id события Line Survay
        /// </summary>
        [DisplayName("id события Line Survey")]
        public long? LineSurveyId
        { get; set; }
    }
}
