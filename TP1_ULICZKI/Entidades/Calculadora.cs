using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// /Recibe como parametro un char y valida que sea alguno de los caracteres pedidos.
        /// En caso de que reciba un caracter erroneo, devuelve un + como string, sino el caracter validado como string
        /// </summary>
        /// <param name="operador">
        ///     Char - operador ingresado por usuario.
        /// </param>
        /// <returns>
        ///     Devuelve operador en string validado.
        /// </returns>
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
        /// 
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
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
