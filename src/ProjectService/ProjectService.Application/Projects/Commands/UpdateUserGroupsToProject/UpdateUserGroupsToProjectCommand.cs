using MediatR;
using ProjectService.Application.Common.Errors;
using ProjectService.Application.Common.Interfaces;
using ProjectService.Application.Common.Models;
using ProjectService.Domain.Entity;

namespace ProjectService.Application.Projects.Commands.UpdateUserGroupsToProject;

public class UpdateUserGroupsToProjectCommand : IRequest<Unit>
{
    public Guid ProjectId { get; set; }
    public List<string>? UserGroupNames { get; set; }
    public RequestType RequestType { get; set; }
}
public class UpdateUserGroupsToProjectCommandHandler : IRequestHandler<UpdateUserGroupsToProjectCommand, Unit>
{
    private readonly IProjectService _projectService;
    private readonly IUserGroupService _groupService;

    public UpdateUserGroupsToProjectCommandHandler(IProjectService projectService, IUserGroupService groupService)
    {
        _projectService = projectService;
        _groupService = groupService;
    }

    public async Task<Unit> Handle(UpdateUserGroupsToProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await _projectService.GetProjectByIdAsync(request.ProjectId, cancellationToken)
                     ?? throw new NotFoundException(nameof(Project), request.ProjectId);
        if (request.UserGroupNames != null)
        {
            foreach (var UserGroupNames in request.UserGroupNames)
            {
                Guid groupId = await _groupService.GetUserGroupByNameAsync(UserGroupNames, cancellationToken);
                if (groupId == Guid.Empty)
                {
                    throw new NotFoundException("Group", UserGroupNames);
                }
                if (request.RequestType == RequestType.add)
                {
                    project.AddGroup(groupId);
                }
                else
                {
                    project.RemoveGroup(groupId);
                }
            }
        }
        await _projectService.UpdateProject(project, cancellationToken);
        return Unit.Value;
    }
}