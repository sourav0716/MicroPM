namespace ProjectService.Application.Common.Errors;

public class DuplicateException : Exception
{
    public DuplicateException(string message) : base($"Entity \"{message}\"Already Exists") { }

    public DuplicateException(string name, object key) : base($"Entity \"{name}\" ({key}) was not found.") { }
    public DuplicateException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}