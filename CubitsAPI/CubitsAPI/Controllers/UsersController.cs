using CubitsApplication.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CubitsAPI.Controllers
{
    [ApiController]
    [Route("/api/users")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(
            IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetList()
        {
            var request = new GetUserListRequest();
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet]
        [Route("{Name}")]
        public async Task<IActionResult> GetByName([FromRoute] GetUserByNameRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}