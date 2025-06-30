using System;

namespace TODO.Domain.Entities;

public class User : Entity
{
    public User(string name, string password, bool isExternal, string? external_id)
    {
        Name = name;
        IsExternal = isExternal;
        External_id = external_id;
        Password = password;
    }
    public string Name { get; private set; }
    public string Password { get; private set; }
    public string? External_id { get; private set; }
    public bool IsExternal { get; private set; }

    public void Update(string name)
    {
        Name = name;
    }
}
