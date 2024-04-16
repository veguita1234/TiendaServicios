using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.Autor.Model;
using TiendaServicios.Api.Autor.Persistence;

namespace TiendaServicios.Api.Autor.Application
{
    public class Queries
    {
        public class AuthorList : IRequest<List<AuthorDTO>>
        {

        }
        public class Handler : IRequestHandler<AuthorList, List<AuthorDTO>>
        {

            public readonly AuthorContext _context;
            private readonly IMapper _mapper;

            public Handler(AuthorContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<List<AuthorDTO>> Handle(AuthorList request, CancellationToken cancellationToken)
            {
                var authors = await _context.AuthorBook.ToListAsync();
                var authorsDTO = _mapper.Map<List<AuthorBook>, List<AuthorDTO>>(authors);
                
                return authorsDTO;
            }
        }
    }
}
