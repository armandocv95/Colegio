using Colegio.Models;
using ColegioApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Colegio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradoController : ControllerBase
    {
        private readonly ColegioCtx _myContext;

        public GradoController(ColegioCtx _myContext)
        {
            this._myContext = _myContext;
        }

        // GET: api/<GradoController>
        [HttpGet]
        public IActionResult Get()
        {
            var grados = _myContext.Grados.Include(s => s.profesor).ToList();
            return Ok(grados);
        }

        // GET api/<GradoController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var grado = _myContext.Grados.Include(s => s.profesor).First(c => c.Id == id);
            return Ok(grado);
        }

        // POST api/<GradoController>
        [HttpPost]
        public IActionResult Post([FromBody] GradoView value)
        {
            Grado grado = new Grado();
            grado.Id = value.Id;
            grado.Nombre = value.Nombre;

            Profesor profesor = _myContext.Profesores.First(c => c.Id == value.IdProfesor);
            grado.profesor = profesor;

                _myContext.Grados.Add(grado);
                _myContext.SaveChanges();
                return Created($"get-by-id?id={value.Id}", value);
        }

        // PUT api/<GradoController>/5
        [HttpPut]
        public IActionResult Put([FromBody] GradoView value)
        {
            Grado grado = _myContext.Grados.First(c => c.Id == value.Id);
            grado.Id = value.Id;
            grado.Nombre = value.Nombre;

            Profesor profesor = _myContext.Profesores.First(c => c.Id == value.IdProfesor);
            grado.profesor = profesor;
                _myContext.Grados.Update(grado);
                _myContext.SaveChanges();
                return Ok();
        }

        // DELETE api/<GradoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Grado grado = _myContext.Grados.First(c => c.Id == id);
            _myContext.Grados.Remove(grado);
            _myContext.SaveChanges();
            return Ok();
        }
    }
}
