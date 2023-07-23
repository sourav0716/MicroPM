using ProjectService.Domain.Common;

namespace ProjectService.Domain.Entity;

public class WorkflowAction : AuditableEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public WorkflowAction(string Name, string Description)
    {
        this.Name = Name;
        this.Description = Description;
    }
}