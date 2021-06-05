using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LectorCFDI
{
    public partial class FormUnidadEjecutora : Form
    {
        DataTable dtDatos;
        DataView dvFiltro;
        Form padre;
        String TipoResultado;
        public DataGridViewRow RenglonSeleccionado;
        string subsidio = "", MC = "";
        Boolean BanderaSalida = false;
        string msg = "";

        public FormUnidadEjecutora()
        {
            InitializeComponent();
        }
        [DllImport("User32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("User32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void FormUnidadEjecutora_Load(object sender, EventArgs e)
        {
            dgvFiltro.ForeColor = Color.Black;
            dgvListado.ForeColor = Color.Black;
        }

        private void dgvListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Seleccion();
        }
        private void Seleccion()
        {
            if (TipoResultado == "T")
            {
                if (padre.Name == "frmArtStockActualizar")
                {
                    if (this.dgvListado.CurrentRow.Cells[2].Value.ToString() == "4")
                    {
                        RenglonSeleccionado = this.dgvListado.SelectedRows[0] as DataGridViewRow;
                        BanderaSalida = true;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar una cuenta de detalle. ");
                    }
                }
                else
                {
                    if (dgvListado.Rows.Count > 0)
                    {
                        RenglonSeleccionado = this.dgvListado.SelectedRows[0] as DataGridViewRow;
                        BanderaSalida = true;
                        this.Close();
                    }
                }
            }
        }
        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        public FormUnidadEjecutora(DataTable dt, String Titulo, Form Padre, String tipoResultado)
        {
            InitializeComponent();
            this.Text = Titulo;
            padre = Padre;
            dtDatos = dt;

            try
            {
                if (dt.Rows.Count > 0)
                {
                    padre = Padre;
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, msg, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            dvFiltro = dtDatos.DefaultView;
            TipoResultado = tipoResultado; //Si recibe una T es TextBox y una G es para DataGrid
            this.dgvListado.DataSource = dtDatos;
            if (padre.Name == "frmEstructuraPorRubrodeingreso")
            {
                for (int i = 2; i < 9; i++)
                {
                    dgvListado.Columns[i].DefaultCellStyle.Format = "0,0.00";
                    dgvListado.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
                }
            }
            //
            if (padre.Name == "frmPrecompromisoBienes")
            {
                /*for (int i = 1; i < dtDatos.Rows.Count; i++)
                {
                    //MessageBox.Show(dtDatos.Rows[i]["Disponible para Comprometer"].ToString(), ClsVariablesGlobales.MensajeSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (dtDatos.Rows[i]["Disponible para Comprometer"].ToString() != "0.00")
                    {
                        dgvListado.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                    }
                    //dgvListado.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight; this.dataGridView1.DefaultCellStyle.BackColor = Color.Beige;
                }*/
            }
            Cursor = Cursors.Default;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnMaximizar_Click(object sender, EventArgs e)
        {

        }
        private void btnRestaurar_Click(object sender, EventArgs e)
        {

        }
        private void btnMinimizar_Click(object sender, EventArgs e)
        {

        }
    }
}
