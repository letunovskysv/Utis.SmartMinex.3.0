//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: DataService.IMetadata – Класс метаданных Системы, обеспечивает доступ к данным БД.
//--------------------------------------------------------------------------------------------------
#region Using
using System.Diagnostics;
using System.Text.RegularExpressions;
using Utis.SmartMinex.Helpers;
using Utis.SmartMinex.Runtime;
using static Dapper.SqlMapper;
#endregion Using

namespace Utis.SmartMinex.Data;

partial class Metadata
{
    /// <summary> Инициализация локального хранилища метаданных.</summary>
    void LoadMetadata()
    {    
        var sw = Stopwatch.StartNew();
        Helpers.TryAdd(TType.Helper, new EntityDataHelper(this)); // стартовый обработчик
        LoadMetadata(TType.Helper);
        LoadMetadata(TType.Solution);

        _ = Objects.Select<TManifest>() ?? throw new Exception(STR.ManifestNotFound);
        Node = Select<TNode>(node => node.Active)?.FirstOrDefault();
        Runtime.Send(MSG.MetadataLoaded, ProcessId, 0, Node);

        sw.Stop();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("warn: " + string.Format(STR.LoadMetadata,sw.ElapsedMilliseconds));
        Console.ResetColor();
    }

    void LoadMetadata(long idParent) =>
        Select<ZObject>(z => z.Parent == idParent && z.Type != TType.Attribute && !z.Deleted)?.OrderBy(z => z.Id).ToList()
            .ForEach(z =>
            {
                var obj = ReadObject(z);
                if (obj != null)
                    LoadMetadata(obj.Id);
            });

    public TEntity? GetObject(long id)
    {
        var obj = Objects[id];
        if (obj == null
            && Select<ZObject>(o => o.Id == id).FirstOrDefault() is ZObject zobj
            && Helpers.TryGetValue(zobj.Type, out var helper))
        {
            obj = ReadObject(zobj);
        }
        return obj;
    }

    public T? GetObject<T>(long id) where T : TEntity => Objects[id] as T;

    public bool TryGetObject(object search, out TEntity entity)
    {
        if (search == null)
        {
            entity = default!;
            return false;
        }
        switch (search)
        {
            case long id:
                return (entity = Objects[id]) != null;

            case Type type:
                return (entity = Objects[type]) != null;

            default:
                entity = default!;
                var names = search.ToString().Split(['.']);
                long parent = -1;
                foreach (var name in names)
                {
                    if (entity is IAttribute ea && ea.Attributes.FirstOrDefault(a => a.Code.Equals(name, StringComparison.OrdinalIgnoreCase)) is TEntity attr)
                        entity = attr;
                    else
                        entity = Objects.FirstOrDefault(oi =>
                            (parent == -1 || oi.Parent == parent) &&
                            (oi.Code != null && oi.Code.Equals(name, StringComparison.OrdinalIgnoreCase) ||
                            oi.Source != null && Regex.IsMatch(oi.Source, @"\.*" + name + "$")));

                    if (entity == null) return false;
                    parent = entity.Id;
                }
                return true;
        }
    }

    public TEntity? Update(TEntity entity)
    {
        if (WriteObject(entity) is TEntity newobj)
        {
            Runtime.Send(MSG.ObjectModified, newobj.Id, 0, newobj);
            return newobj;
        }
        return null;
    }

    #region Helpers

    /// <summary> Загружает или обновляет объект.</summary>
    TEntity? ReadObject(ZObject info)
    {
        try
        {
            return Helpers.TryGetValue(info.Type, out var helper) && helper.Read(info) is TEntity obj
                    ? Objects.AddOrUpdate(obj)
                    : null;
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка при чтении типа: #" + info.Type, ex);
        }
    }

    public TEntity? WriteObject(TEntity entity)
    {
        if (Helpers.TryGetValue(entity.Type, out var helper))
            if (helper.Write(entity) is TEntity newobj)
                try
                {
                    return Objects.AddOrUpdate(newobj);
                }
                catch (Exception ex)
                {
                    throw new Exception("Ошибка при сохранении типа: #" + entity.Type, ex);
                }
            else throw new Exception("Неизвестная ошибка при сохранении типа: #" + entity.Type);

        throw new Exception("Не найден обработчик типа: #" + entity.Type);
    }

    #endregion Helpers
}