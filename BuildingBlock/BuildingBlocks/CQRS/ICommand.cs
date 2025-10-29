using MediatR;

namespace BuildingBlock.BuildingBlocks.CQRS
{
    public interface ICommand : IRequest
    {
    }

    public interface ICommand<out TResponse> : IRequest<TResponse>
        where TResponse : notnull
    {
    }
}
