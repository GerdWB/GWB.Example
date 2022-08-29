namespace GWB.Example.Application.Core.Abstractions;

using GWB.Example.Application.Core.Results;
using MediatR;

public interface ICommandHandler<in TCommand>
    : IRequestHandler<TCommand, CommandResult>
        where TCommand : ICommand
{ }
