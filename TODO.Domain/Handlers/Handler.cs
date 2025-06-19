using System;
using TODO.Domain.Commands;
using TODO.Domain.Commands.Contracts;
using TODO.Domain.Entities;
using TODO.Domain.Handlers.Contracts;
using TODO.Domain.Repositories;

namespace TODO.Domain.Handlers;

public class Handler :
    IHandler<CreateTodoItemCommand>,
    IHandler<UpdateTodoItemCommand>,
    IHandler<MarkTodoItemAsDoneCommand>,
    IHandler<MarkTodoItemAsUndoneCommand>
{
    private readonly ITodoItemRepository _TodoItemRepository;

    public Handler(ITodoItemRepository todoItemRepository)
    {
        _TodoItemRepository = todoItemRepository;
    }
    public ICommandResult Handle(CreateTodoItemCommand command)
    {
        //valida o command (fail fast validation)
        command.Validate();
        if (command.Invalid)
            return new GenericCommandResult(false, "Oops, parece que a sua tarefa está errada!", command.Notifications);
        //salva no banco
        var todo = new TodoItem(command.Title, command.Date, command.User);
        _TodoItemRepository.Create(todo);
        //retorna o resultado
        return new GenericCommandResult(true, "Tarefa criada com sucesso", todo);
    }

    public ICommandResult Handle(UpdateTodoItemCommand command)
    {
        //valida o command (fail fast validation)
        command.Validate();
        if (command.Invalid)
            return new GenericCommandResult(false, "Oops, parece que a sua tarefa está errada!", command.Notifications);

        //fazer rehidratação
        var todo = _TodoItemRepository.GetById(command.Id, command.User);

        //salva a tarefa
        _TodoItemRepository.Update(todo);

        //retorna o resultado
        return new GenericCommandResult(true, "Tarefa atualizada com sucesso", todo);
    }

    public ICommandResult Handle(MarkTodoItemAsDoneCommand command)
    {
        //valida o command (fail fast validation)
        command.Validate();
        if (command.Invalid)
            return new GenericCommandResult(false, "Oops, parece que a sua tarefa está errada!", command.Notifications);

        //fazer rehidratação
        var todo = _TodoItemRepository.GetById(command.Id, command.User);

        //Marca a tarefa como concluida
        todo.MarkAsDone();

        //salva a tarefa no banco
        _TodoItemRepository.Update(todo);

        //retorna o resultado
        return new GenericCommandResult(true, "Tarefa concluida com sucesso", todo);
    }

    public ICommandResult Handle(MarkTodoItemAsUndoneCommand command)
    {
        //valida o command (fail fast validation)
        command.Validate();
        if (command.Invalid)
            return new GenericCommandResult(false, "Oops, parece que a sua tarefa está errada!", command.Notifications);

        //fazer rehidratação
        var todo = _TodoItemRepository.GetById(command.Id, command.User);
        todo.MarkAsUndone();
        //Altera a tarefa
        _TodoItemRepository.Update(todo);

        //retorna o resultado
        return new GenericCommandResult(true, "Tarefa concluida com sucesso", todo);
    }
}
