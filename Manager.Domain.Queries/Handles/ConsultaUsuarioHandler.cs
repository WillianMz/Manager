using Manager.Domain.Queries.Consultas.Usuarios;
using Manager.Domain.Queries.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Manager.Domain.Queries.Handles
{
    public class ConsultaUsuarioHandler : IRequestHandler<ListarUsuarios, ResponseQueries>,
                                          IRequestHandler<UsuarioPorID, ResponseQueries>,
                                          IRequestHandler<UsuarioPorNome, ResponseQueries>
    {
        private readonly IConsultaUsuario _consultaUsuario;

        public ConsultaUsuarioHandler(IConsultaUsuario consultaUsuario)
        {
            _consultaUsuario = consultaUsuario;
        }

        public async Task<ResponseQueries> Handle(ListarUsuarios request, CancellationToken cancellationToken)
        {
            var usuarios = await _consultaUsuario.Listar();

            if (usuarios.Count == 0)
                return new ResponseQueries(false, "Nenhum usuário encontrado", null);

            return await ResponseHandlerBase.RetornoDaConsulta(true, "Usuarios", usuarios);
        }

        public async Task<ResponseQueries> Handle(UsuarioPorID request, CancellationToken cancellationToken)
        {
            if (request == null)
                return new ResponseQueries(false, "Informe o ID do usuário", null);

            var usuario = await _consultaUsuario.ProcurarPorID(request.Id);

            if (usuario == null)
                return new ResponseQueries(false, "Nenhum usuário encontrado com o ID: " + request.Id, null);

            return await ResponseHandlerBase.RetornoDaConsulta(true, "Usuarios", usuario);
        }

        public async Task<ResponseQueries> Handle(UsuarioPorNome request, CancellationToken cancellationToken)
        {
            if (request == null)
                return new ResponseQueries(false, "Informe um nome para pesquisa", null);

            var usuarios = await _consultaUsuario.ListarPorNome(request.Nome);

            if (usuarios.Count == 0)
                return new ResponseQueries(false, "Nenhum usuário encontrado", null);

            return await ResponseHandlerBase.RetornoDaConsulta(true, "Usuarios", usuarios);
        }
    }
}
