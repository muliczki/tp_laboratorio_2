using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    /// <summary>
    /// Excepcion que se lanzara si existe algun problema al leer/guardar arcchivos
    /// </summary>
    public class ArchivosException :Exception
    {
        public ArchivosException(Exception innerException) : this("Error con el archivo!" ,innerException)
        {

        }

        public ArchivosException( string mensaje,  Exception innerException) : base(mensaje, innerException)
        {

        }

    }
}
