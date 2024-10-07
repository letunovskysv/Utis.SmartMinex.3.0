//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TOptions – Поле JSON дополнительных (расширенных) свойств объекта (оборудования).
//--------------------------------------------------------------------------------------------------
#region Using
using System.Text;
#endregion Using

namespace Utis.SmartMinex.Runtime;

/// <summary> Поле дополнительных свойств объекта, расширение.</summary>
public class TOptions : Dictionary<string, object?>
{
    readonly Dictionary<string, object?> _defaults = [];

    /// <summary> Возвращает дополнительное свойство.</summary>
    public T? Get<T>(string name) =>
        ContainsKey(name)
            ? this[name] is T val ? val
                : typeof(T) == typeof(int?) ? int.Parse(this[name].ToString()) is T @int ? @int : default! : default!
            : default!;

    /// <summary> Возвращает дополнительное свойство.</summary>
    public T? Get<T>(string name, object defaultValue, bool ignoreDefault = false)
    {
        if (!ignoreDefault && !_defaults.ContainsKey(name))
            _defaults.Add(name, defaultValue);

        return ContainsKey(name)
             ? this[name] is T val ? val
                : typeof(T) == typeof(int?) ? int.Parse(this[name].ToString()) is T @int ? @int : (T)defaultValue : (T)defaultValue
            : (T)defaultValue;
    }

    public new object? this[string name]
    {
        get => ContainsKey(name) ? base[name] : null;
        set
        {
            if (ContainsKey(name))
                base[name] = value;
            else
                Add(name, value);
        }
    }

    public override string ToString()
    {
        var res = new StringBuilder("{");
        string comma = string.Empty;
        foreach (var item in this)
            if (item.Value != null)
                if (!_defaults.ContainsKey(item.Key) || _defaults[item.Key] == null || !_defaults[item.Key].Equals(item.Value))
                {
                    res.Append(comma).Append('"').Append(item.Key).Append("\":");
                    if (item.Value is bool @bool)
                        res.Append(@bool ? "true" : "false");
                    else if (item.Value is int @int)
                        res.Append(@int);
                    else if (item.Value is long @long)
                        res.Append(@long);
                    //else if (Attribute.IsDefined(item.Value.GetType(), typeof(JsonObjectAttribute)))
                    //    res.Append(JsonConvert.SerializeObject(item.Value));
                    else if (item.Value != null)
                        res.Append('"').Append(item.Value.ToString()).Append('"');

                    comma = ",";
                }

        return res.Append('}').ToString();
    }
}
