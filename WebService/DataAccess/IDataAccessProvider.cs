using WebService.Models;

namespace WebService.DataAccess
{
    public interface IDataAccessProvider
    {
        List<catalumno> GetAlumnos();
        catalumno GetAlumnoById(int id);
        void AgregarAlumno(catalumno alumno);
    }
}
