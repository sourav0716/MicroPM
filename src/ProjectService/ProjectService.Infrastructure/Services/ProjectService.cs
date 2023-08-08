using Microsoft.EntityFrameworkCore;
using ProjectService.Application.Common.Errors;
using ProjectService.Application.Common.Interfaces;
using ProjectService.Domain.Entity;
using ProjectService.Infrastructure.Persistence;

namespace ProjectService.Infrastructure.Services;


public class ProjectServices : IProjectService
{
    private readonly ProjectServiceDbContext _context;

    public ProjectServices(ProjectServiceDbContext context)
    {
        _context = context;
    }
    public async Task<Guid> AddProject(Project project)
    {
        _context.Add(project);
        await _context.SaveChangesAsync();
        return project.Id;
    }


    public async Task<bool> DeleteProjectById(Project project, CancellationToken cancellationToken)
    {
        _context.Remove(project);
        return await _context.SaveChangesAsync(cancellationToken) > 0;
    }


    public Task<List<Project>> GetAllProjectsAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<Project>? GetProjectByIdAsync(Guid projectId, CancellationToken cancellationToken)
    {
        return await _context.Projects.FirstOrDefaultAsync(p => p.Id == projectId, cancellationToken);
    }

    public async Task<Project>? GetProjectByNameAsync(string projectName, CancellationToken cancellationToken)
    {
        return await _context.Projects.FirstOrDefaultAsync(p => p.Details.Name == projectName, cancellationToken);
    }

    public Task<List<Project>> GetProjectsByNameAndIdAsync(string projectName, Guid projectId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<List<Project>> GetProjectsByNameAsync(string projectName, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<List<Project>> GetProjectsByNameOrIdAsync(string projectName, Guid projectId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateProject(Project project, CancellationToken cancellationToken)
    {
        _context.Update(project);
        await _context.SaveChangesAsync(cancellationToken);
    }
}