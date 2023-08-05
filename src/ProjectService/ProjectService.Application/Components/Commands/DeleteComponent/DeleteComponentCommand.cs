using MediatR;
using ProjectService.Application.Common.Errors;
using ProjectService.Application.Common.Interfaces;
using ProjectService.Domain.Entity;

namespace ProjectService.Application.Components.Commands.DeleteComponent;

public class DeleteComponentCommand : IRequest<Unit>
{
    public Guid ProjectId { get; set; }
    public string Name{get;set;}=string.Empty;
}
public class DeleteComponentCommandHandler : IRequestHandler<DeleteComponentCommand, Unit>
{
    private readonly IComponentService _componentService;
    private readonly IProjectService _projectService;
    public DeleteComponentCommandHandler(IComponentService componentService, IProjectService projectService)
    {
        _componentService = componentService;
        _projectService = projectService;
    }
    public async Task<Unit> Handle(DeleteComponentCommand request, CancellationToken cancellationToken)
    {
        var project = await _projectService.GetProjectByIdAsync(request.ProjectId, cancellationToken)
                      ?? throw new NotFoundException(nameof(Project), request.ProjectId);

         var component = await _componentService.GetComponentByNameAsync(request.Name,
                request.ProjectId,
                cancellationToken);
            if (component == Guid.Empty)
            {
                throw new NotFoundException(nameof(Component), request.Name);
            }
            project.RemoveComponent(component);
        return Unit.Value;
    }
}

    
