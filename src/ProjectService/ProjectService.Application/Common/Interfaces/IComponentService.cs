using ProjectService.Domain.Entity;

namespace ProjectService.Application.Common.Interfaces;

public interface IComponentService
{
  public Task<Guid> GetComponentByNameAsync(
      string componentName, Guid projectId,
       CancellationToken cancellationToken);
  public Task<List<Component>> GetComponentsByNameAsync(
      IEnumerable<string> enumerable, CancellationToken cancellationToken);
}