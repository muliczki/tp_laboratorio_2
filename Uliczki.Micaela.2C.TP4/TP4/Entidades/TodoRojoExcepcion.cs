using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TodoRojoException : Exception
    {
        public TodoRojoException(string mensaje, Exception innerException)
            : base(mensaje, innerException)
        {
        }

        public TodoRojoException(string mensaje)
            : base(mensaje)
        {
        }
    }
}
