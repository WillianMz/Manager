using Manager.Domain.Entidades;
using Manager.Domain.Interfaces.Repositorios;
using Manager.Domain.Interfaces.Servicos;
using System.Threading.Tasks;

namespace Manager.Infra.Services.Notifications
{
    public class NotificarRelease : INotificarRelease
    {
        private readonly IServicoEmail _servicoEmail;
        private readonly IRepositorioUsuario _repositorioUsuario;

        public NotificarRelease(IServicoEmail servicoEmail, IRepositorioUsuario repositorioUsuario)
        {
            _servicoEmail = servicoEmail;
            _repositorioUsuario = repositorioUsuario;
        }

        public async Task Nova(Usuario usuario, Projeto projeto, Release release)
        {
            string remetente = "willianmazzorana@hotmail.com";
            var equipe = projeto.ProjetoUsuarios;
            string titulo = "Nova release para " + projeto.Nome;
            string corpo = "O usuário " + usuario.Nome + " adicionou uma nova release ao projeto " + projeto.Nome + "\n";
            corpo += " Detalhes da release: \n";
            corpo += "Versão: " + release.Versao + "\n";
            corpo += "Data de criação: " + release.DataDeCriacao + "\n";
            corpo += "Data de liberação: " + release.DataDeLiberacao;

            //notifica todos os membros do projeto que um novo ticket foi criado
            foreach (var user in equipe)
            {
                Usuario usu = await _repositorioUsuario.CarregarObjetoPeloID(user.UsuarioId);
                _servicoEmail.EnviaEmail(remetente, usu.Email, titulo, corpo);
            }
        }
    }
}
