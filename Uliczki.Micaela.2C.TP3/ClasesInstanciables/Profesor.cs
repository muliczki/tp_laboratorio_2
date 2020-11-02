using ClasesAbstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClasesInstanciables
{

    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        public Profesor()
        {
        }

        static Profesor()
        {
            random = new Random();
        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) 
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            clasesDelDia = new Queue<Universidad.EClases>();

            this._randomClases();
            Thread.Sleep(2000);
            this._randomClases();

        }

        private void _randomClases()
        {
            this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(0, 4));
        }

        protected override string ParticiparEnClase()
        {
            StringBuilder stb = new StringBuilder();

            stb.AppendLine("CLASES DEL DIA:");
            foreach (Universidad.EClases item in this.clasesDelDia)
            {
                stb.AppendLine($"{item}");
            }

            return stb.ToString();
        }


        protected override string MostrarDatos()
        {
            StringBuilder stb = new StringBuilder();

            stb.AppendLine(base.MostrarDatos());
            stb.AppendLine(this.ParticiparEnClase());

            return stb.ToString();
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }


        public static bool operator == (Profesor i, Universidad.EClases clase)
        {
            foreach (Universidad.EClases item in i.clasesDelDia)
            {
               if(item == clase)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

    }
}
