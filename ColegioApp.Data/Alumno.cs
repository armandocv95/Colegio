using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColegioApp.Data
{
    public class Alumno
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Genero { get; set; }
        public DateTime Fecha { get; set; }
        public ICollection<AlumnoGrado> alumnoGrados { get; set; }
    }

    public class Profesor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Genero { get; set; }
        public ICollection<Grado> grados { get; set; }
    }

    public class Grado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Profesor profesor { get; set; }
        public ICollection<AlumnoGrado> alumnoGrados { get; set; }
    }

    public class AlumnoGrado
    {
        public int Id { get; set; }
        public string Seccion { get; set; }
        public Alumno alumno { get; set; }
        public Grado grado { get; set; }
    }
}
