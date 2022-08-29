namespace GWB.Example.Application.Core.Abstractions;

using MediatR;
using Results;

public interface IQuery<T> : IRequest<QueryResult<T>>
{
}