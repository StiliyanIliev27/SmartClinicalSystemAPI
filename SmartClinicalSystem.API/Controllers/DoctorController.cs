using Microsoft.AspNetCore.Authorization;
using static SmartClinicalSystem.Common.Constants.CommonConstants;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using SmartClinicalSystem.Core.Queries.Doctors;
using SmartClinicalSystem.Core.Commands.Doctors;
using static SmartClinicalSystem.API.Contracts.Requests.DoctorRequests;

namespace SmartClinicalSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = Doctor)]
    public class DoctorController(IMediator mediator) : ControllerBase
    {
        [HttpGet("medical-receipt")]
        public async Task<IActionResult> GetMedicalReceipts(
            [FromQuery] 
            int? pageNumber = 1, 
            int? pageSize = 10, 
            string? patientId = "",
            string? doctorId = "")
        {
            var result = await mediator.Send(new GetMedicalReceiptsQuery(pageNumber, pageSize, patientId, doctorId));
            return Ok(result);
        }

        [HttpPost("medical-receipt")]
        public async Task<IActionResult> CreateMedicalReceipt([FromBody] CreateMedicalReceiptRequest request)
        {
            var result = await mediator.Send(new CreateMedicalReceiptCommand(request.createMedicalReceiptDto));
            return Ok(result);
        }

        [HttpPut("medical-receipt")]
        public async Task<IActionResult> UpdateMedicalReceipt([FromBody] UpdateMedicalReceiptRequest request)
        {
            var result = await mediator.Send(new UpdateMedicalReceiptCommand(request.updateMedicalReceiptDto));
            return Ok(result);
        }

        [HttpPut("user-health-log-status/{userHealthLogToDoctorId}")]
        public async Task<IActionResult> UpdateUserHealthLogStatus([FromRoute]string userHealthLogToDoctorId)
        {
            var result = await mediator.Send(new UpdateUserHealthLogStatusCommand(userHealthLogToDoctorId));
            return Ok(result);
        }
    }
}
