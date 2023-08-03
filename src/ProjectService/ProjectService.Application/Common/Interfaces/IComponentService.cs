using ProjectService.Domain.Entity;

namespace ProjectService.Application.Common.Interfaces
{
    public interface IComponentService
    {
      public Task<Component>  GetComponentByNameAsync(string name);
        Task<List<Component>> GetComponentsByNameAsync(IEnumerable<string> enumerable);
    }
}