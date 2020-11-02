using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasesAbstractas;
using EntidadesAbstractas;

namespace ClasesInstanciables
{

    public sealed class Alumno : Universitario
    {
        public enum EEstadoCuenta { AlDia, Deudor, Becado };

        private EEstadoCuenta estadoCuenta;
        private Universidad.EClases claseQueToma;

        #region Constructores
        public Alumno()
        {
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma) 
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Metodo override MostrarDatos(), devuelve info de universitario y alumno
        /// </summary>
        /// <returns>string con datos de universitario y alumno</returns>
        protected override string MostrarDatos()
        {
            StringBuilder stb = new StringBuilder();

            stb.AppendLine(base.MostrarDatos());
            stb.AppendLine($"ESTADO DE CUENTA: {this.estadoCuenta}");
            stb.AppendLine(this.ParticiparEnClase());

            return stb.ToString();
        }

        /// <summary>
        /// Metodo override PArticiparEnClase, informa la clase del alumno
        /// </summary>
        /// <returns>string con las clases que toma</returns>
        protected override string ParticiparEnClase()
        {
            return $"TOMA CLASES DE {this.claseQueToma}";
        }

        // <summary>
        /// Sobreescritura del metodo ToString()
        /// retorna todos los datos del alumno.
        /// </summary>
        /// <returns>string con datos de alumno</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion

        #region Sobrecargas
        /// <summary>
        /// Un Alumno será igual a un EClase si toma esa clase y su estado de cuenta no es Deudor.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns>true si lo es, false si no</returns>
        public static bool operator == (Alumno a, Universidad.EClases clase)
        {
            return (a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor);
        }

        /// <summary>
        /// Un Alumno será distinto a un EClase sólo si no toma esa clase.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns>true si lo es, false si no</returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return (a.claseQueToma != clase);
        }

        #endregion

    }
}
