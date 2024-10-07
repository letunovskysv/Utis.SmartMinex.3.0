using System;
using System.Collections.Generic;

namespace Utis.Minex.Common
{
    using Utis.Minex.Common.Enum;

    /// <summary>
    /// Тэг события реального времени
    /// </summary>
    [DisplayName("Тэг события реального времени")]
    public class ProxyTag
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="sourceId">идентификатор источника</param>
        /// <param name="value">Значение тэга</param>
        /// <param name="proxyTagType">тип тэга</param>
        /// <param name="sourceType">тип источника</param>
        public ProxyTag(
            ProxyTagType proxyTagType,
            object value
            )
        {
            ProxyTagType = proxyTagType;
            Value = value;
        }

        #endregion 

        /// <summary>
        /// Тип тэга.
        /// </summary>
        [DisplayName("Тип тэга")]
        public ProxyTagType ProxyTagType 
        { get; set; }

        /// <summary>
        /// Значение тэга.
        /// </summary>
        [DisplayName("Значение тэга")]
        public object Value 
        { get; set; }
    }

    public class ProxyTagAckable
    {
        public ProxyTag Tag;
        public bool IsAcked;
        public bool IsRecieved;
        public string Role;
        public string User;

        public ProxyTagAckable(ProxyTag tag, bool isAcked, bool isRecieved, string role, string user)
        {
            Tag     = tag;
            IsAcked = isAcked;
            IsRecieved = isRecieved;
            Role   = role;
            User = user;
        }
    }
}