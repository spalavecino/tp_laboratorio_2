using System;
using System.Threading;
using System.Data.SqlClient;

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
        public void MockCicloDeVida() {            
            bool paqueteEntregado = false;

            while(!paqueteEntregado)
            {
                Thread.Sleep(2000);
                switch (this.estado)
                {
                    case EEstado.Ingresado:
                        this.estado = EEstado.EnViaje;
                        break;
                    case EEstado.EnViaje:
                        this.estado = EEstado.Entregado;
                        break;
                    case EEstado.Entregado:
                        try
                        {
                            PaqueteDAO.Insertar(this);
                        }
                        catch (SqlException e)
                        {
                            ExcepcionMock(e);
                        }
                        finally
                        {
                            paqueteEntregado = true;
                        }
                        break;
                }

                InformaEstado(this, null);
            }
        }

        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            string str = "";

            if(elemento is Paquete)
            {
                Paquete p = (Paquete) elemento;
                str = String.Format("{0} para {1}\n", p.trackingID, p.direccionEntrega);
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
        public delegate void DelegadoEstado(object sender, EventArgs e);
        public delegate void DelegadoException(Exception e);
        public event DelegadoEstado InformaEstado;
        public event DelegadoException ExcepcionMock;
        #endregion
    }
}
