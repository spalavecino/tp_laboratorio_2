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
        /// <summary>
        /// Simula el pasaje del paquete por los distintos estados hasta ser guardado en la base de datos
        /// </summary>
        public void MockCicloDeVida() {            
            bool paqueteEntregado = false;

            while(!paqueteEntregado)
            {
                Thread.Sleep(10000);
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
                            InformaExcepcion(new Exception("Se ha producido un error al intentar guardar los datos.", e));
                        }
                        catch(Exception e)
                        {
                            InformaExcepcion(new Exception("Se ha producido un error al intentar guardar los datos.", e));
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

        /// <summary>
        /// Devuelve un string con los datos del elemento que se le pase por parámetro
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Dice si dos paquetes son iguales teniendo en cuenta su trackingID
        /// </summary>
        /// <param name="paquete1"></param>
        /// <param name="paquete2"></param>
        /// <returns></returns>
        public static bool operator ==(Paquete paquete1, Paquete paquete2)
        {
            return paquete1.trackingID == paquete2.trackingID;
        }

        /// <summary>
        /// Dice si dos paquetes son distintos teniendo en cuenta su trackingID
        /// </summary>
        /// <param name="paquete1"></param>
        /// <param name="paquete2"></param>
        /// <returns></returns>
        public static bool operator !=(Paquete paquete1, Paquete paquete2)
        {
            return !(paquete1 == paquete2);
        }

        /// <summary>
        /// Devuelve en formato string los datos del objeto
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos(this);
        }
        #endregion

        #region Events
        public delegate void DelegadoEstado(object sender, EventArgs e);
        public delegate void DelegadoException(Exception e);
        public event DelegadoEstado InformaEstado;
        public event DelegadoException InformaExcepcion;
        #endregion
    }
}
