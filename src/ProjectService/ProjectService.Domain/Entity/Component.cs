using ProjectService.Domain.Common;

namespace ProjectService.Domain.Entity;

public class Component : AuditableEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<User>? Users { get; set; }
    public Workflow? Workflow { get; set; }

    public Component(string name, string description)
    {
        Name = name;
        Description = description;
    }
}
