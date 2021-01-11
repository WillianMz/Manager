using Flunt.Validations;
using System.Collections.Generic;

namespace Manager.Domain.Entidades
{
    public class Categoria : EntidadeBase
    {
        private readonly List<Ticket> _tickets;

        //para o EFCore
        protected Categoria() {}

        public Categoria(string nome)
        {
            //elvis operator (?.)
            /*
             * Essa sintaxe determina se valor é nulo. Se assim for,
             * os métodos Trim e ToUpper não serão invocados e você não lançará a famigerada exceção NullReferenceException.
            */
            Nome = nome?.Trim().ToUpper();           

            _tickets = new List<Ticket>();

            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(nome, "Nome", "O Nome da categoria não pode estar vazio!")
                .HasMinLen(nome, 3, "Nome", "Nome deve conter pelo menos 3 caracteres ou mais")
                .HasMaxLen(nome, 45, "Nome", "O nome deve conter até 45 caracteres!" )
            );
        }


        public int Id { get; private set; }
        public string Nome { get; private set; }

        public virtual IReadOnlyCollection<Ticket> Tickets => _tickets;


        //METODOS
        public void Editar(string novoNome)
        {
            if (Nome == novoNome)
                AddNotification("Nome", "O novo nome informado é o mesmo do alterior");
            else
                Nome = novoNome?.Trim().ToUpper();
            

            if (string.IsNullOrEmpty(novoNome))
                AddNotification("Nome", "Novo nome não pode ser vazio");

        }
        
    }
}