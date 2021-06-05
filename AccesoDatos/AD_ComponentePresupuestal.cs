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
        //    public DataTable Consultar()
        //    {
        //        DataTable resultado = new DataTable();
        //        ArrayList Parametros = new ArrayList();

        //        resultado = Datos.ExecuteProcReader("SPS_AccesoValoresCtasFijas");

        //        if (resultado.Rows[0]["Conac"].ToString().ToUpper() == "SI")
        //        {
        //            Conac = true;
        //        }
        //        else
        //        {
        //            Conac = false;
        //        }

        //        keCtaImpuestosPorPagar = resultado.Rows[0]["keCtaImpuestosPorPagar"].ToString();
        //        keCtaProveedores = resultado.Rows[0]["keCtaProveedores"].ToString();
        //        keCtaAcreedores = resultado.Rows[0]["keCtaAcreedores"].ToString();
        //        keCtaBancos = resultado.Rows[0]["keCtaBancos"].ToString();
        //        keCtaDeudores = resultado.Rows[0]["keCtaDeudores"].ToString();
        //        keCtaFondosRevolventes = resultado.Rows[0]["keCtaFondosRevolventes"].ToString();
        //        keTituloReporte = resultado.Rows[0]["keTituloReporte"].ToString();
        //        keCtaCap4000 = resultado.Rows[0]["keCtaCap4000"].ToString();

        //        CtaRetencionConac = resultado.Rows[0]["CtaRetencionConac"].ToString();
        //        CtaRetencion1 = resultado.Rows[0]["CtaRetencion1"].ToString();
        //        CtaRetencion2 = resultado.Rows[0]["CtaRetencion2"].ToString();

        //        long_cta_contable = keCtaBancos.Length;

        //        Parametros.Clear();
        //        Parametros.Add(new miParametro("@Usuario", Login, SqlDbType.VarChar, 20));
        //        Parametros.Add(new miParametro("@Clave", Password, SqlDbType.VarChar, 200));

        //        //
        //        PermisoGeneral = 1; //por default Usuario
        //        kLogInUso = Login;
        //        resultado = Datos.ExecuteProcReader("SPS_PERFILES_USUARIOSPermisos", Parametros);
        //        if (resultado.Rows.Count > 0)
        //        {
        //            // Administrador     Permiso General = 0  ve todo y tiene los permisos de crear usuario y conceder todos los permisos
        //            // Usuario           Permiso General = 1  ve solo lo suyo
        //            // Súper User        Permiso General = 2  ve lo de su direccion
        //            // Supervisor        Permiso General = 3  ve lo de todas las direcciones, solo lo de su subsecretaria
        //            // Supervisor Mayor  Permiso General = 4  ve lo de todas las subsecretarias, solo de su secretaria
        //            // Coordinador       Permiso General = 5  ve lo de todas las subsecretarias, de todas las secretarias
        //            // Coordinador Mayor Permiso General = 6  ve todo de todas las secretarias, sin los permisos de crear usuario, ni conceder permisos
        //            Usuario = "0";
        //            SuperUsuario = "0";
        //            Supervisor = "0";
        //            Coordinador = "0";
        //            SupervisorMayor = "0";
        //            CoordinadorMayor = "0";
        //            Administrador = "0";

        //            if (resultado.Rows[0]["DisplayMember"].ToString().IndexOf("Usuario") > -1)
        //            {
        //                Usuario = "1";
        //                PermisoGeneral = 1;
        //            }
        //            if (resultado.Rows[0]["DisplayMember"].ToString().IndexOf("Súper User") > -1)
        //            {
        //                SuperUsuario = "1";
        //                PermisoGeneral = 2;
        //            }
        //            if (resultado.Rows[0]["DisplayMember"].ToString().IndexOf("Supervisor") > -1)
        //            {
        //                Supervisor = "1";
        //                PermisoGeneral = 3;
        //            }
        //            if (resultado.Rows[0]["DisplayMember"].ToString().IndexOf("Superv. Mayor") > -1)
        //            {
        //                SupervisorMayor = "1";
        //                PermisoGeneral = 4;
        //            }
        //            if (resultado.Rows[0]["DisplayMember"].ToString().IndexOf("Coordinador") > -1)
        //            {
        //                Coordinador = "1";
        //                PermisoGeneral = 5;
        //            }
        //            if (resultado.Rows[0]["DisplayMember"].ToString().IndexOf("Coord. Mayor") > -1)
        //            {
        //                CoordinadorMayor = "1";
        //                PermisoGeneral = 6;
        //            }
        //            if (resultado.Rows[0]["DisplayMember"].ToString().IndexOf("Administrador") > -1)
        //            {
        //                Administrador = "1";
        //                PermisoGeneral = 0;
        //            }
        //        }

        //        Parametros.Add(new miParametro("@SuperUsuario", SuperUsuario, SqlDbType.VarChar, 20));
        //        Parametros.Add(new miParametro("@Supervisor", Supervisor, SqlDbType.VarChar, 20));
        //        Parametros.Add(new miParametro("@Coordinador", Coordinador, SqlDbType.VarChar, 20));
        //        Parametros.Add(new miParametro("@SupervisorMayor", SupervisorMayor, SqlDbType.VarChar, 20));
        //        Parametros.Add(new miParametro("@CoordinadorMayor", CoordinadorMayor, SqlDbType.VarChar, 20));
        //        Parametros.Add(new miParametro("@Administrador", Administrador, SqlDbType.VarChar, 20));

        //        resultado = Datos.ExecuteProcReader("SPS_Acceso", Parametros);
        //        if (resultado.Rows.Count > 0)
        //        {
        //            UMA = Convert.ToDecimal(resultado.Rows[0]["UMA"].ToString());
        //            ente = resultado.Rows[0]["ente"].ToString();
        //            tipoente = resultado.Rows[0]["tipoente"].ToString();
        //            nombreusuario = resultado.Rows[0]["nombreempleado"].ToString();
        //            claveAdministrativa = resultado.Rows[0]["claveAdministrativa"].ToString();
        //            descclaveAdministrativa = resultado.Rows[0]["descclaveAdministrativa"].ToString();
        //            claveSecretaria = resultado.Rows[0]["claveSecretaria"].ToString();

        //            SelppClaveSecretaria = resultado.Rows[0]["claveSecretaria"].ToString();
        //            claveSubsecretaria = resultado.Rows[0]["claveSubsecretaria"].ToString();
        //            SelppClaveSubsecretaria = resultado.Rows[0]["claveSubsecretaria"].ToString();
        //            claveDireccion = resultado.Rows[0]["claveDireccion"].ToString();
        //            SelppClaveDireccion = resultado.Rows[0]["claveDireccion"].ToString();

        //            Activo = resultado.Rows[0]["Activo"].ToString();
        //            //Supervisor = resultado.Rows[0]["supervisor"].ToString();
        //            //SuperUsuario = resultado.Rows[0]["SuperUsuario"].ToString();
        //            //Coordinador = resultado.Rows[0]["coordinador"].ToString();

        //            clavePersonal = resultado.Rows[0]["clavePersonal"].ToString();
        //            Logeado = resultado.Rows[0]["Logeado"].ToString();
        //            Cancelado = resultado.Rows[0]["cancelado"].ToString();

        //            NombreUsuarioE = resultado.Rows[0]["nombreempleado"].ToString();
        //            cveUsuarioNomina = resultado.Rows[0]["cveUsuarioNomina"].ToString();
        //            //
        //            sec = resultado.Rows[0]["sec"].ToString();

        //            etq_secretaria = resultado.Rows[0]["etq_secretaria"].ToString();
        //            long_id_secretaria = resultado.Rows[0]["long_id_secretaria"].ToString();
        //            tipo_datos_secretaria = resultado.Rows[0]["tipo_datos_secretaria"].ToString();

        //            etq_subsecretaria = resultado.Rows[0]["etq_subsecretaria"].ToString();
        //            long_id_subsecretaria = resultado.Rows[0]["long_id_subsecretaria"].ToString();
        //            tipo_datos_subsecretaria = resultado.Rows[0]["tipo_datos_subsecretaria"].ToString();

        //            etq_direccion = resultado.Rows[0]["etq_direccion"].ToString();
        //            long_id_direccion = resultado.Rows[0]["long_id_direccion"].ToString();
        //            tipo_datos_direccion = resultado.Rows[0]["tipo_datos_direccion"].ToString();

        //            etq_obraaccion = resultado.Rows[0]["etq_obraaccion"].ToString();
        //            long_id_obraaccion = resultado.Rows[0]["long_id_obraaccion"].ToString();
        //            reg_exp_obraaccion = resultado.Rows[0]["reg_exp_obraaccion"].ToString();

        //            long_cta_bancaria = resultado.Rows[0]["long_cta_bancaria"].ToString();
        //            long_cta_clabe = resultado.Rows[0]["long_cta_clabe"].ToString();

        //            etq_SeparadorNivel = resultado.Rows[0]["SeparadorNivel"].ToString();
        //            long_cta_ctble3Nivel = resultado.Rows[0]["long_cta_ctble3Nivel"].ToString();
        //            long_cta_ctble4Nivel = resultado.Rows[0]["long_cta_ctble4Nivel"].ToString();
        //            long_cta_ctble5Nivel = resultado.Rows[0]["long_cta_ctble5Nivel"].ToString();
        //            long_cta_ctble6Nivel = resultado.Rows[0]["long_cta_ctble6Nivel"].ToString();

        //            diasXPeriodoNominaISR = resultado.Rows[0]["diasXPeriodoNominaISR"].ToString();

        //            try
        //            {
        //                DescProporcional = Convert.ToDecimal(resultado.Rows[0]["DescProporcional"].ToString());
        //            }
        //            catch
        //            {
        //                DescProporcional = 1.40M;
        //            }

        //            fecha_registro = resultado.Rows[0]["fecha_registro"].ToString();

        //            avisosWeb = resultado.Rows[0]["avisosWeb"].ToString();
        //            //
        //            rfcEnte = resultado.Rows[0]["rfc"].ToString();
        //            //
        //            Viaticos = resultado.Rows[0]["viaticos"].ToString();
        //            BolAvion = resultado.Rows[0]["bolavion"].ToString();

        //            enteAbreviado = resultado.Rows[0]["enteAbreviado"].ToString();
        //            clave_estado = resultado.Rows[0]["clave_estado"].ToString();

        //            if (resultado.Rows[0]["Auxiliares"].ToString().ToUpper() == "SI")
        //            {
        //                Auxiliares = true;
        //            }
        //            else
        //            {
        //                Auxiliares = false;
        //            }

        //            if (resultado.Rows[0]["TipoGRP"].ToString().ToUpper() == "0")  //version completa  0, Lite 1
        //            {
        //                VersionCompleta = true;
        //            }
        //            else
        //            {
        //                VersionCompleta = false;
        //            }

        //            //NombresDependencias(); //leo
        //        }
        //        //
        //        return resultado;
        //    }
        //}
    }
}
