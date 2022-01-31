using System.Threading.Tasks;
using Cuhadar.Bank.Application.Configuration.Commands;

namespace Cuhadar.Bank.Application.Configuration.Processing
{
    public interface ICommandsScheduler
    {
        Task EnqueueAsync<T>(ICommand<T> command);
    }
}