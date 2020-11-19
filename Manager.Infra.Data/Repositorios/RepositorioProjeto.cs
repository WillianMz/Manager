using Manager.Domain.Entidades;
using Manager.Domain.Interfaces.Repositorios;
using Manager.Domain.Queries.DTOs;
using Manager.Domain.Queries.Interfaces;
using Manager.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace Manager.Infra.Data.Repositorios
{
    public class RepositorioProjeto : IRepositorioProjeto, IConsultaProjeto
    {
        private readonly ManagerContext context;

        public RepositorioProjeto(ManagerContext managerContext)
        {
            context = managerContext;
        }

        public void Adicionar(Projeto entidade)
        {
            context.Projetos.Add(entidade);
        }

        public void AdicionarLista(IEnumerable<Projeto> entidades)
        {
            context.Projetos.AddRange(entidades);
        }

        public Projeto CarregarObjetoPeloID(int id)
        {
            Projeto projeto = context.Projetos.FirstOrDefault(p => p.Id == id);
            return projeto;
        }

        public void Editar(Projeto entidade)
        {
            context.Projetos.Update(entidade);
        }

        public bool Existe(Projeto entidade)
        {
            var existe = context.Projetos.Any(p => p.Nome == entidade.Nome);
            return existe;
        }

        public void Remover(Projeto entidade)
        {
            context.Projetos.Remove(entidade);
        }

        public void RemoverLista(IEnumerable<Projeto> entidades)
        {
            context.Projetos.RemoveRange(entidades);
        }


        #region CONSULTAS
       
        public List<ProjetoDTO> Listar()
        {
            var projetos = context.Projetos.OrderBy(p => p.Id).ToList();
            List<ProjetoDTO> projetoDTOs = new List<ProjetoDTO>();

            foreach (var p in projetos)
            {
                projetoDTOs.Add(new ProjetoDTO() { Id = p.Id, Nome = p.Nome, Descricao = p.Descricao });
            }

            return projetoDTOs;
        }

        public List<ProjetoDTO> ListarPorNome(string nome)
        {
            var projetos = context.Projetos.Where(p => p.Nome.Contains(nome)).ToList();
            projetos.OrderBy(p => p.Nome);
            List<ProjetoDTO> projetoDTOs = new List<ProjetoDTO>();

            foreach (var p in projetos)
            {
                projetoDTOs.Add(new ProjetoDTO() { Id = p.Id, Nome = p.Nome, Descricao = p.Descricao });
            }

            return projetoDTOs;
        }

        public ProjetoDTO ProcurarPorID(int id)
        {
            var projeto = context.Projetos.FirstOrDefault(p => p.Id == id);
            ProjetoDTO DTO = new ProjetoDTO() { Id = projeto.Id, Descricao = projeto.Descricao, Nome = projeto.Nome };
            return DTO;
        }

        #endregion

    }
}
