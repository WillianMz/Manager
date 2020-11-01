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
            builder.Property(t => t.Titulo).IsRequired().HasMaxLength(30);
            builder.Property(t => t.Descricao).IsRequired().HasMaxLength(300);
            builder.Property(t => t.StatusAtual).IsRequired();
            builder.Property(t => t.PrioridadeAtual).IsRequired();
            builder.Property(t => t.DataFechamento);
            builder.Property(t => t.Solucao).HasMaxLength(300);
            builder.Property(t => t.Tempo);
            builder.Property(t => t.DataCancelamento);
            builder.Property(t => t.MotivoCancelamento).HasMaxLength(100);

            //relacionamentos
            builder.HasMany(t => t.Notas).WithOne(n => n.Ticket);
            builder.HasMany(t => t.Anexos).WithOne(a => a.Ticket);
            builder.HasOne(t => t.Categoria).WithMany(c => c.Tickets);
            builder.HasOne(t => t.Criador).WithMany(u => u.Tickets);
            builder.HasOne(t => t.UsuarioFechamento).WithMany(u => u.TicketsFinalizados);
            builder.HasOne(t => t.UsuarioCancelamento).WithMany(u => u.TicketsCancelados);
        }
    }
}