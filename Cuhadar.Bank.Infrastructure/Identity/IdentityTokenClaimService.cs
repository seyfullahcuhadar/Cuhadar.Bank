using Cuhadar.Bank.Application.Configuration.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.eShopWeb.ApplicationCore.Constants;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Cuhadar.Bank.Infrastructure.Identity
{
    public class IdentityTokenClaimService: ITokenClaimsService
    {
        private readonly UserManager<ApplicationUser> _userManager;

    

        public IdentityTokenClaimService(UserManager<ApplicationUser> userManager)
        {
            this._userManager = userManager;
        }

        public async Task<string> GetTokenAsync(string userName)
        {

            var user = await _userManager.FindByNameAsync(userName);
            var roles = await _userManager.GetRolesAsync(user);


            var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

            foreach (var userRole in roles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AuthorizationConstants.JWT_SECRET_KEY));

            var token = new JwtSecurityToken(
                issuer: AuthorizationConstants.VALID_ISSUER,
                audience: AuthorizationConstants.VALID_AUDIENCE,
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenString;

        }
    }
}
