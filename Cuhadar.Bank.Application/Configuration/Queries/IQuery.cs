using MediatR;

namespace Cuhadar.Bank.Application.Configuration.Queries
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {

    }
}