using Flunt.Validations;
using Manager.Domain.Enums;
using Manager.Utilitario;
using System.Collections.Generic;

namespace Manager.Domain.Entidades
{
    public class Usuario : EntidadeBase
    {
        private List<Ticket> _tickets;
        private List<Ticket> _ticketsFinalizados;
        private List<Ticket> _ticketsCancelados;
        private List<Release> _releases;
        private List<ProjetoUsuario> _projetoUsuarios;

        //Para o EFCore
        protected Usuario() { }

        public Usuario(string nome, string login, string senha, string email)
        {
            Nome = nome?.Trim().ToUpper();
            Login = login?.Trim().ToLower();
            Senha = senha?.Trim();
            Email = email?.Trim().ToLower();
            Tipo = UsuarioEnum.Cliente;
            Ativo = false;

            ValidarSenha();
                
            _tickets = new List<Ticket>();
            _ticketsCancelados = new List<Ticket>();
            _ticketsFinalizados = new List<Ticket>();
            _releases = new List<Release>();
            _projetoUsuarios = new List<ProjetoUsuario>();

            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(nome, "Nome", "Nome do usuário inválido")
                .IsNotNullOrEmpty(login, "Login", "Informe um login")
                .IsNotNullOrEmpty(senha, "Senha", "Informe uma senha")
                .IsNotNullOrEmpty(email, "Email", "Informe um email")
            );

        }

        public int Id { get; private set; }
        public string Nome { get; private set; }        
        public string Login { get; private set; }
        public string Senha { get; private set; }
        public string Email { get; private set; }
        public bool Ativo { get; private set; }
        public UsuarioEnum Tipo { get; private set; }

        public virtual TipoUsuario TipoUsuario { get; private set; }

        //relacionamento 1 para N
        public virtual IReadOnlyCollection<Ticket> Tickets => _tickets;
        public virtual IReadOnlyCollection<Ticket> TicketsFinalizados => _ticketsFinalizados;
        public virtual IReadOnlyCollection<Ticket> TicketsCancelados => _ticketsCancelados;
        public virtual IReadOnlyCollection<Release> Releases => _releases;
        public virtual IReadOnlyCollection<ProjetoUsuario> ProjetoUsuarios => _projetoUsuarios;


        private void ValidarSenha()
        {
            if (Senha == Nome)
                AddNotification("Senha", "Senha não pode ser igual ao nome do usuário");

            if (Senha == Email)
                AddNotification("Senha", "Senha não pode ser o seu email de usuário");

            if (Senha == Login)
                AddNotification("Senha", "Senha não pode ser igual ao seu login de usuário");

            if (Senha.Length < 6)
                AddNotification("Senha", "A senha deve conter 6 ou mais caracteres!");

            Senha.CriptografarSenha();
        }

        public void AtivarDesativar(bool ativarDesativar)
        {
            Ativo = ativarDesativar;
        }

        public void Editar(string nome, string senha)
        {
            Nome = nome?.Trim().ToUpper();
            Senha = senha;

            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(nome, "Nome", "Informe o novo nome do usuário")
                .IsNotNullOrEmpty(senha,"Senha","Informe a senha do usuário")
            );

        }

        public void AlterarSenha(string senhaAtual, string novaSenha)
        {
            senhaAtual.CriptografarSenha();
            novaSenha.CriptografarSenha();

            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(senhaAtual, "Senha Atual", "Para alterar a senha é necessário informar a senha atual")
                .IsNotNullOrEmpty(novaSenha, "Nova Senha", "É necessário informar a nova senha")
            );

            if (senhaAtual == Senha)
            {
                if (novaSenha != Senha)
                    Senha = novaSenha;
                else
                    AddNotification("Senha", "A nova senha não pode ser a atual");
            }
            else
            {
                AddNotification("Senha", "A senha informada não confere com a atual, verifique");
            }            
        }

    }
}