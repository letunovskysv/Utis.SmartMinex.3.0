using System;
using System.Collections.Generic;
using Utis.Minex.Common;
using Utis.Minex.ProductionModel.Catalog.Organize;

namespace Utis.Minex.ProductionModel.Journals
{
    /// <summary>
    /// Журнал изменений по опасным зонам
    /// </summary>
    [DisplayName("Журнал изменений по опасным зонам")]
    public class ZoneDangerousActivityJournal : Journal, IZoneDangerousActivityJournal
    {
        /// <summary>
        /// Опасная зона
        /// </summary>
        [DisplayName("Опасная зона")]
        public virtual ZoneDangerousJournal ZoneDangerous { get; set; }
        ///<summary>
        /// Автор изменения
        /// </summary>
        [DisplayName("Автор изменения")]
        public virtual UserData User { get; set; }
        ///<summary>
        /// Описание
        /// </summary>
        [DisplayName("Описание")]
        public virtual string Description { get; set; }

        IZoneDangerousJournal IZoneDangerousActivityJournal.ZoneDangerous { get => ZoneDangerous; set => ZoneDangerous = value as ZoneDangerousJournal; }
        IUserData IZoneDangerousActivityJournal.User { get => User; set => User = value as UserData; }
    }
}
