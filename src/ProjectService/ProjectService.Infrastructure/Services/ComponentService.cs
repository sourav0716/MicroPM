using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectService.Application.Common.Interfaces;
using ProjectService.Domain.Entity;

namespace ProjectService.Infrastructure.Services
{
    public class ComponentService : IComponentService
    {
        public Task<Guid> GetComponentByNameAsync(string componentName, Guid projectId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<Component>> GetComponentsByNameAsync(IEnumerable<string> enumerable, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}