
namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Формат номера персональной карты.
    /// </summary>
    /// <remarks>поддерживаемые форматы номеров (Z-2 USB: http://www.safemag.ru/z-2-usb/)</remarks>
    [DisplayName("Формат номера персональной карты")]
    public enum PersonalCardHandlerType
    {
        /// <summary>
        /// Запись в чистом виде, например UID карты NXP Mifare.
        /// </summary>
        [DisplayName("Запись в чистом виде, например UID карты NXP Mifare")]
        Plain = 0,

        /// <summary>
        /// получение номеров ключей от считывателей, подключенных по линиям Dallas TM и Wiegand 26.
        /// </summary>
        [DisplayName("получение номеров ключей от считывателей, подключенных по линиям Dallas TM и Wiegand 26;")]
        [Description("DS1996L; http://www.safemag.ru/z-2-base/")]
        Z2base = 1,

        /// <summary>
        /// Читает только карты 13,56 МГц: Mifare. Версия 124-13,56 МГц.
        /// </summary>
        [DisplayName("Читает только карты 13,56 МГц: Mifare. Версия 124-13,56 МГц.")]
        Z2usb_mf = 2,

        /// <summary>
        /// Поддержка 7-байтных карт Mifare. Версия 110.
        /// </summary>
        [DisplayName("Поддержка 7-байтных карт Mifare. Версия 110")]
        Z2usb_110 = 3,

        /// <summary>
        /// Читает только карты 125 кГц: EM-Marin и HID. Версия 124-125 кГц.
        /// </summary>
        [DisplayName("Читает только карты 125 кГц: EM-Marin и HID. Версия 124-125 кГц")]
        Z2usb_125kHz = 4,

        /// <summary>
        /// Вывод номера карт в формате 5 байт. Перевод на новую строку. Версия 128.
        /// </summary>
        [DisplayName("Вывод номера карт в формате 5 байт. Перевод на новую строку. Версия 128.")]
        Z2usb_v128 = 5,

        /// <summary>
        /// Не выводит сообщение «NO CARD» во второй строке сообщения. Версия: nocard.
        /// </summary>
        [DisplayName("Не выводит сообщение «NO CARD» во второй строке сообщения. Версия: nocard.")]
        Z2usb_nocard = 6,

        /// <summary>
        /// конвертер, Поддержка сетевых контроллеров Z-5R Net и Martix-II Net.
        /// </summary>
        [DisplayName("конвертер, Поддержка сетевых контроллеров Z-5R Net и Martix-II Net")]
        [Description("http://www.safemag.ru/z-397-guard/")]
        Z397_guard = 7,
    }
}