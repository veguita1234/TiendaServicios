using FluentValidation;
using MediatR;
using TiendaServicios.Api.Autor.Model;
using TiendaServicios.Api.Autor.Persistence;

namespace TiendaServicios.Api.Autor.Application
{
    public class New
    {

        public class Execute : IRequest
        {
            public string Name { get; set; }

            public string LastName { get; set; }

            public DateTime? DateBirth { get; set; } 
            

        }

        public class ExecuteValidation : AbstractValidator<Execute>
        {
            public ExecuteValidation() 
            {
                RuleFor(x => x.Name).NotEmpty();
                RuleFor(x => x.LastName).NotEmpty();    
            }
        }

        public class Handler : IRequestHandler<Execute>
        {
            public readonly AuthorContext _context;
            
            public Handler(AuthorContext context)
            {
                _context = context; 
            }

            public async Task<Unit> Handle(Execute request, CancellationToken cancellationToken)
            {   
                // Convertir a hora peruana
                DateTime? dateBirthUtc = request.DateBirth; /*.HasValue ?*/
                /*TimeZoneInfo.ConvertTimeToUtc(request.DateBirth.Value, TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time")) : null;*/

                var authorbook = new AuthorBook
                {
                    Name = request.Name,
                    LastName = request.LastName,
                    DateBirth = dateBirthUtc,
                    AuthorBookGuid = Convert.ToString(Guid.NewGuid()),
                };

                _context.AuthorBook.Add(authorbook);
                var valor = await _context.SaveChangesAsync();

                if (valor > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("No se pudo insertar el Autor del libro");
            }
        }
    }
}
