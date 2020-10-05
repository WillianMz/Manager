using Flunt.Validations;
using Manager.Domain.Enums;
using System.Collections.Generic;

namespace Manager.Domain.Entidades
{
    public class Usuario : EntidadeBase
    {
        private List<Nota> _notas;
        private List<Ticket> _tickets;
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

            //Ativo = false;    
            _notas = new List<Nota>();
            _tickets = new List<Ticket>();
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
        public virtual IReadOnlyCollection<Nota> Notas => _notas;
        public virtual IReadOnlyCollection<Ticket> Tickets => _tickets;
        public virtual IReadOnlyCollection<Release> Releases => _releases;
        public virtual IReadOnlyCollection<ProjetoUsuario> ProjetoUsuarios => _projetoUsuarios;


        //METODOS

        private void ValidarSenha()
        {
            //fazer validação e criptografia da senha do usuario
        }

        public void Ativar()
        {

        }

        public void Desativa()
        {

        }

        public void Editar(string nome)
        {

        }

        public void AlterarSenha(string senhaAtual, string novaSenha)
        {
            if(senhaAtual == Senha)
            {
                if (novaSenha != Senha)
                {
                    //fazer criptografia e troca de senha
                }
                else
                    AddNotification("Senha", "A nova senha informada é a mesma da atual");
            }
            else
            {
                AddNotification("Senha", "A senha informada não confere com a atual, verifique");
            }

            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(senhaAtual, "Senha Atual","Para alterar a senha é necessário informar a senha atual")
                .IsNotNullOrEmpty(novaSenha, "Nova Senha","É necessário informar a nova senha")
            );
        }

    }
}