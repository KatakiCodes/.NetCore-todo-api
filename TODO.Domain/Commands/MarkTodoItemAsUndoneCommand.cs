using System;
using Flunt.Notifications;
using Flunt.Validations;
using TODO.Domain.Commands.Contracts;

namespace TODO.Domain.Commands;

public class MarkTodoItemAsUndoneCommand : Notifiable, ICommand
{
    public MarkTodoItemAsUndoneCommand()
    {}
    public MarkTodoItemAsUndoneCommand(Guid id, Guid user_id)
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
