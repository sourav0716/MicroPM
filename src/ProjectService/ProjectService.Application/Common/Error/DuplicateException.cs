namespace ProjectService.Application.Common.Error;

public class DuplicateException : Exception
{
    public DuplicateException(string message) : base(message)
    {
    }

    public DuplicateException() : base()
    {
    }

    public DuplicateException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}