namespace LectorCFDI
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.BarraTitulo = new System.Windows.Forms.Panel();
            this.pictureMaximizar = new System.Windows.Forms.PictureBox();
            this.pictureMinimizar = new System.Windows.Forms.PictureBox();
            this.pictureRestaurar = new System.Windows.Forms.PictureBox();
            this.pictureClose = new System.Windows.Forms.PictureBox();
            this.panelContenedor = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.btnPrecompromisos = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSalir = new FontAwesome.Sharp.IconButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btn_Gasto = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_Presupuestal = new System.Windows.Forms.Button();
            this.BarraTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureMaximizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureMinimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureRestaurar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureClose)).BeginInit();
            this.panelContenedor.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // BarraTitulo
            // 
            this.BarraTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.BarraTitulo.Controls.Add(this.pictureMaximizar);
            this.BarraTitulo.Controls.Add(this.pictureMinimizar);
            this.BarraTitulo.Controls.Add(this.pictureRestaurar);
            this.BarraTitulo.Controls.Add(this.pictureClose);
            this.BarraTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.BarraTitulo.Location = new System.Drawing.Point(0, 0);
            this.BarraTitulo.Name = "BarraTitulo";
            this.BarraTitulo.Size = new System.Drawing.Size(1300, 35);
            this.BarraTitulo.TabIndex = 0;
            this.BarraTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BarraTitulo_MouseDown);
            // 
            // pictureMaximizar
            // 
            this.pictureMaximizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureMaximizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureMaximizar.Image = global::LectorCFDI.Properties.Resources.minTamaño;
            this.pictureMaximizar.Location = new System.Drawing.Point(1239, 5);
            this.pictureMaximizar.Name = "pictureMaximizar";
            this.pictureMaximizar.Size = new System.Drawing.Size(25, 25);
            this.pictureMaximizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureMaximizar.TabIndex = 8;
            this.pictureMaximizar.TabStop = false;
            this.pictureMaximizar.Click += new System.EventHandler(this.pictureMaximizar_Click);
            // 
            // pictureMinimizar
            // 
            this.pictureMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureMinimizar.Image = ((System.Drawing.Image)(resources.GetObject("pictureMinimizar.Image")));
            this.pictureMinimizar.Location = new System.Drawing.Point(1208, 4);
            this.pictureMinimizar.Name = "pictureMinimizar";
            this.pictureMinimizar.Size = new System.Drawing.Size(25, 25);
            this.pictureMinimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureMinimizar.TabIndex = 6;
            this.pictureMinimizar.TabStop = false;
            this.pictureMinimizar.Click += new System.EventHandler(this.pictureMinimizar_Click);
            // 
            // pictureRestaurar
            // 
            this.pictureRestaurar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureRestaurar.Image = global::LectorCFDI.Properties.Resources.restaurar;
            this.pictureRestaurar.Location = new System.Drawing.Point(1239, 5);
            this.pictureRestaurar.Name = "pictureRestaurar";
            this.pictureRestaurar.Size = new System.Drawing.Size(25, 25);
            this.pictureRestaurar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureRestaurar.TabIndex = 7;
            this.pictureRestaurar.TabStop = false;
            this.pictureRestaurar.Click += new System.EventHandler(this.pictureRestaurar_Click);
            // 
            // pictureClose
            // 
            this.pictureClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureClose.Image = ((System.Drawing.Image)(resources.GetObject("pictureClose.Image")));
            this.pictureClose.Location = new System.Drawing.Point(1270, 5);
            this.pictureClose.Name = "pictureClose";
            this.pictureClose.Size = new System.Drawing.Size(25, 25);
            this.pictureClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureClose.TabIndex = 5;
            this.pictureClose.TabStop = false;
            this.pictureClose.Click += new System.EventHandler(this.pictureClose_Click);
            // 
            // panelContenedor
            // 
            this.panelContenedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.panelContenedor.Controls.Add(this.label1);
            this.panelContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenedor.Location = new System.Drawing.Point(220, 35);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(1080, 615);
            this.panelContenedor.TabIndex = 2;
            this.panelContenedor.Paint += new System.Windows.Forms.PaintEventHandler(this.panelContenedor_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 45.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(251, 272);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(579, 70);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombre del Módulo";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.panel2.Controls.Add(this.panel9);
            this.panel2.Controls.Add(this.btnPrecompromisos);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.btnSalir);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.btn_Gasto);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.btn_Presupuestal);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 35);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(220, 615);
            this.panel2.TabIndex = 4;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.panel9.Controls.Add(this.panel10);
            this.panel9.Controls.Add(this.panel12);
            this.panel9.Location = new System.Drawing.Point(0, 83);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(5, 30);
            this.panel9.TabIndex = 5;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.panel10.Controls.Add(this.panel11);
            this.panel10.Location = new System.Drawing.Point(0, -44);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(5, 30);
            this.panel10.TabIndex = 4;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.panel11.Location = new System.Drawing.Point(0, -29);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(5, 30);
            this.panel11.TabIndex = 3;
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.panel12.Location = new System.Drawing.Point(0, -29);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(5, 30);
            this.panel12.TabIndex = 3;
            // 
            // btnPrecompromisos
            // 
            this.btnPrecompromisos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btnPrecompromisos.FlatAppearance.BorderSize = 0;
            this.btnPrecompromisos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.btnPrecompromisos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrecompromisos.ForeColor = System.Drawing.Color.White;
            this.btnPrecompromisos.Location = new System.Drawing.Point(5, 83);
            this.btnPrecompromisos.Name = "btnPrecompromisos";
            this.btnPrecompromisos.Size = new System.Drawing.Size(215, 30);
            this.btnPrecompromisos.TabIndex = 6;
            this.btnPrecompromisos.Text = "Pre Compromisos";
            this.btnPrecompromisos.UseVisualStyleBackColor = false;
            this.btnPrecompromisos.Click += new System.EventHandler(this.btnPrecompromisos_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.panel1.Location = new System.Drawing.Point(2, 554);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(5, 60);
            this.panel1.TabIndex = 5;
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.IconChar = FontAwesome.Sharp.IconChar.DoorOpen;
            this.btnSalir.IconColor = System.Drawing.Color.Gainsboro;
            this.btnSalir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSalir.IconSize = 40;
            this.btnSalir.Location = new System.Drawing.Point(5, 554);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(215, 60);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Location = new System.Drawing.Point(0, 155);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(5, 30);
            this.panel4.TabIndex = 4;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.panel5.Location = new System.Drawing.Point(0, 37);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(5, 30);
            this.panel5.TabIndex = 3;
            // 
            // btn_Gasto
            // 
            this.btn_Gasto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btn_Gasto.FlatAppearance.BorderSize = 0;
            this.btn_Gasto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.btn_Gasto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Gasto.ForeColor = System.Drawing.Color.White;
            this.btn_Gasto.Location = new System.Drawing.Point(5, 155);
            this.btn_Gasto.Name = "btn_Gasto";
            this.btn_Gasto.Size = new System.Drawing.Size(215, 30);
            this.btn_Gasto.TabIndex = 1;
            this.btn_Gasto.Text = "Componente del Gasto";
            this.btn_Gasto.UseVisualStyleBackColor = false;
            this.btn_Gasto.Click += new System.EventHandler(this.btn_Gasto_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(220, 82);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Controls.Add(this.panel3);
            this.panel6.Location = new System.Drawing.Point(0, 119);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(5, 30);
            this.panel6.TabIndex = 2;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Location = new System.Drawing.Point(0, -44);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(5, 30);
            this.panel7.TabIndex = 4;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.panel8.Location = new System.Drawing.Point(0, -29);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(5, 30);
            this.panel8.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.panel3.Location = new System.Drawing.Point(0, -29);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(5, 30);
            this.panel3.TabIndex = 3;
            // 
            // btn_Presupuestal
            // 
            this.btn_Presupuestal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btn_Presupuestal.FlatAppearance.BorderSize = 0;
            this.btn_Presupuestal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.btn_Presupuestal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Presupuestal.ForeColor = System.Drawing.Color.White;
            this.btn_Presupuestal.Location = new System.Drawing.Point(5, 119);
            this.btn_Presupuestal.Name = "btn_Presupuestal";
            this.btn_Presupuestal.Size = new System.Drawing.Size(215, 30);
            this.btn_Presupuestal.TabIndex = 0;
            this.btn_Presupuestal.Text = "Componente Presupuestal";
            this.btn_Presupuestal.UseVisualStyleBackColor = false;
            this.btn_Presupuestal.Click += new System.EventHandler(this.btn_Presupuestal_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 650);
            this.Controls.Add(this.panelContenedor);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.BarraTitulo);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.BarraTitulo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureMaximizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureRestaurar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureClose)).EndInit();
            this.panelContenedor.ResumeLayout(false);
            this.panelContenedor.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel BarraTitulo;
        private System.Windows.Forms.Button btn_Presupuestal;
        private System.Windows.Forms.Button btn_Gasto;
        private System.Windows.Forms.Panel panelContenedor;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureMaximizar;
        private System.Windows.Forms.PictureBox pictureMinimizar;
        private System.Windows.Forms.PictureBox pictureRestaurar;
        private System.Windows.Forms.PictureBox pictureClose;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconButton btnSalir;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Button btnPrecompromisos;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
    }
}