using Demo.Contract.Abstractions.Shared;
using MediatR;

namespace Demo.Contract.Abstractions.Messages
{
    public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
        where TQuery : IQuery<TResponse>
    {
    }
}
