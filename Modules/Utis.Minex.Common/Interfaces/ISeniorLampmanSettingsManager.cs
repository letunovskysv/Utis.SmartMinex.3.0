
namespace Utis.Minex.Common.Settings
{
    using Utis.Minex.Common.Interfaces;

    public interface ISeniorLampmanSettingsManager : IGrpcSettings, ISslClientSettings, IUserThresholdSettings, IDBServicesSettings
    {
        /// <summary>
        /// Показывать и валидировать даты приема и увольнения.
        /// </summary>
        bool ShowPersonHireAndFire
        { get; set; }

        /// <summary>
        /// Удостоверяться, что номер светильника, номер метки и номер радиоблока одинаковы.
        /// </summary>
        bool EnsureEqual_LampNumber_RFID_RFUnitNumber
        { get; set; }

        /// <summary>
        /// Разрешить редактирование номера светильника и метки после создания светильника.
        /// </summary>
        bool AllowEditLampNumberAndRFID
        { get; set; }
    }
}