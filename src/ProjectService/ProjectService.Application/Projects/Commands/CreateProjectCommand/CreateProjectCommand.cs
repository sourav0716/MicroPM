using MediatR;
using ProjectService.Application.Common.Interfaces;
using ProjectService.Domain.Entity;
using ProjectService.Application.DTOs;
using ProjectService.Application.Common.Errors;

namespace ProjectService.Application.Projects.Commands.CreateProjectCommand;

public class CreateProjectCommand : IRequest<Project>
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Owner { get; set; } = string.Empty;
    public List<ComponentDTO>? Components { get; set; }
    public List<string>? UserGroup { get; set; }
    public List<string>? Users { get; set; }
    public string Workflow { get; set; } = string.Empty;
    public List<string>? Admin { get; set; }
}
public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, Project>
{
    private readonly IUserService _userService;
    private readonly IWorkflowService _workflowService;
    private readonly IUserGroupService _userGroupService;

    public CreateProjectCommandHandler(
        IUserService userService,
        IWorkflowService workflowService,
        IUserGroupService userGroupService)
    {
        _userService = userService;
        _workflowService = workflowService;
        _userGroupService = userGroupService;
    }

    public async Task<Project> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        var owner = await ValidateUser(request.Owner);
        Project project = new(
            details: new Details(request.Name, request.Description),
            ownerId: owner,
            workflowId: await ValidateWorkflow(request.Workflow));
        if (request.Admin != null)
        {
            foreach (var admin in request.Admin)
            {
                var user = await ValidateUser(admin);
                project.AddAdmin(user);
            }
        }
        if (request.Users != null)
        {
            foreach (var user in request.Users)
            {
                var userToAdd = await ValidateUser(user);
                project.AddUser(userToAdd);
            }
        }
        if (request.UserGroup != null)
        {
            foreach (var userGroup in request.UserGroup)
            {
                var userGroupToAdd = await ValidateUserGroup(userGroup);
                project.AddGroup(userGroupToAdd);

            }
        }
        if (request.Components != null)
        {
            foreach (var component in request.Components)
            {
                project.AddComponent(new Details(component.Name, component.Description));
            }

        }
        return project;
    }
    private async Task<Guid> ValidateUser(string ownerName)
    {
        var user = await _userService.GetUserByUserNameAsync(ownerName);
        return user == Guid.Empty ? throw new NotFoundException("User", ownerName) : user;
    }

    private async Task<Guid> ValidateWorkflow(string workflowName)
    {
        var workflow = await _workflowService.GetWorkflowByNameAsync(workflowName);
        return workflow == Guid.Empty ? throw new NotFoundException("Workflow", workflowName) : workflow;
    }

    private async Task<Guid> ValidateUserGroup(string userGroupName)
    {
        var usergroup = await _userGroupService.GetUserGroupByNameAsync(userGroupName);
        return usergroup == Guid.Empty ? throw new NotFoundException("UserGroup", userGroupName) : usergroup;
    }
}