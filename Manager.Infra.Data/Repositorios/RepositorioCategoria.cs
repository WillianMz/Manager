using Manager.Domain.Entidades;
using Manager.Domain.Interfaces.Repositorios;
using Manager.Domain.Queries.DTOs;
using Manager.Domain.Queries.Interfaces;
using Manager.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<Categoria> CarregarObjetoPeloID(int id)
        {
            Categoria categoria = context.Categorias.FirstOrDefault(c => c.Id == id);
            return await Task.FromResult(categoria);
        }

        public void Editar(Categoria entidade)
        {
            context.Categorias.Update(entidade);
        }

        public async Task<bool> Existe(Categoria entidade)
        {
            var existe = context.Categorias.Any(c => c.Nome == entidade.Nome);
            return await Task.FromResult(existe);
        }

        public void Remover(Categoria entidade)
        {
            context.Categorias.Remove(entidade);
        }

        public void RemoverLista(IEnumerable<Categoria> entidades)
        {
            context.Categorias.RemoveRange(entidades);
        }


        #region CONSULTAS

        public async Task<List<CategoriaDTO>> Listar()
        {
            var categorias = context.Categorias.OrderByDescending(c => c.Id).ToList();
            List<CategoriaDTO> categoriaDTOs = new List<CategoriaDTO>();

            foreach (var c in categorias)
            {
                CategoriaDTO DTO = new CategoriaDTO() { Id = c.Id, Nome = c.Nome };
                categoriaDTOs.Add(DTO);
            }

            return await Task.FromResult(categoriaDTOs);
        }

        public async Task<List<CategoriaDTO>> ListarPorNome(string nome)
        {
            //contains = caracter coringa do SQL, pesquisa o paramento NOME
            var categorias = context.Categorias.Where(c => c.Nome.Contains(nome)).ToList();
            categorias.OrderBy(c => c.Nome).ToList();
            List<CategoriaDTO> categoriaDTOs = new List<CategoriaDTO>();

            foreach (var c in categorias)
            {
                CategoriaDTO DTO = new CategoriaDTO(){ Id = c.Id, Nome = c.Nome };
                categoriaDTOs.Add(DTO);
            }

            return await Task.FromResult(categoriaDTOs);
        }

        public async Task<CategoriaDTO> ProcurarPorID(int id)
        {
            var categoria = context.Categorias.FirstOrDefault(c => c.Id == id);

            if (categoria == null)
                return null;

            CategoriaDTO categoriaDTO = new CategoriaDTO() { Id = categoria.Id, Nome = categoria.Nome };
            return await Task.FromResult(categoriaDTO);
        }


        #endregion

    }
}
