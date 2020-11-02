using Archivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesInstanciables
{

    public class Jornada
    {

        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        #region Constructores
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor)
            :this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }

        #endregion

        #region Propiedades

        public List<Alumno> Alumnos 
        {
            get
            {
                return this.alumnos;
            }

            set
            {
                this.alumnos = value;
            }
        }

        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }

            set
            {
                this.clase = value;
            }
        }

        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }

            set
            {
                this.instructor = value;
            }
        }

        #endregion

        #region Metodos
        /// <summary>
        ///  Guardar de clase guardará los datos de la Jornada en un archivo de texto.
        /// </summary>
        /// <param name="j"></param>
        /// <returns>true si lo pudo guardar</returns>
        public static bool Guardar (Jornada j)
        {
            Texto texto = new Texto();
            return texto.Guardar("Jornada.txt", j.ToString()); 
        }

        /// <summary>
        /// Leer de clase retornará los datos de la Jornada como texto.
        /// </summary>
        /// <returns>string con los datos</returns>
        public static string Leer()
        {
            Texto texto = new Texto();
            texto.Leer("Jornada.txt", out string datos);
            return datos;
        }

        // <summary>
        /// Sobreescritura del metodo ToString()
        /// retorna todos los datos de la jornada.
        /// </summary>
        /// <returns>string con datos de la jornada</returns>
        public override string ToString()
        {
            StringBuilder stb = new StringBuilder();

            stb.Append($"CLASE DE {this.clase} POR ");
            stb.AppendLine(this.instructor.ToString());
            stb.AppendLine("ALUMNOS: ");
            foreach (Alumno item in alumnos)
            {
                stb.AppendLine(item.ToString());
            }


            return stb.ToString();
        }

        #endregion

        #region Sobrecargas
        /// <summary>
        /// Una Jornada será igual a un Alumno si el mismo participa de la clase.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns>true si lo hace</returns>
        public static bool operator == (Jornada j, Alumno a)
        {
            foreach (Alumno item in j.alumnos)
            {
                if(item == a)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Una Jornada será distinta a un Alumno si el mismo NO participa de la clase.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns>true si NO lo hace</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }


        /// <summary>
        /// Agregar Alumnos a la clase por medio del operador +,
        /// validando que no estén previamente cargados
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns>objeto jornada</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                j.alumnos.Add(a);
            }
           
            return j;
        }

        #endregion

    }

}
