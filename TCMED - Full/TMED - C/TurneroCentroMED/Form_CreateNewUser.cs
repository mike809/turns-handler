using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using TurneroCentroMED.Conexion;
using TurneroCentroMED.Entidades;

namespace TurneroCentroMED
{
    public partial class Form_CreateNewUser : Form
    {
        public Form_CreateNewUser()
        {
            InitializeComponent();
            LB_TipoUser.DataSource = Enum.GetNames(typeof(Accounts.eTipoUser));
        }

        private void BT_CreateUser_Click(object sender, EventArgs e)
        {
            //se verifica si el las claves digitadas fueron correctas
            if (TB_Pass.Text == TB_PassAgain.Text && CheckIfEmpty())
            {
                //se crea la cuenta para enviarla a la base de datos.
                Accounts tmpAcc = new Accounts(TB_Name.Text, TB_LName.Text,TB_User.Text, TB_Pass.Text, LB_TipoUser.SelectedIndex);
                Data tmpData = new Data(null, null, null, tmpAcc);
                FrmPrincipal.m_ClientTerminal.SendMessage(tmpData.DataToByteArray());

                Application.DoEvents();
                Thread.Sleep(100);
                if (Program.UsuarioCreado)
                {
                    LABEL_Status.Text = "Status: Succesfully created!";
                    Program.UsuarioCreado = false;
                }

            }
            else
            {
                if(TB_Pass.Text != TB_PassAgain.Text)
                    MessageBox.Show("Clave digitada no fue la misma, intente de nuevo.");
                else
                {
                    MessageBox.Show("Favor de llenar todos los campos.");

                }
            }
        }

        public bool CheckIfEmpty()
        {
            if (TB_Name.Text == string.Empty)
            {
                return false;
            }
            if (TB_LName.Text == string.Empty)
            {
                return false;
            }
            if (TB_Pass.Text == string.Empty)
            {
                return false;
            }
            if (TB_PassAgain.Text == string.Empty)
            {
                return false;
            }
            if (TB_User.Text == string.Empty)
            {
                return false;
            }
            return true;
        }
        private void BT_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_CreateNewUser_Load(object sender, EventArgs e)
        {

        }
    }
}
