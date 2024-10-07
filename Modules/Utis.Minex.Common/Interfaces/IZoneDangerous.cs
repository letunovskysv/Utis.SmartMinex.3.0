using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utis.Minex.Common.Enum;
using Utis.Minex.Common.Interfaces;

namespace Utis.Minex.Common
{
    /// <summary>
    /// Опасная зона
    /// </summary>
    [DisplayName("Тип опасной зоны")]
    public interface IZoneDangerous
    {
        /// <summary>
        /// Является ли измененным
        /// </summary>
        bool IsChanged { get; }

        /// <summary>
        /// Архивная (закрытая) зона
        /// </summary>
        bool IsArchive { get; }

        /// <summary>
        /// Активность опасной зоны
        /// </summary>
        [DisplayName("Активность опасной зоны")]
        ZoneDangerousEventType ActiveStatus { get; }


        /// <summary>
        /// Тип опасной зоны
        /// </summary>
        [DisplayName("Тип опасной зоны")]
        DangerousZoneType Type { get; }

        /// <summary>
        /// Наименование
        /// </summary>
        [DisplayName("Наименование")]
        string Name { get; }

        /// <summary>
        /// Проверить статус
        /// </summary>
        /// <returns></returns>
        IZoneDangerousCheckResult CheckStatus(DamageDevicesCache cache = null);

        /// <summary>
        /// Проверка допустимости перемещения сотрудника
        /// </summary>
        /// <param name="accessPerson"></param>
        /// <returns></returns>
        bool IsTryMovePerson(IPerson accessPerson, ZoneEventType typeMove);


        /// <summary>
        /// Проверка допустимости перемещения транспорта
        /// </summary>
        bool IsTryMoveTransport(ZoneEventType typeMove);

        /// <summary>
        /// Сохранить
        /// </summary>
        /// <returns>Статус успеха операции</returns>
        bool Save(long userId, out IContractResult result);

        /// <summary>
        /// Связанная зона
        /// </summary>
        IZone Zone {  get; }

        /// <summary>
        /// Идентификатор зоны ИМР
        /// </summary>
        long ZoneIMRId { get; }

        /// <summary>
        /// Идентификатор зоны
        /// </summary>
        long JournalId { get; }

        /// <summary>
        /// Начать контролировать зону
        /// </summary>
        /// <param name="userId">Пользователь, от которого поступил запрос</param>
        /// <returns></returns>
        Task<IContractResult> SendStartControl(long userId);

        /// <summary>
        /// Закончить контролировать зону
        /// </summary>
        /// <param name="userId">Пользователь, от которого поступил запрос</param>
        /// <returns></returns>
        Task<IContractResult> SendStopControl(long userId);

        /// <summary>
        /// Перевести статус в Stopped
        /// </summary>
        void StopActive();

        /// <summary>
        /// Перевести статус в Active
        /// </summary>
        void StartActive();
    }

    /// <summary>
    /// Зона с допущенными сотрудниками
    /// </summary>
    public interface IZoneDangerousAccessPersons : IZoneDangerous
    {
        /// <summary>
        /// Допущенные лица
        /// </summary>
        IEnumerable<IPerson> AccessPersons { get; }

        /// <summary>
        /// Добавить допущенное лицо
        /// </summary>
        /// <param name="shedulerRange"></param>
        bool AccessPersonAdd(IPerson accessPerson);

        /// <summary>
        /// Удалить допущенное лицо
        /// </summary>
        /// <param name="shedulerRange"></param>
        bool AccessPersonRemove(IPerson accessPerson);

        /// <summary>
        /// Удалить все допущенные лица
        /// </summary>
        bool AccessPersonClear();
    }

    /// <summary>
    /// Зона постового
    /// </summary>
    [DisplayName("Зона постового")]
    public interface IZoneDangerousGuard : IZoneDangerous, IZoneDangerousActivity
    {
        /// <summary>
        /// Родительская зона ЗВР
        /// </summary>
        IZoneDangerousExplosion ParentZone { get; } 

        /// <summary>
        /// Назначенный постовой
        /// </summary>
        IPerson GuardPerson { get; }

        /// <summary>
        /// Назначить нового постового
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        bool SetGuardPerson(IPerson person);

        /// <summary>
        /// Удаление постового
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        bool RemoveGuardPerson();
    }

    /// <summary>
    /// Зона ВР
    /// </summary>
    [DisplayName("Зона ВР")]
    public interface IZoneDangerousExplosion : IZoneDangerousSheduler, IZoneDangerousAccessPersons, IZoneDangerousActivity
    {
        /// <summary>
        /// Зоны постовых
        /// </summary>
        IEnumerable<IZoneDangerousGuard> Guards { get; }

        /// <summary>
        /// Назначить зоны постовых
        /// </summary>
        /// <param name="guards"></param>
        void  SetGuards(IEnumerable<IZoneDangerousGuard> guards);
    }

    /// <summary>
    /// Журнал расписания изменяемый
    /// </summary>
    [DisplayName("Журнал расписания изменяемый")]
    public interface IZoneDangerousActivity
    {
        /// <summary>
        /// Изменение активности зоны
        /// </summary>
        event Action<IZoneDangerous> OnChangeActivity;
    }


    /// <summary>
    /// Журнал расписания
    /// </summary>
    [DisplayName("Журнал расписания")]
    public interface IZoneDangerousSheduler : IZoneDangerous, IZoneDangerousActivity
    {
        /// <summary>
        /// Диапазоны расписания
        /// </summary>
        [DisplayName("Диапазоны расписания")]
        IEnumerable<IZoneSchedulerJournal> ShedulerRanges { get; }

        /// <summary>
        /// Добавить интервал расписания
        /// </summary>
        /// <param name="shedulerRange"></param>
        bool ShedulerRangeAdd(IZoneSchedulerJournal shedulerRange);

        /// <summary>
        /// Удалить интервал расписания
        /// </summary>
        /// <param name="shedulerRange"></param>
        bool ShedulerRangeRemove(IZoneSchedulerJournal shedulerRange);

        /// <summary>
        /// Изменить интервал расписания
        /// </summary>
        /// <param name="shedulerRange"></param>
        bool ShedulerRangeChange(IZoneSchedulerJournal shedulerRange);

        /// <summary>
        /// Запустить проверку расписания
        /// </summary>
        void ShedulerStart(IZoneDangerousEventPriority lastEvent);

        void ShedulerStop();

        /// <summary>
        /// Проверка интервала на пересечение с текущими
        /// </summary>
        /// <param name="shedulerRange"></param>
        /// <returns></returns>
        public static bool CheckIntersection(IEnumerable<IZoneSchedulerJournal> zoneSchedulers, IZoneSchedulerJournal shedulerRange)
        {
            if (!zoneSchedulers.Any())
                return true;

            foreach (var item in zoneSchedulers
                .Where(x => x.DaysOfWeek.Intersect(shedulerRange.DaysOfWeek).Any()))
            {
                bool overlap = shedulerRange.TimeStart <= item.TimeEnd && item.TimeStart <= shedulerRange.TimeEnd;

                return !overlap;
            }

            return true;
        }
    }
}

