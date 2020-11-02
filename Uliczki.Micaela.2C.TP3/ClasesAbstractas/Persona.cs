using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{

    public abstract class Persona
    {
        public enum ENacionalidad { Argentino, Extranjero }

        private string apellido;
        private string nombre;
        private int dni;
        private ENacionalidad nacionalidad;

        #region Propiedades
        /// <summary>
        /// Get/Set de apellido con las validaciones correspondientes
        /// </summary>
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

        /// <summary>
        /// Get/Set de DNI con las validaciones correspondientes
        /// </summary>
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

        /// <summary>
        /// Get/Set de nacionalidad
        /// </summary>
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

        /// <summary>
        /// Get/Set de nombre con las validaciones correspondientes
        /// </summary>
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

        /// <summary>
        /// Get/Set de dni en string con las validaciones correspondientes
        /// </summary>
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
        /// <summary>
        /// Metodo que valida que el DNI sea correcto, teniendo en cuenta su nacionalidad. 
        /// Argentino entre 1 y 89999999 y Extranjero entre 90000000 y 99999999. 
        /// Caso contrario, se lanzará la excepción NacionalidadInvalidaException
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns>Numero de Dni en int</returns>
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

        /// <summary>
        /// Metodo que parsea la cadena que recibe e intenta transformalo en un Dni.
        /// Si el DNI presenta un error de formato (más caracteres de los permitidos, letras, etc.) 
        /// se lanzará DniInvalidoException.
        /// Luego llama a ValidarDni(nac, int)
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns>Numero de Dni en int</returns>
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


        /// <summary>
        /// Validará que los nombres sean cadenas con caracteres válidos para nombres. 
        /// Caso contrario, no se cargará.
        /// </summary>
        /// <param name="dato"></param>
        /// <returns>String con nombre si es correcto, string vacio si es erroneo</returns>
        private string ValidarNombreApellido(string dato)
        {
            foreach (char c in dato)
            {
                if ((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c==' ' && dato.Length > 2)
                {
                }
                else
                {
                    return "";
                }
            }

            return dato;
        }


        /// <summary>
        /// Sobreescritura del metodo ToString()
        /// retorna todos los datos de la persona.
        /// </summary>
        /// <returns>string con datos de persona</returns>
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
