using System.Collections.Generic;
using System.Linq;

namespace Manager.Domain.Entidades
{
    public class Usuario : EntidadeBase
    {
        private IList<Nota> _notas;
        private IList<Ticket> _tickets;
        private IList<UsuarioProjeto> _usuariosProjeto;

        //Para o EFCore
        protected Usuario()
        {
        }

        public Usuario(string nome, string login, string senha, string email)
        {
            Nome = nome?.Trim().ToUpper();
            Login = login?.Trim().ToUpper();
            Senha = senha?.Trim();
            Email = email?.Trim().ToLower();

            //Ativo = false;    
            _notas = new List<Nota>();
            _tickets = new List<Ticket>();
            _usuariosProjeto = new List<UsuarioProjeto>();
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }        
        public string Login { get; private set; }
        public string Senha { get; private set; }
        public string Email { get; private set; }
        public bool Ativo { get; private set; }

        public virtual TipoUsuario TipoUsuario { get; private set; }

        //relacionamento 1 para N
        public virtual IReadOnlyCollection<Nota> Notas { get { return _notas.ToArray(); } }
        public virtual IReadOnlyCollection<Ticket> Tickets { get { return _tickets.ToArray(); } }
        public virtual IReadOnlyCollection<UsuarioProjeto> UsuarioProjetos { get { return _usuariosProjeto.ToArray(); } }
    }
}