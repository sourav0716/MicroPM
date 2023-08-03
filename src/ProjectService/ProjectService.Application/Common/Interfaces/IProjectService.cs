using ProjectService.Domain.Entity;

namespace ProjectService.Application.Common.Interfaces;

public interface IProjectService
{
    public Task<Project> AddProject(Project project);
    public Task<Project> GetProjectByNameAsync(string projectName,CancellationToken cancellationToken);
}