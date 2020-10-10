using Manager.Domain.Entidades;
using Manager.Domain.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Manager.Infra.Data.Repositorios
{
    public class RepositorioPrioridade : IRepositorioPrioridade
    {
        public void Adicionar(Prioridade entidade)
        {
            throw new NotImplementedException();
        }

        public void AdicionarLista(IEnumerable<Prioridade> entidades)
        {
            throw new NotImplementedException();
        }

        public Prioridade CarregarObjetoPeloID(int id)
        {
            throw new NotImplementedException();
        }

        public void Editar(Prioridade entidade)
        {
            throw new NotImplementedException();
        }

        public bool Existe(Prioridade entidade)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Prioridade> ListarNomeEmOrdemCrescente()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Prioridade> ListarNomeEmOrdemDecrescente()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Prioridade> ListarPorNome(string nome)
        {
            throw new NotImplementedException();
        }

        public IList<Prioridade> ListarTodos()
        {
            throw new NotImplementedException();
        }

        public void Remover(Prioridade entidade)
        {
            throw new NotImplementedException();
        }

        public void RemoverLista(IEnumerable<Prioridade> entidades)
        {
            throw new NotImplementedException();
        }
    }
}
