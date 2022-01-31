using System.Threading.Tasks;

namespace Cuhadar.Bank.Application.Configuration.Identity
{
    public interface ITokenClaimsService
    {
        Task<string> GetTokenAsync(string userName);
    }


}
