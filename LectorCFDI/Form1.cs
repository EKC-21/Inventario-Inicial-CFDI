using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Linq;
using System.Collections;
using Entidades;
using Newtonsoft.Json;

namespace LectorCFDI
{
    public partial class Form1 : Form
    {
        #region "Declaraciones"
        E_Comprobante e_Comprobante = new E_Comprobante();
        Conceptos concepto = new Conceptos();
        D_ComponenteGasto metodos = new D_ComponenteGasto();
        DataTable codigos = new DataTable();
        DataTable data = new DataTable();
        DataTable datat = new DataTable();
        ArrayList xml = new ArrayList();
        ComponentePresupuestal CompPres = new ComponentePresupuestal();
        #endregion

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            gbLstXml.ForeColor = Color.White;
            gbTotales.ForeColor = Color.White;
            groupBox1.ForeColor = Color.White;

            dgvRegNotFound.ForeColor = Color.Black;
            dgvTotalConceptos.ForeColor = Color.Black;
            LlenarAcumuladoConceptos();
        }

        #region "Metodos"
        private void InicializarOpenFileDialog()
        {
            this.openFileDialog1.Filter = "|*.xml";
            this.openFileDialog1.Multiselect = true;
            openFileDialog1.ShowDialog();
        }
        private void LlenarListBox()
        {
            InicializarOpenFileDialog();

            foreach (string file in openFileDialog1.SafeFileNames)
            {
                FileInfo f = new FileInfo(file);
                xml.Add(f);
            }
            lstXml.DataSource = xml;

            ProcesarTodosXml();
            GuardarConceptos();
        }
        private void LlenarAcumuladoConceptos()
        {
            dgvRegNotFound.DataSource = metodos.GetAllConceptos();
        }
        private void GuardarConceptos()
        {
            try
            {
                if (dgvCFDI.DataSource != null)
                {
                    foreach (DataGridViewRow row in dgvTotalConceptos.Rows)
                    {
                        if (row.Cells["Descuento"].Value.ToString() == null || row.Cells["Descuento"].Value.ToString() == "") { concepto.Descuento = 0; } else { concepto.Descuento = Convert.ToDouble(row.Cells["Descuento"].Value.ToString()); }
                        concepto.ClaveProdServ1 = Convert.ToInt32(row.Cells["ClaveProdServ"].Value.ToString());
                        concepto.Descripcion1 = row.Cells["Descripcion"].Value.ToString();
                        concepto.Cantidad1 = Convert.ToDouble(row.Cells["Cantidad"].Value.ToString());
                        concepto.ClaveUnidad1 = row.Cells["ClaveUnidad"].Value.ToString();
                        concepto.Unidad1 = row.Cells["Unidad"].Value.ToString();
                        concepto.ValorUnitario1 = Convert.ToDouble(row.Cells["ValorUnitario"].Value.ToString());
                        concepto.Importe1 = Convert.ToDouble(row.Cells["ImporteIva"].Value.ToString());

                        string Respuesta = metodos.GuardarConceptosCfdi(concepto);
                    }
                    LlenarAcumuladoConceptos();
                }
                else
                {
                    MessageBox.Show("No se enontraron datos para procesar, seleccione un archivo porfavor.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void RegularProveedores()
        {
            XNamespace nsCFDI33 = "http://www.sat.gob.mx/cfd/3";

            DataSet ds = new DataSet();
            DataTable dtEmisor = new DataTable();
            DataTable dtCtaContable = new DataTable();

            string filepath = "";
            int respuesta = 0;
            string cuenta = "";

            foreach (string file in openFileDialog1.SafeFileNames)
            {
                filepath = "C:\\Xml\\" + file;
                ds.ReadXml(filepath);
                dtEmisor = ds.Tables["Emisor"];
                dtCtaContable = metodos.ConsultaCtaContable();
                cuenta = dtCtaContable.Rows[1]["Nombre"].ToString().Substring(0, 12);

                e_Comprobante.EmisorRFC1 = dtEmisor.Rows[0]["Rfc"].ToString();
                e_Comprobante.EmisorNombre1 = dtEmisor.Rows[0]["Nombre"].ToString();
                e_Comprobante.Clave1 = metodos.CtaContablesP("A", "", cuenta);
                e_Comprobante.Aux1 = metodos.ObtenerAux();

                
                if(e_Comprobante.Aux1 == "SI") { Convert.ToInt32(e_Comprobante.Aux1 = "1"); } else { Convert.ToInt32(e_Comprobante.Aux1 = "0"); }

                respuesta = metodos.ValidaProveedor(e_Comprobante);
                if(respuesta == 0)
                {
                    metodos.GuardarProveedor(e_Comprobante);
                }
                ds.Clear();
                dtEmisor.Clear();
            }
        }
        private void ProcesarTodosXml()
        {
            XNamespace nsCFDI33 = "http://www.sat.gob.mx/cfd/3";

            DataSet ds = new DataSet();
            DataTable dtConcepto = new DataTable();
            DataTable dtEmisor = new DataTable();
            DataTable dtReceptor = new DataTable();
            DataTable dtComplemento = new DataTable();
            DataTable dtComprobante = new DataTable();
            ArrayList lstXmlRepetidos = new ArrayList();
            DataTable ConceptoDetalle = new DataTable();

            ConceptoDetalle.Columns.Add("ClaveProdServ");
            ConceptoDetalle.Columns.Add("Descripcion");
            ConceptoDetalle.Columns.Add("Cantidad");
            ConceptoDetalle.Columns.Add("ClaveUnidad");
            ConceptoDetalle.Columns.Add("Unidad");
            ConceptoDetalle.Columns.Add("ValorUnitario");
            ConceptoDetalle.Columns.Add("Descuento");
            ConceptoDetalle.Columns.Add("ImporteIva");

            string filepath = "";
            int respuesta = 0;
            int respuestaFactura = 0;

            if (openFileDialog1.SafeFileNames != null)
            {
                RegularProveedores();
                foreach (string file in openFileDialog1.SafeFileNames)
                {
                    filepath = "C:\\Xml\\" + file;
                    ds.ReadXml(filepath);
                    dtConcepto = ds.Tables["Concepto"];
                    dtEmisor = ds.Tables["Emisor"];
                    dtReceptor = ds.Tables["Receptor"];
                    dtComplemento = ds.Tables["TimbreFiscalDigital"];
                    dtComprobante = ds.Tables["Comprobante"];

                    e_Comprobante.EmisorRFC1 = dtEmisor.Rows[0]["Rfc"].ToString();
                    e_Comprobante.Folio = dtComprobante.Rows[0]["Folio"].ToString();
                    e_Comprobante.UUID1 = dtComplemento.Rows[0]["UUID"].ToString();
                    e_Comprobante.NoCertificado = Convert.ToInt64(dtComprobante.Rows[0]["NoCertificado"].ToString());
                    e_Comprobante.ArchivoOriginal = "Cargado por CFDI";
                    e_Comprobante.Version = dtComprobante.Rows[0]["Version"].ToString();
                    e_Comprobante.Formapago = dtComprobante.Rows[0]["FormaPago"].ToString();
                    e_Comprobante.ReceptorRFC1 = dtReceptor.Rows[0]["Rfc"].ToString();
                    e_Comprobante.SubTotal = Convert.ToDouble(dtComprobante.Rows[0]["SubTotal"].ToString());
                    e_Comprobante.Total = Convert.ToDouble(dtComprobante.Rows[0]["Total"].ToString());

                    respuestaFactura = metodos.ValidarFactura(e_Comprobante);
                    if (respuestaFactura == 0)
                    {
                        Cursor = Cursors.WaitCursor;
                        XmlDocument xmlDocument = new XmlDocument();
                        xmlDocument.Load(filepath);
                        StringReader streamXML = new StringReader(xmlDocument.OuterXml);
                        XDocument archivoXML = XDocument.Load(streamXML);

                        var conceptos = archivoXML.Descendants(nsCFDI33 + "Comprobante").Descendants(nsCFDI33 + "Conceptos").Elements();

                        foreach (var concepto in conceptos)
                        {
                            DataRow row = ConceptoDetalle.NewRow();
                            row["ClaveProdServ"] = concepto.Attributes().Where(x => x.Name.ToString().Equals("ClaveProdServ")).Select(x => x.Value.ToString()).SingleOrDefault();
                            row["Descripcion"] = concepto.Attributes().Where(x => x.Name.ToString().Equals("Descripcion")).Select(x => x.Value.ToString()).SingleOrDefault();
                            row["Cantidad"] = concepto.Attributes().Where(x => x.Name.ToString().Equals("Cantidad")).Select(x => x.Value.ToString()).SingleOrDefault();
                            row["ClaveUnidad"] = concepto.Attributes().Where(x => x.Name.ToString().Equals("ClaveUnidad")).Select(x => x.Value.ToString()).SingleOrDefault();
                            row["Unidad"] = concepto.Attributes().Where(x => x.Name.ToString().Equals("Unidad")).Select(x => x.Value.ToString()).SingleOrDefault();
                            row["ValorUnitario"] = concepto.Attributes().Where(x => x.Name.ToString().Equals("ValorUnitario")).Select(x => x.Value.ToString()).SingleOrDefault();
                            row["Descuento"] = concepto.Attributes().Where(x => x.Name.ToString().Equals("Descuento")).Select(x => x.Value.ToString()).SingleOrDefault();
                            var impuestosConceptos = concepto.Descendants(nsCFDI33 + "Impuestos").Descendants(nsCFDI33 + "Traslados").Elements();
                            var importeImpuesto = impuestosConceptos.Sum(P => Convert.ToDecimal(P.Attributes().Where(x => x.Name.ToString().Equals("Importe")).Select(x => x.Value.ToString()).SingleOrDefault()));

                            row["ImporteIva"] = Convert.ToDouble(importeImpuesto.ToString()); //impuestosConceptos.Attributes().Where(x => x.Name.ToString().Equals("Importe")).Select(x => x.Value.ToString()).SingleOrDefault();
                            ConceptoDetalle.Rows.Add(row);
                        }
                        dgvTotalConceptos.DataSource = ConceptoDetalle;
                        e_Comprobante.IdProveedor = metodos.ValidaProveedor(e_Comprobante);
                        respuesta = metodos.GuardaFactura(e_Comprobante);
                        ds.Clear();
                    }
                    else
                    {
                        FileInfo f = new FileInfo(file);
                        lstXmlRepetidos.Add(f);
                    }
                    ds.Clear();
                    dtEmisor.Clear();
                    concepto.Descripcion1 = "";
                    e_Comprobante.NoCertificado = 0;
                    e_Comprobante.EmisorRFC1 = "";
                    e_Comprobante.NoCertificado = 0;
                }
                lstXmlExistentes.DataSource = lstXmlRepetidos;
                Cursor = Cursors.Default;
            }
            else { MessageBox.Show("No se encontraron archivos para procesar"); }
            //CompPres.InsertarPreCompromiso();
        }
        private void LimpiarEntComprobante()
        {
            concepto.ClaveProdServ1 = 0;
            concepto.Descripcion1 = "";
            concepto.Cantidad1 = 0;
            concepto.ClaveUnidad1 = "";
            concepto.Unidad1 = "";
            concepto.Descripcion1 = "";
            concepto.ValorUnitario1 = 0;
            concepto.Importe1 = 0;
        }
        private void GuardarInventario()
        {
            string respuesta = "";
            DataTable dt = new DataTable();
            try
            {
                dt = metodos.GetAllConceptos();
                respuesta = metodos.Guarda(dt);
                MessageBox.Show(respuesta);
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex));
            }
        }
        private void LimpiarAcumuladoDetalles()
        {
            metodos.LimpiaAcumuladoCFDI();
        }

        #endregion

        #region "Eventos"
        private void lstXml_SelectedIndexChanged(object sender, EventArgs e)
        {
            double Importe = 0;
            double Iva = 0;
            double IvaUnitario = 0;
            double Total = 0;
            double Descuento = 0;
            double Subtotal = 0;

            DataSet ds = new DataSet();
            DataTable concepto = new DataTable();
            DataTable dtComprobante = new DataTable();
            DataTable dtEmisor = new DataTable();
            DataTable dtReceptor = new DataTable();
            DataTable dtTraslado = new DataTable();

            dgvCFDI.DataSource = null;
            dgvCFDI.DataMember = "";

            string namefile = "";
            namefile = lstXml.Text;
            string filepath = "C:\\Xml\\" + namefile;

            ds.ReadXml(filepath);

            dgvCFDI.DataSource = ds;
            dgvCFDI.DataMember = "Concepto";


            dtTraslado = ds.Tables["Traslado"];


            foreach (DataGridViewRow row in dgvCFDI.Rows)
            {
                Importe += Convert.ToDouble(row.Cells["Importe"].Value.ToString());
            }

            foreach (DataGridViewRow row in dgvCFDI.Rows)
            {
                if (ds.Tables["Comprobante"].Columns.Contains("Descuento"))
                {
                    Descuento += Convert.ToDouble(row.Cells["Descuento"].Value.ToString());
                }
                else
                {
                    Descuento = 0;
                }
            }

            IvaUnitario = Convert.ToDouble(dtTraslado.Rows[0]["TasaOCuota"].ToString());
            if (Descuento > 0)
            {
                Iva = (Importe - Descuento) * IvaUnitario;
                Total = (Importe - Descuento) + Iva;
            }
            else
            {
                Iva = Importe * IvaUnitario;
                Total = Importe + Iva;
            }
            Subtotal = Importe;


            dgvImpuestos.DataSource = dtTraslado;
            txtSubtotal.Text = Convert.ToString(Subtotal.ToString("C"));
            txtDescuento.Text = Convert.ToString(Descuento.ToString("C"));
            txtIva.Text = Convert.ToString(Iva.ToString("c"));
            txtTotal.Text = Convert.ToString(Total.ToString("C"));

            dtComprobante = ds.Tables["Comprobante"];
            e_Comprobante.Folio = dtComprobante.Rows[0]["Folio"].ToString();
            e_Comprobante.Fecha = Convert.ToDateTime(dtComprobante.Rows[0]["Fecha"].ToString());
            e_Comprobante.LugarExpedicion = Convert.ToInt32(dtComprobante.Rows[0]["LugarExpedicion"].ToString());
            e_Comprobante.NoCertificado = Convert.ToInt64(dtComprobante.Rows[0]["NoCertificado"].ToString());
            e_Comprobante.Serie = dtComprobante.Rows[0]["Serie"].ToString();
            e_Comprobante.TipoDeComprobante = dtComprobante.Rows[0]["TipoDeComprobante"].ToString();
            e_Comprobante.MetodoPago = dtComprobante.Rows[0]["MetodoPago"].ToString();
            e_Comprobante.Serie = dtComprobante.Rows[0]["Serie"].ToString();


            lblAbrir.Text = e_Comprobante.Folio;
            label6.Text = Convert.ToString(e_Comprobante.Fecha);
            label7.Text = Convert.ToString(e_Comprobante.LugarExpedicion);
            label8.Text = Convert.ToString(e_Comprobante.NoCertificado);
            label9.Text = e_Comprobante.Serie;
            label25.Text = e_Comprobante.TipoDeComprobante;
            label26.Text = e_Comprobante.MetodoPago.ToString();
            label27.Text = e_Comprobante.Serie.ToString();

            dtEmisor = ds.Tables["Emisor"];
            e_Comprobante.EmisorRFC1 = dtEmisor.Rows[0]["Rfc"].ToString();
            e_Comprobante.EmisorNombre1 = dtEmisor.Rows[0]["Nombre"].ToString();
            e_Comprobante.RegimenFiscal1 = dtEmisor.Rows[0]["RegimenFiscal"].ToString();
            label12.Text = e_Comprobante.EmisorRFC1;
            label17.Text = e_Comprobante.EmisorNombre1;
            label15.Text = e_Comprobante.RegimenFiscal1;

            dtReceptor = ds.Tables["Receptor"];
            label13.Text = dtReceptor.Rows[0]["Rfc"].ToString();
            label21.Text = dtReceptor.Rows[0]["Nombre"].ToString();
            label19.Text = dtReceptor.Rows[0]["UsoCFDI"].ToString();
        }
        private void btnGuardarTodos_Click(object sender, EventArgs e)
        {
            GuardarInventario();
        }
        private void btnAbrir_Click(object sender, EventArgs e)
        {
            LlenarListBox();
        }
        private void btnLimpia_Click(object sender, EventArgs e)
        {
            LimpiarAcumuladoDetalles();
            LlenarAcumuladoConceptos();
        }
        #endregion
    }
}
