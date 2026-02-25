using Demo.Contract.Abstractions.Shared;
using MediatR;

namespace Demo.Contract.Abstractions.Messages
{
    public interface IQuery<TResponse> : IRequest<Result<TResponse>>
    {
    }



}
