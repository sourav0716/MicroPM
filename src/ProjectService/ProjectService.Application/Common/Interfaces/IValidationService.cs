using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectService.Application.Common.Interfaces
{
    public interface IValidationService
    {
        public ValueTask<Guid> ValidateUser(string ownerName);
        public ValueTask<Guid> ValidateWorkflow(string workflowName);
        public ValueTask<Guid> ValidateUserGroup(string userGroupName);
    }
}