using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace webapi1.Authorization {
    public class AuthorizationPolicyProvider : DefaultAuthorizationPolicyProvider {
        private readonly AuthorizationOptions _options;
        public AuthorizationPolicyProvider (IOptions<AuthorizationOptions> options) : base (options) {
            _options = options.Value;
        }

        public override async Task<AuthorizationPolicy> GetPolicyAsync (string policyName) {
            return await base.GetPolicyAsync (policyName) ??
                new AuthorizationPolicyBuilder ()
                .AddRequirements (new UserRequeriment (policyName))
                .Build ();
        }
    }
}