using System;
using Flunt.Notifications;
using Flunt.Validations;

namespace TODO.Domain.Commands.Contracts;

public class MarkTodoItemAsDoneCommand : Notifiable,ICommand
{
    public MarkTodoItemAsDoneCommand()
    {}
    public MarkTodoItemAsDoneCommand(Guid id, Guid user_id)
    {
        Id = id;
        User_id = user_id;
    }

    public Guid Id { get; set; }
    public Guid User_id { get; set; }
    public void Validate()
    {
        AddNotifications(
            new Contract()
                .Requires()
                .IsNotNull(User_id, "User", "Inválido!")
        );
    }
}
