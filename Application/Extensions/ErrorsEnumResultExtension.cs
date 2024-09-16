
using Microsoft.Extensions.Logging;
using testing.Application.Core;
using testing.Application.Utils.Enums;

namespace testing.Application.Extensions
{
    internal static class ErrorsEnumResultExtension
    {
        public static Result Because(this ErrorTypes errorTypes, string message) => new(message, false)
        {
            ErrorType = errorTypes.ToString(),
        };

        
    }
}
