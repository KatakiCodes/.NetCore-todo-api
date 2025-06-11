using System;
using Flunt.Notifications;
using Flunt.Validations;
using TODO.Domain.Commands.Contracts;

namespace TODO.Domain.Commands;

public class CreateTodoItemCommand : Notifiable,ICommand
{
    public CreateTodoItemCommand()
    {}

    public CreateTodoItemCommand(string title, string user, DateTime date)
    {
        Title = title;
        User = user;
        Date = date;
    }

    public string Title { get; set; } = string.Empty;
    public string User { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public void Validate()
    {
        AddNotifications(
            new Contract()
                .Requires()
                .HasMinLen(Title, 3, "Title", "Descreva melhor a sua tarefa por favor!")
                .HasMinLen(User, 6, "User", "Inválido!")
        );
    }
}
