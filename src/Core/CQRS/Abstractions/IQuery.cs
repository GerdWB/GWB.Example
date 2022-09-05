namespace GWB.Example.Application.Core.Abstractions;

using MediatR;

public interface IQuery<T> : IRequest<QueryResult<T>>
{
}