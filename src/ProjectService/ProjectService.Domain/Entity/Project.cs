using ProjectService.Domain.Common;

namespace ProjectService.Domain.Entity;

public class Project : AuditableEntity
{
    public Project(string name, string description, User owner)
    {
        this.Description = description;
        this.Name = name;
        this.Owner = owner;
    }
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Component>? Components { get; set; }
    public List<User>? Users { get; set; }
    public User Owner { get; set; }
    public User? Admin { get; set; }
    public Workflow? Workflow { get; set; }
    public ProjectStatus Status { get; set; } = ProjectStatus.draft;
}