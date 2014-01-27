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
            this.estudiosMedicosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.resourcesBDDDataSet = new TurneroCentroMED.ResourcesBDDDataSet();
            this.estudiosMedicosTableAdapter = new TurneroCentroMED.ResourcesBDDDataSetTableAdapters.EstudiosMedicosTableAdapter();
            this.TimerDefault = new System.Windows.Forms.Timer(this.components);
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.DATAGRID_Estudios = new System.Windows.Forms.DataGridView();
            this.estudIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estudNomDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estudDeptDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estudDuracionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.estudiosMedicosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resourcesBDDDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DATAGRID_Estudios)).BeginInit();
            this.SuspendLayout();
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
            // progressBar1
            // 
            this.progressBar1.ForeColor = System.Drawing.Color.LawnGreen;
            this.progressBar1.Location = new System.Drawing.Point(12, 52);
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
            this.DATAGRID_Estudios.Size = new System.Drawing.Size(443, 150);
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
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 103);
            this.Controls.Add(this.DATAGRID_Estudios);
            this.Controls.Add(this.progressBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Turnero de Estudios Medicos de Pacientes : Durakuzz Productionz (Light Generic Ve" +
                "rsion)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmPrincipal_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.estudiosMedicosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resourcesBDDDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DATAGRID_Estudios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ResourcesBDDDataSet resourcesBDDDataSet;
        private System.Windows.Forms.BindingSource estudiosMedicosBindingSource;
        private ResourcesBDDDataSetTableAdapters.EstudiosMedicosTableAdapter estudiosMedicosTableAdapter;
        public System.Windows.Forms.Timer TimerDefault;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.DataGridView DATAGRID_Estudios;
        private System.Windows.Forms.DataGridViewTextBoxColumn estudIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn estudNomDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn estudDeptDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn estudDuracionDataGridViewTextBoxColumn;
    }
}

