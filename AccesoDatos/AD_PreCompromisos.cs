using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Entidades;

namespace AccesoDatos
{
    public class AD_PreCompromisos
    {
        public DataTable CargarPrecompromisos()
        {
            using (SqlConnection oConnection = new SqlConnection(AD_Conexion.CN))
            {
                SqlDataReader leer;
                DataTable dtPrecompromisos = new DataTable();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_SelectPrecompromisosCFDI", oConnection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConnection.Open();
                    leer = cmd.ExecuteReader();
                    dtPrecompromisos.Load(leer);
                    oConnection.Close();

                }
                catch (Exception ex)
                {

                    dtPrecompromisos = null;
                }
                return dtPrecompromisos;
            }
        }
    }
}
