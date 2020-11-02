using EntidadesAbstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesAbstractas
{
    //• Abstracta, con el atributo Legajo.
    //• Método protegido y virtual MostrarDatos retornará todos los datos del Universitario.
    //• Método protegido y abstracto ParticiparEnClase.
    //• Dos Universitario serán iguales si y sólo si son del mismo Tipo y su Legajo o DNI son iguales.
    public abstract class Universitario : Persona
    {
        private int legajo;

        public Universitario()
        {

        }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

        protected virtual string MostrarDatos()
        {
            StringBuilder stb = new StringBuilder();

            stb.AppendLine(base.ToString());
            stb.AppendLine($"LEGAJO NÚMERO: {this.legajo}");

            return stb.ToString();
        }

        protected abstract string ParticiparEnClase();

        public override bool Equals(object obj)
        {
            return (obj is Universitario);
        }


        public static bool operator == (Universitario pg1, Universitario pg2)
        {
            if (pg1.Equals(pg2))
            {
                if (pg1.DNI == pg2.DNI || pg1.legajo == pg2.legajo)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
    }
}
