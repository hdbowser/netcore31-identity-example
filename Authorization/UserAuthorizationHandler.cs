using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace webapi1.Authorization {
    public class UserAuthorizationHandler : AuthorizationHandler<UserRequeriment> {
        protected override Task HandleRequirementAsync (AuthorizationHandlerContext context, UserRequeriment requirement) {
            var claims = context.User.Claims.Where (x => x.Type == "can");
            if (claims.Count () == 0) {
                return Task.CompletedTask;
            }
            if (claims.Any (x => x.Value == requirement.ActionCode)) {
                context.Succeed (requirement);
            }
            return Task.CompletedTask;
        }
    }
}