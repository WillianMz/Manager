using Flunt.Validations;

namespace Manager.Domain.ValueObjects
{
    public class Titulo : ValueObjects
    {
        public Titulo(string nome)
        {
            Nome = nome?.Trim().ToUpper();

            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(Nome, "Nome", "Nome do título não pode estar vazio")
            );
        }

        public string Nome { get; private set; }
    }
}
