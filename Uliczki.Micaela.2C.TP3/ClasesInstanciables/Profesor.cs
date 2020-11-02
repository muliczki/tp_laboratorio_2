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

        #region Constructores
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
        #endregion

        #region Metodos
        /// <summary>
        /// Asignara una clase al azar al Profesor
        /// </summary>
        private void _randomClases()
        {
            this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(0, 4));
        }


        /// <summary>
        /// Metodo override PArticiparEnClase, informa las clases del profesor
        /// </summary>
        /// <returns>string con las clases que da</returns>
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

        // <summary>
        /// Metodo override MostrarDatos(), devuelve info de universitario y profesor
        /// </summary>
        /// <returns>string con datos de universitario y profesor</returns>
        protected override string MostrarDatos()
        {
            StringBuilder stb = new StringBuilder();

            stb.AppendLine(base.MostrarDatos());
            stb.AppendLine(this.ParticiparEnClase());

            return stb.ToString();
        }

        // <summary>
        /// Sobreescritura del metodo ToString()
        /// retorna todos los datos del prof.
        /// </summary>
        /// <returns>string con datos de prof</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion

        #region Sobrecargas

        /// <summary>
        /// Un Profesor será igual a un EClase si da esa clase
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns>true si la da, false si no</returns>
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

        /// <summary>
        /// Un Profesor será distinto a un EClase si NO da esa clase
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns>true si NO la da, false si la da</returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        #endregion
    }
}
