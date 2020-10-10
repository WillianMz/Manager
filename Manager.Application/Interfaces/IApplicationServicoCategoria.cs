using Manager.Application.DTOs;
using System.Collections.Generic;

namespace Manager.Application.Interfaces
{
    public interface IApplicationServicoCategoria
    {
        void Add(CategoriaDTO categoriaDTO);
        void Update(CategoriaDTO categoriaDTO);
        void Remove(CategoriaDTO categoriaDTO);
        IEnumerable<CategoriaDTO> GetAll();
        CategoriaDTO GetById(int id);
    }
}
