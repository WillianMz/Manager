using Manager.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Manager.Infra.Data.Mapeamentos
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Nome).IsRequired().HasMaxLength(45);
            builder.Property(u => u.Login).IsRequired().HasMaxLength(100);
            builder.Property(u => u.Senha).IsRequired().HasMaxLength(150);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(100);
            builder.Property(u => u.Ativo).IsRequired();

            builder.HasOne(u => u.TipoUsuario);
            builder.HasMany(u => u.Notas).WithOne(n => n.Usuario);
            builder.HasMany(u => u.Tickets).WithOne(t => t.Usuario);
            builder.HasMany(u => u.UsuarioProjetos).WithOne(p => p.Usuario);
        }
    }
}