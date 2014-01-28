using System;
using System.Net;
using System.Windows.Forms;
using TurneroCentroMED.Conexion;

namespace TurneroCentroMED
{
    static class Program
    {
        public static bool Valid = false;
        public static bool UsuarioCreado = false;
        public static Accounts _Account = new Accounts();
        public const int Puerto = 5656;
        public static IPAddress ipAddress = IPAddress.Parse("127.0.0.1");//IPAddress.Parse("192.168.43.17");

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form_Login());

            if (Valid)
            {
                Application.Run(new FrmPrincipal(_Account));
            }
            
        }
    }
}
