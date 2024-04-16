using FluentValidation;
using MediatR;
using TiendaServicios.Api.Libro.Model;
using TiendaServicios.Api.Libro.Persistence;

namespace TiendaServicios.Api.Libro.Application
{
    public class New
    {
        public class Execute : IRequest
        {
            public string Title { get; set; }

            public DateTime? PublicationDate { get; set; }

            public Guid? AuthorBook { get; set; }
        }

        public class ExecuteValidation : AbstractValidator<Execute>
        {
            public ExecuteValidation() 
            {
                RuleFor(x => x.Title).NotEmpty();
                RuleFor(x => x.PublicationDate).NotEmpty();
                RuleFor(x => x.AuthorBook).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Execute>
        {
            public readonly ContextLibrary _context;

            public Handler(ContextLibrary context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(Execute request, CancellationToken cancellationToken)
            {
                var book = new MaterialLibrary
                {
                    Title = request.Title,
                    PublicationDate = request.PublicationDate,
                    AuthorBook = request.AuthorBook
                };

                _context.MaterialLibrary.Add(book);

                var value = await _context.SaveChangesAsync();

                if (value > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("No se pudo guardar el libro");
            }
        }
    }
}
