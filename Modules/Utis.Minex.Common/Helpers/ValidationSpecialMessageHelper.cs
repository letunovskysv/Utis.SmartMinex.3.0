using System.Collections.Generic;
using System.Linq;

namespace Utis.Minex.Common.Helpers
{
    public static class ValidationSpecialMessageHelper
    {
        private const char _delimiter = '/';
        public static string GetSpecialMessage(string columnName, string validationMessage)
        {
            return $"{columnName}{_delimiter}{validationMessage}";
        }

        public static bool IsSpecialMessage(string message)
        {
            var delimiterIndex = message.IndexOf(_delimiter);
            if (delimiterIndex == -1) return false;
            return !GetColumnName(message, delimiterIndex).IsNullOrEmpty() && !GetMessage(message, delimiterIndex).IsNullOrEmpty();
        }

        public static (string column, string message) ParseMessage(string message)
        {
            var delimiterIndex = message.IndexOf(_delimiter);
            return !IsSpecialMessage(message) ? (string.Empty, string.Empty) : 
                (GetColumnName(message, delimiterIndex), GetMessage(message, delimiterIndex));
        }

        private static string GetMessage(string message, int delimiterIndex)
        {
            return message[(delimiterIndex + 1)..];
        }

        private static string GetColumnName(string message, int delimiterIndex)
        {
            return message[..delimiterIndex];
        }

        public static Dictionary<string, string> GetParsedMessages(IEnumerable<string> operationMessages)
        {
            var parsedMessages = new Dictionary<string, string>();
            foreach (var operationMessage in operationMessages.Where(IsSpecialMessage))
            {
                var (column, message) = ParseMessage(operationMessage);
                if (parsedMessages.TryGetValue(column, out var storedMessage))
                {
                    parsedMessages[column] = $"{storedMessage}\n{message}";
                }
                else
                {
                    parsedMessages[column] = $"{message}";
                }
            }

            return parsedMessages;
        }
    }
}
