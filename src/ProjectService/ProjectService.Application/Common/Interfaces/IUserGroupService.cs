using ProjectService.Domain.Entity;

namespace ProjectService.Application.Common.Interfaces;

public interface IUserGroupService
{
    public Task<Guid> GetUserGroupByNameAsync(string Name);
}