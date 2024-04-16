using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.Libro.Model;
using TiendaServicios.Api.Libro.Persistence;

namespace TiendaServicios.Api.Libro.Application
{
    public class Queries
    {
        public class Execute : IRequest<List<MaterialBookDto>>
        {

        }

        public class Handler : IRequestHandler<Execute, List<MaterialBookDto>>
        {
            private readonly ContextLibrary _context;
            private readonly IMapper _mapper;

            public Handler(ContextLibrary context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<List<MaterialBookDto>> Handle(Execute request, CancellationToken cancellationToken)
            {
                var books = await _context.MaterialLibrary.ToListAsync();
                var booksDto = _mapper.Map<List<MaterialLibrary>, List<MaterialBookDto>>(books);

                return booksDto;
            }
        }
    }
}
