using Manager.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Manager.Infra.Data.Mapeamentos
{
    public class UsuarioProjetoMap : IEntityTypeConfiguration<UsuarioProjeto>
    {
        public void Configure(EntityTypeBuilder<UsuarioProjeto> builder)
        {
            builder.HasKey(u => new { u.UsuarioId, u.ProjetoId });
        }
    }
}