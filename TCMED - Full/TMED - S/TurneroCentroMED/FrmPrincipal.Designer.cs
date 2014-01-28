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
            this.TimerDefault = new System.Windows.Forms.Timer(this.components);
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.DATAGRID_Estudios = new System.Windows.Forms.DataGridView();
            this.estudIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estudNomDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estudDeptDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estudDuracionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estudiosMedicosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.resourcesBDDDataSet = new TurneroCentroMED.ResourcesBDDDataSet();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usernameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.passwordDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DATAGRID_login = new System.Windows.Forms.DataGridView();
            this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apellidoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usernameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.passwordDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();

            loginsBindingSource = new System.Windows.Forms.BindingSource(this.components);

            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.estudiosMedicosTableAdapter = new TurneroCentroMED.ResourcesBDDDataSetTableAdapters.EstudiosMedicosTableAdapter();

            loginsTableAdapter = new TurneroCentroMED.ResourcesBDDDataSetTableAdapters.LoginsTableAdapter();

            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbDataAdapter1 = new System.Data.OleDb.OleDbDataAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DATAGRID_Estudios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.estudiosMedicosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resourcesBDDDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DATAGRID_login)).BeginInit();

            ((System.ComponentModel.ISupportInitialize)(loginsBindingSource)).BeginInit();

            this.SuspendLayout();
            // 
            // TimerDefault
            // 
            this.TimerDefault.Enabled = true;
            this.TimerDefault.Interval = 30000;
            this.TimerDefault.Tick += new System.EventHandler(this.TimerDefault_Tick);
            // 
            // progressBar1
            // 
            this.progressBar1.ForeColor = System.Drawing.Color.LawnGreen;
            this.progressBar1.Location = new System.Drawing.Point(12, 38);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(342, 23);
            this.progressBar1.TabIndex = 0;
            this.progressBar1.Value = 100;
            // 
            // DATAGRID_Estudios
            // 
            this.DATAGRID_Estudios.AutoGenerateColumns = false;
            this.DATAGRID_Estudios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DATAGRID_Estudios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.estudIDDataGridViewTextBoxColumn,
            this.estudNomDataGridViewTextBoxColumn,
            this.estudDeptDataGridViewTextBoxColumn,
            this.estudDuracionDataGridViewTextBoxColumn});
            this.DATAGRID_Estudios.DataSource = this.estudiosMedicosBindingSource;
            this.DATAGRID_Estudios.Location = new System.Drawing.Point(12, 81);
            this.DATAGRID_Estudios.Name = "DATAGRID_Estudios";
            this.DATAGRID_Estudios.Size = new System.Drawing.Size(228, 28);
            this.DATAGRID_Estudios.TabIndex = 1;
            this.DATAGRID_Estudios.Visible = false;
            // 
            // estudIDDataGridViewTextBoxColumn
            // 
            this.estudIDDataGridViewTextBoxColumn.DataPropertyName = "Estud_ID";
            this.estudIDDataGridViewTextBoxColumn.HeaderText = "Estud_ID";
            this.estudIDDataGridViewTextBoxColumn.Name = "estudIDDataGridViewTextBoxColumn";
            // 
            // estudNomDataGridViewTextBoxColumn
            // 
            this.estudNomDataGridViewTextBoxColumn.DataPropertyName = "Estud_Nom";
            this.estudNomDataGridViewTextBoxColumn.HeaderText = "Estud_Nom";
            this.estudNomDataGridViewTextBoxColumn.Name = "estudNomDataGridViewTextBoxColumn";
            // 
            // estudDeptDataGridViewTextBoxColumn
            // 
            this.estudDeptDataGridViewTextBoxColumn.DataPropertyName = "Estud_Dept";
            this.estudDeptDataGridViewTextBoxColumn.HeaderText = "Estud_Dept";
            this.estudDeptDataGridViewTextBoxColumn.Name = "estudDeptDataGridViewTextBoxColumn";
            // 
            // estudDuracionDataGridViewTextBoxColumn
            // 
            this.estudDuracionDataGridViewTextBoxColumn.DataPropertyName = "Estud_Duracion";
            this.estudDuracionDataGridViewTextBoxColumn.HeaderText = "Estud_Duracion";
            this.estudDuracionDataGridViewTextBoxColumn.Name = "estudDuracionDataGridViewTextBoxColumn";
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
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // usernameDataGridViewTextBoxColumn
            // 
            this.usernameDataGridViewTextBoxColumn.DataPropertyName = "Username";
            this.usernameDataGridViewTextBoxColumn.HeaderText = "Username";
            this.usernameDataGridViewTextBoxColumn.Name = "usernameDataGridViewTextBoxColumn";
            this.usernameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // passwordDataGridViewTextBoxColumn
            // 
            this.passwordDataGridViewTextBoxColumn.DataPropertyName = "Password";
            this.passwordDataGridViewTextBoxColumn.HeaderText = "Password";
            this.passwordDataGridViewTextBoxColumn.Name = "passwordDataGridViewTextBoxColumn";
            this.passwordDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tipoDataGridViewTextBoxColumn
            // 
            this.tipoDataGridViewTextBoxColumn.DataPropertyName = "Tipo";
            this.tipoDataGridViewTextBoxColumn.HeaderText = "Tipo";
            this.tipoDataGridViewTextBoxColumn.Name = "tipoDataGridViewTextBoxColumn";
            this.tipoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // DATAGRID_login
            // 
            this.DATAGRID_login.AutoGenerateColumns = false;
            this.DATAGRID_login.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DATAGRID_login.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombreDataGridViewTextBoxColumn,
            this.apellidoDataGridViewTextBoxColumn,
            this.usernameDataGridViewTextBoxColumn1,
            this.passwordDataGridViewTextBoxColumn1,
            this.tipoDataGridViewTextBoxColumn1});

            this.DATAGRID_login.DataSource = loginsBindingSource;

            this.DATAGRID_login.Location = new System.Drawing.Point(132, 67);
            this.DATAGRID_login.Name = "DATAGRID_login";
            this.DATAGRID_login.Size = new System.Drawing.Size(240, 51);
            this.DATAGRID_login.TabIndex = 2;
            this.DATAGRID_login.Visible = false;
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            this.nombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre";
            this.nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            this.nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            // 
            // apellidoDataGridViewTextBoxColumn
            // 
            this.apellidoDataGridViewTextBoxColumn.DataPropertyName = "Apellido";
            this.apellidoDataGridViewTextBoxColumn.HeaderText = "Apellido";
            this.apellidoDataGridViewTextBoxColumn.Name = "apellidoDataGridViewTextBoxColumn";
            // 
            // usernameDataGridViewTextBoxColumn1
            // 
            this.usernameDataGridViewTextBoxColumn1.DataPropertyName = "Username";
            this.usernameDataGridViewTextBoxColumn1.HeaderText = "Username";
            this.usernameDataGridViewTextBoxColumn1.Name = "usernameDataGridViewTextBoxColumn1";
            // 
            // passwordDataGridViewTextBoxColumn1
            // 
            this.passwordDataGridViewTextBoxColumn1.DataPropertyName = "Password";
            this.passwordDataGridViewTextBoxColumn1.HeaderText = "Password";
            this.passwordDataGridViewTextBoxColumn1.Name = "passwordDataGridViewTextBoxColumn1";
            // 
            // tipoDataGridViewTextBoxColumn1
            // 
            this.tipoDataGridViewTextBoxColumn1.DataPropertyName = "Tipo";
            this.tipoDataGridViewTextBoxColumn1.HeaderText = "Tipo";
            this.tipoDataGridViewTextBoxColumn1.Name = "tipoDataGridViewTextBoxColumn1";
            // 
            // loginsBindingSource
            //

            //TODO: These were this.loginsBindingSource before modifications to be static were done
            loginsBindingSource.DataMember = "Logins";
            loginsBindingSource.DataSource = this.resourcesBDDDataSet;

            // 
            // oleDbConnection1
            // 
            this.oleDbConnection1.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\"C:\\Users\\Richard\\Desktop\\TMED - Se" +
    "rver\\TurneroCentroMED\\ResourcesBDD.accdb\"";
            // 
            // estudiosMedicosTableAdapter
            // 
            this.estudiosMedicosTableAdapter.ClearBeforeFill = true;


            // 
            // loginsTableAdapter
            // 
            loginsTableAdapter.ClearBeforeFill = true;


            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = "SELECT        Nombre, Apellido, Username, [Password], Tipo\r\nFROM            Login" +
    "s";
            this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
            // 
            // oleDbInsertCommand1
            // 
            this.oleDbInsertCommand1.CommandText = "INSERT INTO `Logins` (`Nombre`, `Apellido`, `Username`, `Password`, `Tipo`) VALUE" +
    "S (?, ?, ?, ?, ?)";
            this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Nombre", System.Data.OleDb.OleDbType.VarWChar, 0, "Nombre"),
            new System.Data.OleDb.OleDbParameter("Apellido", System.Data.OleDb.OleDbType.VarWChar, 0, "Apellido"),
            new System.Data.OleDb.OleDbParameter("Username", System.Data.OleDb.OleDbType.VarWChar, 0, "Username"),
            new System.Data.OleDb.OleDbParameter("Password", System.Data.OleDb.OleDbType.VarWChar, 0, "Password"),
            new System.Data.OleDb.OleDbParameter("Tipo", System.Data.OleDb.OleDbType.Integer, 0, "Tipo")});
            // 
            // oleDbUpdateCommand1
            // 
            this.oleDbUpdateCommand1.CommandText = resources.GetString("oleDbUpdateCommand1.CommandText");
            this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Nombre", System.Data.OleDb.OleDbType.VarWChar, 0, "Nombre"),
            new System.Data.OleDb.OleDbParameter("Apellido", System.Data.OleDb.OleDbType.VarWChar, 0, "Apellido"),
            new System.Data.OleDb.OleDbParameter("Username", System.Data.OleDb.OleDbType.VarWChar, 0, "Username"),
            new System.Data.OleDb.OleDbParameter("Password", System.Data.OleDb.OleDbType.VarWChar, 0, "Password"),
            new System.Data.OleDb.OleDbParameter("Tipo", System.Data.OleDb.OleDbType.Integer, 0, "Tipo"),
            new System.Data.OleDb.OleDbParameter("Original_Nombre", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Nombre", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Apellido", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Apellido", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Apellido", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Apellido", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Username", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Username", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Username", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Username", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Password", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Password", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Password", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Password", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Tipo", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Tipo", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Tipo", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Tipo", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbDeleteCommand1
            // 
            this.oleDbDeleteCommand1.CommandText = resources.GetString("oleDbDeleteCommand1.CommandText");
            this.oleDbDeleteCommand1.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_Nombre", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Nombre", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Apellido", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Apellido", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Apellido", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Apellido", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Username", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Username", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Username", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Username", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Password", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Password", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Password", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Password", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Tipo", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Tipo", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Tipo", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Tipo", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbDataAdapter1
            // 
            this.oleDbDataAdapter1.DeleteCommand = this.oleDbDeleteCommand1;
            this.oleDbDataAdapter1.InsertCommand = this.oleDbInsertCommand1;
            this.oleDbDataAdapter1.SelectCommand = this.oleDbSelectCommand1;
            this.oleDbDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Logins", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Nombre", "Nombre"),
                        new System.Data.Common.DataColumnMapping("Apellido", "Apellido"),
                        new System.Data.Common.DataColumnMapping("Username", "Username"),
                        new System.Data.Common.DataColumnMapping("Password", "Password"),
                        new System.Data.Common.DataColumnMapping("Tipo", "Tipo")})});
            this.oleDbDataAdapter1.UpdateCommand = this.oleDbUpdateCommand1;
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 126);
            this.Controls.Add(this.DATAGRID_login);
            this.Controls.Add(this.DATAGRID_Estudios);
            this.Controls.Add(this.progressBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TMED Server : Durakuzz Productionz";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmPrincipal_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.DATAGRID_Estudios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.estudiosMedicosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resourcesBDDDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DATAGRID_login)).EndInit();

            ((System.ComponentModel.ISupportInitialize)(loginsBindingSource)).EndInit();

            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource estudiosMedicosBindingSource;
        private ResourcesBDDDataSetTableAdapters.EstudiosMedicosTableAdapter estudiosMedicosTableAdapter;
        public System.Windows.Forms.Timer TimerDefault;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.DataGridView DATAGRID_Estudios;
        private System.Windows.Forms.DataGridViewTextBoxColumn estudIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn estudNomDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn estudDeptDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn estudDuracionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridView DATAGRID_logins;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usernameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn passwordDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoDataGridViewTextBoxColumn;
        public ResourcesBDDDataSet resourcesBDDDataSet;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellidoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usernameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn passwordDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoDataGridViewTextBoxColumn1;
        private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
        private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
        private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
        private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
        private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter1;
        public System.Data.OleDb.OleDbConnection oleDbConnection1;

        public static System.Windows.Forms.BindingSource loginsBindingSource;
        public static ResourcesBDDDataSetTableAdapters.LoginsTableAdapter loginsTableAdapter;

        public System.Windows.Forms.DataGridView DATAGRID_login;

    }
}

