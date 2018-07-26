using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Entidades
{
    public static class GuardaString
    {
        /// <summary>
        /// Guarda un texto dado en un archivo en el escritorio
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="archivo"></param>
        /// <returns></returns>
        public static bool Guardar(this String texto, string archivo)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            path += "/" + archivo;
            StreamWriter sw = null;
            bool archivoGuardado = false;

            try
            {
                sw = new StreamWriter(path, true, Encoding.UTF8);
                sw.Write(texto);
                archivoGuardado = true;                
            }catch(IOException e)
            {
                Console.WriteLine(e.Message);
            }catch(UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
            }catch(ArgumentException e)
            {
                Console.Write(e.Message);
            }catch(NotSupportedException e)
            {
                Console.WriteLine(e.Message); 
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if(sw != null)
                {
                    sw.Close();
                }
            }

            return archivoGuardado;
        }
    }
}
