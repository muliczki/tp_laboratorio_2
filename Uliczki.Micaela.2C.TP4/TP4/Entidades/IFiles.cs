using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Interfaz generica que va a ser implementada por el serializador para llevar a cabo el guardado y lectura de datos en binario
    /// </summary>
    /// <typeparam name="T"></typeparam>
    interface IFiles<T>
    {
        void SerializarBinario(T objeto, string rutaCompleta);


        T DeserializarBinario(string rutaCompleta);
    }
}
