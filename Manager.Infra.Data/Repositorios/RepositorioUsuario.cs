using Manager.Domain.Entidades;
using Manager.Domain.Interfaces.Repositorios;
using Manager.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace Manager.Infra.Data.Repositorios
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        private readonly ManagerContext context;

        public RepositorioUsuario(ManagerContext managerContext)
        {
            context = managerContext;
        }

        public void Adicionar(Usuario entidade)
        {
            context.Usuarios.Add(entidade);
        }

        public void AdicionarLista(IEnumerable<Usuario> entidades)
        {
            context.Usuarios.AddRange(entidades);
        }

        public Usuario CarregarObjetoPeloID(int id)
        {
            Usuario usuario = context.Usuarios.FirstOrDefault(u => u.Id == id);
            return usuario;
        }

        public void Editar(Usuario entidade)
        {
            context.Usuarios.Update(entidade);
        }

        public bool Existe(Usuario entidade)
        {
            var existe = context.Usuarios.Any(u => u.Email == entidade.Email);
            return existe;
        }

        public bool ExisteEmail(string email)
        {
            var existe = context.Usuarios.Any(u => u.Email == email);
            return existe;
        }

        public Usuario ExisteUsuario(string email, string senha)
        {
            IQueryable<Usuario> user = context.Usuarios.Where(u => u.Email == email && u.Senha == senha);
            return (Usuario)user;
        }

        public IList<Usuario> ListarNomeEmOrdemCrescente()
        {
            List<Usuario> usuarios = context.Usuarios.OrderBy(u => u.Id).ToList();
            return usuarios;
        }

        public IList<Usuario> ListarNomeEmOrdemDecrescente()
        {
            List<Usuario> usuarios = context.Usuarios.OrderByDescending(u => u.Id).ToList();
            return usuarios;
        }

        public IList<Usuario> ListarPorNome(string nome)
        {
            List<Usuario> usuarios = context.Usuarios.OrderBy(u => u.Nome).ToList();
            return usuarios;
        }

        //public IQueryable<Usuario> ListarNomeEmOrdemCrescente()
        //{
        //    var usuarios = context.Usuarios.OrderBy(u => u.Nome);
        //    return usuarios;
        //}

        //public IQueryable<Usuario> ListarNomeEmOrdemDecrescente()
        //{
        //    var usuarios = context.Usuarios.OrderByDescending(u => u.Nome);
        //    return usuarios;
        //}

        //public IQueryable<Usuario> ListarPorNome(string nome)
        //{
        //    var usuariosPorNome = context.Usuarios.Where(u => u.Nome == nome);
        //    return usuariosPorNome;
        //}

        public IList<Usuario> ListarTodos()
        {
            var usuarios = context.Usuarios.ToList();
            return usuarios;
        }

        public Usuario ObterUsuarioPorEmail(string email)
        {
            Usuario usuario = context.Usuarios.FirstOrDefault(u => u.Email == email);
            return usuario;
        }

        public void Remover(Usuario entidade)
        {
            context.Usuarios.Remove(entidade);
        }

        public void RemoverLista(IEnumerable<Usuario> entidades)
        {
            context.Usuarios.RemoveRange(entidades);
        }

    }
}
