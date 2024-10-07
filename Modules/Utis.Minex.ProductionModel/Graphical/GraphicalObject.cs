using System;
using System.Collections.Generic;

namespace Utis.Minex.ProductionModel.Graphical
{
    #region Using
    
    using Utis.Minex.Common;
    using Utis.Minex.ProductionModel.MineSpace.MineModel;

        #endregion

    /// <summary>
    /// Графический объект.
    /// </summary>
    [DisplayName("Графический объект")]
    public class GraphicalObject : CatalogBase
    {
        /// <summary>
        /// Порядок.
        /// </summary>
        [DisplayName("Порядок")]
        public virtual int? Order 
        { get; set; }

        /// <summary>
        /// Тип.
        /// </summary>
        [DisplayName("Тип")]
        public virtual long MdType 
        { get; set; }

        /// <summary>
        /// Потомки.
        /// </summary>
        [DisplayName("Потомки")]
        public virtual ISet<GraphicalObject> Childs 
        { get; set; } = new HashSet<GraphicalObject>();

        /// <summary>
        /// Родитель.
        /// </summary>
        [DisplayName("Родитель")]
        public virtual GraphicalObject Parent 
        { get; set; }

        /// <summary>
        /// Подразделение.
        /// </summary>
        [DisplayName("Подразделение")]
        public virtual MineBase MineObject 
        { get; set; }

        /// <summary>
        /// Версия опубликована.
        /// </summary>
        [DisplayName("Версия опубликована")]
        public virtual bool? IsPublished 
        { get; set; }

        /// <summary>
        /// Дата начала действия опубликованной ИМР.
        /// </summary>
        [DisplayName("Дата начала действия")]
        public virtual DateTime? PublishStartDate
        { get; set; }

        /// <summary>
        /// Дата окончания действия опубликованной ИМР.
        /// </summary>
        [DisplayName("Дата окончания действия")]
        public virtual DateTime? PublishEndDate
        { get; set; }

        /// <summary>
        /// Статистика: секций, горных выработок, зон, оборудования в формате JSON.
        /// </summary>
        [DisplayName("Статистика")]
        public virtual string Summary
        { get; set; }

        /// <summary>
        /// Дата последних изменений в ИМР.
        /// </summary>
        [DisplayName("Дата последних изменений")]
        public virtual DateTime? LastChangeDate
        { get; set; }

        /// <summary>
        /// Версия.
        /// </summary>
        [DisplayName("Версия")]
        public virtual int? Version
        { get; set; }
    }
}