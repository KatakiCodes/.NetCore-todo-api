using System;
using Flunt.Notifications;
using TODO.Domain.Commands.Contracts;

namespace TODO.Domain.Commands;

public class CreateTodoItemCommand : ICommand
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
    }
}
