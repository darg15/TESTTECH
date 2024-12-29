using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechnicalAPI.CQRS;
using TechnicalAPI.DTO;
using static TechnicalAPI.CQRS.PaymentsC;

namespace TechnicalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PaymentsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        [Route("GetPays/{id:int}")]
        public async Task<ActionResult<List<PaymentsDTO>>> GetAllPays(int id)
        {
            var query = new GetAllPaysQuery(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        [Route("Pay")]
        public async Task<IActionResult> CreatePay([FromBody] PaymentsDTO payDto)
        {
            if (payDto == null)
            {
                return BadRequest("Invalid data.");
            }

            var command = new CreatePayCommand(payDto);
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
