namespace TiendaServicios.Api.Autor.Model
{
    public class AcademicLevel
    {

        public string AcademicLevelId { get; set; }

        public string Name { get; set; }

        public string AcademicCenter {  get; set; }

        public DateTime? GradeDate { get; set; }

        public int AuthorBookId { get; set; }

        public AuthorBook AuthorBook { get; set; }

        public string AcademicLevelGuid { get; set; }
    }
}
