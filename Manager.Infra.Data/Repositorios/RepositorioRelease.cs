using Manager.Domain.Entidades;
using Manager.Domain.Interfaces.Repositorios;
using Manager.Infra.Data.Context;
using Manager.Domain.Queries.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Manager.Domain.Queries.DTOs;

namespace Manager.Infra.Data.Repositorios
{
    public class RepositorioRelease : IRepositorioRelease, IConsultaRelease
    {
        private readonly ManagerContext context;

        public RepositorioRelease(ManagerContext managerContext)
        {
            context = managerContext;
        }

        public void Adicionar(Release entidade)
        {
            context.Releases.Add(entidade);
        }

        public void AdicionarLista(IEnumerable<Release> entidades)
        {
            throw new NotImplementedException();
        }

        public async Task<Release> CarregarObjetoPeloID(int id)
        {
            Release release = context.Releases.FirstOrDefault(r => r.Id == id);
            return await Task.FromResult(release);
        }

        public void Editar(Release entidade)
        {
            context.Releases.Update(entidade);
        }

        public Task<bool> Existe(Release entidade)
        {
            throw new NotImplementedException();
        }

        public void Remover(Release entidade)
        {
            context.Releases.Remove(entidade);
        }

        public void RemoverLista(IEnumerable<Release> entidades)
        {
            throw new NotImplementedException();
        }

        //CONSULTAS
        public async Task<List<ReleaseDTO>> FiltrarReleasesPorProjeto(int idProjeto)
        {
            var releases = context.Releases.OrderByDescending(r => r.Id).Where(r => r.ProjetoId == idProjeto).ToList();
            //releases.OrderByDescending(r => r.Id).ToList();

            if (releases.Count == 0)
                return null;
                        
            List<ReleaseDTO> releaseDTOs = new List<ReleaseDTO>();

            foreach (var r in releases)
            {
                releaseDTOs.Add(new ReleaseDTO()
                {
                    Id = r.Id,
                    DataCriacao = r.DataDeCriacao.ToString(),
                    DataLiberacao = r.DataDeLiberacao.ToString(),
                    Descricao = r.Descricao,
                    Nome = r.Nome,
                    Usuario = r.Usuario.Nome,
                    Versao = r.Versao
                });
            }

            //releaseDTOs.OrderByDescending(r => r.Id);
            return await Task.FromResult(releaseDTOs);
        }
    }
}
