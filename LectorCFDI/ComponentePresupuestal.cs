using AccesoDatos;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Windows.Forms;
using System.Collections;
using System.IO;

namespace LectorCFDI
{
    public partial class ComponentePresupuestal : Form
    {
        D_ComponentePresupuestal metodos = new D_ComponentePresupuestal();
        E_ComponentePresupuestal datos = new E_ComponentePresupuestal();
        E_Secretaria e_Secretaria = new E_Secretaria();
        E_Subsecretaria e_Subsecretaria = new E_Subsecretaria();
        E_Direccion e_Direccion = new E_Direccion();
        E_Precompromiso e_Precompromiso = new E_Precompromiso();
        ArrayList xml = new ArrayList();
        public ComponentePresupuestal()
        {
            InitializeComponent();
        }

        private void ComponentePresupuestal_Load(object sender, EventArgs e)
        {
            LlenarCmbEnteAdvo();
            LlenarcmbFteFinanciamiento();
            BuscarSecretaria();
            chkAutorizar.Checked = true;
            Seleccionar.ForeColor = Color.Black;
            LlenarListBox();
        }
        private void LlenarListBox()
        {
            foreach (string file in Directory.GetFiles(@"C:\\Xml\\"))
                Seleccionar.Items.Add(Path.GetFileName(file));

        }
        private void ConsultaCveAdva()
        {
            DataTable dt = new DataTable();
            dt = metodos.ConsultaCveAdva();
            if (dt != null)
            {
                datos.ClaveSecretaria = dt.Rows[0]["Clave Unidad Responsable"].ToString().ToUpper().Trim();
                txtBidppiclasificadorsubsidios.Text = datos.ClaveSecretaria;
                txtClaveSecretaria.Text = dt.Rows[0]["Nombre Unidad Responsable"].ToString().ToUpper().Trim();
            }
            else
            {
                MessageBox.Show("No se encontró clave del ente");
            }
        }
        private void LlenarCmbEnteAdvo()
        {
            DataTable dtEnte = new DataTable();
            dtEnte = metodos.ConsultaEnteAdvo();

            if (dtEnte != null)
            {
                cmbClasifAdmin.DataSource = dtEnte;
                cmbClasifAdmin.ValueMember = "idEntePublico";
                cmbClasifAdmin.DisplayMember = "entePublico";

                datos.ClavePresupuestal = dtEnte.Rows[0]["idEntePublico"].ToString();
                datos.Nombre = dtEnte.Rows[0]["entePublico"].ToString();
            }
            else
            {
                MessageBox.Show("No se encontraron entes administrartivos");
            }
        }
        private void LlenarcmbFteFinanciamiento()
        {
            DataTable fteFinan = new DataTable();
            fteFinan = metodos.Consultaftetfin();
            if (fteFinan != null)
            {
                cmbFteFinanciamiento.DataSource = fteFinan;
                cmbFteFinanciamiento.DisplayMember = "DisplayMember";
                cmbFteFinanciamiento.ValueMember = "sec";
            }
            else
            {
                MessageBox.Show("No se encontraron fuentes de financiamiento");
            }
        }
        private void BuscarSecretaria()
        {
            string msg = "";
            DataTable dtSecretaria = new DataTable();
            if (cmbClasifAdmin.SelectedIndex != -1)
            {
                e_Secretaria.ClavePresupuestal = cmbClasifAdmin.SelectedValue.ToString();

                dtSecretaria = metodos.ConsultaSecretaria(e_Secretaria);
                if (dtSecretaria.Rows.Count == 0)
                {
                    Cursor = Cursors.Default;
                    MessageBox.Show("No hay Registros que mostrar. ", e_Secretaria.ClavePresupuestal, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (dtSecretaria.Rows.Count == 1)
                {
                    Cursor = Cursors.Default;
                    txtClaveSecretaria.Text = dtSecretaria.Rows[0]["Clave Unidad Responsable"].ToString().ToUpper().Trim();
                    txtSecretaria.Text = dtSecretaria.Rows[0]["Nombre Unidad Responsable"].ToString().ToUpper().Trim();

                    btnSeccretaria1.Enabled = false;
                    btnSubSecretaria1.Focus();
                    return;
                }
                //Formulario de consulta
                FormUnidadEjecutora v = new FormUnidadEjecutora(dtSecretaria, "Unidad Responsable", this, "T");
                v.ShowDialog();
                DataGridViewRow row = v.RenglonSeleccionado;
                if (row != null)
                {
                    //Se limpia la Subsecretaria y la dirección si se selecciona una secretaria
                    txtClaveSubSecretaria.Text = string.Empty;
                    txtSubSecretaria.Text = string.Empty;
                    txtClaveDireccion.Text = string.Empty;
                    txtDireccion.Text = string.Empty;
                    txtClaveProyecto.Text = string.Empty;
                    txtProyecto.Text = string.Empty;
                    txtClaveSecretaria.Text = row.Cells[0].Value.ToString().ToUpper();
                    txtSecretaria.Text = row.Cells[2].Value.ToString().ToUpper();
                    //btnsub.Focus();

                    BuscarSubSecretaria();
                }
            }
            else
            {
                MessageBox.Show("Debe selccionar una Clave Adminstrativa", msg, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbClasifAdmin.Focus();
            }
        }
        private void BuscarSubSecretaria()
        {
            DataTable dtSubSecretaria = new DataTable();
            if (string.IsNullOrEmpty(txtSecretaria.Text))
            {
                MessageBox.Show("Seleccione una unidad responsable");
                return;
            }
            if (!string.IsNullOrEmpty(txtClaveSecretaria.Text))
            {
                e_Subsecretaria.ClavePresupuestal = cmbClasifAdmin.SelectedValue.ToString();
                e_Subsecretaria.ClaveSecretaria = txtClaveSecretaria.Text;

                Cursor = Cursors.Default;
                dtSubSecretaria = metodos.ConsultaSubsecretaria(e_Subsecretaria);

                if (dtSubSecretaria.Rows.Count == 0)
                {
                    Cursor = Cursors.Default;
                    MessageBox.Show("No hay registros para mostrar");
                    return;
                }

                //Formulario de consulta
                var v = new FormUnidadEjecutora(dtSubSecretaria, "Unidad Ejecutora", this, "T");

                Cursor = Cursors.Default;
                v.ShowDialog();
                //obtengo renglon seleccionado
                var row = v.RenglonSeleccionado;
                if (row != null)
                {
                    //Se limpia la subsecretaria y la dirección si se selecciona una secretaria
                    txtClaveDireccion.Text = String.Empty;
                    txtDireccion.Text = String.Empty;
                    txtClaveProyecto.Text = String.Empty;
                    txtProyecto.Text = String.Empty;
                    //Llenamos los datos de la dependencia
                    txtClaveSubSecretaria.Text = row.Cells[0].Value.ToString();
                    txtSubSecretaria.Text = row.Cells[2].Value.ToString().ToUpper();
                    btnDireccion1.Focus();
                    BuscarDireccion();
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una unidad responsable");
                //btnsec.focus();
            }
        }
        private void BuscarDireccion()
        {
            DataTable dtDireccion = new DataTable();

            if (string.IsNullOrEmpty(txtSecretaria.Text))
            {
                MessageBox.Show("Seleccione una unidad responsable");
                return;
            }
            if (string.IsNullOrEmpty(txtSubSecretaria.Text))
            {
                MessageBox.Show("Seleccione una unidad ejecutora");
                return;
            }
            if (!string.IsNullOrEmpty(txtClaveSubSecretaria.Text))
            {
                e_Direccion.ClavePresupuestal = cmbClasifAdmin.SelectedValue.ToString();
                e_Direccion.ClaveSecretaria = txtClaveSecretaria.Text;
                e_Direccion.ClaveSubsecretaria = txtClaveSubSecretaria.Text;

                Cursor = Cursors.WaitCursor;
                dtDireccion = metodos.BuscaDireccion(e_Direccion);

                if (dtDireccion.Rows.Count == 0)
                {
                    Cursor = Cursors.Default;
                    MessageBox.Show("No se encontraron registros para mostrar");
                    return;
                }
                //Formulario de consulta
                var v = new FormUnidadEjecutora(dtDireccion, "Proyectos", this, "T");

                Cursor = Cursors.Default;
                v.ShowDialog();
                //Renglon seleccionado
                var row = v.RenglonSeleccionado;
                if (row != null)
                {
                    txtClaveProyecto.Text = String.Empty;
                    txtProyecto.Text = String.Empty;
                    //Llenamos los datos de la dependencia
                    txtClaveDireccion.Text = String.Empty;
                    txtClaveDireccion.Text = row.Cells["Cve. Dirección"].Value.ToString();
                    txtDireccion.Text = row.Cells["Nombre Dirección"].Value.ToString().ToUpper();

                    BuscarProyecto();
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una unidad ejecutora");
                //btnSub.Focus();
            }
        }
        private void BuscarProyecto()
        {
            DataTable dtProyectos = new DataTable();

            String CveAdmin = cmbClasifAdmin.SelectedValue.ToString();

            if (string.IsNullOrEmpty(txtSecretaria.Text))
            {
                MessageBox.Show("Seleccione una unidad responsable");
                return;
            }
            if (String.IsNullOrEmpty(txtSubSecretaria.Text))
            {
                MessageBox.Show("Seleccione una unidad ejecutora");
                return;
            }
            if (String.IsNullOrEmpty(txtDireccion.Text))
            {
                MessageBox.Show("Seleccione un proyecto");
                return;
            }
            try
            {
                Cursor = Cursors.WaitCursor;
                dtProyectos = metodos.BuscaProyectos(txtClaveSecretaria.Text, txtClaveSubSecretaria.Text, txtClaveDireccion.Text, CveAdmin, dtpFechaSolicitud.Value.Year);

                if (dtProyectos.Rows.Count == 0)
                {
                    Cursor = Cursors.Default;
                    MessageBox.Show("No hay Registros que mostrar con COG capítulo 2000 o 5000 en el presupuesto de la Dirección seleccionada. ");
                    return;
                }
                FormUnidadEjecutora v = new FormUnidadEjecutora(dtProyectos, "Proyectos", this, "T");

                Cursor = Cursors.Default;
                v.ShowDialog();
                DataGridViewRow row = v.RenglonSeleccionado;
                if (row != null)
                {
                    try
                    {
                        txtIdProyecto.Text = row.Cells["Id_Proyecto"].Value.ToString();
                    }
                    catch
                    {

                        txtIdProyecto.Text = row.Cells["No. Proyecto"].Value.ToString();
                    }
                    txtClaveProyecto.Text = row.Cells["Clave Obra/Acción"].Value.ToString();
                    txtProyecto.Text = row.Cells["Nombre Proyecto"].Value.ToString();
                    txtclaveProyect.Text = txtClaveProyecto.Text;

                    txtBidppiclasificadorsubsidios.Text = "0";
                }
            }
            catch (System.Exception ex)
            {

                throw;
            }
        }

        private E_Precompromiso AsignarCampos()
        {
            if (!String.IsNullOrEmpty(txtNoRequisiscion.Text))
                e_Precompromiso.IdPrecompromiso = Convert.ToInt64(this.txtNoRequisiscion.Text.Trim());
            //e_Precompromiso.NumeroInterno = txtNoInterno.Text.Trim().ToUpper();
            e_Precompromiso.IdTipoGasto = 1;
            //OJO ALAMBRE !!! Convert.ToInt32(txtBTipoGasto.Text); 
            //cboTipoGasto.SelectedValue.ToString());
            //e_Precompromiso.ClavePersonal = ClsLogin.NombreUsuarioE;  //ClsLogin.clavePersonal;
            e_Precompromiso.CveAdva = cmbClasifAdmin.SelectedValue.ToString();
            e_Precompromiso.ClaveSecretaria = txtClaveSecretaria.Text;
            e_Precompromiso.ClaveSubsecretaria = txtClaveSubSecretaria.Text;
            e_Precompromiso.ClaveDireccion = txtClaveDireccion.Text;
            e_Precompromiso.IdProyecto = Convert.ToInt64(this.txtIdProyecto.Text.Trim());
            e_Precompromiso.Iddestino = 20; //Convert.ToInt32(cboDestino.SelectedValue.ToString());
            e_Precompromiso.TipoRequisicion = "Bienes/Materiales"; //cboTipoRequisicion.SelectedItem.ToString();
            //e_Precompromiso.FechaSolicitud = dtpFechaSolicitud.Value;
            e_Precompromiso.Justificacion = rtxtJustificacion.Text.Trim().ToUpper();
            e_Precompromiso.Observaciones = rtxtObservaciones.Text.Trim().ToUpper();
            e_Precompromiso.Especificaciones = rtxtEspecificacion.Text.Trim().ToUpper();
            e_Precompromiso.FechaAutorizacion = dtpFechaAutorizacion.Value;

            txtFF.Text = cmbFteFinanciamiento.SelectedValue.ToString();
            e_Precompromiso.CveFF = cmbFteFinanciamiento.SelectedValue.ToString();
            e_Precompromiso.AR = "";

            e_Precompromiso.idppiclasificadorsubsidios = txtFF.Text;
            e_Precompromiso.nombreFF = txtBidppiclasificadorsubsidios.Text;


            return e_Precompromiso;
        }
        public void InsertarPreCompromiso()
        {
            int consecutivo = 001;
            string Interno = "CFDI-";
            string filepath = "";
            string file = "";

            ArrayList xml = new ArrayList();
            DataSet ds = new DataSet();
            DataTable dtComprobante = new DataTable();
            DataTable Pociciones = new DataTable();
            DataTable dtCveAdva = new DataTable();

            Pociciones.Columns.Add("Numero");
            Pociciones.Columns.Add("Nombre");

            //E_Precompromiso e_Precompromiso = new E_Precompromiso();
            try
            {
                if (Seleccionar.CheckedItems.Count > 0)
                {
                    dtCveAdva = metodos.ConsultaCveAdva();
                    foreach (object indexChecked in Seleccionar.CheckedItems)
                    {
                        DataRow row = Pociciones.NewRow();
                        row["Numero"] = Interno + Convert.ToString(consecutivo++);
                        row["Nombre"] = indexChecked.ToString();
                        Pociciones.Rows.Add(row);
                        //xml.Add(indexChecked.ToString());
                    }
                    foreach (DataRow row in Pociciones.Rows)
                    {
                        ds.Clear();
                        file = row["Nombre"].ToString();
                        e_Precompromiso.NumeroInterno = row["Numero"].ToString();
                        filepath = "C:\\Xml\\" + file;
                        ds.ReadXml(filepath);

                        AsignarCampos();
                        dtComprobante = ds.Tables["Comprobante"];
                        e_Precompromiso.FechaSolicitud = Convert.ToDateTime(dtComprobante.Rows[0]["Fecha"].ToString());
                        e_Precompromiso.FechaAutorizacion = DateTime.Now;
                        e_Precompromiso.Estatus = "A";
                        e_Precompromiso.Elabora = "Administrador Sistemas Sistemas";
                        e_Precompromiso.Autoriza = "Administrador Sistemas Sistemas";
                        e_Precompromiso.CveAdva = dtCveAdva.Rows[0][10].ToString();
                        metodos.AltasPreCompromiso(e_Precompromiso);
                    }
                    MessageBox.Show("los registros se guardaron correctamente.");
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Sleccione al menos un elemento de la lista para procesar");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region Eventos

        private void btnSeccretaria_Click(object sender, EventArgs e)
        {
            BuscarSecretaria();
        }
        private void btnSubSecretaria_Click(object sender, EventArgs e)
        {
            BuscarSubSecretaria();
        }
        private void btnDireccion_Click(object sender, EventArgs e)
        {
            BuscarDireccion();
        }
        private void btnProyecto_Click(object sender, EventArgs e)
        {
            BuscarProyecto();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            InsertarPreCompromiso();
        }
        #endregion
    }
}
