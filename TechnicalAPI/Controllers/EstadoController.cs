using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static TechnicalAPI.CQRS.TransaccionesC;
using TechnicalAPI.DTO;
using static TechnicalAPI.CQRS.EstadoC;

namespace TechnicalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EstadoController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        [Route("GetEstado/{id:int}")]
        public async Task<ActionResult<List<EstadoDTO>>> GetEstadp(int id)
        {
            var query = new GetEstadoQuery(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
