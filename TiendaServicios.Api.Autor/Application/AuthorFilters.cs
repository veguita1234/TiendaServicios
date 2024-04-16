using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using TiendaServicios.Api.Autor.Model;
using TiendaServicios.Api.Autor.Persistence;

namespace TiendaServicios.Api.Autor.Application
{
    public class AuthorFilters
    {
        public class SoleAuthor : IRequest<AuthorDTO>
        {
            public string AuthorGuid { get; set; }
        }

        public class Handler : IRequestHandler<SoleAuthor, AuthorDTO>
        {
            
            private readonly AuthorContext _authorContext;
            private readonly IMapper _mapper;
            public Handler(AuthorContext authorContext, IMapper mapper)
            {
                _authorContext = authorContext;
                _mapper = mapper;
            } 
            public async Task<AuthorDTO> Handle(SoleAuthor request, CancellationToken cancellationToken)
            {
                var author = await _authorContext.AuthorBook.Where(x => x.AuthorBookGuid == request.AuthorGuid).FirstOrDefaultAsync();
                var authorDTO = _mapper.Map<AuthorBook, AuthorDTO>(author);
                if (author == null) 
                {
                    throw new Exception("No se encontro el autor");                
                }

                return authorDTO;
            }
        }
    }
}
