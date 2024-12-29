using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechnicalAPI.CQRS;
using TechnicalAPI.DTO;

namespace TechnicalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MovsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("Mov")]
        public async Task<IActionResult> CreateMov([FromBody] MovDTO movDto)
        {
            if (movDto == null)
            {
                return BadRequest("Invalid data.");
            }

            var command = new CreateMovCommand(movDto);
            var result = await _mediator.Send(command);

            return Ok(result);
        }


        [HttpGet]
        [Route("GetMovs/{id:int}")]
        public async Task<ActionResult<List<MovDTO>>> GetAllMovs(int id)
        {
            var query = new GetAllMovsQuery(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
