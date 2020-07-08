using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using webapi1.Models;

namespace webapi1.Data {
    public class AppDbContext : IdentityDbContext<User> {
        public AppDbContext (DbContextOptions<AppDbContext> options) : base (options) { }
    }
}