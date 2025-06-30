using System;
using Flunt.Notifications;
using Flunt.Validations;
using TODO.Domain.Commands.Contracts;

namespace TODO.Domain.Commands;

public class CreateUserCommand : Notifiable, ICommand
{
    public CreateUserCommand()
    { }

    public CreateUserCommand(string name, string password, bool isExternal, string? external_id)
    {
        Name = name;
        Password = password;
        IsExternal = isExternal;
        External_id = external_id;
    }

    public string Name { get; set; }
    public string Password { get; set; }
    public bool IsExternal { get; set; }
    public string? External_id { get; set; }

    public void Validate()
    {
        AddNotifications(
            new Contract()
                .Requires()
                .HasMinLen(Name, 3, "Name", "Nome do utilizador é pequeno demais")
                .HasMinLen(Password, 6, "Password", "A palavra-passe do utilizador deve conter no minimo 6 caracteres")
        );
    }
}
