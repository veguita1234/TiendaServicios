namespace TiendaServicios.Api.Libro.Application
{
    public class MaterialBookDto
    {
        public Guid? MaterialLibraryId { get; set; }

        public string Title { get; set; }

        public DateTime? PublicationDate { get; set; }

        public Guid? AuthorBook { get; set; }
    }
}
