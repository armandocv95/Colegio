using Colegio.Models;
using ColegioApp.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Colegio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesorController : ControllerBase
    {
        private readonly ColegioCtx _myContext;

        public ProfesorController(ColegioCtx _myContext)
        {
            this._myContext = _myContext;
        }

        // GET: api/<ProfesorController>
        [HttpGet]
        public IActionResult Get()
        {
            var profesores = this._myContext.Profesores.ToList();
            return Ok(profesores);
        }

        // GET api/<ProfesorController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var profesores = _myContext.Profesores.First(c => c.Id == id);
            return Ok(profesores);
        }

        // POST api/<profesorController>
        [HttpPost]
        public IActionResult Post([FromBody] ProfesorView value)
        {
            Profesor profesor = new Profesor();
            profesor.Id = value.Id;
            profesor.Nombre = value.Nombre;
            profesor.Apellidos = value.Apellidos;
            profesor.Genero = value.Genero;
            _myContext.Profesores.Add(profesor);
            _myContext.SaveChanges();
            return Created($"get-by-id?id={value.Id}", value);
        }

        // PUT api/<ProfesorController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] ProfesorView value)
        {
            Profesor profesor = new Profesor();
            profesor.Id = value.Id;
            profesor.Nombre = value.Nombre;
            profesor.Apellidos = value.Apellidos;
            profesor.Genero = value.Genero;
            _myContext.Profesores.Update(profesor);
            _myContext.SaveChanges();
            return NoContent();
        }

        // DELETE api/<ProfesorController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var profesor = _myContext.Profesores.Find(id);
            if (profesor == null)
            {
                return NotFound();
            }
            _myContext.Profesores.Remove(profesor);
            _myContext.SaveChanges();
            return NoContent();
        }
    }
}
