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
        public Task<Component> GetComponentByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<List<Component>> GetComponentsByNameAsync(IEnumerable<string> enumerable)
        {
            throw new NotImplementedException();
        }
    }
}