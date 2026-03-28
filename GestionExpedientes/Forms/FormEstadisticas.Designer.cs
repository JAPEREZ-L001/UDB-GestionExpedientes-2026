namespace GestionExpedientes.Forms
{
    partial class FormEstadisticas
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblTotalTitulo = new System.Windows.Forms.Label();
            this.lblTotalValor = new System.Windows.Forms.Label();
            this.lblAlturaTitulo = new System.Windows.Forms.Label();
            this.lblAlturaValor = new System.Windows.Forms.Label();
            this.lblCarrerasTitulo = new System.Windows.Forms.Label();
            this.lblResumen = new System.Windows.Forms.Label();
            this.dgvCarreras = new System.Windows.Forms.DataGridView();
            this.btnVolver = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarreras)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Tai Le", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(239, 50);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(191, 23);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Estadísticas del Árbol";
            // 
            // lblTotalTitulo
            // 
            this.lblTotalTitulo.AutoSize = true;
            this.lblTotalTitulo.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalTitulo.Location = new System.Drawing.Point(123, 121);
            this.lblTotalTitulo.Name = "lblTotalTitulo";
            this.lblTotalTitulo.Size = new System.Drawing.Size(146, 19);
            this.lblTotalTitulo.TabIndex = 1;
            this.lblTotalTitulo.Text = "Total de estudiantes:";
            // 
            // lblTotalValor
            // 
            this.lblTotalValor.AutoSize = true;
            this.lblTotalValor.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalValor.Location = new System.Drawing.Point(291, 121);
            this.lblTotalValor.Name = "lblTotalValor";
            this.lblTotalValor.Size = new System.Drawing.Size(17, 19);
            this.lblTotalValor.TabIndex = 2;
            this.lblTotalValor.Text = "0";
            // 
            // lblAlturaTitulo
            // 
            this.lblAlturaTitulo.AutoSize = true;
            this.lblAlturaTitulo.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlturaTitulo.Location = new System.Drawing.Point(153, 160);
            this.lblAlturaTitulo.Name = "lblAlturaTitulo";
            this.lblAlturaTitulo.Size = new System.Drawing.Size(116, 19);
            this.lblAlturaTitulo.TabIndex = 3;
            this.lblAlturaTitulo.Text = "Altura del árbol:";
            // 
            // lblAlturaValor
            // 
            this.lblAlturaValor.AutoSize = true;
            this.lblAlturaValor.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlturaValor.Location = new System.Drawing.Point(291, 160);
            this.lblAlturaValor.Name = "lblAlturaValor";
            this.lblAlturaValor.Size = new System.Drawing.Size(17, 19);
            this.lblAlturaValor.TabIndex = 4;
            this.lblAlturaValor.Text = "0";
            // 
            // lblResumen
            // 
            this.lblResumen.AutoSize = true;
            this.lblResumen.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResumen.Location = new System.Drawing.Point(123, 199);
            this.lblResumen.Name = "lblResumen";
            this.lblResumen.Size = new System.Drawing.Size(250, 19);
            this.lblResumen.TabIndex = 8;
            this.lblResumen.Text = "Total: 0 estudiantes | Altura: 0";
            // 
            // lblCarrerasTitulo
            // 
            this.lblCarrerasTitulo.AutoSize = true;
            this.lblCarrerasTitulo.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCarrerasTitulo.Location = new System.Drawing.Point(70, 238);
            this.lblCarrerasTitulo.Name = "lblCarrerasTitulo";
            this.lblCarrerasTitulo.Size = new System.Drawing.Size(164, 19);
            this.lblCarrerasTitulo.TabIndex = 5;
            this.lblCarrerasTitulo.Text = "Estudiantes por carrera:";
            // 
            // dgvCarreras
            // 
            this.dgvCarreras.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCarreras.BackgroundColor = System.Drawing.Color.GhostWhite;
            this.dgvCarreras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCarreras.Location = new System.Drawing.Point(70, 280);
            this.dgvCarreras.Name = "dgvCarreras";
            this.dgvCarreras.ReadOnly = true;
            this.dgvCarreras.RowHeadersWidth = 51;
            this.dgvCarreras.RowTemplate.Height = 24;
            this.dgvCarreras.Size = new System.Drawing.Size(564, 125);
            this.dgvCarreras.TabIndex = 6;
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.Lavender;
            this.btnVolver.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.Location = new System.Drawing.Point(501, 435);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(133, 50);
            this.btnVolver.TabIndex = 7;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // FormEstadisticas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightYellow;
            this.ClientSize = new System.Drawing.Size(683, 512);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.dgvCarreras);
            this.Controls.Add(this.lblCarrerasTitulo);
            this.Controls.Add(this.lblResumen);
            this.Controls.Add(this.lblAlturaValor);
            this.Controls.Add(this.lblAlturaTitulo);
            this.Controls.Add(this.lblTotalValor);
            this.Controls.Add(this.lblTotalTitulo);
            this.Controls.Add(this.lblTitulo);
            this.Name = "FormEstadisticas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Estadísticas del Árbol";
            this.Load += new System.EventHandler(this.FormEstadisticas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarreras)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblTotalTitulo;
        private System.Windows.Forms.Label lblTotalValor;
        private System.Windows.Forms.Label lblAlturaTitulo;
        private System.Windows.Forms.Label lblAlturaValor;
        private System.Windows.Forms.Label lblCarrerasTitulo;
        private System.Windows.Forms.Label lblResumen;
        private System.Windows.Forms.DataGridView dgvCarreras;
        private System.Windows.Forms.Button btnVolver;
    }
}
