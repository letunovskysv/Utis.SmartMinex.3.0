using System;

namespace Utis.Minex.Common.Enum.Converter
{
    public static class ToStateEventConverter
    {
        public static StateEvent ToStateEvent(this EmergencyCallType emergencyCallerType)
        {
            switch (emergencyCallerType)
            {
                case EmergencyCallType.MineAlarm:  return StateEvent.Alarm;
                case EmergencyCallType.MineReset:  return StateEvent.Notification;
                case EmergencyCallType.RaiseReset: return StateEvent.Notification;
                case EmergencyCallType.Default:
                default:
                {
                    return StateEvent.Default;
                }
            }
        }

        public static StateEvent ToStateEvent(this EmergencyType emergencyType)
        {
            switch (emergencyType)
            {
                case EmergencyType.AutoConfirm:
                {
                    return StateEvent.Warning;
                }
                case EmergencyType.CallConfirmedSubr:
                case EmergencyType.CallConfirmedReader:
                case EmergencyType.Raise:
                {
                    return StateEvent.Alarm;
                }
                case EmergencyType.ButtonConfirm:
                case EmergencyType.RaiseReset:
                {
                    return StateEvent.Notification;
                }
                default:
                {
                    return StateEvent.Default;
                }
            }
        }

        public static StateEvent ToStateEvent(this DeviceState deviceState)
        {
            switch (deviceState)
            {
                case DeviceState.Fault: return StateEvent.Alarm;
                case DeviceState.Good:  return StateEvent.Notification;
                default:
                {
                    return StateEvent.Default;
                }
            }
        }

        public static StateEvent ToStateEvent(this LineState lineState)
        {
            switch (lineState)
            {
                case LineState.Breakage: return StateEvent.Alarm;
                case LineState.Recovery: return StateEvent.Notification;                
                default:
                {
                    return StateEvent.Default;
                }
            }
        }

        public static StateEvent ToStateEvent(this AntennaState antennaState)
        {
            switch (antennaState)
            {
                case AntennaState.Fault:     return StateEvent.Warning;
                case AntennaState.Good:      return StateEvent.Notification;
                case AntennaState.Shortened: return StateEvent.Warning;
                case AntennaState.Unused:
                default:
                {
                    return StateEvent.Default;
                }
            }
        }

        public static StateEvent ToStateEvent(this CoverState coverState)
        {
            switch (coverState)
            {
                case CoverState.Closed: return StateEvent.Notification;
                case CoverState.Opened: return StateEvent.Warning;
                default:
                {
                    return StateEvent.Default;
                }
            }
        }

        public static StateEvent ToStateEvent(this RouteEventType zoneEventType)
        {
            switch (zoneEventType)
            {
                case RouteEventType.GetOffRoute: return StateEvent.Alarm;
                case RouteEventType.BackToRoute: return StateEvent.Notification;
                default:
                {
                    return StateEvent.Default;
                }
            }
        }

        public static StateEvent ToStateEvent(this PagerEventType pagerEventType)
        {
            switch (pagerEventType)
            {
                case PagerEventType.DeleteMessage: return StateEvent.Warning;

                case PagerEventType.DefaultPagerEventType:
                case PagerEventType.AutoConfirmText:
                case PagerEventType.AutoConfirmVibro:
                case PagerEventType.ButtonConfirm:
                case PagerEventType.FromPerson:
                default:
                {
                    return StateEvent.Notification;
                }
            }
        }

        public static StateEvent ToStateEvent(this FreezeType freezeType)
        {
            switch (freezeType)
            {
                case FreezeType.FreezeFiveMinuts: return StateEvent.Alarm;
                case FreezeType.NotFreeze:
                default:
                {
                    return StateEvent.Notification;
                }
            }
        }

        public static StateEvent ToStateEvent(this MethaneLevel methaneLevel)
        {
            switch (methaneLevel)
            {
                case MethaneLevel.ElevatedMPC: return StateEvent.Warning;
                case MethaneLevel.ExcessMPC:   return StateEvent.Alarm;
                case MethaneLevel.NormaMPC:
                default:
                {
                    return StateEvent.Notification;
                }
            }
        }

        public static StateEvent ToStateEvent(this ChargeLevel chargeLevel)
        {
            switch (chargeLevel)
            {
                case ChargeLevel.Low:    return StateEvent.Alarm;
                case ChargeLevel.Normal: return StateEvent.Notification;
                default:
                {
                    return StateEvent.Notification;
                }
            }
        }

        public static StateEvent ToStateEvent(this PowerSupplyType chargeLevel)
        {
            switch (chargeLevel)
            {
                case PowerSupplyType.BatterySupply: return StateEvent.Alarm;
                case PowerSupplyType.MainsSupply:   return StateEvent.Notification; 
                default:
                {
                    return StateEvent.Notification;
                }
            }
        }

        public static StateEvent ToStateEvent(this SurveyState surveyState)
        {
            switch (surveyState)
            {
                case SurveyState.SurveyIsEnable:    return StateEvent.Notification;
                case SurveyState.SurveyIsNotEnable: return StateEvent.Alarm;
                default:
                {
                    throw new Exception($"Не поддерживаемый тип {surveyState}");
                }
            }
        }
        public static StateEvent ToStateEvent(this FaultState faultState)
        {
            switch (faultState)
            {
                case FaultState.Good:  return StateEvent.Notification;
                case FaultState.Fault: return StateEvent.Alarm;
                default:
                {
                    throw new Exception($"Не поддерживаемый тип {faultState}");
                }
            }
        }

        public static StateEvent ToStateEvent(this PuksMessage puksMessage)
        {
            switch (puksMessage)
            {
                case PuksMessage.AlarmStart:
                case PuksMessage.AlarmFinish:
                case PuksMessage.AlarmFromSubr:
                case PuksMessage.IndNumIncorrect:
                {
                    return StateEvent.Alarm;
                }
                case PuksMessage.HashNotCorrect:
                case PuksMessage.TransNotFinish:
                case PuksMessage.ResetIncorrect:
                case PuksMessage.UnknownCommand:
                {
                    return StateEvent.Warning;
                }
                case PuksMessage.IndNumStart:
                case PuksMessage.IndNumFinish:
                case PuksMessage.SubrBusy:
                case PuksMessage.SubrFree:
                case PuksMessage.ResetSock:
                {
                    return StateEvent.Notification;
                }

                default:
                {
                    throw new Exception($"Не поддерживаемый тип {puksMessage}");
                }
            }
        }

        public static StateEvent ToStateEvent(this PuksState puksState)
        {
            switch (puksState)
            {
                case PuksState.Connected:
                case PuksState.Disconnected:
                {
                    return StateEvent.Warning;
                }
                default:
                {
                    throw new Exception($"Не поддерживаемый тип {puksState}");
                }
            }
        }

        public static StateEvent ToStateEvent(this TransportModuleConnectionState tmState)
        {
            switch (tmState)
            {
                case TransportModuleConnectionState.Connected:
                case TransportModuleConnectionState.Disconnected:
                {
                    return StateEvent.Warning;
                }
                default:
                {
                    throw new Exception($"Не поддерживаемый тип {tmState}");
                }
            }
        }

        public static StateEvent ToStateEvent(this DataProviderState dataProviderState)
        {
            switch (dataProviderState)
            {
                case DataProviderState.Warning:
                {
                    return StateEvent.Alarm;
                }
                case DataProviderState.Default:
                case DataProviderState.Connected:
                case DataProviderState.Disconnected:
                case DataProviderState.Registered:
                case DataProviderState.Subscribed:
                case DataProviderState.Unsubscribed:
                {
                    return StateEvent.Notification;
                }
                default:
                {
                    throw new Exception($"Не поддерживаемый тип {dataProviderState}");
                }
            }
        }

        public static StateEvent ToStateEvent(this TrafficLightState trafficLightState)
        {
            switch (trafficLightState)
            {
                case TrafficLightState.RedLight: 
                case TrafficLightState.GreenLight:
                case TrafficLightState.GreenBlink:
                case TrafficLightState.RedBlink:
                {
                    return StateEvent.Notification;
                }
                case TrafficLightState.RedGreenBlink:
                {
                    return StateEvent.Warning;
                }
                case TrafficLightState.DefaultTrafficLightState:
                default:
                {
                    return StateEvent.Default;
                }
                    
            }
        }

        public static StateEvent ToStateEvent(this TransportBreakState transportBreakState)
        {
            switch (transportBreakState)
            {
                case TransportBreakState.Unbroken: return StateEvent.Notification;
                case TransportBreakState.Broken:   return StateEvent.Alarm;

                default:
                {
                    return StateEvent.Default;
                }                    
            }
        }
    }
}