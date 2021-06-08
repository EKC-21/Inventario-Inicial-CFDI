using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace AccesoDatos
{
    public class AD_ComponenteGasto
    {
        public static AD_ComponenteGasto _instancia = null;

        private static AD_ComponenteGasto Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new AD_ComponenteGasto();
                }
                return _instancia;
            }
        }

        public int ComprobarProveedor(E_Comprobante e_Comprobante)
        {
            int respuesta = 5;
            using (SqlConnection oConecction = new SqlConnection(AD_Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_IdProveedorXRFC", oConecction);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@rfc", SqlDbType.VarChar, 15);

                    cmd.Parameters["@rfc"].Value = e_Comprobante.EmisorRFC1;

                    oConecction.Open();

                    respuesta = Convert.ToInt32(cmd.ExecuteScalar());

                    oConecction.Close();
                    cmd.Parameters.Clear();

                }
                catch (Exception ex)
                {

                    return respuesta;
                }
            }
            return respuesta;
        }
        public int ComprobarFactura(E_Comprobante e_Comprobante)
        {
            var respuesta = 300;
            using (SqlConnection oConecction = new SqlConnection(AD_Conexion.CN))
            {
                try
                {

                    SqlCommand cmd = new SqlCommand("SP_AL_VerificarFactMismoProcesoXRFC", oConecction);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();

                    cmd.Parameters.Add("@rfcEmisor", SqlDbType.VarChar, 20);
                    cmd.Parameters.Add("@Factura", SqlDbType.VarChar, 50);
                    cmd.Parameters.Add("@proceso", SqlDbType.VarChar, 6);
                    cmd.Parameters.Add("@txtUUID", SqlDbType.VarChar, 50);

                    cmd.Parameters["@rfcEmisor"].Value = e_Comprobante.EmisorRFC1;
                    cmd.Parameters["@Factura"].Value = e_Comprobante.Folio;
                    cmd.Parameters["@proceso"].Value = "NE";
                    cmd.Parameters["@txtUUID"].Value = e_Comprobante.UUID1;

                    oConecction.Open();

                    respuesta = Convert.ToInt32(cmd.ExecuteScalar());

                    oConecction.Close();
                    cmd.Parameters.Clear();
                }
                catch (Exception ex)
                {

                    return respuesta;
                }
            }
            return respuesta;
        }

        public string GuardarXML(Conceptos conceptos)
        {
            string msg = "";
            using (SqlConnection oConection = new SqlConnection(AD_Conexion.CN))
            {
                try
                {

                    SqlCommand cmd = new SqlCommand("sp_AdcBienes_GuardarProdServ_Xml", oConection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@c_ClaveProdServ", SqlDbType.Int);
                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 300);
                    cmd.Parameters.Add("@siglaunimed", SqlDbType.VarChar, 50);
                    cmd.Parameters.Add("@costounidad", SqlDbType.Decimal, 20 - 4);
                    cmd.Parameters.Add("@descripcionbreve", SqlDbType.VarChar, 300);
                    cmd.Parameters.Add("@existencias", SqlDbType.Decimal, 20 - 4);
                    cmd.Parameters.Add("@msg", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;

                    cmd.Parameters["@c_ClaveProdServ"].Value = conceptos.ClaveProdServ1;
                    cmd.Parameters["@nombre"].Value = conceptos.Descripcion1;
                    cmd.Parameters["@siglaunimed"].Value = conceptos.Unidad1;
                    cmd.Parameters["@costounidad"].Value = conceptos.ValorUnitario1;
                    cmd.Parameters["@descripcionbreve"].Value = conceptos.Descripcion1;
                    cmd.Parameters["@existencias"].Value = conceptos.Cantidad1;

                    oConection.Open();

                    cmd.ExecuteNonQuery();

                    msg = Convert.ToString(cmd.Parameters["@msg"].Value.ToString());

                    oConection.Close();

                    cmd.Parameters.Clear();

                }
                catch (Exception ex)
                {

                    return ex.ToString();
                }
            }
            return msg;
        }
        public string GuardarCfdiConcepto(Conceptos conceptos)
        {
            string msg = "";
            using (SqlConnection oConnection = new SqlConnection(AD_Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_GuardarCfdiConceptos", oConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();

                    cmd.Parameters.Add("@ClaveProdServ", SqlDbType.Int);
                    cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar);
                    cmd.Parameters.Add("@Cantidad", SqlDbType.Decimal, 20 - 4);
                    cmd.Parameters.Add("@ClaveUnidad", SqlDbType.VarChar);
                    cmd.Parameters.Add("@Unidad", SqlDbType.VarChar);
                    cmd.Parameters.Add("@ValorUnitario", SqlDbType.Decimal, 20 - 4);
                    cmd.Parameters.Add("@Descuento", SqlDbType.VarChar);
                    cmd.Parameters.Add("@ImporteIvaUnitario", SqlDbType.Decimal, 20 - 4);
                    cmd.Parameters.Add("@msg", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;

                    cmd.Parameters["@ClaveProdServ"].Value = conceptos.ClaveProdServ1;
                    cmd.Parameters["@Descripcion"].Value = conceptos.Descripcion1;
                    cmd.Parameters["@Cantidad"].Value = conceptos.Cantidad1;
                    cmd.Parameters["@ClaveUnidad"].Value = conceptos.ClaveUnidad1;
                    cmd.Parameters["@Unidad"].Value = conceptos.Unidad1;
                    cmd.Parameters["@ValorUnitario"].Value = conceptos.ValorUnitario1;
                    cmd.Parameters["@Descuento"].Value = conceptos.Descuento;
                    cmd.Parameters["@ImporteIvaUnitario"].Value = conceptos.Importe1;

                    oConnection.Open();

                    cmd.ExecuteNonQuery();

                    msg = Convert.ToString(cmd.Parameters["@msg"].Value.ToString());

                    oConnection.Close();

                    cmd.Parameters.Clear();
                }
                catch (Exception ex)
                {

                    return ex.ToString();
                }
            }
            return msg;
        }
        public string GuardarCfdiTraslados(E_Comprobante e_Comprobante)
        {
            string msg = "";

            using (SqlConnection oConnection = new SqlConnection(AD_Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_GuardarCfdiTraslados", oConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();

                    cmd.Parameters.Add("@NoCertificado", SqlDbType.BigInt);
                    cmd.Parameters.Add("@Base", SqlDbType.Decimal, 20 - 4);
                    cmd.Parameters.Add("@Impuesto", SqlDbType.VarChar);
                    cmd.Parameters.Add("@TipoFactor", SqlDbType.VarChar);
                    cmd.Parameters.Add("@TasaOCuota", SqlDbType.Decimal, 20 - 4);
                    cmd.Parameters.Add("@ImporteImpuesto", SqlDbType.Decimal, 20 - 4);
                    cmd.Parameters.Add("@ClaveProdServ", SqlDbType.Int);
                    cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar);
                    cmd.Parameters.Add("@msg", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;

                    cmd.Parameters["@NoCertificado"].Value = e_Comprobante.NoCertificado;
                    cmd.Parameters["@Base"].Value = e_Comprobante.Base1;
                    cmd.Parameters["@Impuesto"].Value = e_Comprobante.Impuesto1;
                    cmd.Parameters["@TipoFactor"].Value = e_Comprobante.TipoFactor1;
                    cmd.Parameters["@TasaOCuota"].Value = e_Comprobante.TasaOCuota1;
                    cmd.Parameters["@ImporteImpuesto"].Value = e_Comprobante.ImporteImpuesto1;
                    //cmd.Parameters["@ClaveProdServ"].Value = obj.ClaveProdServ1;
                    //cmd.Parameters["@Descripcion"].Value = obj.Descripcion1;

                    oConnection.Open();

                    cmd.ExecuteNonQuery();

                    msg = Convert.ToString(cmd.Parameters["@msg"].Value.ToString());

                    oConnection.Close();

                    cmd.Parameters.Clear();
                }
                catch (Exception ex)
                {

                    return ex.ToString();
                }
            }
            return msg;
        }
        public string Guardar(DataTable data)
        {
            using (SqlConnection oConection = new SqlConnection(AD_Conexion.CN))
            {
                string msg = "OK";
                try
                {
                    if (data != null)
                    {
                        foreach (DataRow row in data.Rows)
                        {
                            SqlCommand cmd = new SqlCommand("sp_AdcBienes_GuardarProdServ_Xml", oConection);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Clear();

                            int clave = Convert.ToInt32(row["ClaveProdServ"].ToString());
                            string nombre = row["Descripcion"].ToString();
                            string unidad = row["Unidad"].ToString();
                            double costounidad = Convert.ToDouble(row["ValorUnitario"].ToString());
                            string desc = row["Descripcion"].ToString();
                            double existencias = Convert.ToDouble(row["Cantidad"].ToString());

                            cmd.Parameters.Add("@c_ClaveProdServ", SqlDbType.Int);
                            cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 300);
                            cmd.Parameters.Add("@siglaunimed", SqlDbType.VarChar, 50);
                            cmd.Parameters.Add("@costounidad", SqlDbType.Decimal, 20 - 4);
                            cmd.Parameters.Add("@descripcionbreve", SqlDbType.VarChar, 300);
                            cmd.Parameters.Add("@existencias", SqlDbType.Decimal, 20 - 4);
                            cmd.Parameters.Add("@msg", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;

                            cmd.Parameters["@c_ClaveProdServ"].Value = clave;
                            cmd.Parameters["@nombre"].Value = nombre;
                            cmd.Parameters["@siglaunimed"].Value = unidad;
                            cmd.Parameters["@costounidad"].Value = costounidad;
                            cmd.Parameters["@descripcionbreve"].Value = nombre;
                            cmd.Parameters["@existencias"].Value = existencias;

                            oConection.Open();

                            cmd.ExecuteNonQuery();

                            msg = cmd.Parameters["@msg"].Value.ToString();

                            oConection.Close();
                            cmd.Parameters.Clear();
                            //return msg;
                        }
                    }
                    else
                    {
                        return msg;
                    }
                }
                catch (Exception ex)
                {
                    return ex.ToString();

                }
                return msg;
            }
        }
        public int GuardarFactura(E_Comprobante e_Comprobante)
        {
            int respuesta = 5;
            using (SqlConnection oConnection = new SqlConnection(AD_Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_AL_RegistraFact", oConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();

                    cmd.Parameters.Add("@idProveedor", SqlDbType.BigInt);
                    cmd.Parameters.Add("@numeroFactura", SqlDbType.VarChar, 50);
                    cmd.Parameters.Add("@TablaOrigen", SqlDbType.VarChar, 50);
                    cmd.Parameters.Add("@Secuencial", SqlDbType.BigInt);
                    cmd.Parameters.Add("@importeTotal", SqlDbType.Decimal, 20 - 2);
                    cmd.Parameters.Add("@txtUUID", SqlDbType.VarChar, 50);
                    cmd.Parameters.Add("@txtbSerie", SqlDbType.VarChar, 15);
                    cmd.Parameters.Add("@txtVersion", SqlDbType.VarChar, 10);
                    cmd.Parameters.Add("@txtFormaPago", SqlDbType.VarChar, 3);
                    cmd.Parameters.Add("@txtMetodoPago", SqlDbType.VarChar, 6);
                    cmd.Parameters.Add("@txtTipoComprobante", SqlDbType.VarChar, 3);
                    cmd.Parameters.Add("@txtRFCEmisor", SqlDbType.VarChar, 20);
                    cmd.Parameters.Add("@txtRFCReceptor", SqlDbType.VarChar, 20);
                    cmd.Parameters.Add("@txtSubTotal", SqlDbType.Decimal, 15 - 2);
                    cmd.Parameters.Add("@txtTotal", SqlDbType.Decimal, 15 - 2);
                    cmd.Parameters.Add("@txtUuidRelacionado", SqlDbType.VarChar, 30);
                    cmd.Parameters.Add("@txtUsoCfdi", SqlDbType.VarChar, 3);
                    cmd.Parameters.Add("@txtnumParcialidad", SqlDbType.VarChar, 6);
                    cmd.Parameters.Add("@txtimporteSaldoAnterior", SqlDbType.Decimal, 15 - 2);
                    cmd.Parameters.Add("@txtimporteSaldoInsoluto", SqlDbType.Decimal, 15 - 2);
                    cmd.Parameters.Add("@idCogRastreo", SqlDbType.VarChar, 17);
                    cmd.Parameters.Add("@archivoOriginal", SqlDbType.VarChar, 260);

                    cmd.Parameters["@idProveedor"].Value = e_Comprobante.IdProveedor;
                    cmd.Parameters["@numeroFactura"].Value = e_Comprobante.Folio;
                    cmd.Parameters["@TablaOrigen"].Value = "NE";
                    cmd.Parameters["@Secuencial"].Value = 0;
                    cmd.Parameters["@importeTotal"].Value = e_Comprobante.Total;
                    cmd.Parameters["@txtUUID"].Value = e_Comprobante.UUID1;
                    cmd.Parameters["@txtbSerie"].Value = e_Comprobante.Serie;
                    cmd.Parameters["@txtVersion"].Value = e_Comprobante.Version;
                    cmd.Parameters["@txtFormaPago"].Value = e_Comprobante.Formapago;
                    cmd.Parameters["@txtMetodoPago"].Value = e_Comprobante.MetodoPago;
                    cmd.Parameters["@txtTipoComprobante"].Value = e_Comprobante.TipoDeComprobante;
                    cmd.Parameters["@txtRFCEmisor"].Value = e_Comprobante.EmisorRFC1;
                    cmd.Parameters["@txtRFCReceptor"].Value = e_Comprobante.ReceptorRFC1;
                    cmd.Parameters["@txtSubTotal"].Value = e_Comprobante.SubTotal;
                    cmd.Parameters["@txtTotal"].Value = e_Comprobante.Total;
                    cmd.Parameters["@txtUuidRelacionado"].Value = e_Comprobante.Uuidrelacionado;
                    cmd.Parameters["@txtUsoCfdi"].Value = e_Comprobante.UsoCFDI1;
                    cmd.Parameters["@txtnumParcialidad"].Value = 0;
                    cmd.Parameters["@txtimporteSaldoAnterior"].Value = 0;
                    cmd.Parameters["@txtimporteSaldoInsoluto"].Value = 0;
                    cmd.Parameters["@idCogRastreo"].Value = 0;
                    cmd.Parameters["@archivoOriginal"].Value = e_Comprobante.ArchivoOriginal;

                    oConnection.Open();
                    respuesta = Convert.ToInt32(cmd.ExecuteScalar());
                    oConnection.Close();
                    cmd.Parameters.Clear();

                }
                catch (Exception ex)
                {

                    return respuesta;
                }
            }
            return respuesta;
        }
        public string AgregarProveedor(E_Comprobante e_Comprobante)
        {
            string msg = "";
            using (SqlConnection oConnection = new SqlConnection(AD_Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_Adc_CatProveedoresBeneficiarios_AltasAux", oConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();

                    cmd.Parameters.Add("@password", SqlDbType.VarChar, 10);
                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 200);
                    cmd.Parameters.Add("@giro", SqlDbType.VarChar, 200);
                    cmd.Parameters.Add("@nombrefiscal", SqlDbType.VarChar, 200);
                    cmd.Parameters.Add("@direccion", SqlDbType.VarChar, 300);
                    cmd.Parameters.Add("@telefono", SqlDbType.VarChar, 15);
                    cmd.Parameters.Add("@contacto", SqlDbType.VarChar, 100);
                    cmd.Parameters.Add("@clasificacion", SqlDbType.VarChar, 13);
                    cmd.Parameters.Add("@rfc", SqlDbType.VarChar, 13);
                    cmd.Parameters.Add("@beneficiario", SqlDbType.VarChar, 120);
                    cmd.Parameters.Add("@FondoRev", SqlDbType.SmallInt);
                    cmd.Parameters.Add("@ivaSiNo", SqlDbType.SmallInt);
                    cmd.Parameters.Add("@ivaFletesManiobras", SqlDbType.SmallInt);
                    cmd.Parameters.Add("@comprobacionFiscal", SqlDbType.VarChar, 20);
                    cmd.Parameters.Add("@cuenta", SqlDbType.VarChar, 80);
                    cmd.Parameters.Add("@clabeInterbancaria", SqlDbType.VarChar, 18);
                    cmd.Parameters.Add("@clabeInterbancariaAlterna", SqlDbType.VarChar, 18);
                    cmd.Parameters.Add("@pagoTesofeEnte", SqlDbType.Bit);
                    cmd.Parameters.Add("@kIVAUsa", SqlDbType.Int, 10);
                    cmd.Parameters.Add("@Auxiliares", SqlDbType.Bit, 1);

                    cmd.Parameters["@password"].Value = "123456";
                    cmd.Parameters["@nombre"].Value = e_Comprobante.EmisorNombre1;
                    cmd.Parameters["@giro"].Value = "PENDIENTE";
                    cmd.Parameters["@nombrefiscal"].Value = e_Comprobante.EmisorNombre1;
                    cmd.Parameters["@direccion"].Value = "S/D";
                    cmd.Parameters["@telefono"].Value = "0000000000";
                    cmd.Parameters["@contacto"].Value = "PENDIENTE";
                    cmd.Parameters["@clasificacion"].Value = 2;
                    cmd.Parameters["@rfc"].Value = e_Comprobante.EmisorRFC1;
                    cmd.Parameters["@beneficiario"].Value = e_Comprobante.EmisorNombre1;
                    cmd.Parameters["@FondoRev"].Value = 0;
                    cmd.Parameters["@ivaSiNo"].Value = 1;
                    cmd.Parameters["@ivaFletesManiobras"].Value = 0;
                    cmd.Parameters["@comprobacionFiscal"].Value = "CFDI";
                    cmd.Parameters["@cuenta"].Value = e_Comprobante.Clave1;
                    cmd.Parameters["@clabeInterbancaria"].Value = "000000000000000000";
                    cmd.Parameters["@clabeInterbancariaAlterna"].Value = "000000000000000000";
                    cmd.Parameters["@pagoTesofeEnte"].Value = 0;
                    cmd.Parameters["@kIVAUsa"].Value = 0;
                    cmd.Parameters["@Auxiliares"].Value = Convert.ToInt32(e_Comprobante.Aux1);

                    oConnection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();

                }
                catch (Exception ex)
                {

                    return msg = ex.ToString(); ;
                }
                return msg;
            }
        }

        public DataTable LeerConcentradoConceptos()
        {
            SqlDataReader leer;
            DataTable data = new DataTable();
            using (SqlConnection oConnection = new SqlConnection(AD_Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_GetAllConceptosInvIni", oConnection);
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
        public string ConsultarClave()
        {
            string respuesta = "";
            using (SqlConnection oConnection = new SqlConnection(AD_Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_conparameter_parametro", oConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@Parametro", SqlDbType.VarChar, 60);

                    cmd.Parameters["@Parametro"].Value = "PROVEEDORES POR PAGAR A CORTO PLAZO";

                    oConnection.Open();
                    respuesta = Convert.ToString(cmd.ExecuteScalar());

                    oConnection.Close();
                    cmd.Parameters.Clear();

                }
                catch (Exception ex)
                {

                    return respuesta;
                }
            }
            return respuesta;
        }
        public string ConsultarAux()
        {
            string msg = "";
            using (SqlConnection oConnection = new SqlConnection(AD_Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_conparameter_parametro", oConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();

                    cmd.Parameters.Add("@Parametro", SqlDbType.VarChar, 60);

                    cmd.Parameters["@Parametro"].Value = "Auxiliares";

                    oConnection.Open();
                    msg = Convert.ToString(cmd.ExecuteScalar());
                    oConnection.Close();
                    cmd.Parameters.Clear();
                }
                catch (Exception ex)
                {

                    return ex.ToString(); ;
                }
            }
            return msg;
        }
        public DataTable ConsultaCtaContable5()
        {
            DataTable dtCta5nivel = new DataTable();
            SqlDataReader leer;

            using (SqlConnection oConnection = new SqlConnection(AD_Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SPS_Ctas5nivelProveedores", oConnection);
                    cmd.Parameters.Clear();
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConnection.Open();
                    leer = cmd.ExecuteReader();
                    dtCta5nivel.Load(leer);
                    oConnection.Close();

                }
                catch (Exception ex)
                {

                    return dtCta5nivel = null;
                }
                return dtCta5nivel;
            }
        }
        public string CuentasContablesP(string Tipo, string Nombre, string BusCuenta)
        {
            string cuenta = "";

            using (SqlConnection oConecction = new SqlConnection(AD_Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sps_CuentasContablesProveedores", oConecction);
                    cmd.Parameters.Clear();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@tipo", SqlDbType.VarChar, 1);
                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 300);
                    cmd.Parameters.Add("@busCuenta", SqlDbType.VarChar, 80);

                    cmd.Parameters["@tipo"].Value = Tipo;
                    cmd.Parameters["@nombre"].Value = Nombre;
                    cmd.Parameters["@busCuenta"].Value = BusCuenta;

                    oConecction.Open();
                    cuenta = Convert.ToString(cmd.ExecuteScalar());
                    oConecction.Close();
                    cmd.Parameters.Clear();

                    return cuenta;
                }
                catch (Exception ex)
                {

                    throw new ArgumentException(ex.Message);
                }
            }
        }
    }
}
