using ProjectService.Domain.Common;

namespace ProjectService.Application.DTOs;

public class ProjectDto
{
    public Guid Id { get; set; }
    public DetailsDto Details { get; set; }
    public Guid OwnerId { get; set; }
    public ICollection<ComponentDto> Components { get; set; }
    public Guid WorkflowId { get; set; }
    public ICollection<ProjectUserDto> ProjectUsers { get; set; }
    public ProjectStatus ProjectStatus { get; set; }
}

public class ProjectUserDto
{
    public Guid UserId { get; set; }
    public Guid ProjectId { get; set; }
    public UserRole UserRole { get; set; }
}

public class DetailsDto
{
    public string Name { get; set; }
    public string Description { get; set; }
}

