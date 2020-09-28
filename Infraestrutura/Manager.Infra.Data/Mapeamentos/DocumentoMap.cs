using Manager.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Manager.Infra.Data.Mapeamentos
{
    public class DocumentoMap : IEntityTypeConfiguration<Documento>
    {
        public void Configure(EntityTypeBuilder<Documento> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Titulo).IsRequired().HasMaxLength(45);
            builder.Property(d => d.Conteudo).IsRequired().HasMaxLength(200);
            builder.HasIndex(d => d.teste).IsUnique();
        }
    }
}