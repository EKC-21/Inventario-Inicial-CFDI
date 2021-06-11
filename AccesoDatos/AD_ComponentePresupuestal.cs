using Entidades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class AD_ComponentePresupuestal
    {
        public static AD_ComponentePresupuestal _instancia = null;
        private static AD_ComponentePresupuestal Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new AD_ComponentePresupuestal();
                }
                return _instancia;
            }
        }
        public DataTable ConsultarAcceso()
        {
            SqlDataReader leer;
            DataTable data = new DataTable();
            using (SqlConnection oConnection = new SqlConnection(AD_Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SPS_AccesoValoresCtasFijas", oConnection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConnection.Open();
                    leer = cmd.ExecuteReader();
                    data.Load(leer);
                    oConnection.Close();
                }
                catch (Exception ex)
                {

                    data = null;
                }
            }
            return data;
        }
        public DataTable ConsultarEnteAdvo()
        {
            SqlDataReader leer;
            DataTable dtEnteAdvo = new DataTable();
            using (SqlConnection oConnection = new SqlConnection(AD_Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_Adc_CatClaveAdministrativa_Consultar", oConnection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConnection.Open();
                    leer = cmd.ExecuteReader();
                    dtEnteAdvo.Load(leer);
                    oConnection.Close();
                }
                catch (Exception ex)
                {

                    dtEnteAdvo = null;
                }
            }
            return dtEnteAdvo;
        }
        public DataTable ConsultarCveAdva()
        {
            SqlDataReader leer;
            DataTable dtCveAdva = new DataTable();
            using (SqlConnection oConnection = new SqlConnection(AD_Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sps_orgSecretaria", oConnection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConnection.Open();
                    leer = cmd.ExecuteReader();
                    dtCveAdva.Load(leer);
                    oConnection.Close();
                }
                catch (Exception ex)
                {

                    dtCveAdva = null;
                }
            }
            return dtCveAdva;
        }
        public DataTable ConsultaFteFinanciamiento()
        {
            SqlDataReader leer;
            DataTable dtftefin = new DataTable();
            using (SqlConnection oConnection = new SqlConnection(AD_Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("st_PrcGetCat_FuenteFinanciamientoSinTodas", oConnection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConnection.Open();
                    leer = cmd.ExecuteReader();
                    dtftefin.Load(leer);
                    oConnection.Close();
                }
                catch (Exception ex)
                {

                    dtftefin = null;
                }
            }
            return dtftefin;
        }
        public DataTable BuscarSecretaria(E_Secretaria obj)
        {
            SqlDataReader leer;
            DataTable dtSecretaria = new DataTable();
            using (SqlConnection oConnection = new SqlConnection(AD_Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sps_orgSecretaria", oConnection);
                    cmd.Parameters.Clear();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@claveAdministrativa", SqlDbType.VarChar, 50);
                    cmd.Parameters.Add("@claveSecretaria", SqlDbType.VarChar, 7);
                    cmd.Parameters.Add("@cog", SqlDbType.VarChar, 20);

                    cmd.Parameters["@claveAdministrativa"].Value = obj.ClavePresupuestal;
                    cmd.Parameters["@claveSecretaria"].Value = obj.ClaveSecretaria;
                    cmd.Parameters["@cog"].Value = obj.Cog;

                    oConnection.Open();
                    leer = cmd.ExecuteReader();
                    dtSecretaria.Load(leer);
                    oConnection.Close();
                    cmd.Parameters.Clear();
                }
                catch (Exception)
                {

                    throw;
                }
                return dtSecretaria;
            }
        }
        public DataTable BuscarSubSecretaria(E_Subsecretaria obj)
        {
            SqlDataReader leer;
            DataTable dtSubSecretaria = new DataTable();
            using (SqlConnection oConnection = new SqlConnection(AD_Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sps_orgSubsecretariaP", oConnection);
                    cmd.Parameters.Clear();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@claveSubsecretaria", SqlDbType.VarChar, 50);
                    cmd.Parameters.Add("@claveSecretaria", SqlDbType.VarChar, 7);
                    cmd.Parameters.Add("@claveAdministrativa", SqlDbType.VarChar, 20);

                    cmd.Parameters["@claveSubsecretaria"].Value = obj.ClaveSubsecretaria;
                    cmd.Parameters["@claveSecretaria"].Value = obj.ClaveSecretaria;
                    cmd.Parameters["@claveAdministrativa"].Value = obj.ClavePresupuestal;

                    oConnection.Open();
                    leer = cmd.ExecuteReader();
                    dtSubSecretaria.Load(leer);
                    oConnection.Close();
                    cmd.Parameters.Clear();
                }
                catch (Exception)
                {

                    throw;
                }
                return dtSubSecretaria;
            }
        }
        public DataTable BuscarDireccion(E_Direccion obj)
        {
            SqlDataReader leer;
            DataTable dtSubSecretaria = new DataTable();
            using (SqlConnection oConnection = new SqlConnection(AD_Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ADC_ConsultarOBraAccionPresII", oConnection);
                    cmd.Parameters.Clear();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Secretaria", SqlDbType.VarChar, 10);
                    cmd.Parameters.Add("@Subsecretaria", SqlDbType.VarChar, 10);
                    cmd.Parameters.Add("@cveAdmin", SqlDbType.VarChar, 20);
                    cmd.Parameters.Add("@anio", SqlDbType.Int, 0);

                    cmd.Parameters["@Secretaria"].Value = obj.ClaveSecretaria;
                    cmd.Parameters["@Subsecretaria"].Value = obj.ClaveSubsecretaria;
                    cmd.Parameters["@cveAdmin"].Value = obj.ClavePresupuestal;
                    cmd.Parameters["@anio"].Value = DateTime.Now.Year.ToString();

                    oConnection.Open();
                    leer = cmd.ExecuteReader();
                    dtSubSecretaria.Load(leer);
                    oConnection.Close();
                    cmd.Parameters.Clear();
                }
                catch (Exception)
                {

                    throw;
                }
                return dtSubSecretaria;
            }
        }
        public DataTable BuscarProyecto(string Secretaria, string SubSecretaria, string Direccion, string cveAdmin, Int32 anio)//, MetodoAcceso conexion)
        {
            SqlDataReader leer;
            DataTable dtProyectos = new DataTable();
            using (SqlConnection oConnection = new SqlConnection(AD_Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_POA_Proyectos_ConsultarProyectosSinTipoProyNew", oConnection);
                    cmd.Parameters.Clear();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@claveAdministrativa", SqlDbType.VarChar, 20);
                    cmd.Parameters.Add("@claveSecretaria", SqlDbType.VarChar, 10);
                    cmd.Parameters.Add("@claveSubsecretaria", SqlDbType.VarChar, 10);
                    cmd.Parameters.Add("@claveDireccion", SqlDbType.VarChar, 10);
                    cmd.Parameters.Add("@anio", SqlDbType.VarChar, 10);

                    cmd.Parameters["@claveAdministrativa"].Value = cveAdmin;
                    cmd.Parameters["@claveSecretaria"].Value = Secretaria;
                    cmd.Parameters["@claveSubsecretaria"].Value = SubSecretaria;
                    cmd.Parameters["@claveDireccion"].Value = Direccion;
                    cmd.Parameters["@anio"].Value = anio.ToString();

                    oConnection.Open();
                    leer = cmd.ExecuteReader();
                    dtProyectos.Load(leer);
                    oConnection.Close();
                    cmd.Parameters.Clear();
                }
                catch (Exception)
                {

                    throw;
                }
                return dtProyectos;
            }
        }
        public Int64 AltaPreCompromiso(E_Precompromiso e_Precompromiso)
        {
            using (SqlConnection oConnection = new SqlConnection(AD_Conexion.CN))
            {
                String tipoRequisicion = String.Empty;
                String iddestino = String.Empty;
                String tipoServicio = String.Empty;
                Int64 idPrecompromiso = 0;
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ADC_Precompromiso_Altas", oConnection);
                    cmd.Parameters.Clear();
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@numeroInterno", SqlDbType.VarChar, 30);
                    cmd.Parameters.Add("@estatus", SqlDbType.VarChar, 2);

                    //if (boton.Text.StartsWith("5."))
                    cmd.Parameters.Add("@idTipoGasto", SqlDbType.Int, 0);

                    cmd.Parameters.Add("@elabora", SqlDbType.VarChar, 60);
                    cmd.Parameters.Add("@autoriza", SqlDbType.VarChar, 60);
                    cmd.Parameters.Add("@claveAdva", SqlDbType.VarChar, 20);
                    cmd.Parameters.Add("@claveSecretaria", SqlDbType.VarChar, 7);
                    cmd.Parameters.Add("@claveSubsecretaria", SqlDbType.VarChar, 7);
                    cmd.Parameters.Add("@claveDireccion", SqlDbType.VarChar, 7);
                    cmd.Parameters.Add("@id_proyecto", SqlDbType.Int, 0);
                    cmd.Parameters.Add("@iddestino", SqlDbType.Int, 0);
                    cmd.Parameters.Add("@tipoRequisicion", SqlDbType.VarChar, 30);
                    cmd.Parameters.Add("@fechaSolicitud", SqlDbType.Date, 25);
                    cmd.Parameters.Add("@fechaAutorizacion", SqlDbType.Date, 25);
                    cmd.Parameters.Add("@justificacion", SqlDbType.VarChar, 500);
                    cmd.Parameters.Add("@especificaciones", SqlDbType.VarChar, 500);
                    cmd.Parameters.Add("@observaciones", SqlDbType.VarChar, 500);
                    cmd.Parameters.Add("@tipoServicio", SqlDbType.VarChar, 70);
                    cmd.Parameters.Add("@idppiclasificadorsubsidios", SqlDbType.VarChar, 10);
                    cmd.Parameters.Add("@nombreFF", SqlDbType.VarChar, 120);

                    if (string.IsNullOrEmpty(e_Precompromiso.AR))
                        e_Precompromiso.AR = DateTime.Now.Year.ToString();

                    cmd.Parameters.Add("@AR", SqlDbType.VarChar, 4);
                    cmd.Parameters.Add("@CveFF", SqlDbType.Int, 0);

                    cmd.Parameters["@numeroInterno"].Value = e_Precompromiso.NumeroInterno;
                    cmd.Parameters["@estatus"].Value = e_Precompromiso.Estatus;
                    cmd.Parameters["@idTipoGasto"].Value = e_Precompromiso.IdTipoGasto;
                    cmd.Parameters["@elabora"].Value = e_Precompromiso.Elabora;
                    cmd.Parameters["@autoriza"].Value = e_Precompromiso.Autoriza;
                    cmd.Parameters["@claveAdva"].Value = e_Precompromiso.CveAdva;
                    cmd.Parameters["@claveSecretaria"].Value = e_Precompromiso.ClaveSecretaria;
                    cmd.Parameters["@claveSubsecretaria"].Value = e_Precompromiso.ClaveSubsecretaria;
                    cmd.Parameters["@claveDireccion"].Value = e_Precompromiso.ClaveDireccion;
                    cmd.Parameters["@id_proyecto"].Value = e_Precompromiso.IdProyecto;
                    cmd.Parameters["@iddestino"].Value = e_Precompromiso.Iddestino;
                    cmd.Parameters["@tipoRequisicion"].Value = e_Precompromiso.TipoRequisicion;
                    cmd.Parameters["@fechaSolicitud"].Value = e_Precompromiso.FechaSolicitud;
                    cmd.Parameters["@fechaAutorizacion"].Value = e_Precompromiso.FechaAutorizacion;
                    cmd.Parameters["@justificacion"].Value = e_Precompromiso.Justificacion;
                    cmd.Parameters["@especificaciones"].Value = e_Precompromiso.Especificaciones;
                    cmd.Parameters["@observaciones"].Value = e_Precompromiso.Observaciones;
                    cmd.Parameters["@tipoServicio"].Value = e_Precompromiso.TipoServicio;
                    cmd.Parameters["@idppiclasificadorsubsidios"].Value = e_Precompromiso.idppiclasificadorsubsidios;
                    cmd.Parameters["@nombreFF"].Value = e_Precompromiso.nombreFF;
                    cmd.Parameters["@AR"].Value = e_Precompromiso.AR;
                    cmd.Parameters["@CveFF"].Value = e_Precompromiso.CveFF;

                    oConnection.Open();
                    //Recibo el retorno de la insercion
                    idPrecompromiso = Convert.ToInt64(cmd.ExecuteScalar());

                    oConnection.Close();
                }
                catch (Exception ex)
                {
                    throw new ArgumentException("No se guardó el registro" + "  " + ex.ToString());
                }
                return idPrecompromiso;
            }
        }
        public int EditarPreCompromiso(E_Precompromiso e_Precompromiso)
        {
            int respuesta = 5;
            using (SqlConnection oConnection = new SqlConnection(AD_Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ADC_Precompromiso_Cambios", oConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();

                    cmd.Parameters.Add("@idPrecompromiso", SqlDbType.BigInt);
                    cmd.Parameters.Add("@numeroInterno", SqlDbType.VarChar, 30);
                    cmd.Parameters.Add("@estatus", SqlDbType.VarChar, 2);
                    cmd.Parameters.Add("@idTipoGasto", SqlDbType.Int);
                    cmd.Parameters.Add("@autoriza", SqlDbType.VarChar, 60);
                    cmd.Parameters.Add("@claveSecretaria", SqlDbType.VarChar, 7);
                    cmd.Parameters.Add("@claveSubsecretaria", SqlDbType.VarChar, 7);
                    cmd.Parameters.Add("@claveDireccion", SqlDbType.VarChar, 7);
                    cmd.Parameters.Add("@id_proyecto", SqlDbType.Int);
                    cmd.Parameters.Add("@tipoRequisicion", SqlDbType.VarChar, 30);
                    cmd.Parameters.Add("@fechaAutorizacion", SqlDbType.Date);
                    cmd.Parameters.Add("@justificacion", SqlDbType.VarChar, 100);
                    cmd.Parameters.Add("@especificaciones", SqlDbType.VarChar, 200);
                    cmd.Parameters.Add("@observaciones", SqlDbType.VarChar, 200);
                    cmd.Parameters.Add("@iddestino", SqlDbType.Int);
                    cmd.Parameters.Add("@idppiclasificadorsubsidios", SqlDbType.VarChar, 10);
                    cmd.Parameters.Add("@AR", SqlDbType.Int);
                    cmd.Parameters.Add("@CveFF", SqlDbType.Int);

                    cmd.Parameters["@idPrecompromiso"].Value = e_Precompromiso.IdPrecompromiso;
                    cmd.Parameters["@numeroInterno"].Value = e_Precompromiso.NumeroInterno;
                    cmd.Parameters["@estatus"].Value = e_Precompromiso.Estatus;
                    cmd.Parameters["@idTipoGasto"].Value = e_Precompromiso.IdTipoGasto;
                    cmd.Parameters["@autoriza"].Value = e_Precompromiso.Autoriza;
                    cmd.Parameters["@claveSecretaria"].Value = e_Precompromiso.ClaveSecretaria;
                    cmd.Parameters["@claveSubsecretaria"].Value = e_Precompromiso.ClaveSubsecretaria;
                    cmd.Parameters["@claveDireccion"].Value = e_Precompromiso.ClaveDireccion;
                    cmd.Parameters["@id_proyecto"].Value = e_Precompromiso.IdProyecto;
                    cmd.Parameters["@tipoRequisicion"].Value = e_Precompromiso.TipoRequisicion;
                    cmd.Parameters["@fechaAutorizacion"].Value = e_Precompromiso.FechaAutorizacion;
                    cmd.Parameters["@justificacion"].Value = e_Precompromiso.Justificacion;
                    cmd.Parameters["@especificaciones"].Value = e_Precompromiso.Especificaciones;
                    cmd.Parameters["@observaciones"].Value = e_Precompromiso.Observaciones;
                    cmd.Parameters["@iddestino"].Value = e_Precompromiso.Iddestino;
                    cmd.Parameters["@idppiclasificadorsubsidios"].Value = e_Precompromiso.idppiclasificadorsubsidios;
                    cmd.Parameters["@AR"].Value = 0;
                    cmd.Parameters["@CveFF"].Value = e_Precompromiso.CveFF;

                    oConnection.Open();
                    respuesta = Convert.ToInt32(cmd.ExecuteScalar());
                    //cmd.ExecuteNonQuery();
                    oConnection.Close();
                    cmd.Parameters.Clear();
                }
                catch (Exception ex)
                {

                    return respuesta;
                }
                return respuesta;
            }
        }
        public int CancelarPreCompromiso(long IdPrecompromiso)
        {
            int respuesta = 5;
            using (SqlConnection oConnection = new SqlConnection(AD_Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ADC_Precompromiso_Bajas", oConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();

                    cmd.Parameters.Add("@idPrecompromiso", SqlDbType.BigInt);
                    cmd.Parameters["@idPrecompromiso"].Value = IdPrecompromiso;

                    oConnection.Open();
                    respuesta = Convert.ToInt32(cmd.ExecuteScalar());
                    oConnection.Close();
                    cmd.Parameters.Clear();
                }
                catch (Exception)
                {

                    return respuesta;
                }
                return respuesta;

            }
        }
    }
}
