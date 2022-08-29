namespace GWB.Example.Application.Core.Abstractions;

using MediatR;
using Results;

public interface ICommand : IRequest<CommandResult>
{
}