using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.Libro.Model;
using TiendaServicios.Api.Libro.Persistence;

namespace TiendaServicios.Api.Libro.Application
{
    public class FilterQuery
    {
        public class UnitBook : MediatR.IRequest<MaterialBookDto>
        {
            public Guid? BookId { get; set; }
        }

        public class Handler : IRequestHandler<UnitBook, MaterialBookDto>
        {
            private readonly ContextLibrary _context;
            private readonly IMapper _mapper;

            public Handler(ContextLibrary context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<MaterialBookDto> Handle(UnitBook request, CancellationToken cancellationToken)
            {

                var book =await _context.MaterialLibrary.Where(x => x.MaterialLibraryId == request.BookId).FirstOrDefaultAsync();

                if (book == null)
                {
                    throw new Exception("No se encontro el libro");
                }

                var bookDto = _mapper.Map<MaterialLibrary,MaterialBookDto>(book);
                return bookDto;
            }


           
        }
    }
}
