using System;

namespace TODO.Domain.Entities;

public class TodoItem : Entity
{
    public TodoItem(string title, DateTime date, Guid user_id)
    {
        Title = title;
        Done = false;
        Date = date;
        User_id = user_id;
    }

    public string Title { get; private set; } = string.Empty;
    public bool Done { get; private set; }
    public DateTime Date { get; private set; }
    public Guid User_id { get; private set; }

    public void MarkAsDone()
    {
        this.Done = true;
    }
    public void MarkAsUndone()
    {
        this.Done = false;
    }
    public void Update(string title,DateTime date)
    {
        this.Title = title;
        this.Date = date;
    }
}
