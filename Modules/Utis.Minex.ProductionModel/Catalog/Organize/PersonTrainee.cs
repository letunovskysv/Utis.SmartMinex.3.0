using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Utis.Minex.ProductionModel.Catalog.Organize
{
    using Utis.Minex.Common;

    /// <summary>
    /// Справочник стажеров.
    /// </summary>
    [DisplayName("Стажер")]
    [Description("Справочник стажеров")]
    public class PersonTrainee : PersonBindCatalogBase
    {
        /// <summary>
        /// Дата начала наставничества.
        /// </summary>
        [DisplayName("Дата начала стажировки")]
        public virtual DateTime BeginDate
        { get; set; }

        /// <summary>
        /// Дата окончания наставничества.
        /// </summary>
        [DisplayName("Дата окончания стажировки")]
        public virtual DateTime EndDate 
        { get; set; }

        [DisplayName("Наставник")]
        public virtual TraineeMentor Mentor 
        { get; set; }

        [DisplayName("Инструктор")]
        public virtual TraineeMentor Instructor 
        { get; set; }
    }
}
