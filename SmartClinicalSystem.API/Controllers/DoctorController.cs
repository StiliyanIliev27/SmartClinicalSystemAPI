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
        [HttpGet("patients")]
        public async Task<IActionResult> GetPatients()
        {
            // Placeholder for actual implementation
            return Ok(new { message = "List of patients accessible by doctors." });
        }

        [HttpPost("register-patient")]
        public async Task<IActionResult> RegisterPatient()
        {
            return Ok(new { message = "Patient registered successfully." });
        }

        [HttpGet("appointments")]
        public async Task<IActionResult> GetAppointments()
        {
            return Ok(new { message = "List of appointments for the doctor." });
        }

        [HttpPost("appointments")]
        public async Task<IActionResult> ScheduleAppointment()
        {
            return Ok(new { message = "Appointment scheduled successfully." });
        }

        [HttpPut("appointments")]
        public async Task<IActionResult> UpdateAppointment()
        {
            return Ok(new { message = "Appointment updated successfully." });
        }

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
    }
}
