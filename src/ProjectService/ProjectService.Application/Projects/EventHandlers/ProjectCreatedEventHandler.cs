using MediatR;
using ProjectService.Domain.Event;

namespace ProjectService.Application.Projects.Eventhandlers;

public class ProjectCreatedEventHandler : INotificationHandler<ProjectCreatedEvent>
{
    public Task Handle(ProjectCreatedEvent notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}