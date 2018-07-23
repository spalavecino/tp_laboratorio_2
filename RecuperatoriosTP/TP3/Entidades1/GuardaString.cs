using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Entidades
{
    public static class GuardaString
    {
        public static bool Guardar(this String texto, string archivo)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            path += "/" + archivo;

            try
            {
                StreamWriter sw = new StreamWriter(path, true, Encoding.UTF8);
                sw.Write(texto);

                return true;
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

            return false;
        }
    }
}
