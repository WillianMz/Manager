using Manager.Domain.Entidades;
using Manager.Domain.Interfaces.Repositorios;
using Manager.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Manager.Infra.Data.Repositorios
{
    public class RepositorioCategoria : IRepositorioCategoria, IConsultaCategoria
    {
        private readonly ManagerContext context;

        public RepositorioCategoria(ManagerContext managerContext)
        {
            context = managerContext;
        }

        public void Adicionar(Categoria entidade)
        {
            context.Categorias.Add(entidade);
        }

        public void AdicionarLista(IEnumerable<Categoria> entidades)
        {
            context.Categorias.AddRange(entidades);
        }

        public Categoria CarregarObjetoPeloID(int id)
        {
            Categoria categoria = context.Categorias.FirstOrDefault(c => c.Id == id);
            return categoria;
        }

        public void Editar(Categoria entidade)
        {
            context.Categorias.Update(entidade);
        }

        public bool Existe(Categoria entidade)
        {
            var existe = context.Categorias.Any(c => c.Nome == entidade.Nome);
            return existe;
        }

        public void Remover(Categoria entidade)
        {
            context.Categorias.Remove(entidade);
        }

        public void RemoverLista(IEnumerable<Categoria> entidades)
        {
            context.Categorias.RemoveRange(entidades);
        }

        //public IList<Categoria> ListarNomeEmOrdemCrescente()
        //{
        //    var categorias = context.Categorias.OrderBy(c => c.Nome).ToList();
        //    return categorias;
        //}

        //public IList<Categoria> ListarNomeEmOrdemDecrescente()
        //{
        //    var categorias = context.Categorias.OrderByDescending(c => c.Nome).ToList();
        //    return categorias;
        //}

        //public IList<Categoria> ListarPorNome(string nome)
        //{
        //    var categorias = context.Categorias.Where(c => c.Nome.Contains(nome)).ToList();
        //    return categorias;
        //}

        //public IList<Categoria> ListarTodos()
        //{
        //    var categorias = context.Categorias.ToList();
        //    return categorias;
        //}

        //CONSULTAS DA INTERFACE IConsultaCategoria -> Projeto Manager.Domain.Queries
        public IList<Categoria> ListarNomeEmOrdemCrescente()
        {
            List<Categoria> categorias = context.Categorias.OrderBy(c => c.Nome).ToList();
            return categorias;
        }

        public IList<Categoria> ListarNomeEmOrdemDecrescente()
        {
            List<Categoria> categorias = context.Categorias.OrderByDescending(c => c.Nome).ToList();
            return categorias;
        }

        public Categoria ListarPorId(int id)
        {
            Categoria categoria = context.Categorias.FirstOrDefault(c => c.Id == id);
            return categoria;
        }

        public IList<Categoria> ListarPorIdCrescente()
        {
            List<Categoria> categorias = context.Categorias.OrderBy(c => c.Id).ToList();
            return categorias;
        }

        public IList<Categoria> ListarPorIdDecrescente()
        {
            List<Categoria> categorias = context.Categorias.OrderByDescending(c => c.Id).ToList();
            return categorias;
        }

        public IList<Categoria> ListarPorNome(string nome)
        {
            List<Categoria> categorias = context.Categorias.OrderByDescending(c => c.Nome).ToList();
            return categorias;
        }

        public IList<Categoria> ListarTodos()
        {
            List<Categoria> categorias = context.Categorias.ToList();
            return categorias;
        }

        public IList<Categoria> ListarTodos(bool ativo)
        {
            throw new NotImplementedException();
        }

    }
}
