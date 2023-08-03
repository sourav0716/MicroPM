using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectService.Application.Common.Interfaces;

namespace ProjectService.Infrastructure.Services
{
    public class WorkflowService : IWorkflowService
    {
        public Task<Guid> GetWorkflowByNameAsync(string Workflowname)
        {
            throw new NotImplementedException();
        }
    }
}