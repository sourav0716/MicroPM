using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectService.Application.Common.Interfaces;
using ProjectService.Domain.Entity;

namespace ProjectService.Infrastructure.Services
{
    public class ProjectServices : IProjectService
    {
        public Task<Project> AddProject(Project project)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteProject(string projectName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteProjectById(Guid projectId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<Project>> GetAllProjectsAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Project> GetProjectByIdAsync(Guid projectId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Project> GetProjectByNameAsync(string projectName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
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

        public Task<bool> ProjectExists(string projectName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ProjectExistsById(Guid projectId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ProjectExistsByName(string projectName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ProjectExistsByNameAndId(string projectName, Guid projectId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Project> UpdateProject(Project project, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}