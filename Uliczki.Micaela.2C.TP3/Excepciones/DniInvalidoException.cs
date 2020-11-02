using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    /// <summary>
    /// Excepcion que se lanzara cuando haya un error de formato en el dni de las personas
    /// </summary>
    public class DniInvalidoException : Exception
    {

        public DniInvalidoException()
        {

        }


        public DniInvalidoException(string mensaje) : base(mensaje)
        {

        }
    }
}
