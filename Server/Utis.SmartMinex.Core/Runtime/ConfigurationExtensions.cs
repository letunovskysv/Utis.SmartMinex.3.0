//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: ConfigurationExtensions –
//--------------------------------------------------------------------------------------------------
#region Using
using Microsoft.Extensions.Configuration;
using Utis.SmartMinex.Data;
#endregion Using

namespace Utis.SmartMinex.Runtime;

public static class ConfigurationExtensions
{
    public static string? GetValue(this IConfiguration config, string paramName) =>
        config.GetSection("runtimeOptions:" + paramName)?.Value;

    public static TModule? GetRuntime(this IConfiguration config)
    {
        var rtm = config.GetSection("runtimeOptions:runtime")?.GetChildren();
        if (rtm == null || !rtm.Any()) return default!;

        return rtm.Select(ri => ReadModuleParameters(ri, 0, 0, null)).FirstOrDefault(ri => ri.Start == RuntimeStartMode.Auto);
    }

    public static List<TModule> GetModules(this IConfiguration config, string? workDirectory)
    {
        var modules = config.GetSection("runtimeOptions:modules")?.GetChildren();
        if (modules == null || !modules.Any()) return [];

        var id = TType.Module << 10 - 1;
        int npp = -modules.Count();
        var res = modules.Select(mi => ReadModuleParameters(mi, id--, npp++, workDirectory)).Where(mod => mod != null).ToList();
        int cnt = 2;
        res.ForEach(mod =>
        {
            if (res.OrderBy(m => m.Id).TakeWhile(m => m.Id < mod.Id).Any(m => m.Code == mod.Code))
            {
                mod.Code += cnt.ToString();
                mod.Name += " " + cnt++.ToString();
            }
        });
        return res;
    }

    static TModule ReadModuleParameters(IConfigurationSection section, long id, int ordinal, string? workDirectory)
    {
        var mod = new TModule()
        {
            Id = id,
            Parent = TType.Module,
            Type = TType.Module,
            Ordinal = ordinal
        };
        foreach (var prop in section.GetChildren())
        {
            switch (prop.Key.ToUpper())
            {
                case "START":
                    mod.Start = Enum.TryParse(typeof(RuntimeStartMode), prop.Value, true, out var start)
                        ? (RuntimeStartMode)start : RuntimeStartMode.None;

                    if (mod.Start == RuntimeStartMode.None || mod.Start == RuntimeStartMode.Disabled)
                        return default!;
                    break;

                case "NAME":
                    mod.Parameters.Add(prop.Key, mod.Name = prop.Value);
                    mod.Code = mod.Name.ToCamelString();
                    break;

                case "TYPE":
                    mod.ModuleType = prop?.Value.ToType(workDirectory);
                    break;

                default:
                    if (prop.Value == null)
                        mod.Parameters.Add(prop.Key, string.Concat('{',
                                string.Join(',', prop.GetChildren().Select(p => string.Concat('"', p.Key, "\":\"", p.Value?.Replace("\\", "\\\\"), '"'))),
                            '}'));
                    else
                        mod.Parameters.Add(prop.Key, prop.Value);
                    break;
            }
        }
        return mod;
    }
}
