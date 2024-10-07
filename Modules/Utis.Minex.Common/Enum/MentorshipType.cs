using System;

namespace Utis.Minex.Common.Enum
{
    [DisplayName("Тип наставничества")]
    public enum MentorshipType
    {
        [DisplayName("Наставник")]
        Mentor = 0,

        [DisplayName("Инструктор")]
        Instructor = 1,
    }
}
