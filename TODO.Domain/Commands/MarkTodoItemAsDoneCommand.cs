using System;
using Flunt.Notifications;
using Flunt.Validations;

namespace TODO.Domain.Commands.Contracts;

public class MarkTodoItemAsDoneCommand : Notifiable,ICommand
{
    public Guid Id { get; set; }
    public string User { get; set; } = string.Empty;
    public void Validate()
    {
        AddNotifications(
            new Contract()
                .Requires()
                .HasMinLen(User, 6, "User", "Inválido!")
        );
    }
}
