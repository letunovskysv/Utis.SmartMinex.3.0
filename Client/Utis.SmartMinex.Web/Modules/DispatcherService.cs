//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: DispatcherService – Веб-служба диспетчеризации данных (DSP).
//--------------------------------------------------------------------------------------------------
#region Using
using Utis.SmartMinex.Runtime;
#endregion Using

namespace Utis.SmartMinex.Client;

public class DispatcherService : IDispatcher
{
    #region Declarations

    readonly IMetadata _md;
    readonly TManifest _manifest;

    #endregion Declarations

    #region Properties

    public string Name => _manifest.Name;
    public string Company => _manifest.Company;
    public string Version => _manifest.Version;

    public string Title => string.Concat(Name, " - ", Company, ", ", Version);
    public string Header => string.Concat(Name, " - ", "Начало работы");

    #endregion Properties

    public DispatcherService(IMetadata md)
    {
        _md = md;
        _manifest = _md.Objects.Select<TManifest>().First();
    }

    #region Authentification

    public async Task<UserAccount?> Authentificate(string username, string password) =>
        await Task.FromResult(new UserAccount() { Id = 1, Name = "Админситратор", Email = "lesev@mail.ru"});

    #endregion Authentification

    public bool TryGetObject(object search, out TEntity entity) => _md.TryGetObject(search, out entity);

    public List<T>? Select<T>(Func<T, bool> predicate) => _md.Objects.Where(predicate);

    public List<T>? Select<T>()
    {
        if (typeof(T).IsAssignableTo(typeof(TEntity)))
            return _md.Objects.Select<T>();

        return null;
    }

    public TEntity? Update(TEntity? entity)
    {
        if (entity == null) return null;
        return _md.Update(entity);
    }

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
