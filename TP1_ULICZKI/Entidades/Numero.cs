using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        public Numero()
        {
            numero = 0;
        }

        public Numero (double numero)
        {
            this.SetNumero = numero.ToString();
        }

        public Numero (string strNumero)
        {
            this.SetNumero = strNumero;
        }


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

        public string SetNumero // ver porque el string
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }


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

        public static string BinarioDecimal (string binario)
        {
            //validar entero meh
            if(EsBinario(binario))
            {
                int numero, suma = 0; /// cambiar nombre de variable

                numero = binario.Length - 1;

                for (int i = 0; i < binario.Length; i++)
                {
                    if (binario[numero] == '1')
                    {
                        suma += (int)Math.Pow(2, i);
                    }
                    numero--;
                }

                return suma.ToString();
            }
            else
            {
                return "Valor inválido";
            }
        }


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

        public static string DecimalBinario(double numero)
        {
           // if()
            numero = Math.Truncate(numero);
            numero = Math.Abs(numero);

            char bin;
            string cadena = "";

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



        public static double operator + (Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        public static double operator /(Numero n1, Numero n2)
        {
            if(n2.numero == 0)
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
