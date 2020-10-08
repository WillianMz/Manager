using Manager.Domain.Entidades;
using Manager.Domain.Interfaces.Repositorios.Base;

namespace Manager.Domain.Interfaces.Repositorios
{
    public interface IRepositorioUsuario : IRepositorioBase<Usuario>
    {
        bool ExisteEmail(string email);
    }
}