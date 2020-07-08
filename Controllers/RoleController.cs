using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using webapi1.Models;
using webapi1.Services;

namespace webapi1.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase {
        private readonly RoleManager<IdentityRole> _roleManager;
        public RoleController (RoleManager<IdentityRole> roleManager) {
            _roleManager = roleManager;
        }

        [HttpPost]
        public async Task<JsonResult> PostAsync ([FromBody] IdentityRole role) {
            await _roleManager.CreateAsync (role);
            return new JsonResult (true);
        }

    }
}