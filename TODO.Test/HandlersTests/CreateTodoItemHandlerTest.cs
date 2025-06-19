using Microsoft.VisualStudio.TestTools.UnitTesting;
using TODO.Domain.Commands;
using TODO.Domain.Handlers;
using TODO.Test.Repositories;

namespace Company.TestProject1;

[TestClass]
public class CreateTodoItemHandlerTest
{
    [TestMethod]
    public void Dado_um_comando_invalido_deve_interromper_a_tarefa()
    {
        var command = new CreateTodoItemCommand("", "", DateTime.Now);
        var handler = new Handler(new FakeTodoItemRepository());
        Assert.Fail();
    }
    [TestMethod]
    public void Dado_um_comando_valido_deve_criar_a_tarefa()
    {
        Assert.Fail();
    }
}
