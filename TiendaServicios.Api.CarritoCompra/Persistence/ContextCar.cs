using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.CarritoCompra.Model;

namespace TiendaServicios.Api.CarritoCompra.Persistence
{
    public class ContextCar : DbContext
    {
        public ContextCar(DbContextOptions<ContextCar> options) : base(options) { }

        public DbSet<CarSession> CarSession { get; set; }

        public DbSet<CarSessionDetail> CarSessionDetail { get; set; }
    }
}
