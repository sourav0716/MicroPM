using MediatR;
using ProjectService.Application.Common.Errors;
using ProjectService.Application.Common.Interfaces;
using ProjectService.Application.Common.Models;
using ProjectService.Domain.Entity;

namespace ProjectService.Application.Projects.Commands.UpdateAdminsToProject;

public class UpdateAdminsToProjectCommand : IRequest<Unit>
{
    public Guid ProjectId { get; set; }
    public List<string>? Admins { get; set; }
    public RequestType RequestType { get; set; }
}
public class UpdateAdminsToProjectCommandHandler : IRequestHandler<UpdateAdminsToProjectCommand, Unit>
{
    private readonly IProjectService _projectService;
    private readonly IUserService _userService;

    public UpdateAdminsToProjectCommandHandler(IProjectService projectService, IUserService userService)
    {
        _projectService = projectService;
        _userService = userService;
    }

    public async Task<Unit> Handle(UpdateAdminsToProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await _projectService.GetProjectByIdAsync(request.ProjectId, cancellationToken)
                      ?? throw new NotFoundException(nameof(Project), request.ProjectId);
        if (request.Admins != null)
        {
            foreach (var userName in request.Admins)
            {
                Guid userId = await _userService.GetUserIdByUserNameAsync(userName, cancellationToken);
                if (userId == Guid.Empty)
                {
                    throw new NotFoundException("userName", userName);
                }
                if (request.RequestType == RequestType.add)
                {
                    project.AddAdmin(userId);
                }
                else
                {
                    project.RemoveAdmin(userId);
                }
            }
        }
        await _projectService.UpdateProject(project, cancellationToken);
        return Unit.Value;
    }
}