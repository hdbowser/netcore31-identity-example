using System;
using Microsoft.AspNetCore.Identity;

namespace webapi1.Models {
    public class User : IdentityUser {
        public string Name { get; set; }

        public string LastName { get; set; }
        public bool IsAdmin { get; set; }
        public int CategoriaID { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}