using System;
using TODO.Domain.Commands;
using TODO.Domain.Commands.Contracts;
using TODO.Domain.Entities;
using TODO.Domain.Handlers.Contracts;
using TODO.Domain.Repositories;

namespace TODO.Domain.Handlers;

public class Handler :
    IHandler<CreateTodoItemCommand>,
    IHandler<CreateUserCommand>,
    IHandler<UpdateTodoItemCommand>,
    IHandler<MarkTodoItemAsDoneCommand>,
    IHandler<MarkTodoItemAsUndoneCommand>
{
    private readonly ITodoItemRepository _TodoItemRepository;
    private readonly IUserRepository _UserRepository;

    public Handler(ITodoItemRepository todoItemRepository, IUserRepository userRepository)
    {
        _TodoItemRepository = todoItemRepository;
        _UserRepository = userRepository;
    }
    public ICommandResult Handle(CreateTodoItemCommand command)
    {
        //valida o command (fail fast validation)
        command.Validate();
        if (command.Invalid)
            return new GenericCommandResult(false, "Oops, parece que a sua tarefa está errada!", command.Notifications);
        //salva no banco
        var todo = new TodoItem(command.Title, command.Date, command.User_id);
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
        var todo = _TodoItemRepository.GetById(command.User_id, command.Id);
        if(todo is null)
            return new GenericCommandResult(false, "Tarefa não localizada!", todo);
        todo.Update(command.Title,command.Date);

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
        var todo = _TodoItemRepository.GetById(command.User_id, command.Id);
        if (todo is null)
            return new GenericCommandResult(false, "tarefa não localiza!", todo);
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
        var todo = _TodoItemRepository.GetById(command.User_id, command.Id);
        if (todo is null)
            return new GenericCommandResult(false, "tarefa não localiza!", todo);
        todo.MarkAsUndone();
        //Altera a tarefa
        _TodoItemRepository.Update(todo);

        //retorna o resultado
        return new GenericCommandResult(true, "Tarefa concluida com sucesso", todo);
    }

    public ICommandResult Handle(CreateUserCommand command)
    {
        //valida o command (fail fast validation)
        command.Validate();
        if (command.Invalid)
            return new GenericCommandResult(false, "Oops, Erro ao validar o utilizador!", command.Notifications);

        //salva no banco
        var user = new User(command.Name, command.Password, command.IsExternal, command.External_id);
        _UserRepository.Create(user);
        //retorna o resultado
        return new GenericCommandResult(true, "Utilizador criado com sucesso", user);
    }
}
