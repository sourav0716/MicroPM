using MediatR;
using Serilog;

namespace ProjectService.Application.Common.Behaviours;

public class UnhandledExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly ILogger _logger;

    public UnhandledExceptionBehaviour()
    {
        _logger = Log.ForContext<UnhandledExceptionBehaviour<TRequest, TResponse>>();
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,CancellationToken cancellationToken)
    {
        try
        {
            return await next();
        }
        catch (Exception ex)
        {
            var requestName = typeof(TRequest).Name;

            _logger.Error(ex, "ProjectService Request: Unhandled Exception for Request {Name} {@Request}", requestName, request);

            throw;
        }
    }
}