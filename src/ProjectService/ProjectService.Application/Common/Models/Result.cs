namespace ProjectService.Application.Common.Models
{
   public class Result<T>
{
    public bool Successful { get; private set; }
    public T? Data { get; private set; }
    public string Error { get; private set; } =string.Empty;

    public static Result<T> Success(T data)
    {
        return new Result<T> { Successful = true, Data = data };
    }

    public static Result<T> Failure(string error)
    {
        return new Result<T> { Successful = false, Error = error };
    }
}
}