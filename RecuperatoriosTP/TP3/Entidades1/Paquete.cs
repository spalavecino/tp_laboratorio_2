using System;

namespace Entidades
{
    public class Paquete:IMostrar<Paquete>
    {
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;

        #region Properties
        public string DireccionEntrega
        {
            get
            {
                return this.direccionEntrega;
            }

            set
            {
                this.direccionEntrega = value;
            }
        }

        public EEstado Estado
        {
            get
            {
                return this.estado;
            }

            set
            {
                this.estado = value;
            }
        }

        public string TrackingID
        {
            get
            {
                return this.trackingID;
            }

            set
            {
                this.trackingID = value;
            }
        }
        #endregion

        #region Enums
        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }
        #endregion

        #region Contructors
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.direccionEntrega = direccionEntrega;
            this.trackingID = trackingID;
        }
        #endregion

        #region Methods
        public void MockCicloDeVida() { }

        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            string str = "";

            if(elemento is Paquete)
            {
                Paquete p = (Paquete) elemento;
                str = String.Format("{0} para {1}", p.trackingID, p.direccionEntrega);
            }
            
            return str;
        }

        public static bool operator ==(Paquete paquete1, Paquete paquete2)
        {
            return paquete1.trackingID == paquete2.trackingID;
        }

        public static bool operator !=(Paquete paquete1, Paquete paquete2)
        {
            return !(paquete1 == paquete2);
        }

        public override string ToString()
        {
            return this.MostrarDatos(this);
        }
        #endregion

        #region Events
        public delegate void DelegadoEstado();
        public event DelegadoEstado InformaEstado;
        #endregion
    }
}
