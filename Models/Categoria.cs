using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi1.Models {
    public class Categoria {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}