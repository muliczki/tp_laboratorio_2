using System;
using System.Collections.Generic;
using System.Text;

namespace Archivos
{
    /// <summary>
    /// Interfaz que me permitira leer y guardar archivos
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IArchivo<T>
    {
        bool Guardar(string archivo, T datos);
        bool Leer(string archivo, out T datos);
    }
}
