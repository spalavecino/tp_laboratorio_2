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
        }
        #endregion

        #region Methods
        public static bool Insertar(Paquete p)
        {
            return true;
        }
        #endregion
    }
}
