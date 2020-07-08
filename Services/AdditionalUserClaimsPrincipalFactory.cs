using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using webapi1.Models;

namespace webapi1.Services
{
    public class AdditionalUserClaimsPrincipalFactory
        : UserClaimsPrincipalFactory<User, IdentityRole> {
            public AdditionalUserClaimsPrincipalFactory (
                UserManager<User> userManager,
                RoleManager<IdentityRole> roleManager,
                IOptions<IdentityOptions> optionsAccessor) : base (userManager, roleManager, optionsAccessor) { }

            public async override Task<ClaimsPrincipal> CreateAsync (User user) {
                var principal = await base.CreateAsync (user);
                var identity = (ClaimsIdentity) principal.Identity;

                var claims = new List<Claim> ();
                if (user.IsAdmin) {
                    claims.Add (new Claim (ClaimTypes.Role, "admin"));
                } else {
                    claims.Add (new Claim (ClaimTypes.Role, "user"));
                }

                identity.AddClaims (claims);
                return principal;
            }
        }

}