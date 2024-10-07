//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: DialogExtensions – Расширения методов для независимых окон.
//--------------------------------------------------------------------------------------------------
#region Using
using System.Data;
using Radzen;
using Utis.SmartMinex.Runtime;
#endregion Using

namespace Utis.SmartMinex.Client;

public static class DialogExtensions
{
    /// <summary> Открыть форму выдачи светильнка сотруднику.</summary>
    public static async Task OpenFindPersonForm(this DialogService service, LampAction action)
    {
        //await service.OpenAsync<FindPersonDialog>(TResources.FindPersonTitle,
        //    new Dictionary<string, object>() { { "Next", action } },
        //    new DialogOptions() { Width = "700px", Left = "300px", Top = "100px", Draggable = true });
    }

    /// <summary> Открыть форму выдачи светильнка сотруднику.</summary>
    public static async Task OpenTakeLampForm(this DialogService service, TObject target, DataRow row)
    {
        if (row != null)
            await OpenTakeLampForm(service, target, row["person_id"] as long?, row["lamp_id"] as long?);
    }

    /// <summary> Открыть форму выдачи светильнка сотруднику.</summary>
    public static async Task OpenTakeLampForm(this DialogService service, TObject target, long? idPerson, long? idLamp)
    {
        //await service.OpenAsync<TakeLampDialog>(TResources.TakeLampTitle,
        //    new Dictionary<string, object?>() { { "Type", target.Id }, { "Person", idPerson }, { "Lamp", idLamp } },
        //    new DialogOptions() { Width = "700px", Left = "300px", Top = "100px", Draggable = true });
    }

    /// <summary> Открыть форму сдачи светильнка сотрудником.</summary>
    public static async Task OpenBackLampForm(this DialogService service, TObject target, DataRow row)
    {
        if (row != null)
            await OpenBackLampForm(service, target, row["person_id"] as long?, row["lamp_id"] as long?);
    }

    /// <summary> Открыть форму сдачи светильнка сотрудником.</summary>
    public static async Task OpenBackLampForm(this DialogService service, TObject target, long? idPerson, long? idLamp)
    {
        //await service.OpenAsync<BackLampDialog>(TResources.GiveLampTitle,
        //    new Dictionary<string, object?>() { { "Type", target.Id }, { "Person", idPerson }, { "Lamp", idLamp } },
        //    new DialogOptions() { Width = "700px", Left = "300px", Top = "100px", Draggable = true });
    }

    ///// <summary> Получить идентификатор пользовательской сессии.</summary>
    //public static int GetSessionId(this Task<AuthenticationState>? state) =>
    //    int.TryParse(state?.Result.User.Claims.FirstOrDefault(a => a.Type == "sid")?.Value, out int sid) ? sid : 0;

    ///// <summary> Получить идентификатор пользовательской сессии.</summary>
    //public static string? GetLabel(this Task<AuthenticationState>? state) =>
    //    ((System.Security.Claims.ClaimsIdentity)state.Result.User.Identity).Label;
}

/// <summary> Операции над светильнками.</summary>
public enum LampAction
{
    /// <summary> Не опредедена.</summary>
    None,
    /// <summary> Получить.</summary>
    Take,
    /// <summary> Сдать.</summary>
    Back,
    /// <summary> Утерян.</summary>
    Lost
}
