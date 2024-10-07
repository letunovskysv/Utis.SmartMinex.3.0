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
    /// Справочник смен
    /// </summary>
    [DisplayName("Справочник режимов сменности")]
    public class ShiftMode : CatalogBase
    {
        /// <summary>
        /// Является ли режим сменности режимом по умолчанию
        /// </summary>
        [DisplayName("Режим по умолчанию")]
        public virtual bool IsDefault { get; set; }
    }
}