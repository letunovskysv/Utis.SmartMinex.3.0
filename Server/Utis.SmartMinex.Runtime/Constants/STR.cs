//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: STR – Различные строковые константы, текст.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Runtime;

/// <summary> Различные строковые константы, текст.</summary>
public static class STR
{
    public const string InitDatabase = "Инициализация базы данных {0}.";
    public const string AmendDatabase = "Корректировка базы данных {0}, {1} мс.";
    public const string LoadMetadata = "Загрузка метаданных, {0} мс.";
    public const string ManifestNotFound = "Не найден манифест конфигурации.";

    public const string TerminalMessageOutputON = "Вывод сообщений продолжен!";
    public const string TerminalMessageOutputOFF = "Вывод сообщений остановлен!";

    public const string FailedCreateDatabaseConnection = "Невозможно создать подключение к БД.";
    public const string FailedCreateFactorySuite = "Невозможно создать построитель инструкций БД.";
    public const string FailedReadDatabaseInitFile = "Невозможно прочитать файл инициализации базы данных «{0}».";
    public const string DataHelperByTypeNotFound = "Не найден обработчик типа метаданных #{0}.";
    public const string ObjectByIdentityNotFound = "Объект «{0}» не найден!";

    public const string FailedInsertDbBasedOfType = "Невозможно внести изменения в БД на основании данного типа.";
}