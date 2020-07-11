using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using webapi1.Configurations;
using webapi1.Models;

namespace webapi1.Data {
    public class AppDbContext : IdentityDbContext<User> {
        public virtual DbSet<Categoria> Categorias { get; set; }
        public AppDbContext (DbContextOptions<AppDbContext> options) : base (options) { }

        protected override void OnModelCreating (ModelBuilder builder) {
            builder.ApplyConfiguration (new UserConfiguration ());
            builder.ApplyConfiguration (new CategoriaConfiguration ());
            base.OnModelCreating (builder);
        }
    }
}