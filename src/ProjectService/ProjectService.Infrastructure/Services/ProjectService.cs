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

        public Task<Project> GetProjectByNameAsync(string projectName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}