using Manager.Domain.Interfaces.Repositorios;

namespace Manager.Domain.Core.Handlers
{
    public class ConsultaCategoriaHandler 
    {
        private readonly IConsultaCategoria _consultaCategoria;

        public ConsultaCategoriaHandler(IConsultaCategoria consultaCategoria)
        {
            _consultaCategoria = consultaCategoria;
        }

    }
}
