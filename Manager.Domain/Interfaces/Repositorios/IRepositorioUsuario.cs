using Manager.Domain.Entidades;

namespace Manager.Domain.Interfaces.Repositorios
{
    public interface IRepositorioUsuario : IRepositorioBase<Usuario>
    {
        bool ExisteEmail(string email);
        Usuario ExisteUsuario(string email, string senha);
    }
}