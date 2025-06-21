using System;
using TODO.Domain.Entities;

namespace TODO.Domain.Repositories;

public interface ITodoItemRepository
{
    TodoItem GetById(Guid Id, string User);
    void Create(TodoItem todoItem);
    void Update(TodoItem todoItem);
    public IEnumerable<TodoItem> GetAll(string user);
    public IEnumerable<TodoItem> GetAllDone(string user);
    public IEnumerable<TodoItem> GetAllUndone(string user);
    public IEnumerable<TodoItem> GetByPeriod(string user, DateTime date, bool done);
}
