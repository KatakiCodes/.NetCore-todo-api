using System;
using Microsoft.EntityFrameworkCore;
using TODO.Domain.Entities;
using TODO.Domain.Repositories;
using TODO.Infra.DataContexts;

namespace TODO.Infra.Repositories;

public class TodoRepository : ITodoItemRepository
{
    private readonly DataContext _DataContext;

    public TodoRepository(DataContext dataContext)
    {
        _DataContext = dataContext;
    }

    public void Create(TodoItem todoItem)
    {
        _DataContext.Todos.Add(todoItem);
        _DataContext.SaveChanges();
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
        _DataContext.Entry(todoItem).State = EntityState.Modified;
        _DataContext.SaveChanges();
    }
}
