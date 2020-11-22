using Manager.Domain.Entidades;
using Manager.Domain.Interfaces.Repositorios;
using Manager.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manager.Infra.Data.Repositorios
{
    public class RepositorioDocumento : IRepositorioDocumento
    {
        private readonly ManagerContext context;

        public RepositorioDocumento(ManagerContext managerContext)
        {
            context = managerContext;
        }

        public void Adicionar(Documento entidade)
        {
            context.Documentos.Add(entidade);
        }

        public void AdicionarLista(IEnumerable<Documento> entidades)
        {
            throw new NotImplementedException();
        }

        public async Task<Documento> CarregarObjetoPeloID(int id)
        {
            Documento documento = context.Documentos.FirstOrDefault(d => d.Id == id);
            return await Task.FromResult(documento);
        }

        public void Editar(Documento entidade)
        {
            context.Documentos.Update(entidade);
        }

        public Task<bool> Existe(Documento entidade)
        {
            throw new NotImplementedException();
        }

        public void Remover(Documento entidade)
        {
            context.Documentos.Remove(entidade);
        }

        public void RemoverLista(IEnumerable<Documento> entidades)
        {
            throw new NotImplementedException();
        }
    }
}
