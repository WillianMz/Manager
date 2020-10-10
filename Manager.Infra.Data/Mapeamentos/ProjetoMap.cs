using Manager.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Manager.Infra.Data.Mapeamentos
{
    public class ProjetoMap : IEntityTypeConfiguration<Projeto>
    {
        public void Configure(EntityTypeBuilder<Projeto> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Descricao).IsRequired().HasMaxLength(200);

            //relacionamentos
            builder.HasMany(p => p.Documentos).WithOne(d => d.Projeto);
            builder.HasMany(p => p.Releases).WithOne(r => r.Projeto);
            builder.HasMany(p => p.Tickets).WithOne(t => t.Projeto);
        }
    }
}