//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: IDispatcher – Интерфейс Веб-службы диспетчеризации данных (DSP).
//--------------------------------------------------------------------------------------------------
using Utis.SmartMinex.Runtime;

namespace Utis.SmartMinex.Client;

public interface IDispatcher
{
    string Name { get; }
    string Company { get; }
    string Version { get; }

    string Title { get; }
    string Header { get; }

    Task<UserAccount?> Authentificate(string username, string password);

    bool TryGetObject(object search, out TEntity entity);
    List<T>? Select<T>(Func<T, bool> predicate);
    List<T> Select<T>();

    /// <summary> Обновление объекта конфигурации в базе данных.</summary>
    TEntity? Update(TEntity? entity);

    #region Старший ламповщик

    /// <summary> Выданные/используемые светильники всего.</summary>
    int BusyLamps { get; set; }
    /// <summary> Свободные светильники.</summary>
    int FreeLamps { get; set; }
    /// <summary> Выданные/используемые светильники за смену.</summary>
    int TakeLampsShift { get; set; }
    /// <summary> Сдано светильников за смену.</summary>
    int BackLampsShift { get; set; }

    #endregion Старший ламповщик
}
