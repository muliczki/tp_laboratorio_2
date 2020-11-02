using Excepciones;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        public bool Guardar(string archivo, string datos)
        {
            StreamWriter streamWriter = null;
            bool retorno = false;

            try
            {
                string rutaCompleta = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"/" + archivo + ".txt";
                streamWriter = new StreamWriter(rutaCompleta, false);
                streamWriter.WriteLine(datos);
                retorno = true;
            }
            catch (Exception e)
            {
                throw new ArchivosException("Error con el archivo!", e);
            }
            finally
            {
                if (streamWriter != null)
                {
                    streamWriter.Close();
                }
            }

            return retorno;

        }

        public bool Leer(string archivo, out string datos)
        {
            StreamReader streamReader = null;
            bool retorno = false;

            try
            {
                string rutaCompleta = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"/" + archivo + ".txt";
                streamReader = new StreamReader(rutaCompleta);

                datos = string.Empty;
                string newLine = streamReader.ReadLine();

                while (newLine != null)
                {
                    datos += newLine + "\n";
                    newLine = streamReader.ReadLine();
                }

                retorno = true;
            }
            catch (Exception e)
            {
                throw new ArchivosException("Error con el archivo!", e);
            }
            finally
            {
                if (streamReader != null)
                {
                    streamReader.Close();
                }
            }

            return retorno;
        }
    }
}
