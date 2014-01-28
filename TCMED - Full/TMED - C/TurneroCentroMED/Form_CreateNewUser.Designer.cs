namespace TurneroCentroMED
{
    partial class Form_CreateNewUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_CreateNewUser));
            this.BT_CreateUser = new System.Windows.Forms.Button();
            this.BT_Cancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TB_Name = new System.Windows.Forms.TextBox();
            this.TB_LName = new System.Windows.Forms.TextBox();
            this.TB_User = new System.Windows.Forms.TextBox();
            this.TB_Pass = new System.Windows.Forms.TextBox();
            this.TB_PassAgain = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LB_TipoUser = new System.Windows.Forms.ListBox();
            this.LABEL_Status = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // BT_CreateUser
            // 
            this.BT_CreateUser.Location = new System.Drawing.Point(197, 180);
            this.BT_CreateUser.Name = "BT_CreateUser";
            this.BT_CreateUser.Size = new System.Drawing.Size(86, 23);
            this.BT_CreateUser.TabIndex = 6;
            this.BT_CreateUser.Text = "Crear Usuario";
            this.BT_CreateUser.UseVisualStyleBackColor = true;
            this.BT_CreateUser.Click += new System.EventHandler(this.BT_CreateUser_Click);
            // 
            // BT_Cancelar
            // 
            this.BT_Cancelar.Location = new System.Drawing.Point(289, 180);
            this.BT_Cancelar.Name = "BT_Cancelar";
            this.BT_Cancelar.Size = new System.Drawing.Size(75, 23);
            this.BT_Cancelar.TabIndex = 7;
            this.BT_Cancelar.Text = "Cancelar";
            this.BT_Cancelar.UseVisualStyleBackColor = true;
            this.BT_Cancelar.Click += new System.EventHandler(this.BT_Cancelar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Nombre:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Apellido:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "UserName:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Contraseña:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Reescriba Contraseña:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Tipo:";
            // 
            // TB_Name
            // 
            this.TB_Name.Location = new System.Drawing.Point(65, 16);
            this.TB_Name.Name = "TB_Name";
            this.TB_Name.Size = new System.Drawing.Size(180, 20);
            this.TB_Name.TabIndex = 0;
            // 
            // TB_LName
            // 
            this.TB_LName.Location = new System.Drawing.Point(65, 42);
            this.TB_LName.Name = "TB_LName";
            this.TB_LName.Size = new System.Drawing.Size(180, 20);
            this.TB_LName.TabIndex = 1;
            // 
            // TB_User
            // 
            this.TB_User.Location = new System.Drawing.Point(78, 66);
            this.TB_User.Name = "TB_User";
            this.TB_User.Size = new System.Drawing.Size(118, 20);
            this.TB_User.TabIndex = 2;
            // 
            // TB_Pass
            // 
            this.TB_Pass.Location = new System.Drawing.Point(78, 94);
            this.TB_Pass.Name = "TB_Pass";
            this.TB_Pass.PasswordChar = '*';
            this.TB_Pass.Size = new System.Drawing.Size(118, 20);
            this.TB_Pass.TabIndex = 3;
            // 
            // TB_PassAgain
            // 
            this.TB_PassAgain.Location = new System.Drawing.Point(133, 117);
            this.TB_PassAgain.Name = "TB_PassAgain";
            this.TB_PassAgain.PasswordChar = '*';
            this.TB_PassAgain.Size = new System.Drawing.Size(112, 20);
            this.TB_PassAgain.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TurneroCentroMED.Properties.Resources.contacts;
            this.pictureBox1.Location = new System.Drawing.Point(273, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 98);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // LB_TipoUser
            // 
            this.LB_TipoUser.FormattingEnabled = true;
            this.LB_TipoUser.Location = new System.Drawing.Point(49, 146);
            this.LB_TipoUser.Name = "LB_TipoUser";
            this.LB_TipoUser.Size = new System.Drawing.Size(120, 17);
            this.LB_TipoUser.TabIndex = 5;
            // 
            // LABEL_Status
            // 
            this.LABEL_Status.AutoSize = true;
            this.LABEL_Status.Location = new System.Drawing.Point(46, 185);
            this.LABEL_Status.Name = "LABEL_Status";
            this.LABEL_Status.Size = new System.Drawing.Size(40, 13);
            this.LABEL_Status.TabIndex = 15;
            this.LABEL_Status.Text = "Status:";
            // 
            // Form_CreateNewUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 211);
            this.Controls.Add(this.LABEL_Status);
            this.Controls.Add(this.LB_TipoUser);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.TB_PassAgain);
            this.Controls.Add(this.TB_Pass);
            this.Controls.Add(this.TB_User);
            this.Controls.Add(this.TB_LName);
            this.Controls.Add(this.TB_Name);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BT_Cancelar);
            this.Controls.Add(this.BT_CreateUser);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_CreateNewUser";
            this.Text = "Create New User";
            this.Load += new System.EventHandler(this.Form_CreateNewUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BT_CreateUser;
        private System.Windows.Forms.Button BT_Cancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TB_Name;
        private System.Windows.Forms.TextBox TB_LName;
        private System.Windows.Forms.TextBox TB_User;
        private System.Windows.Forms.TextBox TB_Pass;
        private System.Windows.Forms.TextBox TB_PassAgain;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox LB_TipoUser;
        public System.Windows.Forms.Label LABEL_Status;
    }
}