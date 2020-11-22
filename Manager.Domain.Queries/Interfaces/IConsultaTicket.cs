using Manager.Domain.Queries.DTOs;
using System.Threading.Tasks;

namespace Manager.Domain.Queries.Interfaces
{
    public interface IConsultaTicket : IConsultaBase<TicketDTO>
    {
        Task<TicketDTO> ConsultarDetalhes(int id);
    }
}
