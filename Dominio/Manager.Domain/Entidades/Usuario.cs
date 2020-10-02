using Flunt.Validations;
using System.Collections.Generic;

namespace Manager.Domain.Entidades
{
    public class Usuario : EntidadeBase
    {
        private List<Nota> _notas;
        private List<Ticket> _tickets;
        private List<ProjetoUsuario> _projetoUsuarios;

        //Para o EFCore
        protected Usuario() { }

        public Usuario(string nome, string login, string senha, string email)
        {
            Nome = nome?.Trim().ToUpper();
            Login = login?.Trim().ToUpper();
            Senha = senha?.Trim();
            Email = email?.Trim().ToLower();

            //Ativo = false;    
            _notas = new List<Nota>();
            _tickets = new List<Ticket>();
            _projetoUsuarios = new List<ProjetoUsuario>();

            AddNotifications(new Contract()
                .Requires()
                .IsNullOrEmpty(Nome, "Nome", "Nome do usuário inválido")
                .IsNullOrEmpty(Login, "Login", "Informe um login")
                .IsNullOrEmpty(Senha, "Senha", "Informe uma senha")
                .IsNullOrEmpty(Email, "Email", "Informe um email")
            );

        }

        public int Id { get; private set; }
        public string Nome { get; private set; }        
        public string Login { get; private set; }
        public string Senha { get; private set; }
        public string Email { get; private set; }
        public bool Ativo { get; private set; }

        public virtual TipoUsuario TipoUsuario { get; private set; }

        //relacionamento 1 para N
        public virtual IReadOnlyCollection<Nota> Notas => _notas;
        public virtual IReadOnlyCollection<Ticket> Tickets => _tickets;
        public virtual IReadOnlyCollection<ProjetoUsuario> ProjetoUsuarios => _projetoUsuarios;


        //metodos
        public void AlterarSenha(string senhaAtual, string novaSenha)
        {

        }

    }
}