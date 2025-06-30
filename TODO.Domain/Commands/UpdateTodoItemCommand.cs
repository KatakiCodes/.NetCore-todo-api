using System;
using Flunt.Notifications;
using Flunt.Validations;
using TODO.Domain.Commands.Contracts;

namespace TODO.Domain.Commands;

public class UpdateTodoItemCommand : Notifiable, ICommand
{
    public UpdateTodoItemCommand()
    {}
    public UpdateTodoItemCommand(Guid id, Guid user_id, string title, DateTime date)
    {
        Id = id;
        User_id = user_id;
        Title = title;
        Date = date;
    }

    public Guid Id { get; set; }
    public Guid User_id { get; set; }
    public string Title { get; set; }
    public DateTime Date { get; set; }
    public void Validate()
    {
        AddNotifications(
            new Contract()
                .Requires()
                .HasMinLen(Title, 3, "Title", "Especifique melhor a sua tarefa por favor!")
                .IsNotNull(User_id,"User", "Inválido!")
        );
    }
}
