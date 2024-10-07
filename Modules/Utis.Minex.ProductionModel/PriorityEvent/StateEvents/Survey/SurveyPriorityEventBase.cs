
namespace Utis.Minex.ProductionModel.PriorityEvent.StateEvents.Survey
{
    #region Using

    using Utis.Minex.Common;
    using Utis.Minex.Common.Enum;

    #endregion

    /// <summary>
    /// Состояние опроса.
    /// </summary>
    [DisplayName("Состояние опроса")]
    public abstract class SurveyPriorityEventBase : PriorityEventBase
    {
        /// <summary>
        /// Источник.
        /// </summary>
        [DisplayName("Источник")]
        public virtual NamedObjectBase Source 
        { get; set; }

        /// <summary>
        /// Состояние опроса.
        /// </summary>
        [DisplayName("Состояние опроса")]
        public virtual SurveyState SurveyState 
        { get; set; }
    }
}