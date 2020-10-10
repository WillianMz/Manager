using Manager.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Manager.Infra.Data.Mapeamentos
{
    public class PrioridadeMap : IEntityTypeConfiguration<Prioridade>
    {
        public void Configure(EntityTypeBuilder<Prioridade> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Descricao).IsRequired();

            //alimenta a tabela com dados iniciais ao cria-la
            builder.HasData(
                new Prioridade() { Id = 1, Descricao = "Baixo" },
                new Prioridade() { Id = 2, Descricao = "Normal" },
                new Prioridade() { Id = 3, Descricao = "Alto" },
                new Prioridade() { Id = 4, Descricao = "Urgente" }
            );
        }
    }
}