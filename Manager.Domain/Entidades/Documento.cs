using Flunt.Validations;

namespace Manager.Domain.Entidades
{
    public class Documento : EntidadeBase
    {
        //Para o EFCore
        protected Documento() { }

        public Documento(string titulo, string url, Projeto projeto)
        {
            Titulo = titulo?.Trim().ToUpper();
            URL = url?.Trim().ToUpper();
            Projeto = projeto;

            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(titulo, "Titulo", "Não é permitido documento sem titulo")
                .IsNotNullOrEmpty(url, "URL", "Informe o endereço do documento")
            );
        }


        public int Id { get; private set; }
        public string Titulo { get; private set; }
        public string URL { get; private set; }
        public int ProjetoId { get; private set; }
        public virtual Projeto Projeto { get; private set; }

        //metodos
        public void Editar(string titulo, string url)
        {
            Titulo = titulo?.Trim().ToUpper();
            URL = url?.Trim().ToUpper();

            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(titulo, "Titulo", "Não é permitido documento sem título")
                .IsNotNullOrEmpty(url, "URL", "Informe o endereço do documento")
            );
        }

    }
}