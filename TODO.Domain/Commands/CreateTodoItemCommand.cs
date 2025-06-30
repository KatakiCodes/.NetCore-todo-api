using System;
using Flunt.Notifications;
using Flunt.Validations;
using TODO.Domain.Commands.Contracts;

namespace TODO.Domain.Commands;

public class CreateTodoItemCommand : Notifiable,ICommand
{
    public CreateTodoItemCommand()
    {}

    public CreateTodoItemCommand(string title, Guid user_id, DateTime date)
    {
        Title = title;
        User_id = user_id;
        Date = date;
    }

    public string Title { get; set; } = string.Empty;
    public Guid User_id { get; set; }
    public DateTime Date { get; set; }
    public void Validate()
    {
        AddNotifications(
            new Contract()
                .Requires()
                .HasMinLen(Title, 3, "Title", "Descreva melhor a sua tarefa por favor!")
                .IsNotNull(User_id, "User", "Inválido!")
        );
    }
}
