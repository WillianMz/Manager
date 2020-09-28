using Manager.Domain.Entidades;
using Manager.Domain.Interfaces.Repositorios;
using Manager.Domain.Interfaces.Repositorios.Base;
using Manager.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Manager.Infra.Data.Repositorios
{
    public class RepositorioCategoria : IRepositorioCategoria
    {
        private readonly ManagerContext context;

        public RepositorioCategoria(ManagerContext managerContext)
        {
            context = managerContext;
        }

        /// <summary>
        /// Adiciona na base de dados um novo objeto categoria
        /// </summary>
        /// <param name="entidade"></param>
        public void Adicionar(Categoria entidade)
        {
            context.Categorias.Add(entidade);
        }

        /// <summary>
        /// Adiciona na base de dados uma coleção de objetos do tipo categoria
        /// </summary>
        /// <param name="entidades"></param>
        public void AdicionarLista(IEnumerable<Categoria> entidades)
        {
            context.Categorias.AddRange(entidades);
        }

        /// <summary>
        /// Retorna da base de dados um objeto categoria pelo ID informado
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Objeto Categoria</returns>
        public Categoria CarregarObjetoPeloID(int id)
        {
            Categoria categoria = context.Categorias.FirstOrDefault(c => c.Id == id);
            return categoria;
        }

        /// <summary>
        /// Faz o update do objeto categoria na base de dados
        /// </summary>
        /// <param name="entidade"></param>
        public void Editar(Categoria entidade)
        {
            context.Categorias.Update(entidade);
        }

        /// <summary>
        /// Consulta na base de dados se existe o objeto categoria informado
        /// </summary>
        /// <param name="entidade"></param>
        /// <returns>True ou False</returns>
        public bool ExisteEntidade(Categoria entidade)
        {
            var existe = context.Categorias.Any(c => c.Nome == entidade.Nome);
            return existe;
        }

        public IList<Categoria> ListarOrdenadoPor()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retorna da base de dados uma lista com todas as categorias ordenadas pelo Id
        /// </summary>
        /// <returns>IList, List</returns>
        public IList<Categoria> ListarTodos()
        {
            var categorias = context.Categorias.ToList();
            return categorias;
        }

        /// <summary>
        /// Remove da base de dados o objeto categoria informado
        /// </summary>
        /// <param name="entidade"></param>
        public void Remover(Categoria entidade)
        {
            context.Categorias.Remove(entidade);
        }

        /// <summary>
        /// Remove da base de dados uma lista de objetos categoria
        /// </summary>
        /// <param name="entidades"></param>
        public void RemoverLista(IEnumerable<Categoria> entidades)
        {
            context.Categorias.RemoveRange(entidades);
        }

        public void Teste()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retorna uma coleção de categorias ordenadas de forma crescente pelo nome
        /// </summary>
        /// <returns></returns>
        IQueryable<Categoria> IRepositorioBase<Categoria>.ListarNomeEmOrdemCrescente()
        {
            var categorias = context.Categorias.OrderBy(c => c.Nome);
            return categorias;
        }

        /// <summary>
        /// Retorna uma coleção de categorias ordenadas de forma decrescente pelo nome
        /// </summary>
        /// <returns></returns>
        IQueryable<Categoria> IRepositorioBase<Categoria>.ListarNomeEmOrdemDecrescente()
        {
            var categorias = context.Categorias.OrderByDescending(c => c.Nome);
            return categorias;
        }

        /// <summary>
        /// Retorna uma coleção de categorias que contenham tudo ou parte do nome informado
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        IQueryable<Categoria> IRepositorioBase<Categoria>.ListarPorNome(string nome)
        {
            var categorias = context.Categorias.Where(c => c.Nome.Contains(nome));
            return categorias;
        }
    }
}
