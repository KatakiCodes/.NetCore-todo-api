using Flunt.Notifications;
using Flunt.Validations;
using TODO.Domain.Commands.Contracts;

namespace TODO.Domain.Commands;

public class LoginCommand : Notifiable, ICommand
{
    public LoginCommand(string name, string password)
    {
        Name = name;
        Password = password;
    }

    public string Name { get; set; }
    public string Password { get; set; }

    public void Validate()
    {
        AddNotifications(
            new Contract()
                .Requires()
                .IsNotNullOrEmpty(Name,"Name", "Nome do utilizador deve ser informado!")
                .IsNotNullOrEmpty(Password,"Password", "A palavra-passe do utilizador deve ser informada!")
        );
    }
}
