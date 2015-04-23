namespace Simulator
{
    partial class frmModDatosObjetivos
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
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.lbNombre = new System.Windows.Forms.Label();
            this.tbVelocidad = new System.Windows.Forms.TextBox();
            this.tbRumbo = new System.Windows.Forms.TextBox();
            this.tbLongitud = new System.Windows.Forms.TextBox();
            this.tbLatitude = new System.Windows.Forms.TextBox();
            this.tbMMSI = new System.Windows.Forms.TextBox();
            this.lbRumbo = new System.Windows.Forms.Label();
            this.lbVelocidadTitle = new System.Windows.Forms.Label();
            this.lbLongitud = new System.Windows.Forms.Label();
            this.lbLatitudTitle = new System.Windows.Forms.Label();
            this.lbMMSItitle = new System.Windows.Forms.Label();
            this.lbGuardar = new System.Windows.Forms.Button();
            this.lbCancelar = new System.Windows.Forms.Button();
            this.lbModificarDatos = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbNombre
            // 
            this.tbNombre.Location = new System.Drawing.Point(158, 101);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(121, 20);
            this.tbNombre.TabIndex = 25;
            // 
            // lbNombre
            // 
            this.lbNombre.AutoSize = true;
            this.lbNombre.Location = new System.Drawing.Point(55, 104);
            this.lbNombre.Name = "lbNombre";
            this.lbNombre.Size = new System.Drawing.Size(44, 13);
            this.lbNombre.TabIndex = 30;
            this.lbNombre.Text = "Nombre";
            // 
            // tbVelocidad
            // 
            this.tbVelocidad.Location = new System.Drawing.Point(158, 225);
            this.tbVelocidad.Name = "tbVelocidad";
            this.tbVelocidad.Size = new System.Drawing.Size(121, 20);
            this.tbVelocidad.TabIndex = 29;
            // 
            // tbRumbo
            // 
            this.tbRumbo.Location = new System.Drawing.Point(158, 194);
            this.tbRumbo.Name = "tbRumbo";
            this.tbRumbo.Size = new System.Drawing.Size(121, 20);
            this.tbRumbo.TabIndex = 28;
            // 
            // tbLongitud
            // 
            this.tbLongitud.Location = new System.Drawing.Point(158, 163);
            this.tbLongitud.Name = "tbLongitud";
            this.tbLongitud.Size = new System.Drawing.Size(121, 20);
            this.tbLongitud.TabIndex = 27;
            // 
            // tbLatitude
            // 
            this.tbLatitude.Location = new System.Drawing.Point(158, 133);
            this.tbLatitude.Name = "tbLatitude";
            this.tbLatitude.Size = new System.Drawing.Size(121, 20);
            this.tbLatitude.TabIndex = 26;
            // 
            // tbMMSI
            // 
            this.tbMMSI.Location = new System.Drawing.Point(158, 70);
            this.tbMMSI.Name = "tbMMSI";
            this.tbMMSI.ReadOnly = true;
            this.tbMMSI.Size = new System.Drawing.Size(121, 20);
            this.tbMMSI.TabIndex = 24;
            // 
            // lbRumbo
            // 
            this.lbRumbo.AutoSize = true;
            this.lbRumbo.Location = new System.Drawing.Point(55, 196);
            this.lbRumbo.Name = "lbRumbo";
            this.lbRumbo.Size = new System.Drawing.Size(41, 13);
            this.lbRumbo.TabIndex = 23;
            this.lbRumbo.Text = "Rumbo";
            // 
            // lbVelocidadTitle
            // 
            this.lbVelocidadTitle.AutoSize = true;
            this.lbVelocidadTitle.Location = new System.Drawing.Point(55, 228);
            this.lbVelocidadTitle.Name = "lbVelocidadTitle";
            this.lbVelocidadTitle.Size = new System.Drawing.Size(54, 13);
            this.lbVelocidadTitle.TabIndex = 22;
            this.lbVelocidadTitle.Text = "Velocidad";
            // 
            // lbLongitud
            // 
            this.lbLongitud.AutoSize = true;
            this.lbLongitud.Location = new System.Drawing.Point(55, 166);
            this.lbLongitud.Name = "lbLongitud";
            this.lbLongitud.Size = new System.Drawing.Size(48, 13);
            this.lbLongitud.TabIndex = 21;
            this.lbLongitud.Text = "Longitud";
            // 
            // lbLatitudTitle
            // 
            this.lbLatitudTitle.AutoSize = true;
            this.lbLatitudTitle.Location = new System.Drawing.Point(55, 135);
            this.lbLatitudTitle.Name = "lbLatitudTitle";
            this.lbLatitudTitle.Size = new System.Drawing.Size(39, 13);
            this.lbLatitudTitle.TabIndex = 20;
            this.lbLatitudTitle.Text = "Latitud";
            // 
            // lbMMSItitle
            // 
            this.lbMMSItitle.AutoSize = true;
            this.lbMMSItitle.Location = new System.Drawing.Point(55, 73);
            this.lbMMSItitle.Name = "lbMMSItitle";
            this.lbMMSItitle.Size = new System.Drawing.Size(35, 13);
            this.lbMMSItitle.TabIndex = 19;
            this.lbMMSItitle.Text = "MMSI";
            // 
            // lbGuardar
            // 
            this.lbGuardar.Location = new System.Drawing.Point(204, 289);
            this.lbGuardar.Name = "lbGuardar";
            this.lbGuardar.Size = new System.Drawing.Size(75, 23);
            this.lbGuardar.TabIndex = 31;
            this.lbGuardar.Text = "Guardar";
            this.lbGuardar.UseVisualStyleBackColor = true;
            this.lbGuardar.Click += new System.EventHandler(this.lbGuardar_Click);
            // 
            // lbCancelar
            // 
            this.lbCancelar.Location = new System.Drawing.Point(109, 289);
            this.lbCancelar.Name = "lbCancelar";
            this.lbCancelar.Size = new System.Drawing.Size(75, 23);
            this.lbCancelar.TabIndex = 32;
            this.lbCancelar.Text = "Cerrar";
            this.lbCancelar.UseVisualStyleBackColor = true;
            // 
            // lbModificarDatos
            // 
            this.lbModificarDatos.AutoSize = true;
            this.lbModificarDatos.Location = new System.Drawing.Point(105, 25);
            this.lbModificarDatos.Name = "lbModificarDatos";
            this.lbModificarDatos.Size = new System.Drawing.Size(163, 13);
            this.lbModificarDatos.TabIndex = 33;
            this.lbModificarDatos.Text = "Modificar Parametros de Objetivp";
            // 
            // frmModDatosObjetivos
            // 
            this.AcceptButton = this.lbGuardar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.lbCancelar;
            this.ClientSize = new System.Drawing.Size(337, 368);
            this.Controls.Add(this.lbModificarDatos);
            this.Controls.Add(this.lbCancelar);
            this.Controls.Add(this.lbGuardar);
            this.Controls.Add(this.tbNombre);
            this.Controls.Add(this.lbNombre);
            this.Controls.Add(this.tbVelocidad);
            this.Controls.Add(this.tbRumbo);
            this.Controls.Add(this.tbLongitud);
            this.Controls.Add(this.tbLatitude);
            this.Controls.Add(this.tbMMSI);
            this.Controls.Add(this.lbRumbo);
            this.Controls.Add(this.lbVelocidadTitle);
            this.Controls.Add(this.lbLongitud);
            this.Controls.Add(this.lbLatitudTitle);
            this.Controls.Add(this.lbMMSItitle);
            this.Name = "frmModDatosObjetivos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificar Datos del Objetivo";
            this.Load += new System.EventHandler(this.frmModDatosObjetivos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.Label lbNombre;
        private System.Windows.Forms.TextBox tbVelocidad;
        private System.Windows.Forms.TextBox tbRumbo;
        private System.Windows.Forms.TextBox tbLongitud;
        private System.Windows.Forms.TextBox tbLatitude;
        private System.Windows.Forms.TextBox tbMMSI;
        private System.Windows.Forms.Label lbRumbo;
        private System.Windows.Forms.Label lbVelocidadTitle;
        private System.Windows.Forms.Label lbLongitud;
        private System.Windows.Forms.Label lbLatitudTitle;
        private System.Windows.Forms.Label lbMMSItitle;
        private System.Windows.Forms.Button lbGuardar;
        private System.Windows.Forms.Button lbCancelar;
        private System.Windows.Forms.Label lbModificarDatos;
    }
}