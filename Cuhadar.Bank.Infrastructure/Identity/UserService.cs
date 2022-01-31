using Cuhadar.Bank.Application.Configuration.Identity;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace Cuhadar.Bank.Infrastructure.Identity
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly ITokenClaimsService tokenClaimService;

        public UserService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ITokenClaimsService tokenClaimService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.tokenClaimService = tokenClaimService;
        }
        public async Task<string> LoginAsync(string username, string password)
        {
            try
            {
                var user = await userManager.FindByNameAsync(username);
                var result = await signInManager.PasswordSignInAsync(user, password, false, true);
                if (result.Succeeded)
                {
                    var token = await tokenClaimService.GetTokenAsync(username);
                    return token;
                }
                throw new InvalidUsernameOrPasswordException();

            }
            catch (System.Exception)
            {

                throw new InvalidUsernameOrPasswordException();
            }
            

        }

        public async Task<string> RegisterAsync(string username, string password)
        {
            try
            {
                var appUser = new ApplicationUser { UserName = username };
                var result = await userManager.CreateAsync(appUser, password);
                if (result.Succeeded)
                {
                    return await tokenClaimService.GetTokenAsync(username);
                }
                throw new UserRegistrationFailedException(result);
            }
            catch (System.Exception e)
            {

                throw;
            }
          


        }
    }
}
