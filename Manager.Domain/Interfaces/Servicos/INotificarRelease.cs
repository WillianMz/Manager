using Manager.Domain.Entidades;
using System.Threading.Tasks;

namespace Manager.Domain.Interfaces.Servicos
{
    public interface INotificarRelease
    {
        Task Nova(Usuario usuario, Projeto projeto, Release release);
    }
}
