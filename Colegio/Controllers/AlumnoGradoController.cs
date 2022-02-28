using Colegio.Models;
using ColegioApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Colegio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoGradoController : ControllerBase
    {
        private readonly ColegioCtx _myContext;

        public AlumnoGradoController(ColegioCtx _myContext)
        {
            this._myContext = _myContext;
        }

        // GET: api/<AlumnoGradoController>
        [HttpGet]
        public IActionResult Get()
        {
            var grados = this._myContext.AlumnoGrados.Include(s => s.alumno).Include(s => s.grado).ToList();
            return Ok(grados);
        }

        // GET api/<AlumnoGradoController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var grado = _myContext.AlumnoGrados.Include(s => s.alumno).Include(s => s.grado).First(c => c.Id == id);
            return Ok(grado);
        }

        // POST api/<AlumnoGradoController>
        [HttpPost]
        public IActionResult Post([FromBody] AlumnoGradoView value)
        {
            AlumnoGrado grado = new AlumnoGrado();
            grado.Id = value.Id;
            grado.Seccion = value.Seccion;

            Alumno alumno = _myContext.Alumnos.First(c => c.Id == value.IdAlumno);
            grado.alumno = alumno;

            Grado g = _myContext.Grados.First(c => c.Id == value.IdGrado);
            grado.grado = g;

            _myContext.AlumnoGrados.Add(grado);
            _myContext.SaveChanges();
            return Created($"get-by-id?id={value.Id}", value);
        }

        // PUT api/<AlumnoGradoController>/5
        [HttpPut]
        public IActionResult Put([FromBody] AlumnoGradoView value)
        {
            AlumnoGrado grado = _myContext.AlumnoGrados.First(c => c.Id == value.Id);
            grado.Id = value.Id;
            grado.Seccion = value.Seccion;

            Alumno alumno = _myContext.Alumnos.First(c => c.Id == value.IdAlumno);
            grado.alumno = alumno;

            Grado g = _myContext.Grados.First(c => c.Id == value.IdGrado);
            grado.grado = g;

            _myContext.AlumnoGrados.Update(grado);
            _myContext.SaveChanges();
            return Ok();
        }

        // DELETE api/<AlumnoGradoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            AlumnoGrado grado = _myContext.AlumnoGrados.First(c => c.Id == id);
            _myContext.AlumnoGrados.Remove(grado);
            _myContext.SaveChanges();
            return Ok();
        }
    }
}
