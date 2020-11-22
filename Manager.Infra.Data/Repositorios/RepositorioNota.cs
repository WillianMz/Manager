using Manager.Domain.Entidades;
using Manager.Domain.Interfaces.Repositorios;
using Manager.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manager.Infra.Data.Repositorios
{
    public class RepositorioNota : IRepositorioNota
    {
        private readonly ManagerContext context;

        public RepositorioNota(ManagerContext managerContext)
        {
            context = managerContext;
        }

        public void Adicionar(Nota entidade)
        {
            context.Notas.Add(entidade);
        }

        public void AdicionarLista(IEnumerable<Nota> entidades)
        {
            throw new System.NotImplementedException();
        }

        public Task<Nota> CarregarObjetoPeloID(int id)
        {
            Nota nota = context.Notas.FirstOrDefault(n => n.Id == id);
            return Task.FromResult(nota);
        }

        public void Editar(Nota entidade)
        {
            context.Notas.Update(entidade);
        }

        public Task<bool> Existe(Nota entidade)
        {
            throw new System.NotImplementedException();
        }

        public void Remover(Nota entidade)
        {
            context.Notas.Remove(entidade);
        }

        public void RemoverLista(IEnumerable<Nota> entidades)
        {
            throw new System.NotImplementedException();
        }
    }
}
