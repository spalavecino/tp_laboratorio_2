﻿using System;
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
        public void FinEntregas() {
            foreach(var hilo in this.mockPaquetes)
            {
                if (hilo.IsAlive)
                {
                    hilo.Abort();
                }
            }
        }

        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            string str = "";

            if(elementos is Correo)
            {
                Correo correo = (Correo) elementos;

                foreach(var paquete in correo.paquetes)
                {
                    str += string.Format("{0} para {1} ({2})\n", paquete.TrackingID, paquete.DireccionEntrega, paquete.Estado.ToString());
                }
            }

            return str;
        }

        public static Correo operator +(Correo c, Paquete p)
        {
            foreach(var paquete in c.paquetes)
            {
                if(paquete == p)
                {
                    throw new TrackingIdRepetidoException("El Tracking ID " + p.TrackingID + " ya figura en la lista de envios.");
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
