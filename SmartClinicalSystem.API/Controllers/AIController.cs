using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartClinicalSystem.Core.Queries.AI;
using static SmartClinicalSystem.API.Contracts.Requests.AIRequest;

namespace SmartClinicalSystem.API.Controllers
{
    [Route("api/ai")]
    [ApiController]
    public class AIController(IMediator mediator) : ControllerBase
    {
        [HttpPost("diagnose")]
        public async Task<IActionResult> Diagnose([FromBody]DiagnoseRequest request)
        {
            var result = await mediator.Send(new GetDiagnoseQuery(request.Symptoms));
            return Ok(result);
        }
    }
}
