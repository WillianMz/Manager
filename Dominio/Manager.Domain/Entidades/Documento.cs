using Flunt.Validations;

namespace Manager.Domain.Entidades
{
    public class Documento : EntidadeBase
    {
        //Para o EFCore
        protected Documento() { }

        public Documento(string titulo, string conteudo, Projeto projeto)
        {
            Titulo = titulo?.Trim().ToUpper();
            Conteudo = conteudo?.Trim().ToUpper();
            Projeto = projeto;

            AddNotifications(new Contract()
                .Requires()
                .IsNullOrEmpty(Titulo, "Titulo", "Não é permitido documento sem titulo")
                .IsNullOrEmpty(Conteudo, "Conteudo", "Coloque uma descrição breve sobre o documento")
            );
        }


        public int Id { get; private set; }
        public string Titulo { get; private set; }
        public string Conteudo { get; private set; }
        public string teste { get; private set; }

        public int ProjetoId { get; private set; }
        public virtual Projeto Projeto { get; private set; }

    }
}