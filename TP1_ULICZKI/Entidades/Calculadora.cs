using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{   
    /// <summary>
    /// Clase estática que me permite realizar operaciones (+ - / *) entre dos números. 
    /// Me permite validar el operador que ingresó el usuario.
    /// </summary>
    public static class Calculadora
    {
        /// <summary>
        /// Recibe como parametro un char y valida que sea alguno de los caracteres pedidos (+ - / *).
        /// En caso de recibir un caracter erróneo, devuelve un + por default.
        /// </summary>
        /// <param name="operador">Char ingresado por usuario para validar.</param>
        /// <returns>Operador en string validado o el "+" por default.</returns>
        private static string ValidarOperador (char operador)
        {
            if(operador=='+' || operador=='-' || operador=='*' || operador=='/')
            {
                return operador.ToString();
            }else
            {
                return "+";
            }
            
        }

        /// <summary>
        /// Valida el string recibido, en caso de ser una cadena vacía asigna un +.
        /// Si no está vacía, llama al método "ValidarOperador". 
        /// Con el operador validado, realiza alguna de las operaciones posibles (+ - / *) entre los dos numeros recibidos.
        /// Excepción: en caso de que se intente dividir y el num2 sea un cero, devolverá el double.MinValue.
        /// </summary>
        /// <param name="num1">Objeto de tipo Numero, elegido por el usuario</param>
        /// <param name="num2">Objeto de tipo Numero, elegido por el usuario</param>
        /// <param name="operador">Operador a validar, elegido por el usuario</param>
        /// <returns>El resultado de la operación entre los dos números en formato double.</returns>
        public static double Operar (Numero num1, Numero num2, string operador)
        {
            if(string.IsNullOrEmpty(operador)) // valido que no este vacia la cadena
            {
                operador = "+";
            }
            else
            {
                operador = ValidarOperador(operador[0]); // si no esta vacia o nula, llamo a validar operador,  
                                                         // le paso el primer caracter de la cadena. Me devuelve string.
            }

            switch (operador)
            {
                case "-":
                    return num1 - num2;

                case "*":
                    return num1 * num2;

                case "/":
                    return num1 / num2;

                default:
                    return num1 + num2;

            }

           

        }
    }
}
