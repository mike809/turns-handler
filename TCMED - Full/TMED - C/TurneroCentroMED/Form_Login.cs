using System;
using System.Net.Sockets;
using System.Windows.Forms;
using Communication.Sockets.Core;
using Communication.Sockets.Core.Client;
using TurneroCentroMED.Conexion;
using TurneroCentroMED.Entidades;

namespace TurneroCentroMED
{
    public partial class Form_Login : Form
    {
        public static ClientTerminal m_ClientTerminal = new ClientTerminal();
        
        delegate void Cerrar();

        public static Accounts tmpAccount = null;
        public static bool WasCorrect = false;
        public int LoginTry = 0;

        public Form_Login()
        {
            InitializeComponent();
            m_ClientTerminal.Connected += IniciarConexion;
            m_ClientTerminal.Disconncted += ConexionCaida;
            m_ClientTerminal.MessageRecived += MensajeRecibido;
            //image[0] = wrong;
            //image[1] = correct;
        }

        void ConexionCaida(Socket socket)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new TCPTerminal_DisconnectDel(ConexionCaida), socket);
                return;
            }

            MessageBox.Show("Server has been disconnected");
            m_ClientTerminal.Connect(Program.ipAddress, Program.Puerto);
        }

        void MensajeRecibido(byte[] bytes)
        {
            Data.ByteArrayToData(bytes);
            
            if (WasCorrect)
            {
                PB_imagen.Image = imageList2.Images[1];
                //Program.m_ClientTerminal = m_ClientTerminal;
                Program._Account = tmpAccount;
                Program.Valid = true;

                //Ingreso un credencial valido, por lo tanto se abre el form principal de acuerdo al tipo user.
                m_ClientTerminal.Close();
                _cerrar();
            }
            else
            {
                PB_imagen.Image = imageList2.Images[0];
            }
        }

        void _cerrar()
        {
            if(InvokeRequired)
            {
                Cerrar close = _cerrar;
                Invoke(close);
                return;
            }

            Close();
        }

        void IniciarConexion(Socket socket)
        {
            m_ClientTerminal.SendMessage(new Data(null, null, null, tmpAccount).DataToByteArray());
            m_ClientTerminal.StartListen();
        }

        private void BT_login_Click(object sender, EventArgs e)
        {
            //aqui tiene que ir la llamada al form principal dependiendo del tipo de usuario que se registro.
            //Cajero, DeptRayoX, DeptTomo, DeptSono, DeptRes
            tmpAccount = new Accounts(TB_User.Text, TB_Pass.Text);
            
            if(LoginTry == 0)
            {
                m_ClientTerminal.Connect(Program.ipAddress,Program.Puerto);
                LoginTry++;
            }

            else
                m_ClientTerminal.SendMessage(new Data(null,null,null,tmpAccount).DataToByteArray());
            

        }

        private void BT_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            //Application.Exit();
        }

        private void Form_Login_Load(object sender, EventArgs e)
        {
        }

        private void TB_Pass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                BT_login.PerformClick();
            }
        }
    }
}
