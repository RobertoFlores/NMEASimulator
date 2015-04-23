namespace Simulator
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btCerrar = new System.Windows.Forms.Button();
            this.btAgregar = new System.Windows.Forms.Button();
            this.lbTitulo = new System.Windows.Forms.Label();
            this.lbTypeTitle = new System.Windows.Forms.Label();
            this.lbMMSItitle = new System.Windows.Forms.Label();
            this.lbLatitudTitle = new System.Windows.Forms.Label();
            this.lbLongitud = new System.Windows.Forms.Label();
            this.lbVelocidadTitle = new System.Windows.Forms.Label();
            this.lbRumbo = new System.Windows.Forms.Label();
            this.cbTiposObjetivos = new System.Windows.Forms.ComboBox();
            this.tbMMSI = new System.Windows.Forms.TextBox();
            this.tbLatitude = new System.Windows.Forms.TextBox();
            this.tbLongitud = new System.Windows.Forms.TextBox();
            this.tbRumbo = new System.Windows.Forms.TextBox();
            this.tbVelocidad = new System.Windows.Forms.TextBox();
            this.lbIniciarSimulacion = new System.Windows.Forms.Button();
            this.dgObjetivos = new System.Windows.Forms.DataGridView();
            this.cmsListaObjetivos = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.modVelocidad = new System.Windows.Forms.ToolStripMenuItem();
            this.modCoordenadas = new System.Windows.Forms.ToolStripMenuItem();
            this.modRumbo = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarTodosLosParametrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbListaObjetivos = new System.Windows.Forms.Label();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.lbNombre = new System.Windows.Forms.Label();
            this.gbControlPanel = new System.Windows.Forms.GroupBox();
            this.btEnviarObjetivos = new System.Windows.Forms.Button();
            this.lbOnOffSimulacion = new System.Windows.Forms.Label();
            this.lbOnOffEnvio = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbObjetivos = new System.Windows.Forms.Label();
            this.lbSimulador = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btConvertirAGrados = new System.Windows.Forms.Button();
            this.tbMinutos = new System.Windows.Forms.TextBox();
            this.tbSegundos = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbGrados = new System.Windows.Forms.TextBox();
            this.tbGradosDecimales = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgObjetivos)).BeginInit();
            this.cmsListaObjetivos.SuspendLayout();
            this.gbControlPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btCerrar
            // 
            this.btCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCerrar.Location = new System.Drawing.Point(840, 576);
            this.btCerrar.Name = "btCerrar";
            this.btCerrar.Size = new System.Drawing.Size(75, 23);
            this.btCerrar.TabIndex = 0;
            this.btCerrar.Text = "Cerrar";
            this.btCerrar.UseVisualStyleBackColor = true;
            this.btCerrar.Click += new System.EventHandler(this.btCerrar_Click);
            // 
            // btAgregar
            // 
            this.btAgregar.Location = new System.Drawing.Point(184, 324);
            this.btAgregar.Name = "btAgregar";
            this.btAgregar.Size = new System.Drawing.Size(75, 23);
            this.btAgregar.TabIndex = 1;
            this.btAgregar.Text = "Agregar";
            this.btAgregar.UseVisualStyleBackColor = true;
            this.btAgregar.Click += new System.EventHandler(this.btAgregar_Click);
            // 
            // lbTitulo
            // 
            this.lbTitulo.AutoSize = true;
            this.lbTitulo.Location = new System.Drawing.Point(95, 56);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(179, 13);
            this.lbTitulo.TabIndex = 2;
            this.lbTitulo.Text = "Agregar Objetivos a la Lista de Inicio";
            // 
            // lbTypeTitle
            // 
            this.lbTypeTitle.AutoSize = true;
            this.lbTypeTitle.Location = new System.Drawing.Point(35, 101);
            this.lbTypeTitle.Name = "lbTypeTitle";
            this.lbTypeTitle.Size = new System.Drawing.Size(28, 13);
            this.lbTypeTitle.TabIndex = 3;
            this.lbTypeTitle.Text = "Tipo";
            // 
            // lbMMSItitle
            // 
            this.lbMMSItitle.AutoSize = true;
            this.lbMMSItitle.Location = new System.Drawing.Point(35, 137);
            this.lbMMSItitle.Name = "lbMMSItitle";
            this.lbMMSItitle.Size = new System.Drawing.Size(35, 13);
            this.lbMMSItitle.TabIndex = 4;
            this.lbMMSItitle.Text = "MMSI";
            // 
            // lbLatitudTitle
            // 
            this.lbLatitudTitle.AutoSize = true;
            this.lbLatitudTitle.Location = new System.Drawing.Point(35, 199);
            this.lbLatitudTitle.Name = "lbLatitudTitle";
            this.lbLatitudTitle.Size = new System.Drawing.Size(39, 13);
            this.lbLatitudTitle.TabIndex = 5;
            this.lbLatitudTitle.Text = "Latitud";
            // 
            // lbLongitud
            // 
            this.lbLongitud.AutoSize = true;
            this.lbLongitud.Location = new System.Drawing.Point(35, 230);
            this.lbLongitud.Name = "lbLongitud";
            this.lbLongitud.Size = new System.Drawing.Size(48, 13);
            this.lbLongitud.TabIndex = 6;
            this.lbLongitud.Text = "Longitud";
            // 
            // lbVelocidadTitle
            // 
            this.lbVelocidadTitle.AutoSize = true;
            this.lbVelocidadTitle.Location = new System.Drawing.Point(35, 292);
            this.lbVelocidadTitle.Name = "lbVelocidadTitle";
            this.lbVelocidadTitle.Size = new System.Drawing.Size(54, 13);
            this.lbVelocidadTitle.TabIndex = 7;
            this.lbVelocidadTitle.Text = "Velocidad";
            // 
            // lbRumbo
            // 
            this.lbRumbo.AutoSize = true;
            this.lbRumbo.Location = new System.Drawing.Point(35, 260);
            this.lbRumbo.Name = "lbRumbo";
            this.lbRumbo.Size = new System.Drawing.Size(41, 13);
            this.lbRumbo.TabIndex = 8;
            this.lbRumbo.Text = "Rumbo";
            // 
            // cbTiposObjetivos
            // 
            this.cbTiposObjetivos.FormattingEnabled = true;
            this.cbTiposObjetivos.Items.AddRange(new object[] {
            "Class A",
            "Class B",
            "SART",
            "AtoN"});
            this.cbTiposObjetivos.Location = new System.Drawing.Point(138, 98);
            this.cbTiposObjetivos.Name = "cbTiposObjetivos";
            this.cbTiposObjetivos.Size = new System.Drawing.Size(121, 21);
            this.cbTiposObjetivos.TabIndex = 9;
            this.cbTiposObjetivos.Text = "Seleccionar";
            // 
            // tbMMSI
            // 
            this.tbMMSI.Location = new System.Drawing.Point(138, 134);
            this.tbMMSI.Name = "tbMMSI";
            this.tbMMSI.Size = new System.Drawing.Size(121, 20);
            this.tbMMSI.TabIndex = 10;
            // 
            // tbLatitude
            // 
            this.tbLatitude.Location = new System.Drawing.Point(138, 197);
            this.tbLatitude.Name = "tbLatitude";
            this.tbLatitude.Size = new System.Drawing.Size(121, 20);
            this.tbLatitude.TabIndex = 12;
            // 
            // tbLongitud
            // 
            this.tbLongitud.Location = new System.Drawing.Point(138, 227);
            this.tbLongitud.Name = "tbLongitud";
            this.tbLongitud.Size = new System.Drawing.Size(121, 20);
            this.tbLongitud.TabIndex = 13;
            // 
            // tbRumbo
            // 
            this.tbRumbo.Location = new System.Drawing.Point(138, 258);
            this.tbRumbo.Name = "tbRumbo";
            this.tbRumbo.Size = new System.Drawing.Size(121, 20);
            this.tbRumbo.TabIndex = 14;
            // 
            // tbVelocidad
            // 
            this.tbVelocidad.Location = new System.Drawing.Point(138, 289);
            this.tbVelocidad.Name = "tbVelocidad";
            this.tbVelocidad.Size = new System.Drawing.Size(121, 20);
            this.tbVelocidad.TabIndex = 15;
            // 
            // lbIniciarSimulacion
            // 
            this.lbIniciarSimulacion.Location = new System.Drawing.Point(47, 142);
            this.lbIniciarSimulacion.Name = "lbIniciarSimulacion";
            this.lbIniciarSimulacion.Size = new System.Drawing.Size(75, 23);
            this.lbIniciarSimulacion.TabIndex = 19;
            this.lbIniciarSimulacion.Text = "Iniciar";
            this.lbIniciarSimulacion.UseVisualStyleBackColor = true;
            this.lbIniciarSimulacion.Click += new System.EventHandler(this.lbIniciarSimulacion_Click);
            // 
            // dgObjetivos
            // 
            this.dgObjetivos.AllowUserToAddRows = false;
            this.dgObjetivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgObjetivos.Location = new System.Drawing.Point(360, 101);
            this.dgObjetivos.MultiSelect = false;
            this.dgObjetivos.Name = "dgObjetivos";
            this.dgObjetivos.RowHeadersVisible = false;
            this.dgObjetivos.RowTemplate.ContextMenuStrip = this.cmsListaObjetivos;
            this.dgObjetivos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgObjetivos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgObjetivos.Size = new System.Drawing.Size(555, 443);
            this.dgObjetivos.TabIndex = 16;
            this.dgObjetivos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgObjetivos_CellDoubleClick);
            // 
            // cmsListaObjetivos
            // 
            this.cmsListaObjetivos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modVelocidad,
            this.modCoordenadas,
            this.modRumbo,
            this.modificarTodosLosParametrosToolStripMenuItem});
            this.cmsListaObjetivos.Name = "cmsListaObjetivos";
            this.cmsListaObjetivos.Size = new System.Drawing.Size(248, 92);
            // 
            // modVelocidad
            // 
            this.modVelocidad.Name = "modVelocidad";
            this.modVelocidad.Size = new System.Drawing.Size(247, 22);
            this.modVelocidad.Text = "Modificar Velocidad del Objetivo";
            this.modVelocidad.Click += new System.EventHandler(this.modVelocidad_Click);
            // 
            // modCoordenadas
            // 
            this.modCoordenadas.Name = "modCoordenadas";
            this.modCoordenadas.Size = new System.Drawing.Size(247, 22);
            this.modCoordenadas.Text = "Modificar Coordenadas";
            this.modCoordenadas.Click += new System.EventHandler(this.modCoordenadas_Click);
            // 
            // modRumbo
            // 
            this.modRumbo.Name = "modRumbo";
            this.modRumbo.Size = new System.Drawing.Size(247, 22);
            this.modRumbo.Text = "Modificar Rumbo";
            this.modRumbo.Click += new System.EventHandler(this.modRumbo_Click);
            // 
            // modificarTodosLosParametrosToolStripMenuItem
            // 
            this.modificarTodosLosParametrosToolStripMenuItem.Name = "modificarTodosLosParametrosToolStripMenuItem";
            this.modificarTodosLosParametrosToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.modificarTodosLosParametrosToolStripMenuItem.Text = "Modificar Todos los Parametros";
            this.modificarTodosLosParametrosToolStripMenuItem.Click += new System.EventHandler(this.modificarTodosLosParametrosToolStripMenuItem_Click);
            // 
            // lbListaObjetivos
            // 
            this.lbListaObjetivos.AutoSize = true;
            this.lbListaObjetivos.Location = new System.Drawing.Point(824, 56);
            this.lbListaObjetivos.Name = "lbListaObjetivos";
            this.lbListaObjetivos.Size = new System.Drawing.Size(91, 13);
            this.lbListaObjetivos.TabIndex = 17;
            this.lbListaObjetivos.Text = "Lista de Objetivos";
            // 
            // tbNombre
            // 
            this.tbNombre.Location = new System.Drawing.Point(138, 165);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(121, 20);
            this.tbNombre.TabIndex = 11;
            // 
            // lbNombre
            // 
            this.lbNombre.AutoSize = true;
            this.lbNombre.Location = new System.Drawing.Point(35, 168);
            this.lbNombre.Name = "lbNombre";
            this.lbNombre.Size = new System.Drawing.Size(44, 13);
            this.lbNombre.TabIndex = 18;
            this.lbNombre.Text = "Nombre";
            // 
            // gbControlPanel
            // 
            this.gbControlPanel.Controls.Add(this.btEnviarObjetivos);
            this.gbControlPanel.Controls.Add(this.lbOnOffSimulacion);
            this.gbControlPanel.Controls.Add(this.lbOnOffEnvio);
            this.gbControlPanel.Controls.Add(this.label1);
            this.gbControlPanel.Controls.Add(this.lbObjetivos);
            this.gbControlPanel.Controls.Add(this.lbIniciarSimulacion);
            this.gbControlPanel.Location = new System.Drawing.Point(38, 364);
            this.gbControlPanel.Name = "gbControlPanel";
            this.gbControlPanel.Size = new System.Drawing.Size(221, 180);
            this.gbControlPanel.TabIndex = 20;
            this.gbControlPanel.TabStop = false;
            this.gbControlPanel.Text = "Control Panel";
            // 
            // btEnviarObjetivos
            // 
            this.btEnviarObjetivos.Location = new System.Drawing.Point(47, 70);
            this.btEnviarObjetivos.Name = "btEnviarObjetivos";
            this.btEnviarObjetivos.Size = new System.Drawing.Size(75, 23);
            this.btEnviarObjetivos.TabIndex = 29;
            this.btEnviarObjetivos.Text = "Iniciar";
            this.btEnviarObjetivos.UseVisualStyleBackColor = true;
            this.btEnviarObjetivos.Click += new System.EventHandler(this.btEnviarObjetivos_Click);
            // 
            // lbOnOffSimulacion
            // 
            this.lbOnOffSimulacion.AutoSize = true;
            this.lbOnOffSimulacion.ForeColor = System.Drawing.Color.Red;
            this.lbOnOffSimulacion.Location = new System.Drawing.Point(175, 109);
            this.lbOnOffSimulacion.Name = "lbOnOffSimulacion";
            this.lbOnOffSimulacion.Size = new System.Drawing.Size(27, 13);
            this.lbOnOffSimulacion.TabIndex = 28;
            this.lbOnOffSimulacion.Text = "OFF";
            // 
            // lbOnOffEnvio
            // 
            this.lbOnOffEnvio.AutoSize = true;
            this.lbOnOffEnvio.ForeColor = System.Drawing.Color.Red;
            this.lbOnOffEnvio.Location = new System.Drawing.Point(173, 35);
            this.lbOnOffEnvio.Name = "lbOnOffEnvio";
            this.lbOnOffEnvio.Size = new System.Drawing.Size(27, 13);
            this.lbOnOffEnvio.TabIndex = 27;
            this.lbOnOffEnvio.Text = "OFF";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Envío de Objetivos";
            // 
            // lbObjetivos
            // 
            this.lbObjetivos.AutoSize = true;
            this.lbObjetivos.Location = new System.Drawing.Point(44, 109);
            this.lbObjetivos.Name = "lbObjetivos";
            this.lbObjetivos.Size = new System.Drawing.Size(120, 13);
            this.lbObjetivos.TabIndex = 23;
            this.lbObjetivos.Text = "Simulación de Objetivos";
            // 
            // lbSimulador
            // 
            this.lbSimulador.AutoSize = true;
            this.lbSimulador.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSimulador.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lbSimulador.Location = new System.Drawing.Point(356, 9);
            this.lbSimulador.Name = "lbSimulador";
            this.lbSimulador.Size = new System.Drawing.Size(205, 24);
            this.lbSimulador.TabIndex = 21;
            this.lbSimulador.Text = "Simulador de Objetivos";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(38, 553);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(74, 71);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // btConvertirAGrados
            // 
            this.btConvertirAGrados.Location = new System.Drawing.Point(574, 562);
            this.btConvertirAGrados.Name = "btConvertirAGrados";
            this.btConvertirAGrados.Size = new System.Drawing.Size(75, 23);
            this.btConvertirAGrados.TabIndex = 23;
            this.btConvertirAGrados.Text = "Convertir";
            this.btConvertirAGrados.UseVisualStyleBackColor = true;
            this.btConvertirAGrados.Click += new System.EventHandler(this.btConvertirAGrados_Click);
            // 
            // tbMinutos
            // 
            this.tbMinutos.Location = new System.Drawing.Point(437, 563);
            this.tbMinutos.Name = "tbMinutos";
            this.tbMinutos.Size = new System.Drawing.Size(49, 20);
            this.tbMinutos.TabIndex = 25;
            // 
            // tbSegundos
            // 
            this.tbSegundos.Location = new System.Drawing.Point(502, 563);
            this.tbSegundos.Name = "tbSegundos";
            this.tbSegundos.Size = new System.Drawing.Size(49, 20);
            this.tbSegundos.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(422, 560);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "o";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(487, 567);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(9, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "\'";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(557, 566);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "\'\'";
            // 
            // tbGrados
            // 
            this.tbGrados.Location = new System.Drawing.Point(371, 563);
            this.tbGrados.Name = "tbGrados";
            this.tbGrados.Size = new System.Drawing.Size(49, 20);
            this.tbGrados.TabIndex = 24;
            // 
            // tbGradosDecimales
            // 
            this.tbGradosDecimales.Location = new System.Drawing.Point(474, 593);
            this.tbGradosDecimales.Name = "tbGradosDecimales";
            this.tbGradosDecimales.Size = new System.Drawing.Size(175, 20);
            this.tbGradosDecimales.TabIndex = 30;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(368, 596);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "Grados Decimales:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label6.Location = new System.Drawing.Point(118, 572);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 24);
            this.label6.TabIndex = 32;
            this.label6.Text = "Aerys";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label7.Location = new System.Drawing.Point(118, 596);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(126, 24);
            this.label7.TabIndex = 33;
            this.label7.Text = "Technologies";
            // 
            // Form1
            // 
            this.AcceptButton = this.btAgregar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCerrar;
            this.ClientSize = new System.Drawing.Size(934, 636);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbGradosDecimales);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbSegundos);
            this.Controls.Add(this.tbMinutos);
            this.Controls.Add(this.tbGrados);
            this.Controls.Add(this.btConvertirAGrados);
            this.Controls.Add(this.lbSimulador);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.gbControlPanel);
            this.Controls.Add(this.tbNombre);
            this.Controls.Add(this.lbNombre);
            this.Controls.Add(this.tbVelocidad);
            this.Controls.Add(this.lbListaObjetivos);
            this.Controls.Add(this.dgObjetivos);
            this.Controls.Add(this.tbRumbo);
            this.Controls.Add(this.tbLongitud);
            this.Controls.Add(this.tbLatitude);
            this.Controls.Add(this.tbMMSI);
            this.Controls.Add(this.cbTiposObjetivos);
            this.Controls.Add(this.lbRumbo);
            this.Controls.Add(this.lbVelocidadTitle);
            this.Controls.Add(this.lbLongitud);
            this.Controls.Add(this.lbLatitudTitle);
            this.Controls.Add(this.lbMMSItitle);
            this.Controls.Add(this.lbTypeTitle);
            this.Controls.Add(this.lbTitulo);
            this.Controls.Add(this.btAgregar);
            this.Controls.Add(this.btCerrar);
            this.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NMEA Simulator Aerys Technologies ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgObjetivos)).EndInit();
            this.cmsListaObjetivos.ResumeLayout(false);
            this.gbControlPanel.ResumeLayout(false);
            this.gbControlPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btCerrar;
        private System.Windows.Forms.Button btAgregar;
        private System.Windows.Forms.Label lbTitulo;
        private System.Windows.Forms.Label lbTypeTitle;
        private System.Windows.Forms.Label lbMMSItitle;
        private System.Windows.Forms.Label lbLatitudTitle;
        private System.Windows.Forms.Label lbLongitud;
        private System.Windows.Forms.Label lbVelocidadTitle;
        private System.Windows.Forms.Label lbRumbo;
        private System.Windows.Forms.ComboBox cbTiposObjetivos;
        private System.Windows.Forms.TextBox tbMMSI;
        private System.Windows.Forms.TextBox tbLatitude;
        private System.Windows.Forms.TextBox tbLongitud;
        private System.Windows.Forms.TextBox tbRumbo;
        private System.Windows.Forms.TextBox tbVelocidad;
        private System.Windows.Forms.Button lbIniciarSimulacion;
        private System.Windows.Forms.DataGridView dgObjetivos;
        private System.Windows.Forms.Label lbListaObjetivos;
        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.Label lbNombre;
        private System.Windows.Forms.ContextMenuStrip cmsListaObjetivos;
        private System.Windows.Forms.ToolStripMenuItem modVelocidad;
        private System.Windows.Forms.ToolStripMenuItem modCoordenadas;
        private System.Windows.Forms.ToolStripMenuItem modRumbo;
        private System.Windows.Forms.ToolStripMenuItem modificarTodosLosParametrosToolStripMenuItem;
        private System.Windows.Forms.GroupBox gbControlPanel;
        private System.Windows.Forms.Label lbSimulador;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbObjetivos;
        private System.Windows.Forms.Label lbOnOffSimulacion;
        private System.Windows.Forms.Label lbOnOffEnvio;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btEnviarObjetivos;
        private System.Windows.Forms.Button btConvertirAGrados;
        private System.Windows.Forms.TextBox tbMinutos;
        private System.Windows.Forms.TextBox tbSegundos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbGrados;
        private System.Windows.Forms.TextBox tbGradosDecimales;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}

