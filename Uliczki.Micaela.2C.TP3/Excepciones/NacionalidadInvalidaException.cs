using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    /// <summary>
    /// Excepcion que se lanzara cuando la nacionalidad no coincida con el numero de dni
    /// </summary>
    public class NacionalidadInvalidaException : Exception
    {
        public NacionalidadInvalidaException()
        {

        }

        public NacionalidadInvalidaException(string mensaje) :base(mensaje)
        {

        }
    }
}
