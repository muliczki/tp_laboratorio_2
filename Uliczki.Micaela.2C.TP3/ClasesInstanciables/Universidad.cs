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


        public Universidad()
        {
            alumnos = new List<Alumno>();
            jornada = new List<Jornada>();
            profesores = new List<Profesor>();

        }

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

        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

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

        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        public static Universidad operator + (Universidad g, Profesor i)
        {
            if (g != i)
            {
                g.profesores.Add(i);
            }

            return g;
        }

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

        public override string ToString()
        {
            return MostrarDatos(this);
        }


        public static bool Guardar (Universidad uni)
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            return xml.Guardar("Universidad.xml", uni);
        }


        public static Universidad Leer()
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            xml.Leer("Universidad.xml", out Universidad uni);
            return uni;
        }



    }
}
