using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechnicalAPI.CQRS;
using TechnicalAPI.Repo.User;

namespace TechnicalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository) { 
            _userRepository = userRepository;
        }

        //[HttpGet]
        //[Route("GetUserInfo")]
        //public async Task<IActionResult> GetUserInfo()
        //{
        //    var respuesta = _userRepository.GetUserInfo();

        //    if (respuesta is null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(respuesta);

        //}



        [HttpGet]
        [Route("GetUserInfo")]
        public async Task<IActionResult> GetUserInfo([FromServices] IMediator mediator)
        {
            var query = new GetUserInfoQuery();
            var respuesta = await mediator.Send(query);

            if (respuesta is null)
            {
                return NotFound();
            }

            return Ok(respuesta);
        }
    }
}
