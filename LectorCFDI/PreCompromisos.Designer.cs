namespace LectorCFDI
{
    partial class PreCompromisos
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.gbLstPrecompromisos = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.gbLstPrecompromisos.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(10, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(966, 368);
            this.dataGridView1.TabIndex = 0;
            // 
            // gbLstPrecompromisos
            // 
            this.gbLstPrecompromisos.Controls.Add(this.dataGridView1);
            this.gbLstPrecompromisos.ForeColor = System.Drawing.Color.White;
            this.gbLstPrecompromisos.Location = new System.Drawing.Point(9, 50);
            this.gbLstPrecompromisos.Name = "gbLstPrecompromisos";
            this.gbLstPrecompromisos.Size = new System.Drawing.Size(982, 393);
            this.gbLstPrecompromisos.TabIndex = 1;
            this.gbLstPrecompromisos.TabStop = false;
            this.gbLstPrecompromisos.Text = "Listado de Pre - Compromisos";
            // 
            // PreCompromisos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(1784, 576);
            this.Controls.Add(this.gbLstPrecompromisos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PreCompromisos";
            this.Text = "PreCompromisos";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.gbLstPrecompromisos.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox gbLstPrecompromisos;
    }
}