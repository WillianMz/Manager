using Manager.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Manager.Infra.Data.Mapeamentos
{
    public class UsuarioAtivacaoMap : IEntityTypeConfiguration<UsuarioAtivacao>
    {
        public void Configure(EntityTypeBuilder<UsuarioAtivacao> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.DataValidade);
            builder.Property(a => a.HorasValidade);

            builder.HasOne(a => a.Usuario).WithMany(u => u.UsuarioAtivacoes);
        }
    }
}
