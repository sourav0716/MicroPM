using ProjectService.Domain.Common;

namespace ProjectService.Domain.Entity;

public class WorkflowStep: AuditableEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<WorkflowAction>? Actions { get; set; }

    public WorkflowStep(string name, string description)
    {
        Name = name;
        Description = description;
    }
}