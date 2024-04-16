namespace TiendaServicios.Api.Libro.Model
{
    public class MaterialLibrary
    {
        public Guid? MaterialLibraryId { get; set; }

        public string Title { get; set; }

        public DateTime? PublicationDate { get; set; }

        public Guid? AuthorBook {  get; set; }


    }
}
