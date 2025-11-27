using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartClinicalSystem.Core.Commands.HealthLogs;
using SmartClinicalSystem.Core.Queries.HealthLogs;
using System.Security.Claims;
using static SmartClinicalSystem.API.Contracts.Requests.UserHealthLogRequest;
using static SmartClinicalSystem.Common.Constants.CommonConstants;

namespace SmartClinicalSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserHealthLogController(IMediator mediator, IMapper mapper) : ControllerBase
    {
        [HttpGet("{id}")]
        [Authorize(Roles = Doctor)]
        public async Task<IActionResult> GetHealthLogsForUser([FromRoute]string id)
        {
            var response = await mediator.Send(new GetHealthLogsQuery(id));
            return Ok(response);
        }

        [HttpGet("health-log/{id}")]
        public async Task<IActionResult> GetHealthLogById([FromRoute] string id)
        {
            var response = await mediator.Send(new GetHealthLogByIdQuery(id));
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetCurrentUserHealthLogs()
        {
            var response = await mediator.Send(new GetHealthLogsQuery(User.GetUserId()));
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateHealthLog([FromBody]CreateUserHealthLogRequest request)
        {
            var command = mapper.Map<CreateUserHealthCommand>(request);
            var response = await mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateHealthLog([FromBody]UpdateUserHealthLogRequest request)
        {
            var command = mapper.Map<UpdateUserHealthLogCommand>(request);
            var response = await mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHealthLog(string id)
        {
            var response = await mediator.Send(new DeleteUserHealthLogCommand(id));
            return Ok(response);
        }
    }
}
