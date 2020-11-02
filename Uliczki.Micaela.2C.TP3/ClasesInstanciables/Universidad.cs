using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;

namespace ClasesInstanciables
{

    public class Universidad
    {
        public enum EClases { Programacion, Laboratorio, Legislacion, SPD};
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

        #region Constructores
        public Universidad()
        {
            alumnos = new List<Alumno>();
            jornada = new List<Jornada>();
            profesores = new List<Profesor>();

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

        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }

            set
            {
                this.profesores = value;
            }
        }

        public List<Jornada> Jornada
        {
            get
            {
                return this.jornada;
            }

            set
            {
                this.jornada = value;
            }
        }

        public Jornada this[int i]
        {
            get
            {
                try
                {
                    if (i < this.jornada.Count() && i >= 0)
                    {
                        return this.Jornada[i];
                    }
                    else
                    {

                        throw new NullReferenceException("Indice incorrecto!");
                    }

                }catch (Exception e)
                {
                    throw e;
                }
              
            }
            set
            {
                if (i > this.Jornada.Count() - 1)
                {
                    this.Jornada.Add(value);
                }
                else
                {
                    this.Jornada[i] = value;
                }
            }
        }

        #endregion

        #region Sobrecargas
        /// <summary>
        /// Un Universidad será igual a un Alumno si el mismo está inscripto en él.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns>true si lo esta</returns>
        public static bool operator == (Universidad g, Alumno a)
        {

            foreach (Alumno item in g.alumnos)
            {
                if(item == a)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Un Universidad será igual a un Alumno si el mismo NO está inscripto en él.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns>true si NO lo esta</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Un Universidad será igual a un Profesor si el mismo está dando clases en él.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns>true si lo esta</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {

            foreach (Profesor item in g.profesores)
            {
                if (item == i)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Un Universidad será igual a un Profesor si el mismo NO está dando clases en él.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns>true si NO lo esta</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// agregar Profesores mediante el operador +, validando que no estén previamente cargados.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns>objeto universidad</returns>
        public static Universidad operator + (Universidad g, Profesor i)
        {
            if (g != i)
            {
                g.profesores.Add(i);
            }

            return g;
        }

        /// <summary>
        ///  agregar ALumnos mediante el operador +, validando que no estén previamente cargados.
        ///  Si se repite, se lanza la excepcion AlumnoRepetido.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns>objeto universidad</returns>
        public static Universidad operator +(Universidad g, Alumno a)
        {
            if (g != a)
            {
                g.alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException("Alumno repetido.");
            }

            return g;

        }

        /// <summary>
        /// Al agregar una clase a un Universidad se deberá generar y agregar una nueva Jornada indicando la
        /// clase, un Profesor que pueda darla(según su atributo ClasesDelDia) y la lista de alumnos que la
        /// toman(todos los que coincidan en su campo ClaseQueToma).
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns>objeto universidad</returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Jornada nuevaJornada = new Jornada(clase, g == clase);
            g[g.jornada.Count] = nuevaJornada;

            foreach (Alumno item in g.alumnos)
            {
                if (!(item != clase))
                {
                    nuevaJornada += item;
                }
            }

            return g;
        }

        /// <summary>
        /// La igualación entre un Universidad y una Clase retornará el primer Profesor capaz de dar esa clase.
        /// Sino, lanzará la Excepción SinProfesorException.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns>profesor que de la clase</returns>
        public static Profesor operator ==(Universidad g, EClases clase)
        {
            foreach (Profesor item in g.Instructores)
            {
                if(item == clase)
                {
                    return item;
                }
            }

            throw new SinProfesorException("No hay profesor para la clase");
        }

        /// <summary>
        /// El distinto retornará el primer Profesor que no pueda dar la clase.
        /// Sino, lanzará la Excepción SinProfesorException.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns>profesor que no de la clase</returns>
        public static Profesor operator !=(Universidad g, EClases clase)
        {
            foreach (Profesor item in g.Instructores)
            {
                if (item != clase)
                {
                    return item;
                }
            }

            throw new SinProfesorException("No hay profesor para la clase");
        }

        #endregion

        #region Metodos

        /// <summary>
        ///  Metodo static MostrarDatos(), devuelve info de universidad
        /// </summary>
        /// <param name="uni"></param>
        /// <returns>string con datos de universidad</returns>
        private static string MostrarDatos (Universidad uni)
        {
            StringBuilder stb = new StringBuilder();

            stb.AppendLine("JORNADA: ");
            foreach (Jornada item in uni.Jornada)
            {
                stb.AppendLine(item.ToString());
                stb.AppendLine("<---------------------------------------------------------------------->");
            }

            return stb.ToString();
        }

        // <summary>
        /// Sobreescritura del metodo ToString()
        /// retorna todos los datos de la universidad.
        /// </summary>
        /// <returns>string con datos de la universidad</returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }


        /// <summary>
        /// Guardar de clase serializará los datos del Universidad en un XML, incluyendo todos los datos de sus
        /// Profesores, Alumnos y Jornadas.
        /// </summary>
        /// <param name="uni"></param>
        /// <returns>true si pudo guardar</returns>
        public static bool Guardar (Universidad uni)
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            return xml.Guardar("Universidad.xml", uni);
        }

        /// <summary>
        /// Leer de clase retornará un Universidad con todos los datos previamente serializados.
        /// </summary>
        /// <returns>objeto universidad</returns>
        public static Universidad Leer()
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            xml.Leer("Universidad.xml", out Universidad uni);
            return uni;
        }

        #endregion

    }
}
