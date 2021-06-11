using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades;
using AccesoDatos;

namespace Models
{
    public class D_PreCompromisos
    {
        AD_PreCompromisos metodos = new AD_PreCompromisos();
        
        public DataTable CargaPreCompromisos()
        {
            return metodos.CargarPrecompromisos();
        }
    }
}
