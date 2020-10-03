using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades
{
    public class Sedan : Vehiculo
    {
        public enum ETipo { CuatroPuertas, CincoPuertas }
        private ETipo tipo;

        /// <summary>
        /// Por defecto, TIPO será CuatroPuertas
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color)
            : this(marca, chasis, color, Sedan.ETipo.CuatroPuertas)
        {
        }


        /// <summary>
        /// Constructor con parametro del tipo
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        /// <param name="tipo"></param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color, ETipo tipo)
           : base(chasis, marca, color)
        {
            this.tipo = tipo;
        }


        /// <summary>
        /// Los automoviles son medianos
        /// </summary>
        protected override Vehiculo.ETamanio Tamanio
        {
            get
            {
                return Vehiculo.ETamanio.Mediano;
            }
        }


        /// <summary>
        /// Metodo sobreescrito Mostrar(), devuelve información general
        /// del vehiculo y los atributos especiales del sedan
        /// </summary>
        /// <returns>string con los datos relevantes.</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SEDAN");
            sb.AppendLine(base.Mostrar());
            sb.Append($"TAMAÑO : {this.Tamanio} ");
            sb.AppendLine($"TIPO : {this.tipo}");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
