//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: WellKnownJS – Наименование используемых функций JavaScript. Константы.
//--------------------------------------------------------------------------------------------------
public static class WellKnownJS
{
    /// <summary> Регистрация формы для обратного вызова методов .NET.</summary>
    /// <remarks> После вызова функции, вызов метода выполняется через JS-функцию invokeAsync(methodName, p1, ...)<br/>Вызываемый метод должен быть отмечен атрибутом [JSInvokable]</remarks>
    public const string RegistrySelf = "initDN";

    /// <summary> Регистраци события обратного вызова по клику мыши.</summary>
    /// <remarks> Используем чтобы закрыть контекстное меню по клику в области окна.</remarks>
    public const string RaiseWindowClick = "raiseWindowClick";

    /// <summary> Сброс регистраци события обратного вызова по клику мыши.</summary>
    public const string ResetWindowClick = "resetWindowClick";

    /// <summary> Выгрузка файла из байтового потока с Веб-сервера.</summary>
    public const string DownloadStream = "downloadStream";
}
