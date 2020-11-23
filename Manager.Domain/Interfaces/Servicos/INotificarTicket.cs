using Manager.Domain.Entidades;
using System.Threading.Tasks;

namespace Manager.Domain.Interfaces.Servicos
{
    public interface INotificarTicket
    {
        Task Novo(Projeto projeto, Usuario usuario, Ticket ticket);
        void Finalizar(Ticket ticket, Usuario usuario, string solucao);
    }
}
