using Manager.Domain.Entidades;
using Manager.Domain.Interfaces.Repositorios;
using Manager.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Manager.Infra.Data.Repositorios
{
    public class RepositorioNota : IRepositorioNota
    {
        private readonly ManagerContext context;

        public RepositorioNota(ManagerContext context)
        {
            this.context = context;
        }

        public void Adicionar(Nota entidade)
        {
            context.Notas.Add(entidade);
        }

        public void AdicionarLista(IEnumerable<Nota> entidades)
        {
            context.Notas.AddRange(entidades);
        }

        public Nota CarregarObjetoPeloID(int id)
        {
            Nota nota = context.Notas.FirstOrDefault(n => n.Id == id);
            return nota;
        }

        public void Editar(Nota entidade)
        {
            context.Notas.Update(entidade);
        }

        public bool ExisteEntidade(Nota entidade)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Nota> ListarNomeEmOrdemCrescente()
        {
            var notas = context.Notas.OrderBy(n => n.Titulo);
            return notas;
        }

        public IQueryable<Nota> ListarNomeEmOrdemDecrescente()
        {
            var notas = context.Notas.OrderByDescending(n => n.Titulo);
            return notas;
        }

        public IQueryable<Nota> ListarPorNome(string nome)
        {
            var notas = context.Notas.Where(n => n.Titulo.Contains(nome));
            return notas;
        }

        public IList<Nota> ListarTodos()
        {
            var notas = context.Notas.ToList();
            return notas;
        }

        public void Remover(Nota entidade)
        {
            context.Notas.Remove(entidade);
        }

        public void RemoverLista(IEnumerable<Nota> entidades)
        {
            context.Notas.RemoveRange(entidades);
        }
    }
}
