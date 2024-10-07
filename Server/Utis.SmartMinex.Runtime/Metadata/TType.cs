// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TType – Типы объектов конфигурации.
//--------------------------------------------------------------------------------------------------
using System.ComponentModel;
using System.Reflection;

namespace Utis.SmartMinex.Runtime;

/// <summary> Типы объектов конфигурации.</summary>
public struct TType : IComparable
{
    #region Constants

    public const long Unknown = 0;

    /// <summary> Обработчик.</summary>
    public const long Helper = 1;
    /// <summary> Конфигурация.</summary>
    public const long Solution = 2;
    /// <summary> Манифест. Описание конфигурации.</summary>
    /// <remarks> Должен присутвовать единственный экземпляр.</remarks>
    public const long Manifest = 3;
    /// <summary> Папка.</summary>
    public const long Folder = 4;
    /// <summary> Компонент.</summary>
    public const long Component = 5;
    /// <summary> Приложение.</summary>
    public const long Application = 6;
    /// <summary> Модуль.</summary>
    public const long Module = 7;
    /// <summary> Реквизит.</summary>
    public const long Attribute = 8;
    /// <summary> Категория, группировка.</summary>
    public const long Group = 9;
    /// <summary> Табличная часть.</summary>
    public const long Details = 10;
    /// <summary> Измерение.</summary>
    public const long Dimension = 11;
    /// <summary> Простой тип.</summary>
    public const long Type = 12;
    /// <summary> Объект.</summary>
    public const long Object = 13;
    /// <summary> Меню.</summary>
    public const long Menu = 14;

    public const long Int32 = 130;
    public const long Int64 = 131;

    /// <summary> База дынных.</summary>
    public const long Database = 256;
    /// <summary> Константа.</summary>
    public const long Constant = 257;
    /// <summary> Перечисление.</summary>
    public const long Enum = 258;
    /// <summary> Справочник.</summary>
    [Description("Справочник")]
    public const long Catalog = 259;
    /// <summary> Документ.</summary>
    public const long Document = 260;
    /// <summary> Журнал.</summary>
    public const long Journal = 261;
    /// <summary> Регистр.</summary>
    public const long Register = 262;
    /// <summary> Учётный регистр.</summary>
    public const long Account = 263;
    /// <summary> Отчёт.</summary>
    public const long Report = 264;
    /// <summary> Тэг.</summary>
    public const long Tag = 265;

    /// <summary> Верхняя граница системных идентификаторов.</summary>
    public const long Bound = 1024;

    /// <summary> План-схема, карта.</summary>
    public const long Scheme = 266;
    /// <summary> План-схема, уровень, горизонт.</summary>
    public const long Level = 0x2000000400;
    /// <summary> План-схема, слой.</summary>
    public const long Layer = 0x2000000800;

    /// <summary> Итерация для пользовательских объектов конфигурации.</summary>
    public const long Iterator = 0x1000000000000; // 281474976710656

    #endregion Constants

    readonly long _value;

    TType(long type)
    {
        _value = type;
    }

    public static TType Parse(string name)
    {
        return new TType((long)(typeof(TType).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
            .FirstOrDefault(f => f.Name.StartsWith(name, StringComparison.InvariantCultureIgnoreCase))?.GetValue(null) ?? 0));
    }

    public static implicit operator TType(long t) => new TType(t);

    public static implicit operator long(TType t) => t._value;

    public static bool operator ==(TType left, long right) => left._value == right;

    public static bool operator !=(TType left, long right) => left._value != right;

    public static bool operator ==(TType left, TType right) => left._value == right._value;

    public static bool operator !=(TType left, TType right) => left._value != right._value;

    public override bool Equals(object obj) => this == (TType)obj;

    public override int GetHashCode() => HashCode.Combine(_value);

    public int CompareTo(object obj)
    {
        long value = ((TType)obj)._value;
        return _value < value ? -1 : _value == value ? 0 : 1;
    }

    public override string ToString()
    {
        long value = _value;
        return typeof(TType).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
            .FirstOrDefault(f => f.GetValue(null).Equals(value))?.Name
            ?? string.Concat("Unknow", _value);
    }
}
