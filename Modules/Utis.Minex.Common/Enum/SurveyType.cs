namespace Utis.Minex.Common.Enum
{
    public enum SurveyState
    {
        /// <summary>
        /// Опрос выключён
        /// </summary>
        [DisplayName("Опрос выключен")]
        [Description("Опрос выключен")]
        [EnumDetailEditable(false)]
        SurveyIsNotEnable = 0,

        /// <summary>
        /// Опрос включён
        /// </summary>
        [DisplayName("Опрос включён")]
        [Description("Опрос включён")]
        [EnumDetailEditable(false)]
        SurveyIsEnable = 1
    }
}