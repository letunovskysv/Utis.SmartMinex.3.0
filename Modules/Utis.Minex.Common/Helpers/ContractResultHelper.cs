using System;
using System.Text;
using Utis.Minex.Common.Common;
using Utis.Minex.Common.Enum;
using Utis.Minex.Common.Interfaces;

namespace Utis.Minex.Common.Helpers
{
    public static class ContractResultHelper
    {
        public static string GetMessageReasonStateForClient(this IContractResult contractObjResult)
        {
            switch (contractObjResult.State)
            {
                default:
                case StateContract.Canceled:
                {
                    var builder = new StringBuilder();
                    foreach (var stateMessage in contractObjResult.StateMessages)
                    {
                        if (builder.Length != 0)
                        {
                            builder.Append(Environment.NewLine);
                        }
                        builder.Append(stateMessage);
                    }

                    return builder.ToString();
                }
                case StateContract.ValidationError:
                {
                    var builder = new StringBuilder();
                    foreach (var stateMessage in contractObjResult.StateMessages)
                    {
                        if (builder.Length != 0)
                        {
                            builder.Append(Environment.NewLine);
                        }

                        builder.Append(ValidationSpecialMessageHelper.IsSpecialMessage(stateMessage)
                            ? ValidationSpecialMessageHelper.ParseMessage(stateMessage).message
                            : stateMessage);
                    }

                    return builder.ToString();
                }
                case StateContract.ServerError:
                {
                    return "Непредвиденная ошибка на сервере";
                }
            }
        }

        public static void WriteContractResultExceptionInLog(this IPureLogger logger, IContractObjResult contractObjResult, Exception exception)
        {
            switch (contractObjResult.State)
            {
                default:
                {
                    logger.WriteException(exception, LogMessageType.Error);
                    break;
                }

                case StateContract.ValidationError:
                {
                    logger.WriteException(exception, LogMessageType.Warning);
                    break;
                }
            }
        }
    }
}