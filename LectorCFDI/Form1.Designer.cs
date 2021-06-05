namespace LectorCFDI
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvCFDI = new System.Windows.Forms.DataGridView();
            this.lblAbrir = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dgvImpuestos = new System.Windows.Forms.DataGridView();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.gbTotales = new System.Windows.Forms.GroupBox();
            this.txtDescuento = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.txtIva = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.txtSubtotal = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.gbLstXml = new System.Windows.Forms.GroupBox();
            this.lstXml = new System.Windows.Forms.ListBox();
            this.gbAcumuladoConceptos = new System.Windows.Forms.GroupBox();
            this.dgvRegNotFound = new System.Windows.Forms.DataGridView();
            this.dgvTotalConceptos = new System.Windows.Forms.DataGridView();
            this.gbTotalConceptos = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstXmlExistentes = new System.Windows.Forms.ListBox();
            this.btnAbrir = new FontAwesome.Sharp.IconButton();
            this.btnGuardarTodos = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCFDI)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImpuestos)).BeginInit();
            this.tabPage5.SuspendLayout();
            this.gbTotales.SuspendLayout();
            this.gbLstXml.SuspendLayout();
            this.gbAcumuladoConceptos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegNotFound)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotalConceptos)).BeginInit();
            this.gbTotalConceptos.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCFDI
            // 
            this.dgvCFDI.AllowUserToAddRows = false;
            this.dgvCFDI.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCFDI.Location = new System.Drawing.Point(6, 6);
            this.dgvCFDI.Name = "dgvCFDI";
            this.dgvCFDI.Size = new System.Drawing.Size(793, 164);
            this.dgvCFDI.TabIndex = 0;
            // 
            // lblAbrir
            // 
            this.lblAbrir.AutoSize = true;
            this.lblAbrir.Location = new System.Drawing.Point(104, 11);
            this.lblAbrir.Name = "lblAbrir";
            this.lblAbrir.Size = new System.Drawing.Size(0, 13);
            this.lblAbrir.TabIndex = 2;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Archivos XML(*.xml)|*.xml";
            this.openFileDialog1.Multiselect = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Folio:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Fecha:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "LugarExpedicion:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "NoCertificado:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Serie:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(104, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 13);
            this.label6.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(104, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 13);
            this.label7.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(104, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 13);
            this.label8.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(104, 79);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(0, 13);
            this.label9.TabIndex = 11;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(124, 130);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(0, 13);
            this.label27.TabIndex = 17;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(124, 114);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(0, 13);
            this.label26.TabIndex = 16;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(124, 95);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(0, 13);
            this.label25.TabIndex = 15;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(7, 130);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(34, 13);
            this.label24.TabIndex = 14;
            this.label24.Text = "Serie:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(7, 113);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(81, 13);
            this.label23.TabIndex = 13;
            this.label23.Text = "Forma de pago:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(7, 95);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(111, 13);
            this.label22.TabIndex = 12;
            this.label22.Text = "Tipo de comprobante:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "R.F.C:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(99, 11);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(0, 13);
            this.label12.TabIndex = 2;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 28);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(47, 13);
            this.label14.TabIndex = 4;
            this.label14.Text = "Nombre:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(95, 46);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(0, 13);
            this.label15.TabIndex = 9;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 46);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(82, 13);
            this.label16.TabIndex = 5;
            this.label16.Text = "Regimen Fiscal:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(95, 28);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(0, 13);
            this.label17.TabIndex = 8;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 12);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(37, 13);
            this.label11.TabIndex = 3;
            this.label11.Text = "R.F.C:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(75, 11);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(0, 13);
            this.label13.TabIndex = 2;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(11, 28);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(47, 13);
            this.label18.TabIndex = 4;
            this.label18.Text = "Nombre:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(72, 46);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(0, 13);
            this.label19.TabIndex = 9;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(11, 46);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(56, 13);
            this.label20.TabIndex = 5;
            this.label20.Text = "Uso CFDI:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(72, 28);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(0, 13);
            this.label21.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Controls.Add(this.gbTotales);
            this.panel1.Location = new System.Drawing.Point(212, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(782, 224);
            this.panel1.TabIndex = 15;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(6, 7);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(623, 206);
            this.tabControl1.TabIndex = 19;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label27);
            this.tabPage1.Controls.Add(this.label26);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label25);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label24);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label23);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label22);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.lblAbrir);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(615, 180);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Comprobante";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.label17);
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Controls.Add(this.label16);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(568, 180);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Emisor";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.label13);
            this.tabPage3.Controls.Add(this.label18);
            this.tabPage3.Controls.Add(this.label21);
            this.tabPage3.Controls.Add(this.label19);
            this.tabPage3.Controls.Add(this.label20);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(568, 180);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Receptor";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.dgvImpuestos);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(568, 180);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Impuestos";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // dgvImpuestos
            // 
            this.dgvImpuestos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvImpuestos.Location = new System.Drawing.Point(6, 6);
            this.dgvImpuestos.Name = "dgvImpuestos";
            this.dgvImpuestos.Size = new System.Drawing.Size(583, 168);
            this.dgvImpuestos.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.dgvCFDI);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(568, 180);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Conceptos";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // gbTotales
            // 
            this.gbTotales.Controls.Add(this.txtDescuento);
            this.gbTotales.Controls.Add(this.label31);
            this.gbTotales.Controls.Add(this.txtTotal);
            this.gbTotales.Controls.Add(this.label30);
            this.gbTotales.Controls.Add(this.txtIva);
            this.gbTotales.Controls.Add(this.label29);
            this.gbTotales.Controls.Add(this.txtSubtotal);
            this.gbTotales.Controls.Add(this.label28);
            this.gbTotales.Location = new System.Drawing.Point(635, 4);
            this.gbTotales.Name = "gbTotales";
            this.gbTotales.Size = new System.Drawing.Size(143, 209);
            this.gbTotales.TabIndex = 19;
            this.gbTotales.TabStop = false;
            this.gbTotales.Text = "Totales";
            // 
            // txtDescuento
            // 
            this.txtDescuento.Enabled = false;
            this.txtDescuento.Location = new System.Drawing.Point(7, 82);
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.Size = new System.Drawing.Size(130, 20);
            this.txtDescuento.TabIndex = 7;
            this.txtDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.ForeColor = System.Drawing.Color.White;
            this.label31.Location = new System.Drawing.Point(7, 66);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(62, 13);
            this.label31.TabIndex = 6;
            this.label31.Text = "Descuento:";
            // 
            // txtTotal
            // 
            this.txtTotal.Enabled = false;
            this.txtTotal.Location = new System.Drawing.Point(6, 164);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(130, 20);
            this.txtTotal.TabIndex = 5;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.ForeColor = System.Drawing.Color.White;
            this.label30.Location = new System.Drawing.Point(6, 148);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(34, 13);
            this.label30.TabIndex = 4;
            this.label30.Text = "Total:";
            // 
            // txtIva
            // 
            this.txtIva.Enabled = false;
            this.txtIva.Location = new System.Drawing.Point(6, 122);
            this.txtIva.Name = "txtIva";
            this.txtIva.Size = new System.Drawing.Size(130, 20);
            this.txtIva.TabIndex = 3;
            this.txtIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.ForeColor = System.Drawing.Color.White;
            this.label29.Location = new System.Drawing.Point(6, 106);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(25, 13);
            this.label29.TabIndex = 2;
            this.label29.Text = "Iva:";
            // 
            // txtSubtotal
            // 
            this.txtSubtotal.Enabled = false;
            this.txtSubtotal.Location = new System.Drawing.Point(6, 41);
            this.txtSubtotal.Name = "txtSubtotal";
            this.txtSubtotal.Size = new System.Drawing.Size(130, 20);
            this.txtSubtotal.TabIndex = 1;
            this.txtSubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.ForeColor = System.Drawing.Color.White;
            this.label28.Location = new System.Drawing.Point(6, 23);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(49, 13);
            this.label28.TabIndex = 0;
            this.label28.Text = "Subtotal:";
            // 
            // gbLstXml
            // 
            this.gbLstXml.Controls.Add(this.lstXml);
            this.gbLstXml.ForeColor = System.Drawing.Color.White;
            this.gbLstXml.Location = new System.Drawing.Point(9, 4);
            this.gbLstXml.Name = "gbLstXml";
            this.gbLstXml.Size = new System.Drawing.Size(193, 287);
            this.gbLstXml.TabIndex = 18;
            this.gbLstXml.TabStop = false;
            this.gbLstXml.Text = "Xml seleccionados";
            // 
            // lstXml
            // 
            this.lstXml.FormattingEnabled = true;
            this.lstXml.Location = new System.Drawing.Point(6, 19);
            this.lstXml.Name = "lstXml";
            this.lstXml.Size = new System.Drawing.Size(181, 264);
            this.lstXml.TabIndex = 10;
            this.lstXml.SelectedIndexChanged += new System.EventHandler(this.lstXml_SelectedIndexChanged);
            // 
            // gbAcumuladoConceptos
            // 
            this.gbAcumuladoConceptos.Controls.Add(this.dgvRegNotFound);
            this.gbAcumuladoConceptos.ForeColor = System.Drawing.Color.White;
            this.gbAcumuladoConceptos.Location = new System.Drawing.Point(212, 424);
            this.gbAcumuladoConceptos.Name = "gbAcumuladoConceptos";
            this.gbAcumuladoConceptos.Size = new System.Drawing.Size(856, 179);
            this.gbAcumuladoConceptos.TabIndex = 17;
            this.gbAcumuladoConceptos.TabStop = false;
            this.gbAcumuladoConceptos.Text = "Acumulado de Conceptos";
            // 
            // dgvRegNotFound
            // 
            this.dgvRegNotFound.AllowUserToAddRows = false;
            this.dgvRegNotFound.BackgroundColor = System.Drawing.Color.White;
            this.dgvRegNotFound.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRegNotFound.Location = new System.Drawing.Point(6, 19);
            this.dgvRegNotFound.Name = "dgvRegNotFound";
            this.dgvRegNotFound.Size = new System.Drawing.Size(844, 154);
            this.dgvRegNotFound.TabIndex = 0;
            // 
            // dgvTotalConceptos
            // 
            this.dgvTotalConceptos.AllowUserToAddRows = false;
            this.dgvTotalConceptos.BackgroundColor = System.Drawing.Color.White;
            this.dgvTotalConceptos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTotalConceptos.Location = new System.Drawing.Point(6, 19);
            this.dgvTotalConceptos.Name = "dgvTotalConceptos";
            this.dgvTotalConceptos.Size = new System.Drawing.Size(844, 152);
            this.dgvTotalConceptos.TabIndex = 20;
            // 
            // gbTotalConceptos
            // 
            this.gbTotalConceptos.Controls.Add(this.dgvTotalConceptos);
            this.gbTotalConceptos.ForeColor = System.Drawing.Color.White;
            this.gbTotalConceptos.Location = new System.Drawing.Point(212, 238);
            this.gbTotalConceptos.Name = "gbTotalConceptos";
            this.gbTotalConceptos.Size = new System.Drawing.Size(856, 177);
            this.gbTotalConceptos.TabIndex = 18;
            this.gbTotalConceptos.TabStop = false;
            this.gbTotalConceptos.Text = "Total de Conceptos";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstXmlExistentes);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(9, 297);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(193, 306);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Xml procesados anteriormente";
            // 
            // lstXmlExistentes
            // 
            this.lstXmlExistentes.FormattingEnabled = true;
            this.lstXmlExistentes.Location = new System.Drawing.Point(6, 23);
            this.lstXmlExistentes.Name = "lstXmlExistentes";
            this.lstXmlExistentes.Size = new System.Drawing.Size(181, 277);
            this.lstXmlExistentes.TabIndex = 10;
            // 
            // btnAbrir
            // 
            this.btnAbrir.FlatAppearance.BorderSize = 0;
            this.btnAbrir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbrir.ForeColor = System.Drawing.Color.White;
            this.btnAbrir.IconChar = FontAwesome.Sharp.IconChar.FileUpload;
            this.btnAbrir.IconColor = System.Drawing.Color.White;
            this.btnAbrir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAbrir.IconSize = 30;
            this.btnAbrir.Location = new System.Drawing.Point(1000, 6);
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(68, 55);
            this.btnAbrir.TabIndex = 21;
            this.btnAbrir.Text = "Cargar xml";
            this.btnAbrir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAbrir.UseVisualStyleBackColor = true;
            this.btnAbrir.Click += new System.EventHandler(this.btnAbrir_Click);
            // 
            // btnGuardarTodos
            // 
            this.btnGuardarTodos.FlatAppearance.BorderSize = 0;
            this.btnGuardarTodos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarTodos.ForeColor = System.Drawing.Color.White;
            this.btnGuardarTodos.IconChar = FontAwesome.Sharp.IconChar.TruckLoading;
            this.btnGuardarTodos.IconColor = System.Drawing.Color.White;
            this.btnGuardarTodos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnGuardarTodos.IconSize = 35;
            this.btnGuardarTodos.Location = new System.Drawing.Point(1000, 61);
            this.btnGuardarTodos.Name = "btnGuardarTodos";
            this.btnGuardarTodos.Size = new System.Drawing.Size(73, 65);
            this.btnGuardarTodos.TabIndex = 22;
            this.btnGuardarTodos.Text = "Cargar Inventario";
            this.btnGuardarTodos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnGuardarTodos.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(1080, 615);
            this.Controls.Add(this.btnGuardarTodos);
            this.Controls.Add(this.btnAbrir);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbTotalConceptos);
            this.Controls.Add(this.gbLstXml);
            this.Controls.Add(this.gbAcumuladoConceptos);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCFDI)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvImpuestos)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.gbTotales.ResumeLayout(false);
            this.gbTotales.PerformLayout();
            this.gbLstXml.ResumeLayout(false);
            this.gbAcumuladoConceptos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegNotFound)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotalConceptos)).EndInit();
            this.gbTotalConceptos.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCFDI;
        private System.Windows.Forms.Label lblAbrir;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.ListBox lstXml;
        private System.Windows.Forms.GroupBox gbLstXml;
        private System.Windows.Forms.GroupBox gbAcumuladoConceptos;
        private System.Windows.Forms.DataGridView dgvRegNotFound;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.GroupBox gbTotales;
        private System.Windows.Forms.DataGridView dgvImpuestos;
        private System.Windows.Forms.TextBox txtSubtotal;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox txtIva;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox txtDescuento;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.DataGridView dgvTotalConceptos;
        private System.Windows.Forms.GroupBox gbTotalConceptos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lstXmlExistentes;
        private FontAwesome.Sharp.IconButton btnAbrir;
        private FontAwesome.Sharp.IconButton btnGuardarTodos;
    }
}

