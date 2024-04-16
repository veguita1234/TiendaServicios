using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.Autor.Model;

namespace TiendaServicios.Api.Autor.Persistence
{
    public class AuthorContext : DbContext
    {

        public AuthorContext(DbContextOptions<AuthorContext> options) :base(options) { }

        public DbSet <AcademicLevel> AcademicLevel { get; set;}

        public DbSet <AuthorBook> AuthorBook { get; set;}
    }
}