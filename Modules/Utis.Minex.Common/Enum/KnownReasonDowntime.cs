namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Причина простоя
    /// </summary>
    [DisplayName("Причина простоя")]
    public enum KnownReasonDowntime
    {
        /// <summary>
        /// Значение по умолчанию
        /// </summary>
        [DisplayName("Не задано")]
        None = 0,

        /// <summary>
        /// Общая авария
        /// </summary>
        [DisplayName("Общая авария")]
        GeneralAlarm = 1,

        /// <summary>
        /// Резерв
        /// </summary>
        [DisplayName("Резерв")]
        Reserve = 2,

        /// <summary>
        /// Отсутствие фронта работ
        /// </summary>
        [DisplayName("Отсутствие фронта работ")]
        LackOfWorkFront = 3,

        /// <summary>
        /// Отсутствие машиниста
        /// </summary>
        [DisplayName("Отсутствие машиниста")]
        AbsenceOfEngineDriver = 4,

        /// <summary>
        /// Отсутствие парного агрегата
        /// </summary>
        [DisplayName("Отсутствие парного агрегата")]
        LackOfPairedAggregate = 5,

        /// <summary>
        /// Отсутствие ГСМ
        /// </summary>
        [DisplayName("Отсутствие ГСМ")]
        LackOfFuelAndLubricants = 6,

        /// <summary>
        /// Отсутствие проезда
        /// </summary>
        [DisplayName("Отсутствие проезда")]
        LackOfTravel = 7,

        /// <summary>
        /// Отсутствие электроэнергии
        /// </summary>
        [DisplayName("Отсутствие электроэнергии")]
        LackOfElectricity = 8,

        /// <summary>
        /// Отсутствие воды
        /// </summary>
        [DisplayName("Отсутствие воды")]
        LackOfWater = 9,

        /// <summary>
        /// Отсутствие сжатого воздуха
        /// </summary>
        [DisplayName("Отсутствие сжатого воздуха")]
        LackOfCompressedAir = 10,

        /// <summary>
        /// Перемещение/перезапитка
        /// </summary>
        [DisplayName("Перемещение/перезапитка")]
        MovingRrecharge = 11,

        /// <summary>
        /// Плановый ремонт
        /// </summary>
        [DisplayName("Плановый ремонт")]
        PlannedRepair = 12,

        /// <summary>
        /// Внеплановый ремонт
        /// </summary>
        [DisplayName("Внеплановый ремонт")]
        UnscheduledRepair = 13,

        /// <summary>
        /// Ожидание ремонта
        /// </summary>
        [DisplayName("Ожидание ремонта")]
        AwaitingRepair = 14,

        /// <summary>
        /// Не пригоден к эксплуатации
        /// </summary>
        [DisplayName("Не пригоден к эксплуатации")]
        Unserviceable = 15,

        /// <summary>
        /// Прочие технологические
        /// </summary>
        [DisplayName("Прочие технологические")]
        OthersTechnological = 16,

        /// <summary>
        /// Прочие общерудничные
        /// </summary>
        [DisplayName("Прочие общерудничные")]
        OthersGeneral = 17,
    }
}