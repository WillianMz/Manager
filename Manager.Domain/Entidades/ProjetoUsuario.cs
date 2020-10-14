using Flunt.Validations;

namespace Manager.Domain.Entidades
{
    public class ProjetoUsuario : EntidadeBase
    {
        //Para EFCore
        protected ProjetoUsuario() { }

        public ProjetoUsuario(Projeto projeto, Usuario usuario, bool gerente)
        {
            Projeto = projeto;
            Usuario = usuario;
            Gerente = gerente;

            AddNotifications(new Contract()
                .Requires()
                .IsNotNull(projeto, "Projeto", "Informe o projeto")
                .IsNotNull(usuario, "Usuario", "Informe o usuário")
            );

        }

        public int ProjetoId { get; private set; }
        public int UsuarioId { get; private set; }
        public virtual Projeto Projeto { get; private set; }
        public virtual Usuario Usuario { get; private set; }
        public bool Gerente { get; private set; }
    }
}
