using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Google.Apis.Auth;
using TODO.Api.Services;
using TODO.Domain.Repositories;
using TODO.Domain.Entities;
using TODO.Domain.Commands;
using TODO.Domain.Handlers;

namespace TODO.Api.Controllers
{
    [ApiController]
    [Route("api/auth")]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _Configuration;
        private readonly IUserRepository _Repository;

        public AuthController(IUserRepository _repository, IConfiguration configuration)
        {
            this._Configuration = configuration;
            this._Repository = _repository;
        }


        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult<string> Auth(
        [FromServices] IUserRepository userRepository,
        ITokenService tokenService,
        [FromBody] LoginCommand loginCommand)
        {
            try
            {
                var user = userRepository.Login(loginCommand.Name, loginCommand.Password);
                string token = tokenService.GenerateToken(user.Id.ToString(), user.Name);
                return Ok(token);
            }
            catch (Exception)
            {
                return Unauthorized("Utilizador ou Palavra-passe inválida");
            }
        }

        [HttpPost("google")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<string>> GoogleAuth(
        [FromServices] ITokenService tokenService, [FromBody] string tokenId)
        {
            try
            {
                //Validate Token_Id from external auth
                var payload = await GoogleJsonWebSignature.ValidateAsync(tokenId, new GoogleJsonWebSignature.ValidationSettings
                {
                    Audience = [_Configuration.GetSection("Authentication:Google:Client_Id").Value]
                });
                //Verify if this user is assigned
                User user = this._Repository.GetByExternalId(payload.Subject);
                user ??= this._Repository.Create(new(payload.Name, "", true, payload.Subject));

                string token = tokenService.GenerateToken(user.Id.ToString(), user.Name);
                return Ok(token);
            }
            catch (Exception)
            {
                return Unauthorized("Erro ao validar o token");
            }
        }
    }
}
