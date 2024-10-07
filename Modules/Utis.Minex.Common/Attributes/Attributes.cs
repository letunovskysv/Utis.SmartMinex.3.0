using System;

namespace Utis.Minex.Common
{
    using System.Collections;
    using System.Collections.Generic;
    using Utis.Minex.Common.Enum;

    /// <summary>
    /// Атрибут настроек
    /// </summary>
    public sealed class SettingAttribute : Attribute
    {
        /// <summary>
        /// Значение по умолчанию
        /// </summary>
        public string DefalutValue { get; }

        public string MinValue { get; }

        public string MaxValue { get; } 

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="defalutValue">Значение по умолчанию</param>
        public SettingAttribute(string defalutValue, string minValue = "", string maxValue = "") : base()
        {
            DefalutValue = defalutValue;
            MinValue = minValue;
            MaxValue = maxValue;
        }
    }

    /// <summary>
    /// Атрибут запрета выбора определённых типов опасных зон для пользователя
    /// </summary>
    [System.AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = false)]
    public sealed class CanSelectDangerousZoneTypeAttribute : Attribute
    {
        public bool CanSelect { get; }

        public CanSelectDangerousZoneTypeAttribute(bool canSelect)
        {
            CanSelect = canSelect;
        }
    }

    /// <summary>
    /// Атрибут отображаемого наименования
    /// </summary>
    [System.AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = false)]
    public sealed class DisplayNameAttribute : System.ComponentModel.DisplayNameAttribute
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="displayName">Наименование</param>
        public DisplayNameAttribute(string displayName) : base(displayName) { }
    }

    /// <summary>
    /// Атрибут квитируемого события
    /// </summary>
    [System.AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = false)]
    public sealed class AckableAttribute : Attribute
    { 
    }

    /// <summary>
    /// Атрибут ленивой загрузки ссылки
    /// </summary>
    [System.AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = false)]
    public sealed class LazyLoadingAttribute : Attribute
    {
        /// <summary>
        /// Использовать ли ленивую загрузку ссылки
        /// </summary>
        public bool LazyLoading { get; private set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="lazyLoading">Наименование</param>
        public LazyLoadingAttribute(bool lazyLoading)
        {
            LazyLoading = lazyLoading;
        }
    }

    /// <summary>
    /// Атрибут описания
    /// </summary>
    [System.AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = false)]
    public sealed class DescriptionAttribute : System.ComponentModel.DescriptionAttribute
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="description">Описание</param>
        public DescriptionAttribute(string description) : base(description) { }
    }

    /// <summary>
    /// Атрибут уникального ключа
    /// </summary>
    [System.AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class UniqueKeyAttribute : Attribute
    {
        /// <summary>
        /// Наименование ключа
        /// </summary>
        public readonly string UniqueKeyName;

        /// <summary>
        /// Конструктор
        /// </summary>
        public UniqueKeyAttribute()
        {

        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="uniqueKeyName">Наменование ключа</param>
        public UniqueKeyAttribute(string uniqueKeyName) : base()
        {
            UniqueKeyName = uniqueKeyName;
        }
    }

    /// <summary>
    /// Атрибут изображения
    /// </summary>
    [System.AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class ImageAttribute : Attribute
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public ImageAttribute()
        {
            return;
        }
    }

    /// <summary>
    /// Генерация колонок на клиенте
    /// </summary>
    [System.AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class ColumnGenerateAttribute : Attribute
    {
        /// <summary>
        /// Игнорировать колонку (см. ColumnHelper.GenerateColumns)
        /// </summary>
        public bool IgnoreGenerate { get; set; }

        public ColumnGenerateAttribute(bool ignoreGenerate = false)
        {
            IgnoreGenerate = ignoreGenerate;
        }
    }

    /// <summary>
    /// Metadata dynamicproxy
    /// </summary>
    [System.AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class MetaPropertyAttribute : Attribute
    {
        /// <summary>
        /// Игнорировать свойство и не добалять его в список свойств(TypeMetadata)
        /// </summary>
        /// <remarks>на основе TypeMetadata.Properties генерятся колонки и поля для редактирования при редактировании в TableForm</remarks>
        public bool IgnoreProperty { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="ignoreProperty">проигнорировать свойство во время генерации колонок</param>
        public MetaPropertyAttribute(bool ignoreProperty = false)
        {
            IgnoreProperty = ignoreProperty;
        }
    }

    /// <summary>
    /// Добавление в модель Protobuff
    /// </summary>
    [System.AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class UsedInProtobuff : Attribute
    {
        /// <summary>
        /// Игнорировать колонку при сереализации/десериализации
        /// </summary>
        public bool UseInProtobuff { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="usedInProtobuff">сериализация по protobuf</param>
        public UsedInProtobuff(bool usedInProtobuff = false)
        {
            UseInProtobuff = usedInProtobuff;
        }
    }

    /// <summary>
    /// Атрибут ширины колонки свойства в таблицах
    /// </summary>
    [System.AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class ColumnWidthAttribute : Attribute
    {
        /// <summary>
        /// Ширина колонки
        /// </summary>
        public double Width { get; set; }

        /// <summary>
        /// Тип ширины
        /// </summary>
        public GridUnitType Type { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="width">Ширина колонки в талицах что будет содержать это свойство</param>
        /// <param name="type"></param>
        public ColumnWidthAttribute(double width = 1, GridUnitType type = GridUnitType.Star)
        {
            Width = width;
            Type = type;
        }
    }

    /// <summary>
    /// Атрибут разрешения/запрета выбора значение в каталоге
    /// </summary>
    public sealed class EnumDetailEditable : Attribute
    {
        /// <summary>
        /// Разрешение выбора значение в каталоге
        /// </summary>
        public bool Editable { get; set; }

        /// <param name="editable">разрешение выбора значение в каталоге</param>
        public EnumDetailEditable(bool editable)
        {
            Editable = editable;
        }
    }

    /// <summary>
    /// Атрибут маппинга из DTO в DBO и обратно
    /// </summary>
    public sealed class AlwaysMapAttribute : Attribute
    {
        /// <summary>
        /// Маппить во всех типах маппингов(с RefObject и без)
        /// </summary>
        public readonly bool AlwaysMap;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="alwaysMap">Маппить во всех типах маппингов(с RefObject и без)</param>
        public AlwaysMapAttribute(bool alwaysMap) : base()
        {
            AlwaysMap = alwaysMap;
        }
    }

    /// <summary>
    /// Публикация и подписка не на одиночные события, а на списки
    /// </summary>
    public sealed class PubSubDAEventIEnumerableAttribute : Attribute
    {

    }

    /// <summary>
    /// Атрибут, обозначающий, что необходимо регистрировать изменения класса
    /// </summary>
    public sealed class RegisterChangesAttribute : Attribute
    {
        /// <summary>
        /// Нужно регистрировать
        /// </summary>
        public bool NeedRegister { get; set; } = false;

        /// <summary>
        /// Регистрировать ли изменения этого класса (см ChangesJournalRegistrator)
        /// </summary>
        /// <param name="needRegister">Регистрировать изменения в классе?</param>
        public RegisterChangesAttribute(bool needRegister)
        {
            NeedRegister = needRegister;
        }
    }

    /// <summary>
    /// Атрибут, обозначающий, что необходимо игнорировать пропертю при регистрации изменений
    /// </summary>
    public sealed class RegisterChangesIgnoreAttribute : Attribute
    {
        /// <summary>
        /// Нужно игнорировать при регистрации изменений
        /// </summary>
        public bool Ignore { get; set; }

        /// <param name="ignore">Игнорировать</param>
        public RegisterChangesIgnoreAttribute(bool ignore)
        {
            Ignore = ignore;
        }
    }

    /// <summary>
    /// Атрибут, обозначающий, что необходимо регистрировать пропертю при создании объекта
    /// </summary>
    public sealed class RegisterChangesOnCreateAttribute : Attribute
    {
        /// <summary>
        /// Нужно регистрировать при создании
        /// </summary>
        public bool NeedRegister { get; set; } = false;

        /// <param name="needRegister">Игнорировать</param>
        public RegisterChangesOnCreateAttribute(bool needRegister)
        {
            NeedRegister = needRegister;
        }
    }

    /// <summary>
    /// Атрибут для указания режима отображения пропертей типа DateTime
    /// </summary>
    public sealed class DateTimeDisplayModeAttribute : Attribute
    {
        public enum DateTimeDisplayMode
        {
            DateTime,
            Time,
            Date
        }
        /// <summary>
        /// Нужно регистрировать при создании
        /// </summary>

        public DateTimeDisplayMode DisplayMode { get; set; } = DateTimeDisplayMode.DateTime;
        public DateTimeDisplayModeAttribute(DateTimeDisplayMode mode)
        {
            DisplayMode = mode;
        }
    }

    /// <summary>
    /// Атрибут доступности
    /// </summary>
    [System.AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = false)]
    public sealed class EnabledAttribute : Attribute
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="description">Описание</param>
        public EnabledAttribute(bool enabled, bool debugEnabled = true)  
        {
            Enabled = enabled;
            DebugEnabled = debugEnabled;
        }

        public bool Enabled { get; set; } = true;
        public bool DebugEnabled { get; set; } = true;
    }

    /// <summary>
    /// Атрибут группировки
    /// </summary>
    [System.AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = false)]
    public sealed class GroupPathAttribute : Attribute
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="description">Описание</param>
        public GroupPathAttribute(string groupPath)
        {
           _groupPath = groupPath;
        }

        private string _groupPath = "";

        public IEnumerable<string> Grouping
        {
            get
            {
                List<string> result = new();
                foreach(string group in _groupPath.Split(';'))
                {
                    result.Add(group);
                }
                return result;
            }
        }
    }

    /// <summary>
    /// Атрибут для DTO типов запрещающий изменение сущности на стороне клиентов СП
    /// </summary>
    [System.AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class ClientReadOnlyAttribute : Attribute
    {

    } 
}
