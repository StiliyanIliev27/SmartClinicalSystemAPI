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
        [HttpGet("diagnose")]
        public async Task<IActionResult> Diagnose([FromBody]DiagnoseRequest request)
        {
            var result = await mediator.Send(new GetDiagnoseQuery(request.Symptoms, User.GetUserId()));
            return Ok(result);
        }

        [HttpGet("compare")]
        public async Task<IActionResult> Compare([FromQuery]CompareRequest request)
        {
            var result = await mediator.Send(new GetCompareQuery(request.FirstMedicineId, request.SecondMedicineId, request.Diagnosis, User.GetUserId()));
            return Ok(result);
        }

        [HttpGet("summary-check/{period}")]
        public async Task<IActionResult> SummaryCheck([FromRoute]int period)
        {
            var result = await mediator.Send(new GetSummaryCheckQuery(period, User.GetUserId()));
            return Ok(result);
        }


    }
}
