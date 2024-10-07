namespace Utis.Minex.Common
{
    #region Using
    using System;
    using Utis.Minex.Common.Enum;
    #endregion Using

    /// <summary>Интерфейс управления перемещениями объектов</summary>
    public interface IMovementManager
    {
        #region Methods
        /// <summary>Получение максимальной скорости человека или транспорта</summary>
        float GetMaxSpeed(bool isTransport);

        /// <summary>Проверка возможности прохождения расстояния за заданный промежуток времени</summary>
        bool IsValidSpeed(bool isTransport, DateTime previous, DateTime current, float distance);

        /// <summary>Получение скорости по расстоянию и временному промежутку</summary>
        float GetSpeed(DateTime dateTime1, DateTime dateTime2, float distance);
        #endregion Methods
    }
}
