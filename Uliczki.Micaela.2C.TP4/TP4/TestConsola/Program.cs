using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace TestConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            Local local = new Local();

            local.Productos.Add(new Camiseta(10, 'S', 5000f, "ROJO", 0, "CAMIS-ROJA-S"));
            local.Productos.Add(new Camiseta(15, 'M', 5000f, "ROJO", 0, "CAMIS-ROJA-M"));


            Console.WriteLine(local.ToString());


            Console.ReadKey();

        }
    }
}
