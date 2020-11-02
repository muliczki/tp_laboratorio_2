using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    /// <summary>
    /// Excepcion que se lanzara cuando se intente agregar un alumno ya registrado
    /// </summary>
    public class AlumnoRepetidoException : Exception
    {
        public AlumnoRepetidoException()
        {

        }

        public AlumnoRepetidoException(string mensaje) : base(mensaje)
        {

        }
    }
}
