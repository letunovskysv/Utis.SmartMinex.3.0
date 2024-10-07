using System;
using System.Text;
using System.Reflection;
using System.Diagnostics;
using System.Collections.Generic;

namespace Utis.Minex.Common.ExceptionExtension
{
    /// <see cref="https://stackoverflow.com/questions/37093261/attach-stacktrace-to-exception-without-throwing-in-c-sharp-net"/>
    public static class ExceptionUtilities
    {
        //TODO BREVNOV create test

        private static readonly FieldInfo STACK_TRACE_STRING_FI = typeof(Exception).GetField("_stackTraceString", BindingFlags.NonPublic | BindingFlags.Instance);
        private static readonly Type TRACE_FORMAT_TI = typeof(StackTrace).GetNestedType("TraceFormat", BindingFlags.NonPublic);
        private static readonly MethodInfo TRACE_TO_STRING_MI = typeof(StackTrace).GetMethod("ToString", BindingFlags.NonPublic | BindingFlags.Instance, null, new[] { TRACE_FORMAT_TI }, null);

        /// <summary>
        /// Установить StackTrace, без создания throw.
        /// </summary>
        public static Exception SetStackTrace(this Exception target, StackTrace stack)
        {
            var getStackTraceString = TRACE_TO_STRING_MI.Invoke(stack, new object[] { System.Enum.GetValues(TRACE_FORMAT_TI).GetValue(0) });
            STACK_TRACE_STRING_FI.SetValue(target, getStackTraceString);
            return target;
        }

        /// <summary>
        /// Создать ошибку с StackTrace, для облегчения поиска в коде error из лога.
        /// </summary>
        public static Exception CreatExceptionWitchStackTrace(string exceptionMessage)
        {
            return CreatExceptionWitchStackTrace(exceptionMessage, 2);
        }

        /// <summary>
        /// Создать ошибку с StackTrace, для облегчения поиска в коде error из лога.
        /// </summary>
        private static Exception CreatExceptionWitchStackTrace(string exceptionMessage, int skipFrames)
        {
            var exception = exceptionMessage == null ? new Exception() : new Exception(exceptionMessage);

            var stackTrace = new StackTrace(skipFrames, true);
            exception.SetStackTrace(stackTrace);

            return exception;
        }

        /// <summary>
        /// Создать ошибку с StackTrace, для облегчения поиска в коде error из лога.
        /// </summary>
        public static Exception CreatExceptionWitchStackTrace(IEnumerable<string> exceptionMessages)
        {
            var builder = new StringBuilder();
            foreach (var exceptionMessage in exceptionMessages)
            {
                builder.Append(exceptionMessage);
                builder.Append(Environment.NewLine);
            }

            return CreatExceptionWitchStackTrace(builder.ToString(), 2);
        }
    }
}