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
             * Essa sintaxe determina se valor � nulo. Se assim for,
             * os m�todos Trim e ToUpper n�o ser�o invocados e voc� n�o lan�ar� a famigerada exce��o NullReferenceException.
            */
            Nome = nome?.Trim().ToUpper();           

            Tickets = new List<Ticket>();

            AddNotifications(new Contract()
                .Requires()
                .IsNullOrEmpty(Nome, "Nome", "O Nome da categoria n�o pode estar vazio!")
                .HasMinLen(Nome, 3, "Nome", "Nome deve conter pelo menos 3 caracteres ou mais")
                .HasMaxLen(Nome, 45, "Nome", "O nome deve conter at� 45 caracteres!" )
            );
        }


        public int Id { get; private set; }
        public string Nome { get; private set; }

        public virtual IReadOnlyCollection<Ticket> Tickets { get; set; }
        
    }
}