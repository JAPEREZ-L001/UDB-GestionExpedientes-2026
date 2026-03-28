namespace GestionExpedientes.Forms
{
    partial class FormBusqueda
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
            this.lblCarnet = new System.Windows.Forms.Label();
            this.txtCarnet = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.grpResultado = new System.Windows.Forms.GroupBox();
            this.lblResCarnet = new System.Windows.Forms.Label();
            this.lblResCarrera = new System.Windows.Forms.Label();
            this.lblResPromedio = new System.Windows.Forms.Label();
            this.lblResCreditos = new System.Windows.Forms.Label();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.grpResultado.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Tai Le", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(144, 19);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(162, 23);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Buscar Estudiante";
            // 
            // lblCarnet
            // 
            this.lblCarnet.AutoSize = true;
            this.lblCarnet.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCarnet.Location = new System.Drawing.Point(40, 70);
            this.lblCarnet.Name = "lblCarnet";
            this.lblCarnet.Size = new System.Drawing.Size(59, 19);
            this.lblCarnet.TabIndex = 1;
            this.lblCarnet.Text = "Carnet :";
            // 
            // txtCarnet
            // 
            this.txtCarnet.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCarnet.Location = new System.Drawing.Point(110, 67);
            this.txtCarnet.MaxLength = 10;
            this.txtCarnet.Name = "txtCarnet";
            this.txtCarnet.Size = new System.Drawing.Size(150, 27);
            this.txtCarnet.TabIndex = 2;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.Lavender;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(270, 65);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(140, 30);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.Lavender;
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Location = new System.Drawing.Point(104, 296);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(120, 35);
            this.btnLimpiar.TabIndex = 4;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.Lavender;
            this.btnVolver.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.Location = new System.Drawing.Point(230, 296);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(120, 35);
            this.btnVolver.TabIndex = 5;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = false;
            // 
            // grpResultado
            // 
            this.grpResultado.Controls.Add(this.lblResCreditos);
            this.grpResultado.Controls.Add(this.lblResPromedio);
            this.grpResultado.Controls.Add(this.lblResCarrera);
            this.grpResultado.Controls.Add(this.lblResCarnet);
            this.grpResultado.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpResultado.Location = new System.Drawing.Point(34, 110);
            this.grpResultado.Name = "grpResultado";
            this.grpResultado.Size = new System.Drawing.Size(380, 180);
            this.grpResultado.TabIndex = 6;
            this.grpResultado.TabStop = false;
            this.grpResultado.Text = "Datos del Estudiante";
            // 
            // lblResCarnet
            // 
            this.lblResCarnet.AutoSize = true;
            this.lblResCarnet.Location = new System.Drawing.Point(150, 40);
            this.lblResCarnet.Name = "lblResCarnet";
            this.lblResCarnet.Size = new System.Drawing.Size(24, 19);
            this.lblResCarnet.TabIndex = 0;
            this.lblResCarnet.Text = "—";
            // 
            // lblResCarrera
            // 
            this.lblResCarrera.AutoSize = true;
            this.lblResCarrera.Location = new System.Drawing.Point(150, 75);
            this.lblResCarrera.Name = "lblResCarrera";
            this.lblResCarrera.Size = new System.Drawing.Size(24, 19);
            this.lblResCarrera.TabIndex = 1;
            this.lblResCarrera.Text = "—";
            // 
            // lblResPromedio
            // 
            this.lblResPromedio.AutoSize = true;
            this.lblResPromedio.Location = new System.Drawing.Point(150, 110);
            this.lblResPromedio.Name = "lblResPromedio";
            this.lblResPromedio.Size = new System.Drawing.Size(24, 19);
            this.lblResPromedio.TabIndex = 2;
            this.lblResPromedio.Text = "—";
            // 
            // lblResCreditos
            // 
            this.lblResCreditos.AutoSize = true;
            this.lblResCreditos.Location = new System.Drawing.Point(150, 145);
            this.lblResCreditos.Name = "lblResCreditos";
            this.lblResCreditos.Size = new System.Drawing.Size(24, 19);
            this.lblResCreditos.TabIndex = 3;
            this.lblResCreditos.Text = "—";
            // 
            // lblMensaje
            // 
            this.lblMensaje.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensaje.Location = new System.Drawing.Point(31, 334);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(380, 40);
            this.lblMensaje.TabIndex = 7;
            // 
            // FormBusqueda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightYellow;
            this.ClientSize = new System.Drawing.Size(450, 386);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.grpResultado);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtCarnet);
            this.Controls.Add(this.lblCarnet);
            this.Controls.Add(this.lblTitulo);
            this.Name = "FormBusqueda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar Estudiante";
            this.grpResultado.ResumeLayout(false);
            this.grpResultado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblCarnet;
        private System.Windows.Forms.TextBox txtCarnet;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.GroupBox grpResultado;
        private System.Windows.Forms.Label lblResPromedio;
        private System.Windows.Forms.Label lblResCarrera;
        private System.Windows.Forms.Label lblResCarnet;
        private System.Windows.Forms.Label lblResCreditos;
        private System.Windows.Forms.Label lblMensaje;
    }
}
