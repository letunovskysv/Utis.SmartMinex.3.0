using System;

namespace Utis.Minex.Common.Helpers
{
    using Utis.Minex.Common.Enum;

    public static class CustomQueryHelper
    {
        public static CustomQueryResultType GetTypeResultQuery(CustomQueryType type)
        {
            switch (type)
            {
                case CustomQueryType.FreeLamp:    
                case CustomQueryType.PersonMovementsByReader:    
                case CustomQueryType.MobileMarkPointMovements:
                {
                    return CustomQueryResultType.EntityList;
                }

                case CustomQueryType.PersonAndBindLamp:
                case CustomQueryType.MethanePpmAndPerson:
                case CustomQueryType.MethaneLevelAndPerson:
                {
                    return CustomQueryResultType.EntityInnerList;
                }

                case CustomQueryType.LineStateAndReaders:
                case CustomQueryType.PortStateAndReaders:
                case CustomQueryType.LampsForIndividualDevices:
                case CustomQueryType.TransportInMine:
                case CustomQueryType.PeopleInMineForPeriod:
                case CustomQueryType.LineSurveyAndReaders:
                case CustomQueryType.GetAtoLabelsFromAccurateRfidEvents:
                case CustomQueryType.GetTransportIdsFromMarkPointTransportAccurateRfid:
                case CustomQueryType.LastGiveOutDateForIndDevIds:
                case CustomQueryType.FirstMineOutsAndTurnIns:
                case CustomQueryType.PersonWorkingTransitionCount:
                case CustomQueryType.TransportWorkingTransitionCount:
                    {
                    return CustomQueryResultType.ListObjectArray;
                }

                default: throw new NotImplementedException();
            }
        }

            /*/
            public static CustomQueryParametrType GetParametrType(CustomQueryType type)
            {
                switch (type)
                {
                    case CustomQueryType.FreeLamp:
                    case CustomQueryType.PersonAndBindLamp:
                    case CustomQueryType.PersonMovementAndDivision:
                    {
                        return CustomQueryParametrType.CustomStringValue;
                    }

                    case CustomQueryType.MethaneLevelAndPerson:
                    case CustomQueryType.LampsForIndividualDevices:
                    case CustomQueryType.MethanePpmAndPerson:
                    case CustomQueryType.LineStateAndReaders:
                    case CustomQueryType.PortStateAndReaders:                   
                    case CustomQueryType.LineSurveyAndReaders:
                    case CustomQueryType.TransportInMine:
                    case CustomQueryType.MobileMarkPointMovements:
                    case CustomQueryType.DiscardedAccurateRfidEvent:
                    {
                        return CustomQueryParametrType.Expressions;
                    }

                    default: throw new NotImplementedException();
                }
            }
            //*/
        }
}