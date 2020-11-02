using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClasesInstanciables;
using ClasesAbstractas;
using Excepciones;

namespace TestUnitario
{
    [TestClass]
    public class UnitTest
    {
        /// <summary>
        /// Test que permite controlar que al instanciar una nueva Jornada,
        /// la lista de alumnos no sea nula
        /// </summary>
        [TestMethod]
        public void InstanciarListaAlumnosEnJornadaOK()
        {
            Jornada j = new Jornada(Universidad.EClases.Laboratorio,new Profesor(12, "Jose", "Martinez","12345678", EntidadesAbstractas.Persona.ENacionalidad.Argentino));

            Assert.IsNotNull(j.Alumnos);
        }

        /// <summary>
        /// Test que permite controlar que al instanciar una nueva universidad,
        /// la lista de alumnos, profesores y jornadas no sean nulas
        /// </summary>
        [TestMethod]
        public void InstanciarListaJornadasEnUniversidadOK()
        {
            Universidad u = new Universidad();

            Assert.IsNotNull(u.Jornada);
            Assert.IsNotNull(u.Alumnos);
            Assert.IsNotNull(u.Instructores);
        }

        /// <summary>
        /// Controlar que la excepción DniInvalido
        /// se lance al intentar cargar un Dni sin el formato correcto.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void DniInvalidoExcepcion()
        {
            Alumno alumno = new Alumno(22, "Camila", "Lopez", "qwerdsa", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Legislacion);
        }

        /// <summary>
        /// Controlar que la excepción NacionalidadINvalida
        /// se lance al intentar cargar un Dni con una nacionalidad incorrecta.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void NacionalidadInvalidaExcepcion()
        {
            Profesor prof = new Profesor(22, "Camila", "Lopez", "92323432", EntidadesAbstractas.Persona.ENacionalidad.Argentino);
        }


        /// <summary>
        /// Controlar que la excepción AlumnoRepetido
        /// se lance al intentar agregar a un mismo alumno a una Universidad.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(AlumnoRepetidoException))]
        public void AlumnoRepetidoExcepcion()
        {
            Alumno alumno = new Alumno(22, "Camila", "Lopez", "12345678", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Legislacion, Alumno.EEstadoCuenta.AlDia);
            Universidad u = new Universidad();

            u += alumno;
            u += alumno;


        }

    }
}
