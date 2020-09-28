using Manager.Domain.Entidades;
using Manager.Domain.Interfaces.Repositorios.Base;
using System.Collections.Generic;

namespace Manager.Domain.Interfaces.Repositorios
{
    public interface IRepositorioProjeto : IRepositorioBase<Projeto>
    {
        //void AdicionarDocumentoAoProjeto(Documento documento);
        //void AdicionarDocumentos(IEnumerable<Documento> documentos);
    }
}