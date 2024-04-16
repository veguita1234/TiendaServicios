namespace TiendaServicios.Api.Autor.Model
{
    public class AuthorBook
    {

        public int AuthorBookId { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public DateTime? DateBirth { get; set; }

        public ICollection<AcademicLevel> ListAcademicLevel { get; set; }

        public string AuthorBookGuid { get; set; }
    }
}
