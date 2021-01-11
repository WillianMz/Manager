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
             * Essa sintaxe determina se valor � nulo. Se assim for,
             * os m�todos Trim e ToUpper n�o ser�o invocados e voc� n�o lan�ar� a famigerada exce��o NullReferenceException.
            */
            Nome = nome?.Trim().ToUpper();           

            _tickets = new List<Ticket>();

            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(nome, "Nome", "O Nome da categoria n�o pode estar vazio!")
                .HasMinLen(nome, 3, "Nome", "Nome deve conter pelo menos 3 caracteres ou mais")
                .HasMaxLen(nome, 45, "Nome", "O nome deve conter at� 45 caracteres!" )
            );
        }


        public int Id { get; private set; }
        public string Nome { get; private set; }

        public virtual IReadOnlyCollection<Ticket> Tickets => _tickets;


        //METODOS
        public void Editar(string novoNome)
        {
            if (Nome == novoNome)
                AddNotification("Nome", "O novo nome informado � o mesmo do alterior");
            else
                Nome = novoNome?.Trim().ToUpper();
            

            if (string.IsNullOrEmpty(novoNome))
                AddNotification("Nome", "Novo nome n�o pode ser vazio");

        }
        
    }
}