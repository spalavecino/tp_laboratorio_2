using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace Entidades
{
    public static class PaqueteDAO
    {
        private static SqlCommand _comando;
        private static SqlConnection _conexion;

        #region Constructors
        static PaqueteDAO()
        {
            _conexion = new SqlConnection("Data Source=LAPTOP-A7RGHQPV\\SQLEXPRESS;Initial Catalog=correo-sp-2017;Integrated Security=True");
            _comando = new SqlCommand();
            _comando.CommandType = System.Data.CommandType.Text;
            _comando.Connection = _conexion;
        }
        #endregion

        #region Methods
        public static bool Insertar(Paquete p)
        {
            bool successTransaction = true;
            try
            {
                _comando.CommandText = "INSERT INTO Paquetes (direccionEntrega, trackingID, alumno) VALUES ('" + p.DireccionEntrega + "','" + p.TrackingID + "','Sebastian Palavecino');";
                _conexion.Open();
                _comando.ExecuteNonQuery();

            }
            catch (SqlException e)
            {
                successTransaction = false;
                throw e;
            }
            finally
            {
                if(_conexion != null && _conexion.State != System.Data.ConnectionState.Closed)
                {
                    _conexion.Close();
                }
            }

            return successTransaction;
        }
        #endregion
    }
}
