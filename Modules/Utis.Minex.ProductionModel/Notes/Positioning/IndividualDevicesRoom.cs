using Utis.Minex.Common;
using Utis.Minex.ProductionModel.MineSpace.MineModel;

namespace Utis.Minex.ProductionModel.Positioning
{
    /// <summary>
    /// Ламповая.
    /// </summary>
    [DisplayName("Ламповая")]
    public class IndividualDevicesRoom : CatalogBase
    {
        /// <summary>
        /// Номер ламповой.
        /// </summary>
        [DisplayName("Номер ламповой")]
        public virtual int Number
        { get; set; }

        /// <summary>
        /// Принадлежность к руднику.
        /// </summary>
        [DisplayName("Рудник")]
        public virtual Mine Mine 
        { get; set; }

        /// <summary>
        /// Управление подотчётными светильниками
        /// </summary>
        [DisplayName("Управление подотчётными светильниками")]
        public bool IsOwnerRoomLampControl 
        { get; set; }
    }
}