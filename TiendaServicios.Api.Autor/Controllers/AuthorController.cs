using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiendaServicios.Api.Autor.Application;
using TiendaServicios.Api.Autor.Model;

namespace TiendaServicios.Api.Autor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {

        private readonly IMediator _mediator;

        public AuthorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Create(New.Execute data)
        {
            return await _mediator.Send(data);
        }

        [HttpGet]

        public async Task<ActionResult<List<AuthorDTO>>> GetAuthors()
        {
            return await _mediator.Send(new Queries.AuthorList());
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<AuthorDTO>> GetAuthorBook(string id)
        {
            return await _mediator.Send(new AuthorFilters.SoleAuthor { AuthorGuid = id });
        }
    }
}
