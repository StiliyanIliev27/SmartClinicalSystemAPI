using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartClinicalSystem.Core.Commands.Users;
using SmartClinicalSystem.Core.Queries.Users;
using System.Security.Claims;

namespace SmartClinicalSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController(IMediator mediator) : ControllerBase
    {
        [HttpPost("send-health-log")]
        public async Task<IActionResult> SendHealthLogToDoctor([FromQuery]string userHealthLogId, [FromQuery]string doctorId)
        {
            var response = await mediator.Send(new SendHealthLogToDoctorCommand(userHealthLogId, doctorId));
            return Ok(response);
        }

        [HttpGet("notifications")]
        public async Task<IActionResult> GetNotifications()
        {
            var response = await mediator.Send(new GetNotificationsQuery(User.GetUserId()));
            return Ok(response);
        }
    }
}
