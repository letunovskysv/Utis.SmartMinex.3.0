namespace Utis.Minex.Common.Settings
{
    public interface ISettingsManagerBase
    {
        #region ApplicationName

        /// <summary>
        /// Имя папки которая создастся по умолчанию в ProgramData.
        /// </summary>
        [DisplayName("Имя папки которая создастся по умолчанию в ProgramData")]
        string ApplicationName
        { get; }

        /// <summary>
        /// Префикс лог файлов
        /// </summary>
        [DisplayName("Префикс лог файлов")]
        string ApplicationLogPrefix
        { get; }

        #endregion

        #region LogFolders

        /// <summary>
        /// Путь к папке логирования.
        /// </summary>
        [DisplayName("Используемый файл настроек")]
        string SettingsPath
        { get; }

        /// <summary>
        /// Путь к папке логирования.
        /// </summary>
        [DisplayName("Путь к папке логирования")]
        string LogFolderPath
        { get; set; }

        /// <summary>
        /// Путь к папке сохранения архива логов.
        /// </summary>
        [DisplayName("Путь к папке сохранения архива логов")]
        string CollectLogFolderPath
        { get; set; }

        /// <summary>
        /// Путь к папке логирования исключений.
        /// </summary>
        [DisplayName("Путь к папке логирования исключений")]
        string CollectExceptionsLogFolderPath
        { get; set; }

        /// <summary>
        /// Путь к папке сохранения архива исключений.
        /// </summary>
        [DisplayName("Путь к папке сохранения архива исключений")]
        string ExceptionsLogFolderPath
        { get; set; }

        #endregion

        /// <summary>
        /// Флаг, что файл настроек некорректный и вместо него был создан дефолтный
        /// </summary>
        bool IsCreatedDefaultSettings { get; }

        void LoadSettings();

        void CreateOrUpdateSetttingsJson();
    }
}