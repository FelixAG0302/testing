

namespace testing.Application.Core
{
    public class Result
    {
        public Result()
        {
            IsSuccess = true;
        }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
    public class Result<TData> : Result
        where TData : class
    {
        public TData? Data { get; set; }
    }
}
