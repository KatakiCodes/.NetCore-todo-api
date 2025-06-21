using System;
using TODO.Domain.Entities;
using TODO.Domain.Repositories;

namespace TODO.Infra.Repositories;

public class TodoRepository : ITodoItemRepository
{
    public void Create(TodoItem todoItem)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<TodoItem> GetAll(string user)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<TodoItem> GetAllDone(string user)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<TodoItem> GetAllUndone(string user)
    {
        throw new NotImplementedException();
    }

    public TodoItem GetById(Guid Id, string User)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<TodoItem> GetByPeriod(string user, DateTime date, bool done)
    {
        throw new NotImplementedException();
    }

    public void Update(TodoItem todoItem)
    {
        throw new NotImplementedException();
    }
}
