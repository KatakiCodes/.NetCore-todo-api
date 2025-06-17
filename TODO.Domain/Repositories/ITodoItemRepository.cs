using System;
using TODO.Domain.Entities;

namespace TODO.Domain.Repositories;

public interface ITodoItemRepository
{
    void Create(TodoItem todoItem);
    void Update(TodoItem todoItem);
}
