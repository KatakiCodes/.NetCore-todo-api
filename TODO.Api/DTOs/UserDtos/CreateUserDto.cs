using System;

namespace TODO.Api.DTOs.UserDtos;

public class CreateUserDto
{
    public CreateUserDto()
    {}
    public CreateUserDto(string name, string password)
    {
        Name = name;
        Password = password;
    }

    public string Name { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
