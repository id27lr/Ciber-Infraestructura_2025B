using Microsoft.AspNetCore.Mvc;
using WebService.DataAccess;
using WebService.Models;

namespace WebService.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class catalumnoController : ControllerBase
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        public catalumnoController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        public ActionResult<IEnumerable<catalumno>> Get()
        {
            return _dataAccessProvider.GetAlumnos();
        }

        [HttpGet("{id}")]
        public ActionResult<catalumno> Get(int id)
        {
            var alumno = _dataAccessProvider.GetAlumnoById(id);

            if (alumno == null)
            {
                return NotFound();
            }

            return Ok(alumno);
        }

        public ActionResult<catalumno> Post([FromBody] catalumno alumno)
        {
            if (alumno == null || string.IsNullOrEmpty(alumno.nombre))
            {
                return BadRequest("Nombre requerido.");
            }

            _dataAccessProvider.AgregarAlumno(alumno);

            return CreatedAtAction(nameof(Get), new { id = alumno.id }, alumno);
        }
    }
}
