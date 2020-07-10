 using Microsoft.AspNetCore.Authorization;

 namespace webapi1.Authorization {
     internal class MinimumAgeRequirement : IAuthorizationRequirement {
         public int Age { get; private set; }
         public MinimumAgeRequirement (int age) { Age = age; }
     }
 }