namespace TiendaServicios.Api.CarritoCompra.Model
{
    public class CarSessionDetail
    {
        public int CarSessionDetailId { get; set; }

        public DateTime? CreationDate { get; set; }

        public string SelectedProduct { get; set; }

        public int CarSessionId { get; set; }

        public CarSession CarSession { get; set; }
    }
}
