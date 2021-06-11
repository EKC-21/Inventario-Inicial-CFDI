using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Models;

namespace LectorCFDI
{
    public partial class PreCompromisos : Form
    {
        FormMain fm = new FormMain();
        ComponentePresupuestal cp = new ComponentePresupuestal();
        D_PreCompromisos metodos = new D_PreCompromisos();
        E_Precompromiso e_Precompromiso = new E_Precompromiso();
        public PreCompromisos()
        {
            InitializeComponent();
        }

        private void PreCompromisos_Load(object sender, EventArgs e)
        {
        }
    }
}

