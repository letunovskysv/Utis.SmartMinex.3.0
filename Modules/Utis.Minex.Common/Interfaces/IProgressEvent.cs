using System;

namespace Utis.Minex.Common.Interfaces
{
    /// <summary>
    /// Тип прогресса
    /// </summary>
    public enum ProgressType
    {
        Start = 0,
        Run = 1,
        End = 2,
        Cancel = 3,
        Error = 4
    }

    /// <summary>
    /// Событие прогресса
    /// </summary>
    public interface IProgressEvent
    {
        /// <summary>
        /// Текущий этап
        /// </summary>
        double Step { get; }
        /// <summary>
        /// Общее кол-во этапов
        /// </summary>
        double Count { get; }
        /// <summary>
        /// Сообщение текущего этапа
        /// </summary>
        string StepMessage { get; set; }
        /// <summary>
        /// Тип этапа
        /// </summary>
        ProgressType Type { get; }

        bool IsCompleted { get; }


        private static IProgressEvent CreateEnd(
            ProgressType type,
            double progress,
            string stepMessage = "")
        {
            return new ProgressEvent()
            {
                Type = type,
                Step = progress,
                Count = progress,
                StepMessage = stepMessage
            };
        }

        /// <summary>
        /// Создать пользовательский IProgressEvent
        /// </summary>
        /// <param name="type"></param>
        /// <param name="step"></param>
        /// <param name="count"></param>
        /// <param name="stepMessage"></param>
        /// <returns></returns>
        public static IProgressEvent Create(
            ProgressType type,
            double step, double count,
            string stepMessage = "")
        {
            return new ProgressEvent()
            {
                Type = type,
                Step = step,
                Count = count,
                StepMessage = stepMessage
            };
        }

        /// <summary>
        /// Создать IProgressEvent работы
        /// </summary>
        /// <param name="step"></param>
        /// <param name="count"></param>
        /// <param name="stepMessage"></param>
        /// <returns></returns>
        public static IProgressEvent CreateRun(
            double step,            
            string stepMessage = "",
            double count = 100)
        {
            return Create(ProgressType.Run, step, count, stepMessage);
        }

        /// <summary>
        /// Создать стартовый IProgressEvent
        /// </summary>
        /// <param name="stepMessage"></param>
        /// <returns></returns>
        public static IProgressEvent CreateStart(
            string stepMessage = "")
        {
            return CreateEnd(ProgressType.Start, 0, stepMessage);
        }
        /// <summary>
        /// Создать IProgressEvent ошибки
        /// </summary>
        /// <param name="stepMessage"></param>
        /// <returns></returns>
        public static IProgressEvent CreateError(
            string stepMessage = "",
            double endCount = 100)
        {
            return CreateEnd(ProgressType.Error, endCount, stepMessage);
        }
        /// <summary>
        /// Создать IProgressEvent успешного завершения
        /// </summary>
        /// <param name="stepMessage"></param>
        /// <returns></returns>
        public static IProgressEvent CreateSuccessEnd(
            string stepMessage = "",
            double endCount = 100)
        {
            return CreateEnd(ProgressType.End, endCount, stepMessage);
        }
        /// <summary>
        /// Создать IProgressEvent отмены
        /// </summary>
        /// <param name="stepMessage"></param>
        /// <returns></returns>
        public static IProgressEvent CreateCancel(
            double endCount = 100,
            string stepMessage = "")
        {
            return CreateEnd(ProgressType.Cancel, endCount, stepMessage);
        }

        /// <summary>
        /// Посчитать процент выполнения
        /// </summary>
        /// <param name="stepOrig">Текущий шаг оришинальный</param>
        /// <param name="countOrig">Общее кол-во оригинальное</param>
        /// <param name="decimalRound">Кол-во знаков после запятой в сосчитанном значении</param>
        /// <param name="countPercent">Кол-во процентов(или другое)</param>
        ///  <param name="offset">Смещение процентов(или другое) при разделении на группы</param>
        /// <returns></returns>
        public static double CalculateStep(double stepOrig, double countOrig, 
            double offset = 0, int decimalRound = 0, double countPercent = 100)
        {
            var countPercentLoc = countPercent - offset;
            return offset+ Math.Round(stepOrig / countOrig * countPercentLoc, decimalRound);
        }
    }

    /// <summary>
    /// Событие прогресса с данными
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IProgressDataEvent<T> : IProgressEvent
    {
        /// <summary>
        /// Данные
        /// </summary>
        T Data { get; }


        /// <summary>
        /// Создать пользовательский IProgressDataEvent
        /// </summary>
        /// <param name="type"></param>
        /// <param name="step"></param>
        /// <param name="count"></param>
        /// <param name="stepMessage"></param>
        /// <returns></returns>
        public static IProgressDataEvent<T2> Create<T2>(
            T2 data,
            ProgressType type,
            double step, double count,
            string stepMessage = "")
        {
            return new ProgressDataEvent<T2>(data)
            {
                Type = type,
                Step = step,
                Count = count,
                StepMessage = stepMessage
            };
        }

        /// <summary>
        /// Создать IProgressDataEvent работы
        /// </summary>
        /// <param name="data"></param>
        /// <param name="step"></param>
        /// <param name="count"></param>
        /// <param name="stepMessage"></param>
        /// <returns></returns>
        public static IProgressDataEvent<T> CreateRun<T>(
            T data,
            int step,
            int count = 100,
            string stepMessage = "")
        {
            return Create<T>(data, ProgressType.Run, step, count, stepMessage);
        }
    }

    internal class ProgressEvent : IProgressEvent
    {
        protected internal ProgressEvent() { }

        public double Step { get; protected internal set; }

        public double Count { get; protected internal set; }

        public string StepMessage { get; set; }

        public ProgressType Type { get; protected internal set; }

        public bool IsCompleted => Type
            .In( ProgressType.Cancel, ProgressType.End, ProgressType.Error);
    }

    internal class ProgressDataEvent<T> : ProgressEvent, IProgressDataEvent<T>
    {
        public T Data { get; protected set; }
        internal ProgressDataEvent(T data)
        {
            Data = data;
        }

        public IProgressEvent ToProgressEvent()
        {
            return new ProgressEvent()
            {
                StepMessage = StepMessage,
                Count = Count,
                Step = Step,
                Type = Type
            };
        }
    }
}


