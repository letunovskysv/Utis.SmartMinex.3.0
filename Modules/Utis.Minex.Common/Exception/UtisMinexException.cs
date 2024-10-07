
namespace Utis.Minex.Common
{
    /// <summary>Exception</summary>
    [System.Serializable]
    public abstract class UtisMinesException : System.Exception
    {
        /// <summary>
        /// Constructor
        /// </summary>
        protected UtisMinesException() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Text of message</param>
        protected UtisMinesException(string message) : base(message) { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Text of message</param>
        /// <param name="inner">Inner exception</param>
        protected UtisMinesException(string message, System.Exception inner) : base(message, inner) { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="info">Information for serialization</param>
        /// <param name="context">Context of serialization</param>
        protected UtisMinesException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context
            )
            : base(info, context)
        {
            return;
        }
    }
}