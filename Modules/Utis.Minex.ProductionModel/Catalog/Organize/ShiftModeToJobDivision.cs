//--------------------------------------------------------------------------------------------------
// (C) 2018 ООО «УралТехИс». ПТК «Горный диспетчер». Все права защищены.
// Описание: Класс, описывающий справочник смен.
//--------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using Utis.Minex.Common;

namespace Utis.Minex.ProductionModel.Catalog.Organize
{
    /// <summary>
    /// Справочник привязки режима сменности к паре подразделение-должность
    /// </summary>
    [DisplayName("Справочник привязки режима сменности к паре подразделение-должность")]
    public class ShiftModeToJobDivision : CatalogBase
    {
        /// <summary>
        /// Подразделение
        /// </summary>
        [DisplayName("Подразделение")]
        public virtual Division Division { get; set; }


        /// <summary>
        /// Должность
        /// </summary>
        [DisplayName("Должность")]
        public virtual JobTitle JobTitle { get; set; }

        /// <summary>
        /// Режим сменности
        /// </summary>
        [DisplayName("Режим сменности")]
        public virtual ShiftMode ShiftMode { get; set; }

       
    }
}