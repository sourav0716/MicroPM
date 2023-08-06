using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectService.Application.Common.Errors;
using ProjectService.Application.Common.Interfaces;

namespace ProjectService.Application.Common.Services
{
    public class ValidationService : IValidationService
    {
        private readonly IUserService _userService;
        private readonly IWorkflowService _workflowService;
        private readonly IUserGroupService _userGroupService;

        public ValidationService(IUserGroupService userGroupService,
            IWorkflowService workflowService,
            IUserService userService)
        {
            _userGroupService = userGroupService;
            _workflowService = workflowService;
            _userService = userService;
        }

       

        private async ValueTask<Guid> ValidateEntity(string entityName, Func<string, CancellationToken, Task<Guid>> getEntityFunc)
        {
            CancellationToken cancellationToken = new();
            var entityId = await getEntityFunc(entityName, cancellationToken).ConfigureAwait(false);
            return entityId == Guid.Empty ? throw new NotFoundException(entityName) : entityId;
        }
        public ValueTask<Guid> ValidateUser(string ownerName)
        {
            return ValidateEntity(ownerName, _userService.GetUserIdByUserNameAsync);
        }

        public ValueTask<Guid> ValidateUserGroup(string userGroupName)
        {
            return ValidateEntity(userGroupName, _userGroupService.GetUserGroupByNameAsync);
        }

        public ValueTask<Guid> ValidateWorkflow(string workflowName)
        {
            return ValidateEntity(workflowName, _workflowService.GetWorkflowByNameAsync);

        }

    }
}