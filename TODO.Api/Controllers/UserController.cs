using Microsoft.AspNetCore.Mvc;
using TODO.Api.DTOs.UserDtos;
using TODO.Domain.Commands;
using TODO.Domain.Handlers;

namespace TODO.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost("Register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Register(
        [FromServices] Handler handler,
        [FromBody] CreateUserDto userDto)
        {
            try
            {
                CreateUserCommand command = new (userDto.Name, userDto.Password, false, "");
                var commandResult = (GenericCommandResult)handler.Handle(command);
                return Created("User",commandResult);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
