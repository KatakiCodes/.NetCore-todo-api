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
}
