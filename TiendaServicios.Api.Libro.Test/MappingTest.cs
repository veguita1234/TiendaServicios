using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaServicios.Api.Libro.Application;
using TiendaServicios.Api.Libro.Model;

namespace TiendaServicios.Api.Libro.Test
{
    public class MappingTest : Profile
    {
        public MappingTest()
        {
            CreateMap<MaterialLibrary, MaterialBookDto>();
        }
    }
}
