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

        public async Task<Projeto> CarregarObjetoPeloID(int id)
        {
            Projeto projeto = context.Projetos.FirstOrDefault(p => p.Id == id);
            return await Task.FromResult(projeto);
        }

        public void Editar(Projeto entidade)
        {
            context.Projetos.Update(entidade);
        }

        public async Task<bool> Existe(Projeto entidade)
        {
            var existe = context.Projetos.Any(p => p.Nome == entidade.Nome);
            return await Task.FromResult(existe);
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
       
        public async Task<List<ProjetoDTO>> Listar()
        {
            var projetos = context.Projetos.OrderByDescending(p => p.Id).ToList();
            List<ProjetoDTO> projetoDTOs = new List<ProjetoDTO>();

            foreach (var p in projetos)
            {
                projetoDTOs.Add(new ProjetoDTO() { Id = p.Id, Nome = p.Nome, Descricao = p.Descricao });
            }

            return await Task.FromResult(projetoDTOs);
        }

        public async Task<List<ProjetoDTO>> ListarPorNome(string nome)
        {
            var projetos = context.Projetos.Where(p => p.Nome.Contains(nome)).ToList();
            projetos.OrderBy(p => p.Nome);
            List<ProjetoDTO> projetoDTOs = new List<ProjetoDTO>();

            foreach (var p in projetos)
            {
                projetoDTOs.Add(new ProjetoDTO() { Id = p.Id, Nome = p.Nome, Descricao = p.Descricao });
            }

            return await Task.FromResult(projetoDTOs);
        }

        public async Task<ProjetoDTO> ProcurarPorID(int id)
        {
            var projeto = context.Projetos.FirstOrDefault(p => p.Id == id);

            if (projeto == null) 
                return null;

            ProjetoDTO projetoDTO = new ProjetoDTO() 
            { 
                Id = projeto.Id, 
                Descricao = projeto.Descricao, 
                Nome = projeto.Nome
            };

            //documentos do projeto
            foreach (var docs in projeto.Documentos)
            {
                DocumentoDTO docDTO = new DocumentoDTO
                { 
                    Id = docs.Id,
                    Titulo = docs.Titulo,
                    URL = docs.URL
                };
                projetoDTO.Documentos.Add(docDTO);
            }

            //releases
            foreach (var rel in projeto.Releases.OrderByDescending(r => r.Id))
            {
                ReleaseDTO releaseDTO = new ReleaseDTO
                {
                    Id = rel.Id,
                    Nome = rel.Nome,
                    Versao =  rel.Versao,
                    Usuario =  rel.Usuario.Nome,
                    DataCriacao = rel.DataDeCriacao.ToString(),
                    DataLiberacao = rel.DataDeLiberacao.ToString(),
                    Descricao = rel.Descricao
                };
                projetoDTO.Releases.Add(releaseDTO);
            }

            //equipe do projeto
            foreach (var equipe in projeto.ProjetoUsuarios)
            {
                ProjetoUsuarioDTO equipeDTO = new ProjetoUsuarioDTO
                {
                   Usuario = equipe.Usuario.Nome
                };
                projetoDTO.Equipe.Add(equipeDTO);
            }

            return await Task.FromResult(projetoDTO);
        }

        #endregion

    }
}
