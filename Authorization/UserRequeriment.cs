using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace webapi1.Authorization {
    public class UserRequeriment : IAuthorizationRequirement {
        public string ActionCode { get; set; }
        public UserRequeriment (string actionCode) {
            ActionCode = actionCode ??
                throw new ArgumentNullException (nameof (actionCode));
        }
    }
}