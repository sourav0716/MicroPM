using ProjectService.Domain.Entity;

namespace ProjectService.Application.Common.Interfaces;

public interface IWorkflowService
{
   public Task<Guid>  GetWorkflowByNameAsync(string Workflowname);
}