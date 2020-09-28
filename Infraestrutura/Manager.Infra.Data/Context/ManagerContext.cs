using Manager.Domain.Entidades;
using Manager.Infra.Data.Mapeamentos;
using Microsoft.EntityFrameworkCore;

namespace Manager.Infra.Data.Context
{
    public class ManagerContext : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Documento> Documentos { get; set; }
        public DbSet<Nota> Notas { get; set; }
        public DbSet<Prioridade> Prioridades { get; set; }
        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<Release> Releases { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UsuarioProjeto> UsuarioProjetos { get; set; }

        public ManagerContext(DbContextOptions options) : base(options)
        {
        }

        //configuração das tabelas pelo metodo de sobreposição, utilizando o FluentApi do EFCore
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoriaMap());
            modelBuilder.ApplyConfiguration(new DocumentoMap());
            modelBuilder.ApplyConfiguration(new NotaMap());
            modelBuilder.ApplyConfiguration(new PrioridadeMap());
            modelBuilder.ApplyConfiguration(new ProjetoMap());
            modelBuilder.ApplyConfiguration(new ReleaseMap());
            modelBuilder.ApplyConfiguration(new StatusMap());
            modelBuilder.ApplyConfiguration(new TicketMap());
            modelBuilder.ApplyConfiguration(new TipoUsuarioMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new UsuarioProjetoMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}