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
            LlenarGridPrecompromisos();
            dgvPreCompromisos.ForeColor = Color.Black;
            Seleccionar.ForeColor = Color.White;
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
            e_Precompromiso.NumeroInterno = txtNoInterno.Text.Trim().ToUpper();
            e_Precompromiso.IdTipoGasto = 1;
            //OJO ALAMBRE !!! Convert.ToInt32(txtBTipoGasto.Text); 
            //cboTipoGasto.SelectedValue.ToString());
            //e_Precompromiso.ClavePersonal = ClsLogin.NombreUsuarioE;  //ClsLogin.clavePersonal;
            e_Precompromiso.Autoriza = "Administrador Sistemas Sistemas";
            e_Precompromiso.CveAdva = cmbClasifAdmin.SelectedValue.ToString();
            e_Precompromiso.ClaveSecretaria = txtClaveSecretaria.Text;
            e_Precompromiso.ClaveSubsecretaria = txtClaveSubSecretaria.Text;
            e_Precompromiso.ClaveDireccion = txtClaveDireccion.Text;
            e_Precompromiso.IdProyecto = Convert.ToInt64(this.txtIdProyecto.Text.Trim());
            e_Precompromiso.Iddestino = 20; //Convert.ToInt32(cboDestino.SelectedValue.ToString());
            e_Precompromiso.TipoRequisicion = "Bienes/Materiales"; //cboTipoRequisicion.SelectedItem.ToString();
            e_Precompromiso.FechaSolicitud = dtpFechaSolicitud.Value;
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
        private void InsertarPreCompromiso()
        {
            int consecutivo = 0;
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

            try
            {
                if (string.IsNullOrEmpty(txtClaveSecretaria.Text)) { txtClaveSecretaria.Focus(); return; }
                if (string.IsNullOrEmpty(txtSecretaria.Text)) { txtSecretaria.Focus(); return; }
                if (string.IsNullOrEmpty(txtClaveSubSecretaria.Text)) { txtClaveSubSecretaria.Focus(); return; }
                if (string.IsNullOrEmpty(txtSubSecretaria.Text)) { txtSubSecretaria.Focus(); return; }
                if (string.IsNullOrEmpty(txtClaveDireccion.Text)) { txtClaveDireccion.Focus(); return; }
                if (string.IsNullOrEmpty(txtDireccion.Text)) { txtDireccion.Focus(); return; }
                if (string.IsNullOrEmpty(txtClaveProyecto.Text)) { txtClaveProyecto.Focus(); return; }
                if (string.IsNullOrEmpty(txtIdProyecto.Text)) { txtIdProyecto.Focus(); return; }

                consecutivo = metodos.ConsultaIdPrecompromiso();

                if (Seleccionar.CheckedItems.Count > 0)
                {
                    dtCveAdva = metodos.ConsultaCveAdva();
                    foreach (object indexChecked in Seleccionar.CheckedItems)
                    {
                        if (consecutivo > 0)
                        {
                            DataRow row = Pociciones.NewRow();
                            row["Numero"] = Interno + Convert.ToString(consecutivo++);
                            row["Nombre"] = indexChecked.ToString();
                            Pociciones.Rows.Add(row);
                        }
                        else
                        {
                            MessageBox.Show("Ocurrió un error");
                        }
                    }
                    foreach (DataRow row in Pociciones.Rows)
                    {
                        ds.Clear();
                        file = row["Nombre"].ToString();
                        string NumeroInterno = row["Numero"].ToString();
                        filepath = "C:\\Xml\\" + file;
                        ds.ReadXml(filepath);

                        AsignarCampos();
                        dtComprobante = ds.Tables["Comprobante"];
                        e_Precompromiso.NumeroInterno = NumeroInterno;
                        e_Precompromiso.FechaSolicitud = Convert.ToDateTime(dtComprobante.Rows[0]["Fecha"].ToString());
                        e_Precompromiso.FechaAutorizacion = DateTime.Now;
                        e_Precompromiso.Estatus = "A";
                        e_Precompromiso.Elabora = "Administrador Sistemas Sistemas";
                        e_Precompromiso.Observaciones = "SE CARGA INVENTARIO INICIAL A TRAVEZ DE CFDI";
                        e_Precompromiso.CveAdva = dtCveAdva.Rows[0][10].ToString();
                        metodos.AltasPreCompromiso(e_Precompromiso);
                    }
                    MessageBox.Show("los registros se guardaron correctamente.");
                    this.DialogResult = DialogResult.OK;
                    LlenarGridPrecompromisos();
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
        private void ObtenerValoresPrecompromiso(E_Precompromiso e_Precompromiso)
        {
            txtClaveSubSecretaria.Text = e_Precompromiso.ClaveSubsecretaria;
            txtSecretaria.Text = e_Precompromiso.SubSecretaria;
            txtClaveDireccion.Text = e_Precompromiso.ClaveDireccion;
            txtDireccion.Text = e_Precompromiso.Direccion;

            //txtClaveProyecto.Text = Convert.ToString(e_Precompromiso.IdProyecto);
            txtProyecto.Text = e_Precompromiso.NombreProyecto;
            txtIdProyecto.Text = Convert.ToString(e_Precompromiso.IdProyecto);
            chkAutorizar.Checked = true;
            cmbFteFinanciamiento.SelectedValue = e_Precompromiso.CveFF;
            rtxtEspecificacion.Text = e_Precompromiso.Especificaciones;
            rtxtJustificacion.Text = e_Precompromiso.Justificacion;
            rtxtObservaciones.Text = e_Precompromiso.Observaciones;

        }
        private int EditarPreCompromisos(E_Precompromiso e_Precompromiso)
        {
            int resp = 0;
            resp = metodos.EditaPrecompromiso(e_Precompromiso);
            Limpiar();
            return resp;
        }
        private void LlenarGridPrecompromisos()
        {
            D_PreCompromisos metodosPC = new D_PreCompromisos();
            DataTable dtPreCompromisos = new DataTable();
            dtPreCompromisos = metodosPC.CargaPreCompromisos();

            if (dtPreCompromisos != null)
            {
                dtPreCompromisos.Columns[0].ColumnName = "ID";
                dtPreCompromisos.Columns[1].ColumnName = "Número Interno";
                dtPreCompromisos.Columns[2].ColumnName = "Estatus";
                dtPreCompromisos.Columns[3].ColumnName = "Id Tipo Gasto";
                dtPreCompromisos.Columns[4].ColumnName = "Descripción";
                dtPreCompromisos.Columns[5].ColumnName = "Clave Secretaría";
                dtPreCompromisos.Columns[6].ColumnName = "Secretaría";
                dtPreCompromisos.Columns[7].ColumnName = "Clave SubSecretaría";
                dtPreCompromisos.Columns[8].ColumnName = "SubSecretaría";
                dtPreCompromisos.Columns[9].ColumnName = "Clave Dirección";
                dtPreCompromisos.Columns[10].ColumnName = "Dirección";
                dtPreCompromisos.Columns[11].ColumnName = "Id Proyecto";
                dtPreCompromisos.Columns[12].ColumnName = "Proyecto";
                dtPreCompromisos.Columns[13].ColumnName = "Id Destino";
                dtPreCompromisos.Columns[14].ColumnName = "Tipo Requisisción";
                dtPreCompromisos.Columns[15].ColumnName = "Fecha de Solicitud";
                dtPreCompromisos.Columns[16].ColumnName = "Fecha de Autorización";
                dtPreCompromisos.Columns[17].ColumnName = "Justificación";
                dtPreCompromisos.Columns[18].ColumnName = "Especificaciones";
                dtPreCompromisos.Columns[19].ColumnName = "Observaciones";
                dtPreCompromisos.Columns[20].ColumnName = "Clave Adva";
                dtPreCompromisos.Columns[21].ColumnName = "Fuente de Financiamiento";
                dtPreCompromisos.Columns[22].ColumnName = "Año de Registro";
                dtPreCompromisos.Columns[23].ColumnName = "Clave FF";

                dgvPreCompromisos.DataSource = dtPreCompromisos;

                dgvPreCompromisos.Columns[0].Visible = false;
                dgvPreCompromisos.Columns[3].Visible = false;
                dgvPreCompromisos.Columns[11].Visible = false;
                dgvPreCompromisos.Columns[13].Visible = false;
                dgvPreCompromisos.Columns[17].Visible = false;
                dgvPreCompromisos.Columns[18].Visible = false;
                dgvPreCompromisos.Columns[19].Visible = false;
                dgvPreCompromisos.Columns[23].Visible = false;
            }
            else
            {
                //MessageBox.Show("No se encontarron Precompromisos cargados por CFDI para mostrar");
            }
        }
        private void CancelarPreCompromiso()
        {
            long IdPreCompromiso = 0;
            int resp = 0;

            IdPreCompromiso = Convert.ToInt64(txtNoRequisiscion.Text);
            if (IdPreCompromiso == 0)
            {
                MessageBox.Show("No ha seleccionado ningun registro");
                return;
            }
            else
            {
                resp = metodos.CancelaPrecompromisos(IdPreCompromiso);
                if (resp == 5)
                {
                    MessageBox.Show("Ha ocurrido un error");
                    return;
                }
                else
                {
                    MessageBox.Show("El egistro se canceló con exito");
                }
            }
        }
        private void Limpiar()
        {
            cmbClasifAdmin.SelectedValue = 0;
            txtClaveSecretaria.Text = "";
            txtSecretaria.Text = "";
            txtClaveSubSecretaria.Text = "";
            txtSubSecretaria.Text = "";
            txtClaveDireccion.Text = "";
            txtDireccion.Text = "";
            txtClaveProyecto.Text = "";
            txtclaveProyect.Text = "";
            txtProyecto.Text = "";
            txtIdProyecto.Text = "";
            cmbFteFinanciamiento.SelectedValue = 0;
            rtxtEspecificacion.Text = "";
            rtxtJustificacion.Text = "";
            rtxtObservaciones.Text = "";
            chkAutorizar.Checked = true;
            LlenarCmbEnteAdvo();
            BuscarSecretaria();
            LlenarcmbFteFinanciamiento();


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
            Limpiar();
        }
        private void dgvPreCompromisos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable dtProyectos = new DataTable();
            if (e.RowIndex >= 0 && dgvPreCompromisos.SelectedRows.Count > 0)
            {
                txtNoRequisiscion.Text = Convert.ToString(dgvPreCompromisos[0, e.RowIndex].Value);
                txtNoInterno.Text = Convert.ToString(dgvPreCompromisos[1, e.RowIndex].Value);
                txtClaveSecretaria.Text = Convert.ToString(dgvPreCompromisos[5, e.RowIndex].Value);
                txtSecretaria.Text = Convert.ToString(dgvPreCompromisos[6, e.RowIndex].Value);
                txtClaveSubSecretaria.Text = Convert.ToString(dgvPreCompromisos[7, e.RowIndex].Value);
                txtSubSecretaria.Text = Convert.ToString(dgvPreCompromisos[8, e.RowIndex].Value);
                txtClaveDireccion.Text = Convert.ToString(dgvPreCompromisos[9, e.RowIndex].Value);
                txtDireccion.Text = Convert.ToString(dgvPreCompromisos[10, e.RowIndex].Value);
                txtIdProyecto.Text = Convert.ToString(dgvPreCompromisos[11, e.RowIndex].Value);
                txtProyecto.Text = Convert.ToString(dgvPreCompromisos[12, e.RowIndex].Value);
                dtpFechaSolicitud.Value = Convert.ToDateTime(dgvPreCompromisos[15, e.RowIndex].Value);
                dtpFechaAutorizacion.Value = Convert.ToDateTime(dgvPreCompromisos[16, e.RowIndex].Value);
                rtxtJustificacion.Text = Convert.ToString(dgvPreCompromisos[17, e.RowIndex].Value);
                rtxtEspecificacion.Text = Convert.ToString(dgvPreCompromisos[18, e.RowIndex].Value);
                rtxtObservaciones.Text = Convert.ToString(dgvPreCompromisos[19, e.RowIndex].Value);
                cmbFteFinanciamiento.SelectedValue = Convert.ToInt32(dgvPreCompromisos[23, e.RowIndex].Value);
                string estatus = Convert.ToString(dgvPreCompromisos[2, e.RowIndex].Value);
                if (estatus == "A")
                {
                    chkAutorizar.Checked = true;
                }
                else
                {
                    chkAutorizar.Checked = false;
                }
            }
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            E_Precompromiso e_Precompromiso = new E_Precompromiso();
            e_Precompromiso = AsignarCampos();
            if (chkAutorizar.Checked == true)
            {
                e_Precompromiso.Estatus = "A";
            }
            else
            {
                e_Precompromiso.Estatus = "C";
            }
            if (EditarPreCompromisos(e_Precompromiso) == 0)
            {
                MessageBox.Show("El registro se actualizó correctamente");
            }
            else
            {
                MessageBox.Show("Ocurrió un error, no se pudo actualizar el registro, comuniquese con el administrador de sistemas");
            }
            LlenarGridPrecompromisos();

        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            CancelarPreCompromiso();
            LlenarGridPrecompromisos();
            Limpiar();
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        #endregion


    }
}
