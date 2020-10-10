using Manager.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Manager.Infra.Data.Mapeamentos
{
    public class TipoUsuarioMap : IEntityTypeConfiguration<TipoUsuario>
    {
        public void Configure(EntityTypeBuilder<TipoUsuario> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Descricao).IsRequired();

            //alimentacao de dados iniciais
            builder.HasData(
                new TipoUsuario() { Id = 1, Descricao = "Administrador" },
                new TipoUsuario() { Id = 2, Descricao = "Gerente" },
                new TipoUsuario() { Id = 3, Descricao = "MembroEquipe" },
                new TipoUsuario() { Id = 4, Descricao = "Cliente" }
            );
        }
    }
}