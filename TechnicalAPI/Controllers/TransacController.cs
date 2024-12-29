using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static TechnicalAPI.CQRS.PaymentsC;
using TechnicalAPI.DTO;
using static TechnicalAPI.CQRS.TransaccionesC;

namespace TechnicalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransacController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TransacController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        [Route("GetTransac/{id:int}")]
        public async Task<ActionResult<List<TransaccionesDTO>>> GetTransacciones(int id)
        {
            var query = new GetTransaccionesQuery(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
