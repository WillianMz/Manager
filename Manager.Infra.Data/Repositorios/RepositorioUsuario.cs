using Manager.Domain.Entidades;
using Manager.Domain.Interfaces.Repositorios;
using Manager.Domain.Queries.DTOs;
using Manager.Domain.Queries.Interfaces;
using Manager.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace Manager.Infra.Data.Repositorios
{
    public class RepositorioUsuario : IRepositorioUsuario, IConsultaUsuario
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


        #region CONSULTAS

        public List<UsuarioDTO> Listar()
        {
            var usuarios = context.Usuarios.OrderBy(u => u.Id).ToList();
            List<UsuarioDTO> usuarioDTOs = new List<UsuarioDTO>();

            foreach (var u in usuarios)
            {
                UsuarioDTO usuarioDTO = new UsuarioDTO()
                {
                    Id = u.Id,
                    Nome = u.Nome,
                    Email = u.Email
                };

                usuarioDTOs.Add(usuarioDTO);
            }

            return usuarioDTOs;
        }

        public List<UsuarioDTO> ListarPorNome(string nome)
        {
            var usuarios = context.Usuarios.Where(u => u.Nome.Contains(nome)).ToList();
            usuarios.OrderBy(u => u.Nome);
            List<UsuarioDTO> usuarioDTOs = new List<UsuarioDTO>();

            foreach (var u in usuarios)
            {
                UsuarioDTO usuarioDTO = new UsuarioDTO()
                {
                    Id = u.Id,
                    Nome = u.Nome,
                    Email = u.Email
                };

                usuarioDTOs.Add(usuarioDTO);
            }

            return usuarioDTOs;
        }

        public UsuarioDTO ProcurarPorID(int id)
        {
            var usuario = context.Usuarios.FirstOrDefault(u => u.Id == id);
            UsuarioDTO usuarioDTO = new UsuarioDTO()
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email
            };

            return usuarioDTO;
        }

        #endregion
    }
}
