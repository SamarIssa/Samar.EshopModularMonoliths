using MediatR;

namespace Shared.Contracts.CQRS;

public interface ICommand<out TResponse>:IRequest<TResponse>//Out force that Tresponse id return
{
}

public interface ICommand : ICommand<Unit>//unit as void
{

}
