using FluentAssertions.Execution;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.CarritoCompra.Persistence;
using TiendaServicios.Api.CarritoCompra.RemoteInterface;

namespace TiendaServicios.Api.CarritoCompra.Application
{
    public class Queries
    {
        public class Execute : IRequest<CarDto>
        {
            public int CarSessionId { get; set; }

        }

        public class Handler : IRequestHandler<Execute, CarDto>
        {

            private readonly ContextCar _context;
            private readonly IBooksService _booksService;

            public Handler (ContextCar context, IBooksService booksService)
            {
                _context = context;
                _booksService = booksService;
            }

            public async Task<CarDto> Handle(Execute request, CancellationToken cancellationToken)
            {
                var carsession = await _context.CarSession.FirstOrDefaultAsync(x =>  x.CarSessionId == request.CarSessionId); 

                var carsessiondetail = await _context.CarSessionDetail.Where(x => x.CarSessionDetailId == request.CarSessionId).ToListAsync();
                
                var carlistDto = new List<CarDetailDto>();

                foreach (var book in carsessiondetail)
                {
                    var response = await _booksService.GetBook(book.SelectedProduct);

                    if (response.result)
                    {
                        var bookobject = response.Book;
                        var cardetail = new CarDetailDto
                        {
                            TitleBook = bookobject.Title,
                            PublicationDate = bookobject.PublicationDate,
                            BookId = bookobject.MaterialLibraryId
                        };
                        carlistDto.Add(cardetail);
                    }
                }

                var carsessionDto = new CarDto
                {
                    CarId = carsession.CarSessionId,
                    CreateDateSession = carsession.CreationDate,
                    ListProducts = carlistDto,
                };

                return carsessionDto;
            }
        }
    }

}
