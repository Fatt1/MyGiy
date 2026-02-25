using Demo.Contract.Abstractions.Shared;
using MediatR;

namespace Demo.Contract.Abstractions.Messages
{
    public interface ICommand : IRequest<Result>
    {
    }

    public interface ICommand<TRepsonse> : IRequest<Result<TRepsonse>>
    {

    }
}
