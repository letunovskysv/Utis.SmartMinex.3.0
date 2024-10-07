using System;

namespace Utis.Minex.Common.Enum.Converter
{
    public static class ToLineStateConverter
    {
        public static FaultState ToFaultState(this DeviceState deviceState)
        {
            switch (deviceState)
            {
                case DeviceState.Good:
                {
                    return FaultState.Good;
                }
                case DeviceState.Fault:
                {
                    return FaultState.Fault;
                }
                default:
                {
                    throw new Exception("Не возможно сконвертировать");
                }
            }
        }
    }
}