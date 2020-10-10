using Manager.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Manager.Infra.Data.Mapeamentos
{
    public class NotaMap : IEntityTypeConfiguration<Nota>
    {
        public void Configure(EntityTypeBuilder<Nota> builder)
        {
            builder.HasKey(n => n.Id);
            builder.Property(n => n.Titulo).IsRequired().HasMaxLength(45);
            builder.Property(n => n.Descricao).IsRequired().HasMaxLength(400);
            builder.Property(n => n.DataDaNota).IsRequired();            
        }
    }
}