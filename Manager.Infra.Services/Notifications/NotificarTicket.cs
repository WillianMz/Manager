using Manager.Domain.Entidades;
using Manager.Domain.Interfaces.Repositorios;
using Manager.Domain.Interfaces.Servicos;
using System.Threading.Tasks;

namespace Manager.Infra.Services.Notifications
{
    public class NotificarTicket : INotificarTicket
    {
        private readonly IServicoEmail _servicoEmail;
        //private readonly IRepositorioProjeto _repositorioProjeto;
        private readonly IRepositorioUsuario _repositorioUsuario;

        public NotificarTicket(IServicoEmail servicoEmail, IRepositorioUsuario repositorioUsuario)
        {
            _servicoEmail = servicoEmail;
            //_repositorioProjeto = repositorioProjeto;
            _repositorioUsuario = repositorioUsuario;
        }

        public void Finalizar(Ticket ticket, Usuario usuario, string solucao)
        {
            string remetente = "willianmazzorana@hotmail.com";
            var titulo = "Ticket: " + ticket.Id + " - " + ticket.Titulo;
            var corpo = "Descrição do ticket: " + ticket.Descricao + "\n";
            corpo += " Solução aplicada: " + ticket.Solucao;

            //notificar o usuario, membros do projeto

            _servicoEmail.EnviaEmail(remetente, usuario.Email, titulo, corpo);
        }

        public async Task Novo(Projeto projeto, Usuario usuario, Ticket ticket)
        {
            string remetente = "willianmazzorana@hotmail.com";
            var equipe = projeto.ProjetoUsuarios;
            string titulo = "Novo ticket do projeto " + projeto.Nome;
            string corpo = "O usuário " + usuario.Nome + " criou um novo ticket para o projeto " + projeto.Nome + "\n";
            corpo += " Descrição do ticket criado: " + ticket.Descricao;

            //notifica todos os membros do projeto que um novo ticket foi criado
            foreach (var user in equipe)
            {
                Usuario usu = await _repositorioUsuario.CarregarObjetoPeloID(user.UsuarioId);
                _servicoEmail.EnviaEmail(remetente, usu.Email, titulo, corpo);
            }
            
        }
    }
}
