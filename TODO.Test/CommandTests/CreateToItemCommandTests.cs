using TODO.Domain.Commands;

namespace TODO.Test.CommandTests;

[TestClass]
public sealed class CreateTodoItemCommandTests
{
    [TestMethod]
    public void Dado_um_comando_invalido()
    {
        var command = new CreateTodoItemCommand("", "", DateTime.Now);
        command.Validate();
        Assert.AreEqual(false, command.Valid);
    }
    [TestMethod]
    public void Dado_um_comando_valido()
    {
        var command = new CreateTodoItemCommand("Tarefa 1", "andrebaltieri", DateTime.Now);
        command.Validate();
        Assert.AreEqual(true, command.Valid);
    }
}
