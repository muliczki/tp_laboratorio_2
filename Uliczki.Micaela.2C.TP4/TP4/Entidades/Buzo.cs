using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Buzo : Producto
    {
        private string tela;
        
        public Buzo(int stock, char talle, double precio, string color, int codigo, string descripcion, string tela)
            : base(stock, talle, precio, color, codigo, descripcion)
        {
            this.tela = tela;
        }

        public Buzo()
        {

        }

        protected override string Mostrar()
        {
            StringBuilder stb = new StringBuilder();

           // stb.AppendLine($"BUZO");
            stb.AppendLine(base.Mostrar());

            return stb.ToString();
        }
    }
}
