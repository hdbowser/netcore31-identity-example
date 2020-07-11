using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using webapi1.Models;

namespace webapi1.Configurations {
    public class UserConfiguration : IEntityTypeConfiguration<User> {
        public void Configure (EntityTypeBuilder<User> builder) {
            builder.HasOne (x => x.Categoria)
                .WithMany (c => c.Users)
                .HasForeignKey (x => x.CategoriaID)
                .HasConstraintName ("FK_UsuarioCategoria");
        }
    }
}