using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Camiseta : Producto
    {
        public Camiseta(int stock, char talle, double precio, string color, int codigo, string descripcion)
          : base(stock, talle, precio, color, codigo, descripcion)
        {
        }

        public Camiseta()
        {

        }

        protected override string Mostrar()
        {
            StringBuilder stb = new StringBuilder();

           // stb.AppendLine($"CAMISETA");
            stb.AppendLine(base.Mostrar());

            return stb.ToString();
        }

    }
}
