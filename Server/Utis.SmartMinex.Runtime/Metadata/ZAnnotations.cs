//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: Annotations – Атрибуты объектов конфигурации (метаданных) в базе данных.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Runtime;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class ZTableAttribute(string name) : Attribute
{
    public string Name { get; } = name;
}
