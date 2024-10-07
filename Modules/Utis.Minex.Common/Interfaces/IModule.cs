namespace Utis.Minex.Common.Interfaces
{
    /// <summary>
    /// Представляет интерфейс для реализации модуля сервера.
    /// </summary>
    public interface IModule
    {
        /// <summary>
        /// Наименование модуля.
        /// </summary>
        string Name { get; }
    }
}