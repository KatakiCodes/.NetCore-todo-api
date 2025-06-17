using System;
using TODO.Domain.Commands.Contracts;

namespace TODO.Domain.Handlers.Contracts;

public interface IHandler<T> where T : ICommand
{
    ICommandResult Handle(T command);
}
