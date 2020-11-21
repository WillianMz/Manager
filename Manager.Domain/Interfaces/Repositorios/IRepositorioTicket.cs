using Manager.Domain.Entidades;
using System.Threading.Tasks;

namespace Manager.Domain.Interfaces.Repositorios
{
    public interface IRepositorioTicket : IRepositorioBase<Ticket>
    {
        Task<Ticket> GetByID(int id);
    }
}