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
            foreach(var paquete in c.paquetes)
            {
                if(paquete == p)
                {
                    throw new TrackingIdRepetidoException("Ya existe un paquete con el Tracking ID " + p.TrackingID);
                }
            }

            c.paquetes.Add(p);
            Thread t = new Thread(p.MockCicloDeVida);
            c.mockPaquetes.Add(t);
            t.Start();

            return c;
        }
        #endregion

    }
}
