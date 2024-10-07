
namespace Utis.Minex.ProductionModel.Register.Dimension.Movement
{
    #region Using
    
    using Utis.Minex.Common;
    using Utis.Minex.ProductionModel.Devices;

        #endregion

    /// <summary>
    /// Срез регистра событий регистраций персонала.
    /// </summary>
    [DisplayName("Срез регистраций персонала")]
    [Description("Срез регистра событий регистраций персонала")]
    public class PersonMovementRDimension : RDimensionBase
    {
        /// <summary>
        /// Индивидуальное устройство.
        /// </summary>
        [DisplayName("Устройство")]
        public virtual IndividualDevice IndividualDevice 
        { get; set; }
    }
}