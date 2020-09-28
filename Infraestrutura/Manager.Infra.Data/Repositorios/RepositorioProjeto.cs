﻿using Manager.Domain.Entidades;
using Manager.Domain.Interfaces.Repositorios;
using Manager.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Manager.Infra.Data.Repositorios
{
    public class RepositorioProjeto : IRepositorioProjeto
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

        public bool ExisteEntidade(Projeto entidade)
        {
            var existe = context.Projetos.Any(p => p.Descricao == entidade.Descricao);
            return existe;
        }

        public IQueryable<Projeto> ListarNomeEmOrdemCrescente()
        {
            var projetos = context.Projetos.OrderBy(p => p.Descricao);
            return projetos;
        }

        public IQueryable<Projeto> ListarNomeEmOrdemDecrescente()
        {
            var projetos = context.Projetos.OrderByDescending(p => p.Descricao);
            return projetos;
        }

        public IList<Projeto> ListarOrdenadoPor()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Projeto> ListarPorNome(string nome)
        {
            var projetos = context.Projetos.OrderBy(p => p.Descricao);
            return projetos;
        }

        public IList<Projeto> ListarTodos()
        {
            var projetos = context.Projetos.ToList();
            return projetos;
        }

        public void Remover(Projeto entidade)
        {
            context.Projetos.Remove(entidade);
        }

        public void RemoverLista(IEnumerable<Projeto> entidades)
        {
            context.Projetos.RemoveRange(entidades);
        }
    }
}
