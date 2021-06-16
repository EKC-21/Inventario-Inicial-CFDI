using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace LectorCFDI
{
    public partial class SplashScreen : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRng
            (
            int nLeftRect,
            int nTopRect,
            int RightRect,
            int nBottomRect,
            int nwidthEllipse,
            int nHeightEllipse
            );
        public SplashScreen()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRng(0, 0, Width, Height, 25, 25));
            PrograssBar1.Value = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            PrograssBar1.Value += 1;
            PrograssBar1.Text = PrograssBar1.Value.ToString() + "%";

            if(PrograssBar1.Value == 100)
            {
                timer1.Enabled = false;
                FormMain FM = new FormMain();
                FM.Show();
                this.Hide();
            }
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {

        }
    }
}
