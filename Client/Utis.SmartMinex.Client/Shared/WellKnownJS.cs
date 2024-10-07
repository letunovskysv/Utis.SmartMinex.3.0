//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: WellKnownJS – Наименование используемых функций JavaScript. Константы.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Client;

public static class WellKnownJS
{
    public static readonly string GetCookie = "getCookie";
    public static readonly string SetCookie = "setCookie";
    public static readonly string DropCookie = "dropCookie";

    /// <summary> Операция с локальным хранилищем браузера. Установить значение.</summary>
    public static readonly string SetSessionItem = "sessionStorage.setItem";
    /// <summary> Операция с локальным хранилищем браузера. Получить значение.</summary>
    public static readonly string GetSessionItem = "sessionStorage.getItem";
    /// <summary> Операция с локальным хранилищем браузера. Удалить значение.</summary>
    public static readonly string RemoveSessionItem = "sessionStorage.removeItem";
    /// <summary> Операция с локальным хранилищем браузера. Удалить всё.</summary>
    public static readonly string ClearSession = "sessionStorage.clear";

    /// <summary> Операция с локальным хранилищем браузера. Установить значение.</summary>
    public static readonly string SetLocalItem = "localStorage.setItem";
    /// <summary> Операция с локальным хранилищем браузера. Получить значение.</summary>
    public static readonly string GetLocalItem = "localStorage.getItem";
    /// <summary> Операция с локальным хранилищем браузера. Удалить значение.</summary>
    public static readonly string RemoveLocalItem = "localStorage.removeItem";
    /// <summary> Операция с локальным хранилищем браузера. Удалить всё.</summary>
    public static readonly string ClearLocal = "localStorage.clear";

    #region Custom function

    /// <summary> Выгрузка файла из байтового потока с Веб-сервера.</summary>
    public const string DownloadStream = "downloadStream";

    #endregion Custom function
}
