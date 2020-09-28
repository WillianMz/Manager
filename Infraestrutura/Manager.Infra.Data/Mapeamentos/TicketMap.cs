using Manager.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Manager.Infra.Data.Mapeamentos
{
    public class TicketMap : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.DataAbertura).IsRequired();
            builder.Property(t => t.DataFechamento);
            builder.Property(t => t.Tempo);
            builder.Property(t => t.Descricao).IsRequired().HasMaxLength(300);
            builder.Property(t => t.Solucao).HasMaxLength(300);
            builder.Property(t => t.Arquivo).HasMaxLength(300);

            //relacionamento 
            builder.HasOne(t => t.Status);
            builder.HasOne(t => t.Prioridade);
        }
    }
}