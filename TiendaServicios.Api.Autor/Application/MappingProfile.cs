using AutoMapper;
using TiendaServicios.Api.Autor.Model;

namespace TiendaServicios.Api.Autor.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AuthorBook, AuthorDTO>();
        }
    }
}
