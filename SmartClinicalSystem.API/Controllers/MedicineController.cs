using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartClinicalSystem.Core.Commands.Medicines;
using SmartClinicalSystem.Core.Queries.Medicines;
using static SmartClinicalSystem.API.Contracts.Requests.MedicineRequests;
using static SmartClinicalSystem.Common.Constants.CommonConstants;

namespace SmartClinicalSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController(IMediator mediator, IMapper mapper) : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMedicineById([FromRoute] string id)
        {
            var result = await mediator.Send(new GetMedicineByIdQuery(id));
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetMedicines([FromQuery] int? pageNumber = 1, [FromQuery] int? pageSize = 10)
        {
            var result = await mediator.Send(new GetMedicinesQuery(pageNumber, pageSize));
            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = $"{Doctor}, {Admin}")]
        public async Task<IActionResult> CreateMedicine([FromBody] CreateMedicineRequest request)
        {
            var command = mapper.Map<CreateMedicineCommand>(request);
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        [Authorize(Roles = $"{Doctor}, {Admin}")]
        public async Task<IActionResult> UpdateMedicine([FromBody]UpdateMedicineRequest request)
        {
            var command = mapper.Map<UpdateMedicineCommand>(request);
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = $"{Doctor}, {Admin}")]
        public async Task<IActionResult> DeleteMedicine([FromRoute]string id)
        {
            var result = await mediator.Send(new DeleteMedicineCommand(id));
            return Ok(result);
        }
    }
}
