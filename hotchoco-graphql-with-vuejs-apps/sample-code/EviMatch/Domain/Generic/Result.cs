namespace Domain.Generic
{
    public abstract class AbstractResult
    {
        public bool IsSucceeded { get; set; }
        public string? Error { get; set; }
    }

    public class Result : AbstractResult
    {
        public Result(bool isSucceeded, string? error = null)
        {
            this.IsSucceeded = isSucceeded;
            this.Error = error;
        }

        public static Result Success()
        {
            return new Result(true, null);
        }

        public static Result Failure(string error)
        {
            return new Result(false, error);
        }
    }

    public class Result<T> : AbstractResult
    {
        public Result(T data, bool isSucceeded, string? error = null)
        {
            this.Data = data;
            this.IsSucceeded = isSucceeded;
            this.Error = error;
        }

        public static Result<T> Success(T data)
        {
            return new Result<T>(data, true, null);
        }

        public static Result<T> Failure(string error)
        {
            return new Result<T>(default(T), false, error);
        }

        public T Data { get; }
    }
}
