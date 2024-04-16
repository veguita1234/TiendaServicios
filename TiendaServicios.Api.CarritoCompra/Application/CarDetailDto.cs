namespace TiendaServicios.Api.CarritoCompra.Application
{
    public class CarDetailDto
    {
        public Guid? BookId { get; set; }

        public string TitleBook { get; set; }

        public string AuthorBook { get; set; }

        public DateTime? PublicationDate { get; set; }
    }
}
