using System.Windows.Input;
using TODO.Domain.Commands;

namespace TODO.Test.CommandTests;

[TestClass]
public sealed class CreateTodoItemCommandTests
{
    private readonly CreateTodoItemCommand _invalidCommand = new ("", "", DateTime.Now);
    private readonly CreateTodoItemCommand _validCommand = new ("Tarefa 1", "andrebaltieri", DateTime.Now);
    [TestMethod]
    public void Dado_um_comando_invalido()
    {
        _invalidCommand.Validate();
        Assert.AreEqual(false, _invalidCommand.Valid);
    }
    [TestMethod]
    public void Dado_um_comando_valido()
    {
        _validCommand.Validate();
        Assert.AreEqual(true, _validCommand.Valid);
    }
}
