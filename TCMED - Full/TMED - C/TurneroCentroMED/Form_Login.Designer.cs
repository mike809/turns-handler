using System;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

namespace TurneroCentroMED
{
    partial class Form_Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Login));
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BT_login = new System.Windows.Forms.Button();
            this.BT_cancel = new System.Windows.Forms.Button();
            this.TB_User = new System.Windows.Forms.TextBox();
            this.TB_Pass = new System.Windows.Forms.TextBox();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PB_imagen = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_imagen)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Username:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Password:";
            // 
            // BT_login
            // 
            this.BT_login.Location = new System.Drawing.Point(209, 121);
            this.BT_login.Name = "BT_login";
            this.BT_login.Size = new System.Drawing.Size(44, 23);
            this.BT_login.TabIndex = 2;
            this.BT_login.Text = "Login";
            this.BT_login.UseVisualStyleBackColor = true;
            this.BT_login.Click += new System.EventHandler(this.BT_login_Click);
            // 
            // BT_cancel
            // 
            this.BT_cancel.Location = new System.Drawing.Point(256, 121);
            this.BT_cancel.Name = "BT_cancel";
            this.BT_cancel.Size = new System.Drawing.Size(50, 23);
            this.BT_cancel.TabIndex = 3;
            this.BT_cancel.Text = "Cancel";
            this.BT_cancel.UseVisualStyleBackColor = true;
            this.BT_cancel.Click += new System.EventHandler(this.BT_cancel_Click);
            // 
            // TB_User
            // 
            this.TB_User.Location = new System.Drawing.Point(74, 62);
            this.TB_User.Name = "TB_User";
            this.TB_User.Size = new System.Drawing.Size(232, 20);
            this.TB_User.TabIndex = 0;
            // 
            // TB_Pass
            // 
            this.TB_Pass.Location = new System.Drawing.Point(74, 88);
            this.TB_Pass.Name = "TB_Pass";
            this.TB_Pass.PasswordChar = '*';
            this.TB_Pass.Size = new System.Drawing.Size(232, 20);
            this.TB_Pass.TabIndex = 1;
            this.TB_Pass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TB_Pass_KeyPress);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "error.ico");
            this.imageList2.Images.SetKeyName(1, "button_ok.ico");
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TurneroCentroMED.Properties.Resources.health_care_shield;
            this.pictureBox1.Location = new System.Drawing.Point(153, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 52);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // PB_imagen
            // 
            this.PB_imagen.Location = new System.Drawing.Point(183, 124);
            this.PB_imagen.Name = "PB_imagen";
            this.PB_imagen.Size = new System.Drawing.Size(20, 20);
            this.PB_imagen.TabIndex = 6;
            this.PB_imagen.TabStop = false;
            // 
            // Form_Login
            // 
            this.ClientSize = new System.Drawing.Size(350, 156);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.PB_imagen);
            this.Controls.Add(this.TB_Pass);
            this.Controls.Add(this.TB_User);
            this.Controls.Add(this.BT_cancel);
            this.Controls.Add(this.BT_login);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Form_Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_imagen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ImageList imageList1;
        private Button BOTON_Login;
        private Button button2;
        private Label label1;
        private Label label2;
        private TextBox TEXTBOX_UserName;
        private TextBox TEXTBOX_Password;
        private PictureBox PBOX_image;
        private Label label3;
        private Label label4;
        private Button BT_login;
        private Button BT_cancel;
        private TextBox TB_User;
        private TextBox TB_Pass;
        private ImageList imageList2;
        private PictureBox PB_imagen;
        private PictureBox pictureBox1;
    }
}