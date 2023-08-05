using ProjectService.Domain.Entity;

namespace ProjectService.Application.Common.Interfaces;

public interface IProjectService
{
    public Task<Project> AddProject(Project project);
    public Task<Project> GetProjectByNameAsync(string projectName,CancellationToken cancellationToken);

    public Task<Project> GetProjectByIdAsync(Guid projectId,CancellationToken cancellationToken);

    public Task<List<Project>> GetAllProjectsAsync(CancellationToken cancellationToken);

    public Task<Project> UpdateProject(Project project,CancellationToken cancellationToken);

    public Task<bool> DeleteProject(string projectName,CancellationToken cancellationToken);

    public Task<bool> DeleteProjectById(Guid projectId,CancellationToken cancellationToken);

    public Task<bool> ProjectExists(string projectName,CancellationToken cancellationToken);

    public Task<bool> ProjectExistsById(Guid projectId,CancellationToken cancellationToken);

    public Task<bool> ProjectExistsByName(string projectName,CancellationToken cancellationToken);

    public Task<bool> ProjectExistsByNameAndId(string projectName,Guid projectId,CancellationToken cancellationToken);

    public Task<List<Project>> GetProjectsByNameAsync(string projectName,CancellationToken cancellationToken);

    public Task<List<Project>> GetProjectsByNameAndIdAsync(string projectName,Guid projectId,CancellationToken cancellationToken);

    public Task<List<Project>> GetProjectsByNameOrIdAsync(string projectName,Guid projectId,CancellationToken cancellationToken);
}