using Manager.Domain.Entidades;
using System.Collections.Generic;

namespace Manager.Domain.Interfaces.Repositorios
{
    public interface IRepositorioCategoria //: IRepositorioBase<Categoria>
    {
        void Adicionar(Categoria entidade);
        void Editar(Categoria entidade);
        void Remover(Categoria entidade);
        void AdicionarLista(IEnumerable<Categoria> entidades);
        void RemoverLista(IEnumerable<Categoria> entidades);
        bool Existe(Categoria entidade);
        Categoria CarregarObjetoPeloID(int id);
    }
}