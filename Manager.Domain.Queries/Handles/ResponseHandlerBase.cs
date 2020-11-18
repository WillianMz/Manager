using System.Threading.Tasks;

namespace Manager.Domain.Queries.Handles
{
    public static class ResponseHandlerBase
    {
        public static async Task<ResponseQueries> RetornoDaConsulta(bool sucesso, string mensagem, object dados)
        {
            var result = new ResponseQueries(sucesso, mensagem, dados);
            return await Task.FromResult(result);
        }
    }
}
