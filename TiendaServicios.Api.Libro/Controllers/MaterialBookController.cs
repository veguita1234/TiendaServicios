using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiendaServicios.Api.Libro.Application;

namespace TiendaServicios.Api.Libro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialBookController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MaterialBookController (IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Create(New.Execute data)
        {
            return await _mediator.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult<List<MaterialBookDto>>> GetBooks()
        {
            return await _mediator.Send(new Queries.Execute());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MaterialBookDto>> GetUnitBook(Guid id)
        {
            return await _mediator.Send(new FilterQuery.UnitBook { BookId = id});
        }
    }
}
