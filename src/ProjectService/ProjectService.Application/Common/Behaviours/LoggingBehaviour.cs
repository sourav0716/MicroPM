using MediatR.Pipeline;
using Serilog;

namespace ProjectService.Application.Common.Behaviours;

public class LoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest> where TRequest : notnull
{
    private readonly ILogger _logger;

    public LoggingBehaviour()
    {
        _logger = Log.ForContext<LoggingBehaviour<TRequest>>();
    }

    public async Task Process(TRequest request, CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;
        string userName = string.Empty;

        _logger.Information("Project Service Request: {Name}  {@UserName} {@Request}",
            requestName, userName, request);
    }
}