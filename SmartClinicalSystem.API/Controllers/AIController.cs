using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartClinicalSystem.Core.Queries.AI;
using System.Security.Claims;
using static SmartClinicalSystem.API.Contracts.Requests.AIRequest;

namespace SmartClinicalSystem.API.Controllers
{
    [Route("api/ai")]
    [ApiController]
    [Authorize]
    public class AIController(IMediator mediator) : ControllerBase
    {
        [HttpPost("diagnose")]
        public async Task<IActionResult> Diagnose([FromBody]DiagnoseRequest request)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await mediator.Send(new GetDiagnoseQuery(request.Symptoms, userId!));
            return Ok(result);
        }
    }
}
