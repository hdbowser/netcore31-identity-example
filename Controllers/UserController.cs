using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using webapi1.Core;
using webapi1.Models;
using webapi1.Services;

namespace webapi1.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        public UserController (UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration) {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<JsonResult> PostAsync ([FromBody] User user) {
            await _userManager.CreateAsync (user, user.PasswordHash);
            await _userManager.AddClaimAsync (user, new Claim (ClaimTypes.Role, "admin"));
            return new JsonResult (true);
        }

        [HttpPost ("addtorole/{id}")]
        public async Task<JsonResult> AddToRole (string id, IdentityRole role) {
            var user = await _userManager.FindByIdAsync (id);
            var result = await _userManager.AddToRoleAsync (user, role.Name);
            if (result.Succeeded) {
                HttpContext.Response.StatusCode = StatusCodes.Status200OK;
                return new JsonResult (true);
            }
            HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            return new JsonResult (false);
        }

        [HttpGet ("UserList")]
        public JsonResult UserList () {
            var users = _userManager.Users.Select (x => new {
                x.Email,
                    x.Name,
                    x.UserName,
                    x.Id,
                    x.PhoneNumber,
                    x.IsAdmin
            });
            return new JsonResult (users);
        }

        [HttpGet ("SignIn")]
        public async Task<JsonResult> LogIn ([FromQuery] string username, string password) {
            var user = await _userManager.FindByNameAsync (username);

            if (user != null) {
                var result = await _signInManager.CheckPasswordSignInAsync (user, password, false);
                if (result.Succeeded) {
                    var claims = await _userManager.GetClaimsAsync (user);
                    var roles = await _userManager.GetRolesAsync (user);

                    foreach (var item in roles) {
                        claims.Add (new Claim (ClaimTypes.Role, item));
                    }

                    claims.Add (new Claim (ClaimTypes.Name, user.UserName));
                    claims.Add (new Claim (ClaimTypes.NameIdentifier, user.Id));
                    claims.Add (new Claim (ClaimTypes.DateOfBirth, "15"));

                    var tokenGen = new TokenGenerator (_configuration);
                    var token = tokenGen.CreateToken (user, claims.ToList ());
                    return new JsonResult (new {
                        Data = token,
                            Success = false,
                            Message = result.ToString ()
                    });
                } else {
                    HttpContext.Response.StatusCode = StatusCodes.Status403Forbidden;
                    return new JsonResult (new {
                        Data = "",
                            Success = false,
                            Message = result.ToString ()
                    });
                }
            } else {
                HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                return new JsonResult (new {
                    Data = "",
                        Success = false,
                        Message = "User doesm't exists"
                });
            }
        }
    }
}