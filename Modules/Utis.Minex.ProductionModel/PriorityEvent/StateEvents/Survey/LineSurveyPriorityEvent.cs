using System.Collections.Generic;

namespace Utis.Minex.ProductionModel.PriorityEvent.StateEvents.Survey
{
    using Utis.Minex.Common;

    /// <summary>
    /// Состояние опроса линии.
    /// </summary>
    [DisplayName("Состояние опроса линии")]
    [Ackable]
    public class LineSurveyPriorityEvent : SurveyPriorityEventBase
    {
    }
}