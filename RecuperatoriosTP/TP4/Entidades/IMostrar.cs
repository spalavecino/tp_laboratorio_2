using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public interface IMostrar<T>
    {
        /// <summary>
        /// Devuelve un string con los datos correspondientes al elemento que se le pase por parámetro
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns></returns>
        string MostrarDatos(IMostrar<T> elemento);
    }
}
