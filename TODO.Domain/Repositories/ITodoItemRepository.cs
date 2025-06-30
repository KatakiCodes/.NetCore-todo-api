using System;
using TODO.Domain.Entities;

namespace TODO.Domain.Repositories;

public interface ITodoItemRepository
{
    void Create(TodoItem todoItem);
    void Update(TodoItem todoItem);
    public IEnumerable<TodoItem> GetAll(Guid user_id);
    public TodoItem GetById(Guid user_id, Guid id);
    public IEnumerable<TodoItem> GetAllDone(Guid user_id);
    public IEnumerable<TodoItem> GetAllUndone(Guid user_id);
    public IEnumerable<TodoItem> GetByPeriod(Guid user_id, DateTime date, bool done);
}
