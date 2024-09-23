

using testing.Application.Utils.Enums;

namespace testing.Application.Core
{
    public class Result
    {

        public Result(string message, string errorType)
        {
            IsSuccess = false;
            ErrorType = errorType;
            Message = message;
        }
        
        public  Result() {

            ErrorType = ErrorTypes.None.ToString();
            IsSuccess = true;
        }

        public  Result(string message)
        {
            ErrorType = ErrorTypes.None.ToString();
            Message = message;
            IsSuccess = true;
        }

        public bool IsSuccess { get; }
        public string? ErrorType { get; }
        public string Message { get;}

        public static Result Success(string message) => new(message);

        public static Result Failure(string message, ErrorTypes errorTypes) => new(message, errorTypes.ToString());
        
    }
    public class Result<TData> 
        where TData : class
    {
        public Result(string message, string errorType, bool isSuccess)
        {
            IsSuccess = isSuccess;
            Message = message;
            ErrorType = errorType;  
            Data = default;
        }

        public Result(string message, TData? data)
        {
            Message = message;
            IsSuccess = true;
            ErrorType = ErrorTypes.None.ToString();
            Data = data;
        }
       
        public bool IsSuccess { get; }
        public string Message { get;  }
        public string? ErrorType { get; private set; } = ErrorTypes.None.ToString();
        public TData? Data { get; }

        public static implicit operator Result<TData>(Result result) => new(result.Message, result.ErrorType, result.IsSuccess);

        public static implicit operator Result<TData>(TData data) => new("Operation was successfully completed", data);
    }
}
