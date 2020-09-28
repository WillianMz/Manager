using Manager.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Manager.Infra.Data.Mapeamentos
{
    public class ProjetoUsuarioMap : IEntityTypeConfiguration<ProjetoUsuario>
    {
        public void Configure(EntityTypeBuilder<ProjetoUsuario> builder)
        {
            builder.HasKey(x => new { x.ProjetoId, x.UsuarioId });

            builder.HasOne(up => up.Projeto).WithMany(pu => pu.ProjetoUsuarios).HasForeignKey(up => up.ProjetoId);
            builder.HasOne(up => up.Usuario).WithMany(up => up.ProjetoUsuarios).HasForeignKey(up => up.UsuarioId);
        }
    }
}
