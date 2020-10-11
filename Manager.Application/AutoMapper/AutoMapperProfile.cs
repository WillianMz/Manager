using AutoMapper;
using Manager.Application.DTOs;
using Manager.Domain.Entidades;
using System.Linq;

namespace Manager.Application.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Anexo, AnexoDTO>().ReverseMap();
            CreateMap<Categoria, CategoriaDTO>().ReverseMap();
            CreateMap<Documento, DocumentoDTO>().ReverseMap();
            CreateMap<Nota, NotaDTO>().ReverseMap();
            CreateMap<Ticket, TicketDTO>().ReverseMap();

            //relacionamentos N para N
            CreateMap<Projeto, ProjetoDTO>()
                .ForMember(p => p.Usuarios, opt =>
                {
                    opt.MapFrom(p => p.ProjetoUsuarios.Select(projetoUsuario => projetoUsuario.Usuario).ToList());
                })
                .ReverseMap();

            CreateMap<Usuario, UsuarioDTO>()
                .ForMember(u => u.Projetos, opt =>
                {
                    opt.MapFrom(u => u.ProjetoUsuarios.Select(usuarioProjeto => usuarioProjeto.Projeto).ToList());
                })
                .ReverseMap();
        }
    }
}
