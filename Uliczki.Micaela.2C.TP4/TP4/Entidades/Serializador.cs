using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Entidades
{
    public class Serializador<T> : IFiles<T>
         where T : class, new()
    {

        public Serializador()
        {

        }


        /// <summary>
        /// Serializa el tipo generico a binario 
        /// </summary>
        /// <param name="ruta">Ruta del archivo a serializar.</param>
        /// <returns></returns>
        public void SerializarBinario(T objeto, string rutaCompleta)
        {
            Stream writer = null;
            BinaryFormatter serializer = null;

            try
            {
                writer = new FileStream(rutaCompleta, FileMode.Create);
                serializer = new BinaryFormatter();
                serializer.Serialize(writer, objeto);
            }
            catch (Exception ex)
            {
                throw new TodoRojoException("Ocurrió un error al tratar de serializar el archivo a binario.", ex);
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }
        }


        /// <summary>
        /// Deserializo de binario a genérico 
        /// </summary>
        /// <param name="ruta">Ruta del archivo a serializar.</param>
        /// <returns></returns>
        public T DeserializarBinario(string rutaCompleta)
        {
            try
            {
                using (Stream reader = new FileStream(rutaCompleta, FileMode.Open))
                {
                    BinaryFormatter serializer = new BinaryFormatter();
                    return (T)serializer.Deserialize(reader);
                }
            }
            catch (Exception ex)
            {
                throw new TodoRojoException("Ocurrió un error al tratar de deserializar el archivo XML.", ex);
            }
        }
    }
}
