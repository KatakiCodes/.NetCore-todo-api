using Microsoft.VisualStudio.TestTools.UnitTesting;
using TODO.Domain.Entities;
using TODO.Domain.Queries;

namespace Company.TestProject1;

[TestClass]
public class TodoQueryTests
{
    private List<TodoItem> todoItems;

    public TodoQueryTests()
    {
        this.todoItems = [];
        this.todoItems.Add(new TodoItem("tarefa 1", DateTime.Now, "UserA"));
        this.todoItems.Add(new TodoItem("tarefa 2", DateTime.Now, "Nelson"));
        this.todoItems.Add(new TodoItem("tarefa 3", DateTime.Now, "UserA"));
        this.todoItems.Add(new TodoItem("tarefa 4", DateTime.Now, "Nelson"));
        this.todoItems.Add(new TodoItem("tarefa 5", DateTime.Now, "UserA"));
        this.todoItems.Add(new TodoItem("tarefa 6", DateTime.Now, "UserA"));
    }

    [TestMethod]
    public void Dada_a_consulta_apenas_deve_retornar_as_tarefas_do_user_nelson()
    {
        var result = this.todoItems.AsQueryable().Where(TodoQueries.GetAll("Nelson"));
        Assert.AreEqual(2, result.Count());
    }
}
