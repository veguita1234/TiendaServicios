namespace TiendaServicios.Api.CarritoCompra.RemoteModel
{
    public class BookRemote
    {
        public Guid? MaterialLibraryId { get; set; }

        public string Title { get; set; }

        public DateTime? PublicationDate { get; set; }

        public Guid? AuthorBook { get; set; }
    }
}
