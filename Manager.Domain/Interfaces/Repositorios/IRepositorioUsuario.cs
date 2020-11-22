using Manager.Domain.Entidades;
using System.Threading.Tasks;

namespace Manager.Domain.Interfaces.Repositorios
{
    public interface IRepositorioUsuario : IRepositorioBase<Usuario>
    {
        Task<bool> ExisteEmail(string email);
        Task<Usuario> ExisteUsuario(string email, string senha);
        Task<Usuario> ObterUsuarioPorEmail(string email);
    }
}