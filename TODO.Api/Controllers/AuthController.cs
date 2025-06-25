using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Google.Apis.Auth;
using TODO.Api.Services;

namespace TODO.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _Configuration;

        public AuthController(IConfiguration configuration)
        {
            this._Configuration = configuration;
        }

        [HttpPost("google")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<string>> GoogleAuth(
        [FromServices] ITokenService tokenService, [FromBody]string tokenId)
        {
            try
            {
                var payload = await GoogleJsonWebSignature.ValidateAsync(tokenId, new GoogleJsonWebSignature.ValidationSettings
                {
                    Audience = [_Configuration["Authentication:Google:Client_Id"]]
                });
                string token = tokenService.GenerateToken(payload.Subject, payload.Name);
                return Ok(token);
            }
            catch (Exception ex)
            {
                return Unauthorized("Token invalido "+ex.Message);
            }
        }
    }
}
