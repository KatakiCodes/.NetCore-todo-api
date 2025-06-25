using System;

namespace TODO.Api.Services;

public interface ITokenService
{
    public string GenerateToken(string id, string name);
}
