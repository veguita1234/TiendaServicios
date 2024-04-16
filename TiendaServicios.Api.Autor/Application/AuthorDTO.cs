
using TiendaServicios.Api.Autor.Model;

namespace TiendaServicios.Api.Autor.Application
{
    public class AuthorDTO
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public DateTime? DateBirth { get; set; }

        public string AuthorBookGuid { get; set; }
    }
}
