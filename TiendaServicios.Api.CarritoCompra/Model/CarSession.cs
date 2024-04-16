namespace TiendaServicios.Api.CarritoCompra.Model
{
    public class CarSession
    {
        public int CarSessionId { get; set; }

        public DateTime? CreationDate { get; set; }

        public ICollection<CarSessionDetail> ListDetail { get; set; }
    }
}
