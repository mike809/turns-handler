namespace TurneroCentroMED
{
    partial class Form_Opt_About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Opt_About));
            this.LABEL_Server = new System.Windows.Forms.Label();
            this.LABEL_Client = new System.Windows.Forms.Label();
            this.LABEL_ServerIP = new System.Windows.Forms.Label();
            this.LABEL_ClientIP = new System.Windows.Forms.Label();
            this.BOTON_ReportarBug = new System.Windows.Forms.Button();
            this.RTEXTBOX_BugWrite = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LABEL_Server
            // 
            this.LABEL_Server.AutoSize = true;
            this.LABEL_Server.Location = new System.Drawing.Point(12, 21);
            this.LABEL_Server.Name = "LABEL_Server";
            this.LABEL_Server.Size = new System.Drawing.Size(57, 13);
            this.LABEL_Server.TabIndex = 2;
            this.LABEL_Server.Text = "Server IP :";
            // 
            // LABEL_Client
            // 
            this.LABEL_Client.AutoSize = true;
            this.LABEL_Client.Location = new System.Drawing.Point(12, 43);
            this.LABEL_Client.Name = "LABEL_Client";
            this.LABEL_Client.Size = new System.Drawing.Size(55, 13);
            this.LABEL_Client.TabIndex = 4;
            this.LABEL_Client.Text = "Client IP : ";
            // 
            // LABEL_ServerIP
            // 
            this.LABEL_ServerIP.AutoSize = true;
            this.LABEL_ServerIP.Location = new System.Drawing.Point(69, 21);
            this.LABEL_ServerIP.Name = "LABEL_ServerIP";
            this.LABEL_ServerIP.Size = new System.Drawing.Size(0, 13);
            this.LABEL_ServerIP.TabIndex = 3;
            // 
            // LABEL_ClientIP
            // 
            this.LABEL_ClientIP.AutoSize = true;
            this.LABEL_ClientIP.Location = new System.Drawing.Point(69, 43);
            this.LABEL_ClientIP.Name = "LABEL_ClientIP";
            this.LABEL_ClientIP.Size = new System.Drawing.Size(0, 13);
            this.LABEL_ClientIP.TabIndex = 5;
            // 
            // BOTON_ReportarBug
            // 
            this.BOTON_ReportarBug.Image = global::TurneroCentroMED.Properties.Resources.bug_add;
            this.BOTON_ReportarBug.Location = new System.Drawing.Point(297, 166);
            this.BOTON_ReportarBug.Name = "BOTON_ReportarBug";
            this.BOTON_ReportarBug.Size = new System.Drawing.Size(87, 23);
            this.BOTON_ReportarBug.TabIndex = 1;
            this.BOTON_ReportarBug.Text = "Report Bug";
            this.BOTON_ReportarBug.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BOTON_ReportarBug.UseVisualStyleBackColor = true;
            this.BOTON_ReportarBug.Click += new System.EventHandler(this.BOTON_ReportarBug_Click);
            // 
            // RTEXTBOX_BugWrite
            // 
            this.RTEXTBOX_BugWrite.Location = new System.Drawing.Point(91, 71);
            this.RTEXTBOX_BugWrite.Name = "RTEXTBOX_BugWrite";
            this.RTEXTBOX_BugWrite.Size = new System.Drawing.Size(293, 89);
            this.RTEXTBOX_BugWrite.TabIndex = 0;
            this.RTEXTBOX_BugWrite.Text = "Escriba su inquietud // Write about your problem";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Report a Bug:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Turnero de Ensayos Medicos v2.0";
            // 
            // Form_Opt_About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 204);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RTEXTBOX_BugWrite);
            this.Controls.Add(this.BOTON_ReportarBug);
            this.Controls.Add(this.LABEL_ClientIP);
            this.Controls.Add(this.LABEL_ServerIP);
            this.Controls.Add(this.LABEL_Client);
            this.Controls.Add(this.LABEL_Server);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Opt_About";
            this.Text = "About";
            this.Load += new System.EventHandler(this.Form_Opt_About_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LABEL_Server;
        private System.Windows.Forms.Label LABEL_Client;
        private System.Windows.Forms.Label LABEL_ServerIP;
        private System.Windows.Forms.Label LABEL_ClientIP;
        private System.Windows.Forms.Button BOTON_ReportarBug;
        private System.Windows.Forms.RichTextBox RTEXTBOX_BugWrite;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}