using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using webapi1.Models;

namespace webapi1.Configurations {
    public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria> {
        public void Configure (EntityTypeBuilder<Categoria> builder) {
            builder.HasKey (x => x.Id)
                .HasName ("PRIMARY");
        }
    }
}