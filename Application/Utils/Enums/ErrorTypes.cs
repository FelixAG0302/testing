using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testing.Application.Utils.Enums
{
    internal enum ErrorTypes
    {
        Validation,
        Exceptions,
        DateConfilct,
        TimeConflict,
        OperationError,
        NoAuthenticated,
        NoAuthorize,
    }
}
