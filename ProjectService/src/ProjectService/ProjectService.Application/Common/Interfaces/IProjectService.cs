using ProjectService.Domain.Entity;

namespace ProjectService.Application.Common.Interfaces;

public interface IProjectService
{
    public  Task<Guid> AddProject(Project project);
    public Task<Project>? GetProjectByNameAsync(string projectName,CancellationToken cancellationToken);

    public Task<Project>? GetProjectByIdAsync(Guid projectId,CancellationToken cancellationToken);

    public Task<List<Project>> GetAllProjectsAsync(CancellationToken cancellationToken);

    public Task UpdateProject(Project project,CancellationToken cancellationToken);
    public Task<bool> DeleteProjectById(Project project,CancellationToken cancellationToken);
   
}