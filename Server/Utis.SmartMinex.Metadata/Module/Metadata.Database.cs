//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: DataService.Database – Класс метаданных Системы, обеспечивает доступ к данным БД.
//--------------------------------------------------------------------------------------------------
#region Using
using System;
using System.Data;
using System.Linq.Expressions;
using Utis.SmartMinex.Runtime;
#endregion Using

namespace Utis.SmartMinex.Data;

partial class Metadata
{
    /// <summary> Корректировка базы данных.</summary>
    private void AmendDatabase()
    {
        using var fs = new FileStream(_dbinitfile, FileMode.Open);
        CreateFactorySuite().Amend(fs);
    }

    private IDatabase CreateDatabase() =>
        _dbcreator.Invoke([_connstr]) as IDatabase
        ?? throw new Exception(STR.FailedCreateDatabaseConnection);

    private IDatabase CreateDatabase(string databaseName) =>
        _dbcreator.Invoke([_connstr.Replace(_dbname, databaseName)]) as IDatabase
        ?? throw new Exception(STR.FailedCreateDatabaseConnection);

    private IFactorySuite CreateFactorySuite(IMetadata md, IDatabase db) =>
        _fscreator.Invoke([md, db]) as IFactorySuite
        ?? throw new Exception(STR.FailedCreateFactorySuite);

    public IFactorySuite CreateFactorySuite() => CreateFactorySuite(this, CreateDatabase().Open());

    public T UseDatabase<T>(Func<IFactorySuite, T>? func)
    {
        if (func == null) return default!;
        using var fs = this.SuppressException(() => CreateFactorySuite());
        try
        {
            return func.Invoke(fs);
        }
        catch (Exception ex)
        {
            Runtime.Send(MSG.ErrorMessage, ProcessId, 0, ex);
        }
        return default!;
    }

    public void UseDatabase(Action<IFactorySuite?>? func)
    {
        if (func == null) return;
        using var fs = this.SuppressException(() => CreateFactorySuite());
        try
        {
            func.Invoke(fs);
        }
        catch (Exception ex)
        {
            Runtime.Send(MSG.ErrorMessage, ProcessId, 0, ex);
        }
    }

    #region IEnumerable Results

    public IEnumerable<T>? Select<T>(Expression<Func<T, bool>>? predicate) =>
        UseDatabase(fs => fs.Database.Select(predicate));

    public IEnumerable<TItem>? Select<TItem>() =>
        UseDatabase(fs => fs.Database.Select<TItem>());

    public IEnumerable<object?>? Select(Type type, string? where, string? order) => UseDatabase<IEnumerable<object?>?>(fs =>
    {
        if (TryGetObject(type, out var oi) && oi is TObject obj)
        {
            if (obj.Factory.IsExternal)
                return fs.Use(CreateDatabase(obj.Factory.Database).Open()).Select(obj.Model).Where(where).Order(order).Build().RunAsEnumerable();
            else
                return fs.Select(obj.Model).Where(where).Order(order).Build().RunAsEnumerable();
        }
        return null;
    });

    #endregion IEnumerable Results

    #region DataTable Results

    public DataTable? Select(long id, string? where, string? order) =>
        Select(TryGetObject(id, out var ent) && ent is TObject obj ? obj : throw new Exception(string.Format(STR.ObjectByIdentityNotFound, id)),
            where, order);

    public DataTable? Select(string name, string? where, string? order) =>
        Select(TryGetObject(name, out var ent) && ent is TObject obj ? obj : throw new Exception(string.Format(STR.ObjectByIdentityNotFound, name)),
            where, order);

    public DataTable? Select(TObject obj, string? where, string? order) => UseDatabase(fs =>
    {
        if (obj.Factory.IsExternal)
            return fs.Use(CreateDatabase(obj.Factory.Database).Open()).Select(obj).Where(where).Order(order).Build().Run();
        else
            return fs.Select(obj).Where(where).Order(order).Build().Run();
    });

    public string? Query(object uid, string? where, string? order) => UseDatabase(fs =>
    {
        if (uid is TObject obj)
            return fs.Select(obj).Where(where).Order(order).Build().ToString();

        else if (uid is Type type)
            return fs.Select(type).Where(where).Order(order).Build().ToString();

        return default!;
    });

    #endregion DataTable Results
}