using AutoMapper;
using MediatR;
using MySqlX.XDevAPI;
using TiendaServicios.Api.CarritoCompra.Model;
using TiendaServicios.Api.CarritoCompra.Persistence;

namespace TiendaServicios.Api.CarritoCompra.Application
{
    public class New
    {
        public class Execute : IRequest
        {
            public DateTime? CreationDateSession { get; set; }

            public List<string> ListProducts { get; set; }
        }

        public class Handler : IRequestHandler<Execute>
        {
            private readonly ContextCar _context;

            public Handler(ContextCar context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Execute request, CancellationToken cancellationToken)
            {
                var carsession = new CarSession
                {
                    CreationDate = request.CreationDateSession,
                };

                _context.CarSession.AddAsync(carsession);
                var value = await _context.SaveChangesAsync();

                if (value == 0)
                {
                    throw new Exception("Error en la insercion del carrito de compras");
                } 

                int id = carsession.CarSessionId;

                foreach (var obj in request.ListProducts)
                {
                    var SessionDetail = new CarSessionDetail
                    {
                        CreationDate = DateTime.Now,
                        CarSessionId = id,
                        SelectedProduct = obj
                    };

                    _context.CarSessionDetail.Add(SessionDetail);
                }

                value = await _context.SaveChangesAsync();

                if (value > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("No se puede insertar el detalle del carrito de compras");
            }
        }
    }
}
