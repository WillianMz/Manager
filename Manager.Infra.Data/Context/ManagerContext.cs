using Flunt.Notifications;
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
        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<Release> Releases { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UsuarioAtivacao> UsuarioAtivacoes { get; set; }
        public DbSet<ProjetoUsuario> ProjetoUsuarios { get; set; }
        public DbSet<Anexo> Anexos { get; set; }

        public ManagerContext(DbContextOptions options) : base(options)
        {
        }

        //configuração das tabelas pelo metodo de sobreposição, utilizando o FluentApi do EFCore
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();

            modelBuilder.ApplyConfiguration(new CategoriaMap());
            modelBuilder.ApplyConfiguration(new DocumentoMap());
            modelBuilder.ApplyConfiguration(new NotaMap());
            modelBuilder.ApplyConfiguration(new ProjetoMap());
            modelBuilder.ApplyConfiguration(new ReleaseMap());
            modelBuilder.ApplyConfiguration(new TicketMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new UsuarioAtivacaoMap());
            modelBuilder.ApplyConfiguration(new ProjetoUsuarioMap());
            modelBuilder.ApplyConfiguration(new AnexoMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}