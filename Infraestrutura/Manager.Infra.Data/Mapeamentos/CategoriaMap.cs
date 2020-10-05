using Manager.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Manager.Infra.Data.Mapeamentos
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Nome).IsRequired().HasMaxLength(45);

            builder.HasIndex(c => c.Nome).IsUnique();

            //relacionamento 1 para N
            //uma categoria possui varios tickts, 1 ticket pertence a 1 categoria
            builder.HasMany(c => c.Tickets).WithOne(t => t.Categoria);
        }
    }
}