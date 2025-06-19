using System;
using TODO.Domain.Entities;

namespace TODO.Domain.Repositories;

public interface ITodoItemRepository
{
    TodoItem GetById(Guid Id, string User);
    void Create(TodoItem todoItem);
    void Update(TodoItem todoItem);
}
