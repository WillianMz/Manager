using Flunt.Validations;
using System.Collections.Generic;

namespace Manager.Domain.Entidades
{
    public class Categoria : EntidadeBase
    {

        //para o EFCore
        protected Categoria()
        {
        }

        public Categoria(string nome)
        {
            //elvis operator (?.)
            /*
             * Essa sintaxe determina se valor é nulo. Se assim for,
             * os métodos Trim e ToUpper não serão invocados e você não lançará a famigerada exceção NullReferenceException.
            */
            Nome = nome?.Trim().ToUpper();           

            Tickets = new List<Ticket>();

            AddNotifications(new Contract()
                .Requires()
                .IsNullOrEmpty(Nome, "Nome", "O Nome da categoria não pode estar vazio!")
                .HasMinLen(Nome, 3, "Nome", "Nome deve conter pelo menos 3 caracteres ou mais")
                .HasMaxLen(Nome, 45, "Nome", "O nome deve conter até 45 caracteres!" )
            );
        }


        public int Id { get; private set; }
        public string Nome { get; private set; }

        public virtual IReadOnlyCollection<Ticket> Tickets { get; set; }
        
    }
}