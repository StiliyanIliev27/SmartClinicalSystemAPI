using MediatR;

namespace BuildingBlock.BuildingBlocks.CQRS
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }
}
