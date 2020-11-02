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

        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                j.alumnos.Add(a);
            }
           
            return j;
        }

        public static bool Guardar (Jornada j)
        {
            Texto texto = new Texto();
            return texto.Guardar("Jornada.txt", j.ToString()); 
        }

        public static string Leer()
        {
            Texto texto = new Texto();
            texto.Leer("Jornada.txt", out string datos);
            return datos;
        }

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


    }

}
