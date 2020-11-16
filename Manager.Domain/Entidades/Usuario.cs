using Flunt.Validations;
using Manager.Domain.Enums;
using Manager.Infra.Utilitario;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Manager.Domain.Entidades
{
    public class Usuario : EntidadeBase
    {
        private readonly List<Ticket> _tickets;
        private readonly List<Ticket> _ticketsFinalizados;
        private readonly List<Ticket> _ticketsCancelados;
        private readonly List<Release> _releases;
        private readonly List<ProjetoUsuario> _projetoUsuarios;
        private readonly List<UsuarioAtivacao> _usuarioAtivacoes;

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
                
            _tickets = new List<Ticket>();
            _ticketsCancelados = new List<Ticket>();
            _ticketsFinalizados = new List<Ticket>();
            _releases = new List<Release>();
            _projetoUsuarios = new List<ProjetoUsuario>();
            _usuarioAtivacoes = new List<UsuarioAtivacao>();

            ValidarSenha();
            GerarAtivacao(this);

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

        //relacionamento 1 para N
        public virtual IReadOnlyCollection<Ticket> Tickets => _tickets;
        public virtual IReadOnlyCollection<Ticket> TicketsFinalizados => _ticketsFinalizados;
        public virtual IReadOnlyCollection<Ticket> TicketsCancelados => _ticketsCancelados;
        public virtual IReadOnlyCollection<Release> Releases => _releases;
        public virtual IReadOnlyCollection<ProjetoUsuario> ProjetoUsuarios => _projetoUsuarios;
        public virtual IReadOnlyCollection<UsuarioAtivacao> UsuarioAtivacoes => _usuarioAtivacoes;


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

            Senha = Senha.CriptografarSenha();
        }

        private void GerarAtivacao(Usuario usuario)
        {
            UsuarioAtivacao usuarioAtivacao = new UsuarioAtivacao(usuario);
            _usuarioAtivacoes.Add(usuarioAtivacao);
        }

        public void AtivarDesativar(bool ativarDesativar)
        {
            Ativo = ativarDesativar;
        }

        public void Ativar(string codigo)
        {
            var dataAtual = DateTime.Now;
            var usuarioAtivacao = _usuarioAtivacoes.FirstOrDefault(c => c.CodigoAtivacao == codigo);

            if (usuarioAtivacao != null)
            {
                if (usuarioAtivacao.DataValidade <= dataAtual)
                    Ativo = true;
                else
                    AddNotification("Ativação", "Código de ativação expirado. Solicite ao administrador um novo código");
            }
            else
                AddNotification("Ativação de usuário", "Código de ativação inválido");
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

        public void AlterarTipoDeUsuario(UsuarioEnum tipoUsuario)
        {
            Tipo = tipoUsuario;
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