using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{

    //Extensión del tipo Double, que devuelve un string con el valor formateado 
    //con 2 decimales y el signo $ por delante.

    public static class DoubleExtension
    {
        public static string FormatearPrecio(this double dato)
        {
            return "$ " + dato.ToString("##,###.00");
        }
    }
}
