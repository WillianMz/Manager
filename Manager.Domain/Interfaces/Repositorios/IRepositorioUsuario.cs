using Manager.Domain.Entidades;
using System.Threading.Tasks;

namespace Manager.Domain.Interfaces.Repositorios
{
    public interface IRepositorioUsuario : IRepositorioBase<Usuario>
    {
        bool ExisteEmail(string email);
        Usuario ExisteUsuario(string email, string senha);
        Usuario ObterUsuarioPorEmail(string email);
        Task<Usuario> GetByID(int id);
    }
}