using System;

namespace TODO.Domain.Entities;

public class TodoItem : Entity
{
    public TodoItem(string title, DateTime date, string user)
    {
        Title = title;
        Done = false;
        Date = date;
        User = user;
    }

    public string Title { get; private set; } = string.Empty;
    public bool Done { get; private set; }
    public DateTime Date { get; private set; }
    public string User { get; private set; } = string.Empty;

    public void MarkAsDone()
    {

    }
    public void MarkAsUndone()
    {

    }
    public void UpdateTitle()
    {
        
    }
}
