using System;
using System.Threading;
using System.Collections.Generic;

namespace Entidades
{
    public class Correo:IMostrar<List<Paquete>>
    {
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        #region Properties
        public List<Paquete> Paquetes
        {
            get
            {
                return this.paquetes;
            }

            set
            {
                this.paquetes = value;
            }
        }
        #endregion

        #region Constructors
        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.paquetes = new List<Paquete>();
        }
        #endregion

        #region Methods
        public void FinEntregas() { }

        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            return "";
        }

        public static Correo operator +(Correo c, Paquete p)
        {
            return c;
        }
        #endregion

    }
}
