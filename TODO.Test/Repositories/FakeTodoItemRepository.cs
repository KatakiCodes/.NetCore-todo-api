using System;
using TODO.Domain.Entities;
using TODO.Domain.Repositories;

namespace TODO.Test.Repositories;

public class FakeTodoItemRepository : ITodoItemRepository
{

    public TodoItem GetById(Guid Id, string User)
    {
        return new TodoItem("Tarefa aqui", DateTime.Now, "andrebaltieri");
    }

    public void Create(TodoItem todoItem)
    {
    }

    public void Update(TodoItem todoItem)
    {
    }

    public IEnumerable<TodoItem> GetAll(string user)
    {
        throw new NotImplementedException();
    }

    public TodoItem GetById(string user, Guid id)
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

    public IEnumerable<TodoItem> GetByPeriod(string user, DateTime date, bool done)
    {
        throw new NotImplementedException();
    }
}
