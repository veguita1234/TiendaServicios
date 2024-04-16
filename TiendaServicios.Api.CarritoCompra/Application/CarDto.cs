namespace TiendaServicios.Api.CarritoCompra.Application
{
    public class CarDto
    {
        public int CarId { get; set; }

        public DateTime? CreateDateSession { get; set; }

        public List<CarDetailDto> ListProducts { get; set; }

        
    }
}
