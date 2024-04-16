using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.Libro.Model;

namespace TiendaServicios.Api.Libro.Persistence
{
    public class ContextLibrary:DbContext
    {
        public ContextLibrary() { }
        public ContextLibrary(DbContextOptions<ContextLibrary> options) : base(options) { }

        public virtual DbSet<MaterialLibrary> MaterialLibrary { get; set; }
    }
}
