using Manager.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Manager.Infra.Data.Mapeamentos
{
    public class StatusMap : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Descricao).IsRequired();

            //alimentacao inicial de dados
            builder.HasData(
                new Status() { Id = 1, Descricao = "Aberto" },
                new Status() { Id = 2, Descricao = "EmAndamento" },
                new Status() { Id = 3, Descricao = "Concluido" },
                new Status() { Id = 4, Descricao = "Cancelado" }
            );
        }
    }
}