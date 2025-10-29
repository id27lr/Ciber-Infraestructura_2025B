using WebService.Models;

namespace WebService.DataAccess
{
    public class DataAccessProvider : IDataAccessProvider
    {
        private readonly PostgreSqlContext _context;

        public DataAccessProvider(PostgreSqlContext context)
        {
            _context = context;
        }


        public List<catalumno> GetAlumnos()
        {
            return _context.catalumno.ToList();
        }

        public catalumno GetAlumnoById(int id)
        {
            return _context.catalumno.FirstOrDefault(a => a.id == id);
        }

        public void AgregarAlumno(catalumno alumno)
        {
            _context.catalumno.Add(alumno);
            _context.SaveChanges();
        }
    }
}
