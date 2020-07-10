using System;
using Microsoft.AspNetCore.Authorization;
using webapi1.Core;

namespace webapi1.Authorization {
    [AttributeUsage (AttributeTargets.Method | AttributeTargets.Class, Inherited = false)]
    public class UserCanAttribute : AuthorizeAttribute {
        public UserCanAttribute (Actions action) : base (((int) action).ToString ()) { }
    }

}