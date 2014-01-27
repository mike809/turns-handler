namespace TurneroCentroMED
{
    partial class FrmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.GB_LeftPanel = new System.Windows.Forms.GroupBox();
            this.DUD_OrdenarPor = new System.Windows.Forms.DomainUpDown();
            this.BOTON_EliminarTodos = new System.Windows.Forms.Button();
            this.BOTON_RemoveSelected = new System.Windows.Forms.Button();
            this.LISTBOX_EstudiosSeleccionados = new System.Windows.Forms.ListBox();
            this.LABEL_EstudiosSeleccionado = new System.Windows.Forms.Label();
            this.BOTON_AgregarEstudios = new System.Windows.Forms.Button();
            this.LABEL_EstudiosMed = new System.Windows.Forms.Label();
            this.BOTON_Agregar = new System.Windows.Forms.Button();
            this.NUD_CantPacientes = new System.Windows.Forms.NumericUpDown();
            this.LABEL_CantPaciente = new System.Windows.Forms.Label();
            this.estudiosMedicosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.resourcesBDDDataSet = new TurneroCentroMED.ResourcesBDDDataSet();
            this.MS_menu = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GB_RightPanel = new System.Windows.Forms.GroupBox();
            this.BOTON_Refresh = new System.Windows.Forms.Button();
            this.DATAGRID_SelectedPatient = new System.Windows.Forms.DataGridView();
            this.LABEL_PacienteSelected = new System.Windows.Forms.Label();
            this.DATAGRID_PacientesActuales = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.DATAGRID_Resonancia = new System.Windows.Forms.DataGridView();
            this.LABEL_Resonancia = new System.Windows.Forms.Label();
            this.DATAGRID_Tomografia = new System.Windows.Forms.DataGridView();
            this.LABEL_Tomografia = new System.Windows.Forms.Label();
            this.DATAGRID_Sonografia = new System.Windows.Forms.DataGridView();
            this.LABEL_SONOGRAFIA = new System.Windows.Forms.Label();
            this.LABEL_XRAY = new System.Windows.Forms.Label();
            this.DATAGRID_RAYOX = new System.Windows.Forms.DataGridView();
            this.estudiosMedicosTableAdapter = new TurneroCentroMED.ResourcesBDDDataSetTableAdapters.EstudiosMedicosTableAdapter();
            this.TimerDefault = new System.Windows.Forms.Timer(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TABPAGE_Ingreso = new System.Windows.Forms.TabPage();
            this.TABPAGE_Carga = new System.Windows.Forms.TabPage();
            this.timeDisplayer1 = new TimeDisplay.TimeDisplayer();
            this.DATAGRID_Estudios = new System.Windows.Forms.DataGridView();
            this.CONTROLBOX_Estudios = new System.Windows.Forms.ComboBox();
            this.estudIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estudNomDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estudDeptDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estudDuracionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GB_LeftPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_CantPacientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.estudiosMedicosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resourcesBDDDataSet)).BeginInit();
            this.MS_menu.SuspendLayout();
            this.GB_RightPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DATAGRID_SelectedPatient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DATAGRID_PacientesActuales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DATAGRID_Resonancia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DATAGRID_Tomografia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DATAGRID_Sonografia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DATAGRID_RAYOX)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.TABPAGE_Ingreso.SuspendLayout();
            this.TABPAGE_Carga.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DATAGRID_Estudios)).BeginInit();
            this.SuspendLayout();
            // 
            // GB_LeftPanel
            // 
            this.GB_LeftPanel.Controls.Add(this.CONTROLBOX_Estudios);
            this.GB_LeftPanel.Controls.Add(this.DATAGRID_Estudios);
            this.GB_LeftPanel.Controls.Add(this.DUD_OrdenarPor);
            this.GB_LeftPanel.Controls.Add(this.BOTON_EliminarTodos);
            this.GB_LeftPanel.Controls.Add(this.BOTON_RemoveSelected);
            this.GB_LeftPanel.Controls.Add(this.LISTBOX_EstudiosSeleccionados);
            this.GB_LeftPanel.Controls.Add(this.LABEL_EstudiosSeleccionado);
            this.GB_LeftPanel.Controls.Add(this.BOTON_AgregarEstudios);
            this.GB_LeftPanel.Controls.Add(this.LABEL_EstudiosMed);
            this.GB_LeftPanel.Controls.Add(this.BOTON_Agregar);
            this.GB_LeftPanel.Controls.Add(this.NUD_CantPacientes);
            this.GB_LeftPanel.Controls.Add(this.LABEL_CantPaciente);
            this.GB_LeftPanel.Location = new System.Drawing.Point(0, 3);
            this.GB_LeftPanel.Name = "GB_LeftPanel";
            this.GB_LeftPanel.Size = new System.Drawing.Size(1259, 468);
            this.GB_LeftPanel.TabIndex = 0;
            this.GB_LeftPanel.TabStop = false;
            // 
            // DUD_OrdenarPor
            // 
            this.DUD_OrdenarPor.Items.Add("Menos Duradero Primero");
            this.DUD_OrdenarPor.Items.Add("Mas Duradero Primero");
            this.DUD_OrdenarPor.Location = new System.Drawing.Point(506, 288);
            this.DUD_OrdenarPor.Name = "DUD_OrdenarPor";
            this.DUD_OrdenarPor.Size = new System.Drawing.Size(156, 20);
            this.DUD_OrdenarPor.TabIndex = 12;
            this.DUD_OrdenarPor.Text = "Ordenar Estudios Por";
            // 
            // BOTON_EliminarTodos
            // 
            this.BOTON_EliminarTodos.Image = global::TurneroCentroMED.Properties.Resources.bullet_error;
            this.BOTON_EliminarTodos.Location = new System.Drawing.Point(868, 289);
            this.BOTON_EliminarTodos.Name = "BOTON_EliminarTodos";
            this.BOTON_EliminarTodos.Size = new System.Drawing.Size(103, 22);
            this.BOTON_EliminarTodos.TabIndex = 10;
            this.BOTON_EliminarTodos.Text = "Eliminar Todos";
            this.BOTON_EliminarTodos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BOTON_EliminarTodos.UseVisualStyleBackColor = true;
            this.BOTON_EliminarTodos.Click += new System.EventHandler(this.BOTON_EliminarTodos_Click);
            // 
            // BOTON_RemoveSelected
            // 
            this.BOTON_RemoveSelected.Image = global::TurneroCentroMED.Properties.Resources.Delete;
            this.BOTON_RemoveSelected.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BOTON_RemoveSelected.Location = new System.Drawing.Point(755, 289);
            this.BOTON_RemoveSelected.Name = "BOTON_RemoveSelected";
            this.BOTON_RemoveSelected.Size = new System.Drawing.Size(102, 22);
            this.BOTON_RemoveSelected.TabIndex = 8;
            this.BOTON_RemoveSelected.Text = "    Eliminar Estudio";
            this.BOTON_RemoveSelected.UseVisualStyleBackColor = true;
            this.BOTON_RemoveSelected.Click += new System.EventHandler(this.BOTON_RemoveSelected_Click);
            // 
            // LISTBOX_EstudiosSeleccionados
            // 
            this.LISTBOX_EstudiosSeleccionados.FormattingEnabled = true;
            this.LISTBOX_EstudiosSeleccionados.Location = new System.Drawing.Point(506, 125);
            this.LISTBOX_EstudiosSeleccionados.Name = "LISTBOX_EstudiosSeleccionados";
            this.LISTBOX_EstudiosSeleccionados.Size = new System.Drawing.Size(465, 134);
            this.LISTBOX_EstudiosSeleccionados.TabIndex = 7;
            this.LISTBOX_EstudiosSeleccionados.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LISTBOX_EstudiosSeleccionados_KeyPress);
            // 
            // LABEL_EstudiosSeleccionado
            // 
            this.LABEL_EstudiosSeleccionado.AutoSize = true;
            this.LABEL_EstudiosSeleccionado.Location = new System.Drawing.Point(503, 98);
            this.LABEL_EstudiosSeleccionado.Name = "LABEL_EstudiosSeleccionado";
            this.LABEL_EstudiosSeleccionado.Size = new System.Drawing.Size(123, 13);
            this.LABEL_EstudiosSeleccionado.TabIndex = 6;
            this.LABEL_EstudiosSeleccionado.Text = "Estudios Seleccionados:";
            // 
            // BOTON_AgregarEstudios
            // 
            this.BOTON_AgregarEstudios.Image = global::TurneroCentroMED.Properties.Resources.add;
            this.BOTON_AgregarEstudios.Location = new System.Drawing.Point(9, 285);
            this.BOTON_AgregarEstudios.Name = "BOTON_AgregarEstudios";
            this.BOTON_AgregarEstudios.Size = new System.Drawing.Size(123, 37);
            this.BOTON_AgregarEstudios.TabIndex = 5;
            this.BOTON_AgregarEstudios.Text = "Agregar Estudio";
            this.BOTON_AgregarEstudios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BOTON_AgregarEstudios.UseVisualStyleBackColor = true;
            this.BOTON_AgregarEstudios.Click += new System.EventHandler(this.BOTON_AgregarEstudios_Click);
            // 
            // LABEL_EstudiosMed
            // 
            this.LABEL_EstudiosMed.AutoSize = true;
            this.LABEL_EstudiosMed.Location = new System.Drawing.Point(6, 101);
            this.LABEL_EstudiosMed.Name = "LABEL_EstudiosMed";
            this.LABEL_EstudiosMed.Size = new System.Drawing.Size(93, 13);
            this.LABEL_EstudiosMed.TabIndex = 2;
            this.LABEL_EstudiosMed.Text = "Estudios Medicos:";
            // 
            // BOTON_Agregar
            // 
            this.BOTON_Agregar.Image = global::TurneroCentroMED.Properties.Resources.vcard_add;
            this.BOTON_Agregar.Location = new System.Drawing.Point(151, 285);
            this.BOTON_Agregar.Name = "BOTON_Agregar";
            this.BOTON_Agregar.Size = new System.Drawing.Size(132, 37);
            this.BOTON_Agregar.TabIndex = 9;
            this.BOTON_Agregar.Text = "Agregar Paciente";
            this.BOTON_Agregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BOTON_Agregar.UseVisualStyleBackColor = true;
            this.BOTON_Agregar.Click += new System.EventHandler(this.BOTON_Agregar_Click);
            // 
            // NUD_CantPacientes
            // 
            this.NUD_CantPacientes.Location = new System.Drawing.Point(97, 36);
            this.NUD_CantPacientes.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NUD_CantPacientes.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUD_CantPacientes.Name = "NUD_CantPacientes";
            this.NUD_CantPacientes.Size = new System.Drawing.Size(35, 20);
            this.NUD_CantPacientes.TabIndex = 1;
            this.NUD_CantPacientes.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // LABEL_CantPaciente
            // 
            this.LABEL_CantPaciente.AutoSize = true;
            this.LABEL_CantPaciente.Location = new System.Drawing.Point(6, 36);
            this.LABEL_CantPaciente.Name = "LABEL_CantPaciente";
            this.LABEL_CantPaciente.Size = new System.Drawing.Size(85, 13);
            this.LABEL_CantPaciente.TabIndex = 0;
            this.LABEL_CantPaciente.Text = "Cant. Pacientes:";
            // 
            // estudiosMedicosBindingSource
            // 
            this.estudiosMedicosBindingSource.DataMember = "EstudiosMedicos";
            this.estudiosMedicosBindingSource.DataSource = this.resourcesBDDDataSet;
            // 
            // resourcesBDDDataSet
            // 
            this.resourcesBDDDataSet.DataSetName = "ResourcesBDDDataSet";
            this.resourcesBDDDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // MS_menu
            // 
            this.MS_menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.MS_menu.Location = new System.Drawing.Point(0, 0);
            this.MS_menu.Name = "MS_menu";
            this.MS_menu.Size = new System.Drawing.Size(1293, 24);
            this.MS_menu.TabIndex = 1;
            this.MS_menu.Text = "menuStrip1";
            this.MS_menu.Visible = false;
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "&Options";
            // 
            // GB_RightPanel
            // 
            this.GB_RightPanel.Controls.Add(this.BOTON_Refresh);
            this.GB_RightPanel.Controls.Add(this.DATAGRID_SelectedPatient);
            this.GB_RightPanel.Controls.Add(this.LABEL_PacienteSelected);
            this.GB_RightPanel.Controls.Add(this.DATAGRID_PacientesActuales);
            this.GB_RightPanel.Controls.Add(this.label1);
            this.GB_RightPanel.Controls.Add(this.DATAGRID_Resonancia);
            this.GB_RightPanel.Controls.Add(this.LABEL_Resonancia);
            this.GB_RightPanel.Controls.Add(this.DATAGRID_Tomografia);
            this.GB_RightPanel.Controls.Add(this.LABEL_Tomografia);
            this.GB_RightPanel.Controls.Add(this.DATAGRID_Sonografia);
            this.GB_RightPanel.Controls.Add(this.LABEL_SONOGRAFIA);
            this.GB_RightPanel.Controls.Add(this.LABEL_XRAY);
            this.GB_RightPanel.Controls.Add(this.DATAGRID_RAYOX);
            this.GB_RightPanel.Location = new System.Drawing.Point(3, 3);
            this.GB_RightPanel.Name = "GB_RightPanel";
            this.GB_RightPanel.Size = new System.Drawing.Size(1250, 465);
            this.GB_RightPanel.TabIndex = 2;
            this.GB_RightPanel.TabStop = false;
            // 
            // BOTON_Refresh
            // 
            this.BOTON_Refresh.Image = global::TurneroCentroMED.Properties.Resources.recycle;
            this.BOTON_Refresh.Location = new System.Drawing.Point(1148, 22);
            this.BOTON_Refresh.Name = "BOTON_Refresh";
            this.BOTON_Refresh.Size = new System.Drawing.Size(96, 27);
            this.BOTON_Refresh.TabIndex = 12;
            this.BOTON_Refresh.Text = "Refresh List";
            this.BOTON_Refresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BOTON_Refresh.UseVisualStyleBackColor = true;
            this.BOTON_Refresh.Click += new System.EventHandler(this.TimerDefault_Tick);
            // 
            // DATAGRID_SelectedPatient
            // 
            this.DATAGRID_SelectedPatient.AllowUserToAddRows = false;
            this.DATAGRID_SelectedPatient.AllowUserToDeleteRows = false;
            this.DATAGRID_SelectedPatient.AllowUserToResizeColumns = false;
            this.DATAGRID_SelectedPatient.AllowUserToResizeRows = false;
            this.DATAGRID_SelectedPatient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DATAGRID_SelectedPatient.Location = new System.Drawing.Point(1033, 270);
            this.DATAGRID_SelectedPatient.Name = "DATAGRID_SelectedPatient";
            this.DATAGRID_SelectedPatient.ReadOnly = true;
            this.DATAGRID_SelectedPatient.RowHeadersVisible = false;
            this.DATAGRID_SelectedPatient.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DATAGRID_SelectedPatient.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DATAGRID_SelectedPatient.Size = new System.Drawing.Size(211, 180);
            this.DATAGRID_SelectedPatient.TabIndex = 11;
            // 
            // LABEL_PacienteSelected
            // 
            this.LABEL_PacienteSelected.AutoSize = true;
            this.LABEL_PacienteSelected.Location = new System.Drawing.Point(1030, 254);
            this.LABEL_PacienteSelected.Name = "LABEL_PacienteSelected";
            this.LABEL_PacienteSelected.Size = new System.Drawing.Size(177, 13);
            this.LABEL_PacienteSelected.TabIndex = 10;
            this.LABEL_PacienteSelected.Text = "Estudios del Paciente Seleccionado";
            // 
            // DATAGRID_PacientesActuales
            // 
            this.DATAGRID_PacientesActuales.AllowUserToAddRows = false;
            this.DATAGRID_PacientesActuales.AllowUserToDeleteRows = false;
            this.DATAGRID_PacientesActuales.AllowUserToResizeColumns = false;
            this.DATAGRID_PacientesActuales.AllowUserToResizeRows = false;
            this.DATAGRID_PacientesActuales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DATAGRID_PacientesActuales.Location = new System.Drawing.Point(1033, 52);
            this.DATAGRID_PacientesActuales.Name = "DATAGRID_PacientesActuales";
            this.DATAGRID_PacientesActuales.ReadOnly = true;
            this.DATAGRID_PacientesActuales.RowHeadersVisible = false;
            this.DATAGRID_PacientesActuales.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DATAGRID_PacientesActuales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DATAGRID_PacientesActuales.Size = new System.Drawing.Size(211, 180);
            this.DATAGRID_PacientesActuales.TabIndex = 9;
            this.DATAGRID_PacientesActuales.SelectionChanged += new System.EventHandler(this.DATAGRID_PacientesActuales_SelectionChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1030, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Pacientes Actuales";
            // 
            // DATAGRID_Resonancia
            // 
            this.DATAGRID_Resonancia.AllowUserToAddRows = false;
            this.DATAGRID_Resonancia.AllowUserToDeleteRows = false;
            this.DATAGRID_Resonancia.AllowUserToResizeColumns = false;
            this.DATAGRID_Resonancia.AllowUserToResizeRows = false;
            this.DATAGRID_Resonancia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DATAGRID_Resonancia.Location = new System.Drawing.Point(531, 270);
            this.DATAGRID_Resonancia.Name = "DATAGRID_Resonancia";
            this.DATAGRID_Resonancia.ReadOnly = true;
            this.DATAGRID_Resonancia.RowHeadersVisible = false;
            this.DATAGRID_Resonancia.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DATAGRID_Resonancia.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DATAGRID_Resonancia.Size = new System.Drawing.Size(485, 180);
            this.DATAGRID_Resonancia.TabIndex = 7;
            // 
            // LABEL_Resonancia
            // 
            this.LABEL_Resonancia.AutoSize = true;
            this.LABEL_Resonancia.Location = new System.Drawing.Point(528, 254);
            this.LABEL_Resonancia.Name = "LABEL_Resonancia";
            this.LABEL_Resonancia.Size = new System.Drawing.Size(173, 13);
            this.LABEL_Resonancia.TabIndex = 6;
            this.LABEL_Resonancia.Text = "DEPARTAMENTO: RESONANCIA";
            // 
            // DATAGRID_Tomografia
            // 
            this.DATAGRID_Tomografia.AllowUserToAddRows = false;
            this.DATAGRID_Tomografia.AllowUserToDeleteRows = false;
            this.DATAGRID_Tomografia.AllowUserToResizeColumns = false;
            this.DATAGRID_Tomografia.AllowUserToResizeRows = false;
            this.DATAGRID_Tomografia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DATAGRID_Tomografia.Location = new System.Drawing.Point(6, 270);
            this.DATAGRID_Tomografia.MultiSelect = false;
            this.DATAGRID_Tomografia.Name = "DATAGRID_Tomografia";
            this.DATAGRID_Tomografia.ReadOnly = true;
            this.DATAGRID_Tomografia.RowHeadersVisible = false;
            this.DATAGRID_Tomografia.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DATAGRID_Tomografia.Size = new System.Drawing.Size(485, 180);
            this.DATAGRID_Tomografia.TabIndex = 5;
            // 
            // LABEL_Tomografia
            // 
            this.LABEL_Tomografia.AutoSize = true;
            this.LABEL_Tomografia.Location = new System.Drawing.Point(3, 254);
            this.LABEL_Tomografia.Name = "LABEL_Tomografia";
            this.LABEL_Tomografia.Size = new System.Drawing.Size(174, 13);
            this.LABEL_Tomografia.TabIndex = 4;
            this.LABEL_Tomografia.Text = "DEPARTAMENTO: TOMOGRAFIA";
            // 
            // DATAGRID_Sonografia
            // 
            this.DATAGRID_Sonografia.AllowUserToAddRows = false;
            this.DATAGRID_Sonografia.AllowUserToDeleteRows = false;
            this.DATAGRID_Sonografia.AllowUserToResizeColumns = false;
            this.DATAGRID_Sonografia.AllowUserToResizeRows = false;
            this.DATAGRID_Sonografia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DATAGRID_Sonografia.Location = new System.Drawing.Point(531, 52);
            this.DATAGRID_Sonografia.MultiSelect = false;
            this.DATAGRID_Sonografia.Name = "DATAGRID_Sonografia";
            this.DATAGRID_Sonografia.ReadOnly = true;
            this.DATAGRID_Sonografia.RowHeadersVisible = false;
            this.DATAGRID_Sonografia.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DATAGRID_Sonografia.Size = new System.Drawing.Size(485, 180);
            this.DATAGRID_Sonografia.TabIndex = 3;
            // 
            // LABEL_SONOGRAFIA
            // 
            this.LABEL_SONOGRAFIA.AutoSize = true;
            this.LABEL_SONOGRAFIA.Location = new System.Drawing.Point(528, 36);
            this.LABEL_SONOGRAFIA.Name = "LABEL_SONOGRAFIA";
            this.LABEL_SONOGRAFIA.Size = new System.Drawing.Size(173, 13);
            this.LABEL_SONOGRAFIA.TabIndex = 2;
            this.LABEL_SONOGRAFIA.Text = "DEPARTAMENTO: SONOGRAFIA";
            // 
            // LABEL_XRAY
            // 
            this.LABEL_XRAY.AutoSize = true;
            this.LABEL_XRAY.Location = new System.Drawing.Point(3, 36);
            this.LABEL_XRAY.Name = "LABEL_XRAY";
            this.LABEL_XRAY.Size = new System.Drawing.Size(150, 13);
            this.LABEL_XRAY.TabIndex = 1;
            this.LABEL_XRAY.Text = "DEPARTAMENTO: RAYOS X";
            // 
            // DATAGRID_RAYOX
            // 
            this.DATAGRID_RAYOX.AllowUserToAddRows = false;
            this.DATAGRID_RAYOX.AllowUserToDeleteRows = false;
            this.DATAGRID_RAYOX.AllowUserToResizeColumns = false;
            this.DATAGRID_RAYOX.AllowUserToResizeRows = false;
            this.DATAGRID_RAYOX.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DATAGRID_RAYOX.Location = new System.Drawing.Point(6, 52);
            this.DATAGRID_RAYOX.Name = "DATAGRID_RAYOX";
            this.DATAGRID_RAYOX.ReadOnly = true;
            this.DATAGRID_RAYOX.RowHeadersVisible = false;
            this.DATAGRID_RAYOX.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DATAGRID_RAYOX.Size = new System.Drawing.Size(485, 180);
            this.DATAGRID_RAYOX.TabIndex = 0;
            // 
            // estudiosMedicosTableAdapter
            // 
            this.estudiosMedicosTableAdapter.ClearBeforeFill = true;
            // 
            // TimerDefault
            // 
            this.TimerDefault.Enabled = true;
            this.TimerDefault.Interval = 30000;
            this.TimerDefault.Tick += new System.EventHandler(this.TimerDefault_Tick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.TABPAGE_Ingreso);
            this.tabControl1.Controls.Add(this.TABPAGE_Carga);
            this.tabControl1.Location = new System.Drawing.Point(12, 49);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.ShowToolTips = true;
            this.tabControl1.Size = new System.Drawing.Size(1273, 503);
            this.tabControl1.TabIndex = 3;
            this.tabControl1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tabControl1_KeyPress);
            // 
            // TABPAGE_Ingreso
            // 
            this.TABPAGE_Ingreso.Controls.Add(this.GB_LeftPanel);
            this.TABPAGE_Ingreso.Location = new System.Drawing.Point(4, 22);
            this.TABPAGE_Ingreso.Name = "TABPAGE_Ingreso";
            this.TABPAGE_Ingreso.Padding = new System.Windows.Forms.Padding(3);
            this.TABPAGE_Ingreso.Size = new System.Drawing.Size(1265, 477);
            this.TABPAGE_Ingreso.TabIndex = 0;
            this.TABPAGE_Ingreso.Text = "Ingresar Pacientes";
            this.TABPAGE_Ingreso.UseVisualStyleBackColor = true;
            // 
            // TABPAGE_Carga
            // 
            this.TABPAGE_Carga.Controls.Add(this.GB_RightPanel);
            this.TABPAGE_Carga.Location = new System.Drawing.Point(4, 22);
            this.TABPAGE_Carga.Name = "TABPAGE_Carga";
            this.TABPAGE_Carga.Padding = new System.Windows.Forms.Padding(3);
            this.TABPAGE_Carga.Size = new System.Drawing.Size(1265, 477);
            this.TABPAGE_Carga.TabIndex = 1;
            this.TABPAGE_Carga.Text = "Carga de los Departamentos";
            this.TABPAGE_Carga.ToolTipText = "Presenta la linea de tiempo de cada departamento.";
            this.TABPAGE_Carga.UseVisualStyleBackColor = true;
            // 
            // timeDisplayer1
            // 
            this.timeDisplayer1.Location = new System.Drawing.Point(12, 27);
            this.timeDisplayer1.Name = "timeDisplayer1";
            this.timeDisplayer1.Size = new System.Drawing.Size(67, 17);
            this.timeDisplayer1.TabIndex = 4;
            // 
            // DATAGRID_Estudios
            // 
            this.DATAGRID_Estudios.AllowUserToAddRows = false;
            this.DATAGRID_Estudios.AllowUserToDeleteRows = false;
            this.DATAGRID_Estudios.AutoGenerateColumns = false;
            this.DATAGRID_Estudios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DATAGRID_Estudios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.estudIDDataGridViewTextBoxColumn,
            this.estudNomDataGridViewTextBoxColumn,
            this.estudDeptDataGridViewTextBoxColumn,
            this.estudDuracionDataGridViewTextBoxColumn});
            this.DATAGRID_Estudios.DataSource = this.estudiosMedicosBindingSource;
            this.DATAGRID_Estudios.Location = new System.Drawing.Point(9, 125);
            this.DATAGRID_Estudios.Name = "DATAGRID_Estudios";
            this.DATAGRID_Estudios.ReadOnly = true;
            this.DATAGRID_Estudios.Size = new System.Drawing.Size(394, 134);
            this.DATAGRID_Estudios.TabIndex = 13;
            // 
            // CONTROLBOX_Estudios
            // 
            this.CONTROLBOX_Estudios.DataSource = this.estudiosMedicosBindingSource;
            this.CONTROLBOX_Estudios.DisplayMember = "Estud_Nom";
            this.CONTROLBOX_Estudios.FormattingEnabled = true;
            this.CONTROLBOX_Estudios.Location = new System.Drawing.Point(105, 93);
            this.CONTROLBOX_Estudios.Name = "CONTROLBOX_Estudios";
            this.CONTROLBOX_Estudios.Size = new System.Drawing.Size(298, 21);
            this.CONTROLBOX_Estudios.TabIndex = 14;
            this.CONTROLBOX_Estudios.ValueMember = "Estud_Nom";
            // 
            // estudIDDataGridViewTextBoxColumn
            // 
            this.estudIDDataGridViewTextBoxColumn.DataPropertyName = "Estud_ID";
            this.estudIDDataGridViewTextBoxColumn.HeaderText = "Estud_ID";
            this.estudIDDataGridViewTextBoxColumn.Name = "estudIDDataGridViewTextBoxColumn";
            this.estudIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // estudNomDataGridViewTextBoxColumn
            // 
            this.estudNomDataGridViewTextBoxColumn.DataPropertyName = "Estud_Nom";
            this.estudNomDataGridViewTextBoxColumn.HeaderText = "Estud_Nom";
            this.estudNomDataGridViewTextBoxColumn.Name = "estudNomDataGridViewTextBoxColumn";
            this.estudNomDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // estudDeptDataGridViewTextBoxColumn
            // 
            this.estudDeptDataGridViewTextBoxColumn.DataPropertyName = "Estud_Dept";
            this.estudDeptDataGridViewTextBoxColumn.HeaderText = "Estud_Dept";
            this.estudDeptDataGridViewTextBoxColumn.Name = "estudDeptDataGridViewTextBoxColumn";
            this.estudDeptDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // estudDuracionDataGridViewTextBoxColumn
            // 
            this.estudDuracionDataGridViewTextBoxColumn.DataPropertyName = "Estud_Duracion";
            this.estudDuracionDataGridViewTextBoxColumn.HeaderText = "Estud_Duracion";
            this.estudDuracionDataGridViewTextBoxColumn.Name = "estudDuracionDataGridViewTextBoxColumn";
            this.estudDuracionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1293, 561);
            this.Controls.Add(this.timeDisplayer1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.MS_menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MS_menu;
            this.MaximizeBox = false;
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Turnero de Estudios Medicos de Pacientes : Durakuzz Productionz";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmPrincipal_KeyPress);
            this.GB_LeftPanel.ResumeLayout(false);
            this.GB_LeftPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_CantPacientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.estudiosMedicosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resourcesBDDDataSet)).EndInit();
            this.MS_menu.ResumeLayout(false);
            this.MS_menu.PerformLayout();
            this.GB_RightPanel.ResumeLayout(false);
            this.GB_RightPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DATAGRID_SelectedPatient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DATAGRID_PacientesActuales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DATAGRID_Resonancia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DATAGRID_Tomografia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DATAGRID_Sonografia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DATAGRID_RAYOX)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.TABPAGE_Ingreso.ResumeLayout(false);
            this.TABPAGE_Carga.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DATAGRID_Estudios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox GB_LeftPanel;
        private System.Windows.Forms.MenuStrip MS_menu;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.NumericUpDown NUD_CantPacientes;
        private System.Windows.Forms.Label LABEL_CantPaciente;
        private System.Windows.Forms.Label LABEL_EstudiosMed;
        private System.Windows.Forms.Button BOTON_Agregar;
        private System.Windows.Forms.Button BOTON_AgregarEstudios;
        private System.Windows.Forms.ListBox LISTBOX_EstudiosSeleccionados;
        private System.Windows.Forms.Label LABEL_EstudiosSeleccionado;
        private System.Windows.Forms.Button BOTON_RemoveSelected;
        private System.Windows.Forms.Button BOTON_EliminarTodos;
        private System.Windows.Forms.DomainUpDown DUD_OrdenarPor;
        private System.Windows.Forms.GroupBox GB_RightPanel;
        private System.Windows.Forms.DataGridView DATAGRID_RAYOX;
        private System.Windows.Forms.DataGridView DATAGRID_Sonografia;
        private System.Windows.Forms.Label LABEL_SONOGRAFIA;
        private System.Windows.Forms.Label LABEL_XRAY;
        private System.Windows.Forms.DataGridView DATAGRID_Tomografia;
        private System.Windows.Forms.Label LABEL_Tomografia;
        private System.Windows.Forms.DataGridView DATAGRID_Resonancia;
        private System.Windows.Forms.Label LABEL_Resonancia;
        private ResourcesBDDDataSet resourcesBDDDataSet;
        private System.Windows.Forms.BindingSource estudiosMedicosBindingSource;
        private ResourcesBDDDataSetTableAdapters.EstudiosMedicosTableAdapter estudiosMedicosTableAdapter;
        public System.Windows.Forms.Timer TimerDefault;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage TABPAGE_Ingreso;
        private System.Windows.Forms.TabPage TABPAGE_Carga;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LABEL_PacienteSelected;
        private System.Windows.Forms.DataGridView DATAGRID_PacientesActuales;
        private System.Windows.Forms.DataGridView DATAGRID_SelectedPatient;
        private TimeDisplay.TimeDisplayer timeDisplayer1;
        private System.Windows.Forms.Button BOTON_Refresh;
        private System.Windows.Forms.ComboBox CONTROLBOX_Estudios;
        private System.Windows.Forms.DataGridView DATAGRID_Estudios;
        private System.Windows.Forms.DataGridViewTextBoxColumn estudIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn estudNomDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn estudDeptDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn estudDuracionDataGridViewTextBoxColumn;
    }
}

