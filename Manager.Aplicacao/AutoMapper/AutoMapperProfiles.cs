using AutoMapper;
using Manager.Aplicacao.Modelos;
using Manager.Negocio.Comandos.Categorias;

namespace Manager.Aplicacao.AutoMapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<CriarCategoriaRequest, CategoriaDTO>().ReverseMap();
        }
    }
}
