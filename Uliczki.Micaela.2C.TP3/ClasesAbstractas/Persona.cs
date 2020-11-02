using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{

    //• Se deberá validar que el DNI sea correcto, teniendo en cuenta su nacionalidad.Argentino entre 1 y
    //89999999 y Extranjero entre 90000000 y 99999999. Caso contrario, se lanzará la excepción
    //NacionalidadInvalidaException.
    //• Si el DNI presenta un error de formato (más caracteres de los permitidos, letras, etc.) se lanzará
    //DniInvalidoException.
    //• Sólo se realizarán las validaciones dentro de las propiedades.
    //• Validará que los nombres sean cadenas con caracteres válidos para nombres.Caso contrario, no se
    //cargará.
    //• ToString retornará los datos de la Persona.

    public abstract class Persona
    {
        public enum ENacionalidad { Argentino, Extranjero }

        private string apellido;
        private string nombre;
        private int dni;
        private ENacionalidad nacionalidad;

        #region Propiedades
        public string Apellido
        {
            get
            {
                return this.apellido;
            }

            set
            {
                if(!string.IsNullOrEmpty(this.ValidarNombreApellido(value)))
                {
                    this.apellido = value;
                }

            }
        }

        public int DNI
        {
            get
            {
                return this.dni;
            }

            set
            {
                try
                {
                    this.dni = this.ValidarDni(this.Nacionalidad,value);
                }
                catch (NacionalidadInvalidaException ex)
                {
                    throw ex;
                }
            }
        }

        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }

            set
            {
                this.nacionalidad = value;
            }
        }

        public string Nombre
        {
            get
            {
                return this.nombre;
            }

            set
            {
                if (!string.IsNullOrEmpty(this.ValidarNombreApellido(value)))
                {
                    this.nombre = value;
                }
            }
        }

        public string StringToDNI
        {
            set
            {
                try
                {
                    this.dni = this.ValidarDni(this.Nacionalidad, value);
                }
                catch (NacionalidadInvalidaException ex)
                {
                    throw ex;
                }
                catch (DniInvalidoException ex)
                {
                    throw ex;
                }
            }
        }

        #endregion

        #region Constructores
        public Persona()
        {
        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            :this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        #endregion

        #region Metodos
        private int ValidarDni (ENacionalidad nacionalidad, int dato)
        {
            if(nacionalidad == ENacionalidad.Argentino && dato>= 1 && dato<= 89999999)
            {
                return dato;
            }
            else if (nacionalidad == ENacionalidad.Extranjero && dato >= 90000000 && dato <= 99999999)
            {
                return dato;
            }
            else
            {
                throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI");
            }
        }


        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            foreach (char c in dato)
            {
                if ((!(c >= '0' && c <= '9')) || dato.Length > 8)
                {
                    throw new DniInvalidoException("Ingrese un dni válido");
                }
            }

            bool pudo = int.TryParse(dato, out int dni);

            return this.ValidarDni(nacionalidad, dni);
           
        }


        private string ValidarNombreApellido(string dato)
        {
            foreach (char c in dato)
            {
                if ((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c==' ' && dato.Length > 1)
                {
                }
                else
                {
                    return "";
                }
            }

            return dato;
        }


        public override string ToString()
        {
            StringBuilder stb = new StringBuilder();

            stb.AppendLine($"NOMBRE COMPLETO: {this.Apellido}, {this.Nombre}");
            stb.AppendLine($"NACIONALIDAD: {this.Nacionalidad}");

            return stb.ToString();
        }

        #endregion
    }
}
