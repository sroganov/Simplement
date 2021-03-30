using System;

namespace Simplement.Common.Extensions
{
    public static class ExceptionExtensions
    {
        public static string GetFullMessage(this Exception exception)
        {
            return GetMessageRecursive(exception);
        }

        private static string GetMessageRecursive(Exception exception)
        {
            if (exception.InnerException != null)
                return exception.Message + "; InnerException: " + GetMessageRecursive(exception.InnerException);

            return exception.Message;
        }
    }
}
