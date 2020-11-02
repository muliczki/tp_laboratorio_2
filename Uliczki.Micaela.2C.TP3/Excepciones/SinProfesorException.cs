using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    /// <summary>
    /// Excepcion que se lanzara cuando no haya un profesor para dar la clase
    /// </summary>
    public class SinProfesorException :Exception
    {
        public SinProfesorException()
        {

        }

        public SinProfesorException(string mensaje) : base(mensaje)
        {

        }
    }
}
