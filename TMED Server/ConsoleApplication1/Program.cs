using System;
using System.Speech.Synthesis;
using System.Net.Sockets;
using System.Net;

namespace Servidor
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Propiedades

            public static DiccionarioDept DP = new DiccionarioDept();
            ListaEstudios tmpList = new ListaEstudios();
            public static ListaDepartamento Depts = new ListaDepartamento();
            public static ListaPaciente Pacientes = new ListaPaciente();
            public static ListaPaciente tmpPacientes = new ListaPaciente();
            private Estudio tmpEstudio;
            private Paciente tmpPaciente;
            public TcpListener Servidor { get; set; }
            public int Puerto = 8080;
            public static SpeechSynthesizer reader = new SpeechSynthesizer();

            #endregion
        }
    }
}
