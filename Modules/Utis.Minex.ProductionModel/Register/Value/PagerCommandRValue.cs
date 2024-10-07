
namespace Utis.Minex.ProductionModel.Register.Value
{
    #region Using
    
    using Utis.Minex.Common;
    using Utis.Minex.Common.Enum;
    
    using Utis.Minex.ProductionModel.CommandAndCalls;
    using Utis.Minex.ProductionModel.Register.Dimension;

        #endregion

    /// <summary>
    /// Значения регистра команд (сообщений) на пэйджер.
    /// </summary>
    [DisplayName("Значения регистра команд (сообщений) на пэйджер")]
    public class PagerCommandRValue : RValueBase<PagerCommandRDimension>
    {
        /// <summary>
        /// Команда передачи сообщения на пейджер.
        /// </summary>
        [DisplayName("Команда передачи сообщения на пейджер")]
        public virtual PagerSendCommand PagerSendCommand 
        { get; set; }

        /// <summary>
        /// Статус сообщения на пейджер.
        /// </summary>
        [DisplayName("Статус сообщения на пейджер")]
        public virtual PagerCommandState State
        {get;set;}
    }
}