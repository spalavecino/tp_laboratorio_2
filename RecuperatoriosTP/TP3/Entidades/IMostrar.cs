using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public interface IMostrar<T>
    {
        string MostrarDatos(IMostrar<T> elemento);
    }
}
