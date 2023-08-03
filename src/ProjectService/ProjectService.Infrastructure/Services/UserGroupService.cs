using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectService.Application.Common.Interfaces;

namespace ProjectService.Infrastructure.Services
{
    public class UserGroupService : IUserGroupService
    {
        public Task<Guid> GetUserGroupByNameAsync(string Name)
        {
            throw new NotImplementedException();
        }
    }
}