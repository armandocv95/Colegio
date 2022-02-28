using Colegio.Models;
using ColegioApp.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Colegio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        private readonly ColegioCtx _myContext;

        public AlumnoController(ColegioCtx _myContext)
        {
            this._myContext = _myContext;
        }

        // GET: api/<AlumnoController>
        [HttpGet]
        public IActionResult Get()
        {
            var alumnos = this._myContext.Alumnos.ToList();
            return Ok(alumnos);
        }

        // GET api/<AlumnoController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var alumnos = _myContext.Alumnos.First(c => c.Id == id);
            return Ok(alumnos);
        }

        // POST api/<AlumnoController>
        [HttpPost]
        public IActionResult Post([FromBody] AlumnoView value)
        {
            Alumno alumno = new Alumno();
            alumno.Id = value.Id;
            alumno.Nombre = value.Nombre;
            alumno.Apellidos = value.Apellidos;
            alumno.Genero = value.Genero;
            alumno.Fecha = value.Fecha;
            _myContext.Alumnos.Add(alumno);
            _myContext.SaveChanges();
            return Created($"get-by-id?id={value.Id}", value);
        }

        // PUT api/<AlumnoController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] AlumnoView value)
        {
            Alumno alumno = new Alumno();
            alumno.Id = value.Id;
            alumno.Nombre = value.Nombre;
            alumno.Apellidos = value.Apellidos;
            alumno.Genero = value.Genero;
            alumno.Fecha = value.Fecha;
            _myContext.Alumnos.Update(alumno);
            _myContext.SaveChanges();
            return NoContent();
        }

        // DELETE api/<AlumnoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var alumno = _myContext.Alumnos.Find(id);
            if (alumno == null)
            {
                return NotFound();
            }
            _myContext.Alumnos.Remove(alumno);
            _myContext.SaveChanges();
            return NoContent();
        }
    }
}
