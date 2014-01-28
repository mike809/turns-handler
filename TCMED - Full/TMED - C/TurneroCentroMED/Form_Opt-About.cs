using System;
using System.Windows.Forms;

namespace TurneroCentroMED
{
    public partial class Form_Opt_About : Form
    {
        public static string DefaultString = "Escriba su inquietud // Write about your problem";
        public Form_Opt_About()
        {
            InitializeComponent();
        }

        private void Form_Opt_About_Load(object sender, EventArgs e)
        {
            //sale el nuevo form del about mostrando
            /*
             * El ip del servidor conectado
             * el ip del cliente conectado
             * la opcion para poder presentar un bug.
             */

            LABEL_ServerIP.Text = Program.ipAddress.ToString();
            LABEL_ClientIP.Text = Program.ipAddress.ToString();
            RTEXTBOX_BugWrite.Focus();
            RTEXTBOX_BugWrite.SelectAll();
            //BOTON_ReportarBug.Enabled = false;
        }

        private void BOTON_ReportarBug_Click(object sender, EventArgs e)
        {
            //cuando se le da al boton de reportar bu g, este lo que hace es que lo que se escriba 
            //se le manda un mensaje al servidor para que aya se almacene.

            //Si no se ha escribido nada no se manda nada
            if ((RTEXTBOX_BugWrite.Text != DefaultString) && RTEXTBOX_BugWrite.TextLength != 0 )
            {
                //Va el codigo de enviarle al servidor ese Texto.
            }
        }
    }
}
