

namespace testing.Application.Core
{
    public class Result
    {

        public Result(string message,bool isSuccess = true)
        {
            IsSuccess = isSuccess;
            Message = message;
        }
        public Result() { 
        }

        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
    public class Result<TData> : Result
        where TData : class
    {
        public Result()
        {
            
        }

        public Result(string message,bool isSuccess = true) : base(message,isSuccess)
        {
        }
        public Result( string message, TData? data, bool isSuccess = true)
        {
            Message = message;
            IsSuccess = isSuccess;
            Data = data;
        }
        public Result(string message, TData? data)
        {
            Message = message;
            IsSuccess = true;
            Data = data;
        }
        public TData? Data { get; set; }
    }
}
