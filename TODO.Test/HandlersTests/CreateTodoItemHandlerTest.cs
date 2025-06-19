using Microsoft.VisualStudio.TestTools.UnitTesting;
using TODO.Domain.Commands;
using TODO.Domain.Handlers;
using TODO.Test.Repositories;

namespace Company.TestProject1;

[TestClass]
public class CreateTodoItemHandlerTest
{

    public CreateTodoItemHandlerTest()
    {
        _ValidCommand = new CreateTodoItemCommand("tarefa 1", "andrebaltieri", DateTime.Now);
        _IvalidCommand = new CreateTodoItemCommand("", "", DateTime.Now);
        _Handler =  new Handler(new FakeTodoItemRepository());
    }
    private readonly CreateTodoItemCommand _IvalidCommand;
    private readonly CreateTodoItemCommand _ValidCommand;
    private readonly Handler _Handler;


    [TestMethod]
    public void Dado_um_comando_invalido_deve_interromper_a_tarefa()
    {
        var result = (GenericCommandResult) _Handler.Handle(_IvalidCommand);
        Assert.AreEqual(false, result.Success);
    }
    [TestMethod]
    public void Dado_um_comando_valido_deve_criar_a_tarefa()
    {
        var result = (GenericCommandResult) _Handler.Handle(_ValidCommand);
        Assert.AreEqual(true, result.Success);
    }
}
