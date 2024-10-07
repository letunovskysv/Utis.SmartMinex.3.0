//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: DispatcherClient – Веб-служба диспетчеризации данных (DSP) в случае автономного
// сервиса.
//--------------------------------------------------------------------------------------------------
#region Using
using System;
using Utis.SmartMinex.Runtime;
#endregion Using

namespace Utis.SmartMinex.Client;

public class DispatcherClient : IDispatcher
{
    #region Properties

    public string Name { get; set; } = "АРМ «Горный Диспетчер»";
    public string Company { get; set; } = "УралТехИС";
    public string Version { get; } = typeof(WebApp).Assembly.GetName().Version.ToString();
    public string Title => string.Concat(Name, " - ", Company, ", ", Version);
    public string Header => string.Concat(Name, " - ", "Начало работы");

    #endregion Properties

    #region Authentification

    public async Task<UserAccount?> Authentificate(string username, string password) =>
        await Task.FromResult(new UserAccount() { Id = 1, Name = "Админситратор", Email = "lesev@mail.ru"});

    #endregion Authentification

    public bool TryGetObject(object search, out TEntity entity) => throw new NotImplementedException();
    public List<T>? Select<T>(Func<T, bool> predicate) => throw new NotImplementedException();
    public List<T> Select<T>() => throw new NotImplementedException();
    public TEntity? Update(TEntity? entity) => throw new NotImplementedException();

    #region Старший ламповщик

    /// <summary> Выданные/используемые светильники всего.</summary>
    public int BusyLamps { get; set; }
    /// <summary> Свободные светильники.</summary>
    public int FreeLamps { get; set; }
    /// <summary> Выданные/используемые светильники за смену.</summary>
    public int TakeLampsShift { get; set; }
    /// <summary> Сдано светильников за смену.</summary>
    public int BackLampsShift { get; set; }

    #endregion Старший ламповщик
}
