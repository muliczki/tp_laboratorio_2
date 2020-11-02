using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
        where T : new()
    {
        /// <summary>
        /// Guardar datos en un archivo xml que por default va a estar en el desktop,
        /// si hay algun error, se lanza la excepcion ArchivosException
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Guardar(string archivo, T datos)
        {
            XmlTextWriter writer = null;
            XmlSerializer serializer = null;
            bool retorno = false;

            try
            {
                string rutaCompleta = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"/" + archivo + ".xml";
                writer = new XmlTextWriter(rutaCompleta, Encoding.UTF8);
                writer.Formatting = Formatting.Indented;
                serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(writer, datos);
                retorno = true;
            }
            catch (Exception e)
            {
                throw new ArchivosException("Error con el archivo!", e);
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }

            return retorno;
        }

        /// <summary>
        /// Lee datos en un archivo xml que por default va a estar en el desktop,
        ///  si hay algun error, se lanza la excepcion ArchivosException
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns>en el out se guardan los datos</returns>
        public bool Leer(string archivo, out T datos)
        {
            try
            {
                string rutaCompleta = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"/" + archivo + ".xml";
                using (XmlTextReader reader = new XmlTextReader(rutaCompleta))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    datos = (T)serializer.Deserialize(reader);
                    return true;
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException("Error con el archivo!", e);
            }
        }
    }
}
