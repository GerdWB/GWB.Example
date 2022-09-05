namespace GWB.Example.Application.Core.Abstractions;

using MediatR;

public interface ICommand : IRequest<CommandResult>
{
}