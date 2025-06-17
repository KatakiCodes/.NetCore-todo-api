using System;
using Flunt.Notifications;
using Flunt.Validations;
using TODO.Domain.Commands.Contracts;

namespace TODO.Domain.Commands;

public class UpdateTodoItemCommand : Notifiable, ICommand
{
    public UpdateTodoItemCommand()
    {}
    public UpdateTodoItemCommand(string user, string title)
    {
        User = user;
        Title = title;
    }

    public string User { get; set; }
    public string Title { get; set; }
    public void Validate()
    {
        AddNotifications(
            new Contract()
                .Requires()
                .HasMinLen(Title, 3, "Title", "Especifique melhor a sua tarefa por favor!")
                .HasMinLen(User, 6, "User", "Inválido!")
        );
    }
}
