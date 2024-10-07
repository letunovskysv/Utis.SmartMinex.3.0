namespace Utis.Minex.Common
{
    /// <summary>
    /// Активатор модулей.
    /// </summary>
    public interface IInstantiateModules
    {
        /// <summary>
        /// Запустить все модули системы.
        /// </summary>
        void Run();

        /// <summary>
        /// Остановить все модули системы.
        /// </summary>
        void Stop();
    }
}