using ProjectService.Domain.Common;
using ProjectService.Domain.Event;

namespace ProjectService.Domain.Entity;
public class Project : AuditableEntity
{
    public Guid Id { get; private set; }
    public Details Details { get; private set; }
    public Guid OwnerId { get; private set; }
    public List<Component> Components { get; private set; }
    public Guid WorkflowId { get; private set; }
    private readonly List<Guid> _userIds;
    public IReadOnlyCollection<Guid> UserIds => _userIds;
    private readonly List<Guid> _adminIds;
    public IReadOnlyCollection<Guid> AdminIds => _adminIds;
    private readonly List<Guid> _groupIds;
    public IReadOnlyCollection<Guid> GroupIds => _groupIds;
    public ProjectStatus ProjectStatus { get; private set; }

    public Project(Details details, Guid ownerId, Guid workflowId)
    {
        Id = Guid.NewGuid();
        Details = details;
        OwnerId = ownerId;
        Components = new List<Component>();
        WorkflowId = workflowId;
        _userIds = new List<Guid>();
        _adminIds = new List<Guid>();
        _groupIds = new List<Guid>();

        AddDomainEvent(new ProjectCreatedEvent(this));
    }
    public void AddComponent(Details componentDetails)
    {
        var component = new Component(componentDetails);
        Components.Add(component);
    }

    public void AddUser(Guid userId)
    {
        if (!_userIds.Contains(userId))
        {
            _userIds.Add(userId);
        };
    }

    public void AddAdmin(Guid adminId)
    {
        if (!_adminIds.Contains(adminId))
        {
            _adminIds.Add(adminId);
        };
    }

    public void AssignWorkflow(Guid workflowId)
    {
        WorkflowId = workflowId;
    }

    public void AddGroup(Guid groupId)
    {
        if (!_groupIds.Contains(groupId))
        {
            _groupIds.Add(groupId);
        };
    }
    public bool RemoveUser(Guid userId)
    {
        return _adminIds.Remove(userId);
    }
    public bool RemoveAdmin(Guid adminId)
    {
        return _userIds.Remove(adminId);
    }
    public bool RemoveGroup(Guid groupId)
    {
        return _groupIds.Remove(groupId);
    }

    public void ChangeStatus(ProjectStatus newStatus)
    {
        ProjectStatus = newStatus;
    }
}