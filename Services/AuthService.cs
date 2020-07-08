using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using webapi1.Core;
using webapi1.Models;

namespace webapi1.Services {
    public class AuthService {
        private User user;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public AuthService (UserManager<User> userManager, SignInManager<User> signInManager) {
            _userManager = userManager;
            _signInManager = signInManager;
            this.user = new User ();
        }
        public async Task<Result> Login (string username, string password) {
            Result r = new Result ();
            user = await _userManager.FindByNameAsync (username);
            if (user != null) {
                var result = await _signInManager.CheckPasswordSignInAsync (user, password, false);
                if (!result.Succeeded) {
                    r.Errors.Add (result.ToString ());
                }
            } else {
                r.Errors.Add ("User not found.");
            }
            return r;
        }
        public User GetUser () {
            return this.user;
        }

    }
}