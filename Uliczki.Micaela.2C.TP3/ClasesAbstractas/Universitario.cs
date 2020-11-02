using EntidadesAbstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesAbstractas
{

    public abstract class Universitario : Persona
    {
        private int legajo;

        #region Constructores
        public Universitario()
        {

        }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

        #endregion

        #region Metodos
        /// <summary>
        /// Metodo virtual MostrarDatos(), devuelve info de persona y universitario
        /// </summary>
        /// <returns>string con datos de persona y universitario</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder stb = new StringBuilder();

            stb.AppendLine(base.ToString());
            stb.AppendLine($"LEGAJO NÚMERO: {this.legajo}");

            return stb.ToString();
        }

        /// <summary>
        /// Metodo abstracto ParticiparEnClase
        /// </summary>
        /// <returns>string con participación</returns>
        protected abstract string ParticiparEnClase();

        /// <summary>
        /// Sobreescritura del metodo Equals, devuelve si el objeto del parametro es un universiatario
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>true si lo es, false si no</returns>
        public override bool Equals(object obj)
        {
            return (obj is Universitario);
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Sobrecarga ==, 
        /// dos Universitario serán iguales si y sólo si son del mismo Tipo y su Legajo o DNI son iguales.
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns>true si lo son, false si no</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
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

        /// <summary>
        /// Sobrecarga !=, 
        /// dos Universitario serán distintos si no son del mismo Tipo o su Legajo o DNI son distintos.
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns>true si lo son, false si no</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
        #endregion
    }
}
