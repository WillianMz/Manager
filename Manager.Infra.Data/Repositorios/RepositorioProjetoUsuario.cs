using Manager.Domain.Entidades;
using Manager.Domain.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Manager.Infra.Data.Repositorios
{
    public class RepositorioProjetoUsuario : IRepositorioProjetoUsuario
    {
        public void Adicionar(ProjetoUsuario entidade)
        {
            throw new NotImplementedException();
        }

        public void AdicionarLista(IEnumerable<ProjetoUsuario> entidades)
        {
            throw new NotImplementedException();
        }

        public ProjetoUsuario CarregarObjetoPeloID(int id)
        {
            throw new NotImplementedException();
        }

        public void Editar(ProjetoUsuario entidade)
        {
            throw new NotImplementedException();
        }

        public bool Existe(ProjetoUsuario entidade)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ProjetoUsuario> ListarNomeEmOrdemCrescente()
        {
            throw new NotImplementedException();
        }

        public IQueryable<ProjetoUsuario> ListarNomeEmOrdemDecrescente()
        {
            throw new NotImplementedException();
        }

        public IQueryable<ProjetoUsuario> ListarPorNome(string nome)
        {
            throw new NotImplementedException();
        }

        public IList<ProjetoUsuario> ListarTodos()
        {
            throw new NotImplementedException();
        }

        public void Remover(ProjetoUsuario entidade)
        {
            throw new NotImplementedException();
        }

        public void RemoverLista(IEnumerable<ProjetoUsuario> entidades)
        {
            throw new NotImplementedException();
        }
    }
}
