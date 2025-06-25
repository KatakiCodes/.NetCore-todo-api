using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace TODO.Api.Services;

public class TokenService : ITokenService
{
    private readonly JwtSecurityTokenHandler _TokenHandler;
    private readonly IConfiguration _configuration;
    private readonly string? _SecretKey;

    public TokenService(IConfiguration configuration)
    {
        this._TokenHandler = new JwtSecurityTokenHandler();
        this._configuration = configuration;
        this._SecretKey = configuration["Jwt:SecretKey"];
    }
    public string GenerateToken(string id, string name)
    {
        //Create symmetric key
        var symmetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_SecretKey));
        //Get claim collection
        var claims = new List<Claim>()
        {
            new (JwtRegisteredClaimNames.Sub, id),
            new (JwtRegisteredClaimNames.Name, name),
        };
        //create token descriptor
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            SigningCredentials = new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256Signature),
            Expires = DateTime.UtcNow.AddHours(1)
        };
        var token = this._TokenHandler.CreateToken(tokenDescriptor);
        return this._TokenHandler.WriteToken(token);
    }
}
