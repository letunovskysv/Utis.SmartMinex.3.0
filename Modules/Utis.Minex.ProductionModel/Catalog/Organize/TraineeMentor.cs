using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Utis.Minex.ProductionModel.Catalog.Organize
{
    #region Using

    using Utis.Minex.Common;
    using Utis.Minex.Common.Enum;

    #endregion

    /// <summary>
    /// Справочник наставников.
    /// </summary>
    [DisplayName("Наставник")]
    [Description("Справочник наставников")]
    public class TraineeMentor : PersonBindCatalogBase
    {
        /// <summary>
        /// Стажер.
        /// </summary>
        [DisplayName("Стажер")]
        public virtual Person Trainee 
        { get; set; }

        /// <summary>
        /// Дата начала наставничества.
        /// </summary>
        [DisplayName("Дата начала наставничества")]
        public virtual DateTime BeginDate 
        { get; set; }

        /// <summary>
        /// Дата окончания наставничества.
        /// </summary>
        [DisplayName("Дата окончания наставничества")]
        public virtual DateTime EndDate 
        { get; set; }

        /// <summary>
        /// Номер приказа.
        /// </summary>
        [DisplayName("Номер приказа")]
        public virtual string OrderNumber 
        { get; set; }

        /// <summary>
        /// Тип наставничества.
        /// </summary>
        [DisplayName("Тип наставничества")]
        public virtual MentorshipType MentorshipType 
        { get; set; }
    }
}
