using Microsoft.VisualStudio.TestTools.UnitTesting;
using TODO.Domain.Entities;

namespace Company.TestProject1;

[TestClass]
public class TodoItemTests
{
    public TodoItemTests()
    {
        _TodoItem = new TodoItem("Tarefa 1", DateTime.Now, "Andrebaltieri");
    }
    private readonly TodoItem _TodoItem;
    [TestMethod]
    public void Dada_uma_nova_tarefa_a_mesma_nao_deve_ser_concluida()
    {
        Assert.AreEqual(false, _TodoItem.Done);
    }
    [TestMethod]
    public void Dada_uma_nova_tarefa_existente_a_mesma_deve_ser_concluida()
    {
        _TodoItem.MarkAsDone();
        Assert.AreEqual(true, _TodoItem.Done);
    }
    [TestMethod]
    public void Dada_uma_nova_tarefa_existente_a_mesma_deve_ser_marcada_como_nao_concluida()
    {
        _TodoItem.MarkAsUndone();
        Assert.AreEqual(false, _TodoItem.Done);
    }
    [TestMethod]
    public void Dada_uma_nova_tarefa_existente_a_mesma_deve_ter_o_titulo_atualizado()
    {
        _TodoItem.UpdateTitle("Novo title");
        Assert.AreEqual("Novo title", _TodoItem.Title);
    }
}
