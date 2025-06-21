using System;
using Microsoft.EntityFrameworkCore;
using TODO.Domain.Entities;
using TODO.Domain.Queries;
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
        return _DataContext.Todos.AsNoTracking()
        .Where(TodoQueries.GetAll(user))
        .OrderBy(c => c.Date);
    }

    public IEnumerable<TodoItem> GetAllDone(string user)
    {
        return _DataContext.Todos.AsNoTracking()
        .Where(TodoQueries.GetAll(user))
        .OrderBy(c => c.Date);
    }

    public IEnumerable<TodoItem> GetAllUndone(string user)
    {
        return _DataContext.Todos.AsNoTracking()
        .Where(TodoQueries.GetAll(user))
        .OrderBy(c => c.Date);
    }

    public TodoItem? GetById(string user, Guid id)
    {
        return _DataContext.Todos.FirstOrDefault(TodoQueries.GetById(user, id));
    }

    public IEnumerable<TodoItem> GetByPeriod(string user, DateTime date, bool done)
    {
        return _DataContext.Todos.AsNoTracking()
        .Where(TodoQueries.GetByPeriod(user, date,done))
        .OrderBy(c => c.Date);
    }

    public void Update(TodoItem todoItem)
    {
        _DataContext.Entry(todoItem).State = EntityState.Modified;
        _DataContext.SaveChanges();
    }
}
