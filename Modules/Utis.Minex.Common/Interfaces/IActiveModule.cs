namespace Utis.Minex.Common.Interfaces
{
    /// <summary>
    /// Представляет интерфейс для реализации модуля сервера,
    /// имеющий возможность запуска/останова работы
    /// </summary>
    public interface IActiveModule : IModule
    {
        /// <summary>
        /// Порядок запуска модуля.
        /// </summary>
        int Order { get; }

        /// <summary>
        /// Запуск модуля.
        /// </summary>
        void Start();

        /// <summary>
        /// Остановка модуля.
        /// </summary>
        void Stop();
    }
}