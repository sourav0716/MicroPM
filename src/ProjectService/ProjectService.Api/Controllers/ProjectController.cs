using Microsoft.AspNetCore.Mvc;
using ProjectService.Application.Projects.Commands.CreateProjectCommand;
using ProjectService.Domain.Entity;

namespace ProjectService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ApiControllerBase
    {
       [HttpPost]
        public async Task<ActionResult<Project>> Create(CreateProjectCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}