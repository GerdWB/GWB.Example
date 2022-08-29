namespace GWB.Example.Application.Core.Abstractions;

using MediatR;
using Results;

public interface ICommandHandler<in TCommand>
    : IRequestHandler<TCommand, CommandResult>
    where TCommand : ICommand
{
}