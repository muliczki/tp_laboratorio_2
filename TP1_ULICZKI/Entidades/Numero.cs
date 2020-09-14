using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase pública que permite crear objetos de tipo Número, 
    /// para poder realizar operaciones entre ellos o conversiones de decimal-binario o binario-decimal, previa validación.
    /// </summary>
    public class Numero
    { 
       /// <summary>
        /// Atributo privado en formato double que guarda un número.
        /// </summary>
        private double numero;

        /// <summary>
        /// Constructor por defecto que inicializa los campos del objeto en cero.
        /// </summary>
        public Numero()
        {
            this.SetNumero = "0";
        }

        /// <summary>
        /// Constructor que invoca al Set para asignar el parámetro recibido como DOUBLE al campo del objeto.
        /// </summary>
        /// <param name="numero">Numero double para asignar al campo del objeto.</param>
        public Numero (double numero)
        {
            this.SetNumero = numero.ToString();
        }

        /// <summary>
        /// Constructor que invoca al Set para asignar el parámetro recibido como STRING al campo del objeto.
        /// </summary>
        /// <param name="strNumero">Numero en string para asignar al campo del objeto.</param>
        public Numero (string strNumero)
        {
            this.SetNumero = strNumero;
        }

        /// <summary>
        /// Metodo privado que permite validar que el string recibido puede convertirse en formato double.
        /// Excepcion: En caso que no pueda convertir, devuelve un cero por default.
        /// </summary>
        /// <param name="strNumero">String para validar si se puede transformar en formato double.</param>
        /// <returns>El número transformado en formato double o un cero por default.</returns>
        private double ValidarNumero (string strNumero)
        {
            if(double.TryParse(strNumero, out double numero))
            {
                return numero;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Propiedad Set que va a asignar el value en el campo del objeto, previa validación del mismo. 
        /// Llama al método ValidarNumero().
        /// </summary>
        public string SetNumero 
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }

        /// <summary>
        /// Método privado y estático que valida que la cadena recibida contenga unicamente 0 y 1 (sea una cadena binaria).
        /// </summary>
        /// <param name="binario">Cadena a ser validada de que contenga solo 0 y 1.</param>
        /// <returns>True: si solo contiene 0 y 1. False: si encuentra algún caracter distinto de 0 y 1.</returns>
        private static bool EsBinario (string binario)
        {
            foreach (char caracter in binario)
            {
                if(caracter!= '0' && caracter != '1')
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Método que permite convertir un número binario a número decimal. 
        /// Primero llama a EsBinario() y valida que sea una cadena binaria. 
        /// Si es correcta la validación, realiza la conversión y obtiene el numero decimal.
        /// Si no, devuelve la leyenda "Valor inválido".
        /// </summary>
        /// <param name="binario">Cadena binaria a ser validada y posteriormente convertida a decimal</param>
        /// <returns>Cadena con el número decimal o la leyenda "Valor inválido" en caso que no se pueda convertir.</returns>
        public static string BinarioDecimal (string binario)
        {
            if(EsBinario(binario))
            {
                int largo, suma = 0; 

                largo = binario.Length - 1;

                for (int i = 0; i < binario.Length; i++)
                {
                    if (binario[largo] == '1')
                    {
                        suma += (int)Math.Pow(2, i);
                    }
                    largo--;
                }

                return suma.ToString();
            }
            else
            {
                return "Valor inválido";
            }
        }

        /// <summary>
        /// Sobrecarga del Método que permite convertir un número decimal a número binario. 
        /// Recibe un string de un numero. Lo intenta convertir a double. 
        /// En caso que pueda, llama a la otra sobrecarga de DecimalBinario(double), sino devuelve la leyenda "Valor inválido".
        /// </summary>
        /// <param name="numero">Cadena a ser validada de que pueda transformarse en número double.</param>
        /// <returns>Cadena con el numero binario o la leyenda "Valor inválido".</returns>
        public static string DecimalBinario (string numero)
        {
            if(double.TryParse(numero, out double numeroDouble))
            {
                return DecimalBinario(numeroDouble); 
            }else
            {
                return "Valor inválido";
            }
                
        }


        /// <summary>
        /// Sobrecarga del método, que permite convertir un número decimal a binario.
        /// Se queda con el valor entero y absoluto del double recibido.
        /// Convierte el número a binario. Devuelve una cadena.
        /// </summary>
        /// <param name="numero">Número double a ser transformado a binario.</param>
        /// <returns>Cadena con el número binario.</returns>
        public static string DecimalBinario(double numero)
        {
            numero = Math.Truncate(numero);
            numero = Math.Abs(numero);

            char bin;
            string cadena = string.Empty;

            do
            {
                if ((int)numero % 2 == 1)
                {
                    bin = '1';
                }
                else
                {
                    bin = '0';
                }

                numero = (int)numero / 2;

                cadena = bin + cadena;

            } while (numero > 0);

            return cadena;
        }


        /// <summary>
        /// Sobrecarga del operador +.
        /// Me permite sumar los campos de los objetos Número.
        /// </summary>
        /// <param name="n1">Objeto tipo Numero.</param>
        /// <param name="n2">Objeto tipo Numero.</param>
        /// <returns>La suma de los campos en double.</returns>
        public static double operator + (Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }


        /// <summary>
        /// Sobrecarga del operador -.
        /// Me permite restar los campos de los objetos Número.
        /// </summary>
        /// <param name="n1">Objeto tipo Numero.</param>
        /// <param name="n2">Objeto tipo Numero.</param>
        /// <returns>La resta de los campos en double.</returns>
        public static double operator - (Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }


        /// <summary>
        /// Sobrecarga del operador *.
        /// Me permite multiplicar los campos de los objetos Número.
        /// </summary>
        /// <param name="n1">Objeto tipo Numero.</param>
        /// <param name="n2">Objeto tipo Numero.</param>
        /// <returns>El producto de los campos en double.</returns>
        public static double operator * (Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }


        /// <summary>
        /// Sobrecarga del operador /.
        /// Me permite dividir los campos de los objetos Número.
        /// Excepción: en caso de que el campo del segundo parámetro sea un cero, devuelve el double.MinValue;
        /// </summary>
        /// <param name="n1">Objeto tipo Numero.</param>
        /// <param name="n2">Objeto tipo Numero.</param>
        /// <returns>La división de los campos en double o el double.MinValue.</returns>
        public static double operator / (Numero n1, Numero n2)
        {
            if (n2.numero == 0)
            {
                return double.MinValue;
            }
            else
            {
                return n1.numero / n2.numero;
            }
        }
    }
}
