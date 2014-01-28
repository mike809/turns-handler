using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;
using System.Speech.Synthesis;
using Communication.Sockets.Core;
using Communication.Sockets.Core.Server;
using TurneroCentroMED.Conexion;
using TurneroCentroMED.Entidades;
using TurneroCentroMED.ResourcesBDDDataSetTableAdapters;

namespace TurneroCentroMED
{
    public partial class FrmPrincipal : Form
    {
        #region Propiedades
        //public static ResourcesBDDDataSetTableAdapters.LoginsTableAdapter loginsTableAdapter_fix;

        public static DataGridView tmpLoginsGrid;
        public static DataTable tmpTable = new DataTable();
        private static ResourcesBDDDataSetTableAdapters.LoginsTableAdapter loginsTadapter = new LoginsTableAdapter();

        ServerTerminal m_ServerTerminal;
        public static DiccionarioDept DP = new DiccionarioDept();
        public static ListaDepartamento Depts = new ListaDepartamento();
        public static ListaPaciente Pacientes = new ListaPaciente();
        public static ListaPaciente tmpPacientes = new ListaPaciente();
        public static ListaPaciente tmpPa = new ListaPaciente();
        public static ListaEstudios EstudiosBDD = new ListaEstudios();
        public static Data DataForClient = new Data();
        public static ListaAccounts ListAccounts = new ListaAccounts();
        public static Accounts tmpAccount = null;
               
        
        public static SpeechSynthesizer reader = new SpeechSynthesizer();

        public const int Puerto = 5656;

        #endregion
        
        public FrmPrincipal()
        {
            InitializeComponent();
            reader.GetInstalledVoices();
            reader.Volume = 100;
            Funciones.GetSavedData();//Abrimos el archivo binario para sacar la ultima lista de pacientes actuales.
            UpdateDepSchedule();
            TimerDefault.Start();
            Pacientes.UpdatePatients();
            reader.Pause();
            reader.SpeakAsync("Initializing Server");

            createTerminal(Puerto);
        }

        private void createTerminal(int alPort)
        {
            m_ServerTerminal = new ServerTerminal();
            m_ServerTerminal.MessageRecived += ReadCallback;
            m_ServerTerminal.StartListen(alPort);
        }

        private void closeTerminal()
        {
            m_ServerTerminal.MessageRecived -= new TCPTerminal_MessageRecivedDel(ReadCallback);
   
            m_ServerTerminal.Close();
        }

        public void ReadCallback(ConnectedClient clienteActual, byte[] ar)
        {
            Data.ByteArrayToData(ar, clienteActual);  
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'resourcesBDDDataSet.Logins' table. You can move, or remove it, as needed.
            loginsTableAdapter.Fill(this.resourcesBDDDataSet.Logins);
            // TODO: This line of code loads data into the 'resourcesBDDDataSet.EstudiosMedicos' table. You can move, or remove it, as needed.
            this.estudiosMedicosTableAdapter.Fill(this.resourcesBDDDataSet.EstudiosMedicos);

            for (int i = 0; i < DATAGRID_Estudios.RowHeadersWidth - 1; i++)
            {
                DATAGRID_Estudios.Rows[i].Selected = true;
                //Agregamos el estudio de ese selected row count.
                EstudiosBDD.Add(new Estudio(DATAGRID_Estudios));
                DATAGRID_Estudios.Rows[i].Selected = false;
            }
            
            tmpLoginsGrid = DATAGRID_login;
            loginsTadapter = loginsTableAdapter;
            //tmpTable.DataSet = resourcesBDDDataSet.Logins;

        }

        public static bool AgregarNuevoUsuario(Accounts UserN)
        {
            try
            {
                int Tipo = Convert.ToInt32(UserN.TipoUsuario);
                //DATAGRID_login.Rows.Add(UserN.Nombre, UserN.Apellido, UserN.Username, UserN.Password, Tipo);

                loginsTableAdapter.InsertInto(UserN.Nombre, UserN.Apellido, UserN.Username, UserN.Password, Tipo);
                //loginsTableAdapter_fix.InsertInto(UserN.Nombre, UserN.Apellido, UserN.Username, UserN.Password, Tipo);

                //loginsBindingSource.AddNew();

                //DATAGRID_login.Update();
                //Conexion
                //oleDbConnection1.Open();

                ////Intruccion SQL
                //String CadenaSQL = "INSERT INTO Logins (Nombre,Apellido,Username,Password,Tipo) VALUES ('" + UserN.Nombre + "', '" + UserN.Apellido + "', '" + UserN.Username + "', '" + UserN.Password + "', " + Tipo + " )";
                ////oleDbDataAdapter1.InsertCommand.INSERT INTO `Logins` (`Nombre`, `Apellido`, `Username`, `Password`, `Tipo`) VALUES (?, ?, ?, ?, ?)
                //oleDbDataAdapter1.InsertCommand.CommandText = CadenaSQL;
                //oleDbDataAdapter1.InsertCommand.ExecuteNonQuery();

                //oleDbConnection1.Close();

                //Conexion
                //Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName
                //OleDbConnection Conexion = new OleDbConnection();
                //string filename = "|DataDirectory|\\ResourcesBDD.accdb";
                //Conexion.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filename + "; Persist Security Info= false ";

                //crear comando
                //OleDbCommand Comando = Conexion.CreateCommand();
                //Comando.CommandText = CadenaSQL;

                //Ejecutar la consulta de accion
                //Conexion.Open();
                //Comando.ExecuteNonQuery();//ejecutamos la consulta
                //Conexion.Close();
                return true;
            }
            catch (Exception)
            {  
            }
            return false;
        }

        static void loginsBindingSource_AddingNew(object sender, System.ComponentModel.AddingNewEventArgs e)
        {
            DataView dataView = new DataView();
            dataView = (DataView)loginsBindingSource.List;

            DataRowView rowView = dataView.AddNew();

            rowView[0] = tmpAccount.Nombre;
            rowView[1] = tmpAccount.Apellido;
            rowView[2] = tmpAccount.Username;
            rowView[3] = tmpAccount.Password;
            rowView[4] = (int)tmpAccount.TipoUsuario;

            e.NewObject = rowView;
            loginsBindingSource.MoveLast();
        }

        public static void Agregar_Paciente()
        {
            int j;
            //ListaEstudios tmpList = new ListaEstudios(tmpPacientes[0].Estudios);
            bool orden = tmpPacientes[0].OrdenDuradero;

            for (int i = 0; i < tmpPacientes.Count; i++)
            {
                //tmpPacient = new Paciente(tmpList, orden);
                Pacientes.Add(new Paciente(tmpPacientes[i].Estudios, orden, tmpPacientes[i].WhoCreatedMe));
                j = Pacientes.Count - 1;
 
                //Ahora se procesde a organizarles los estudios al paciente por Mas Duradero o Menos Duradero.
                Pacientes[j].Estudios = Pacientes[j].Estudios.ArrangePatientSchedule(Pacientes[j].OrdenDuradero);
 
                //Ahora se procede a agregar los estudios seleccionados de cada paciente a su respectivo horario.
                foreach (Estudio tmpEstudio in Pacientes[j].Estudios)
                {
                    tmpEstudio.IdPaciente = Pacientes[j].P_Id;//Buscamos el id de ese paciente para igualarlo al idpaciente de tmpEstudio.
                    Pacientes[j].Estudios.AddAppointment(tmpEstudio, Pacientes);
                }
            }

            for (int k = Pacientes.Count; k > 0; k--)
            {
                tmpPa.Add(Pacientes[k - 1]);
            }
        }

        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            //aqui se guarda el ultimo Id usado para guardar, la lista de pacientes y la lista de departamentos
            //SavedData Data = new SavedData(Depts,Pacientes,DateTime.Now);
            closeTerminal();
        }

        public static void UpdateDepSchedule()
        {
            foreach (var dept in FrmPrincipal.Depts)
            {
                if (dept.Estudios_En_Cola.Count != 0)
                {
                    dept.Estudios_En_Cola.ArrangeDeptSchedule();
                }
            }
        }
        /// <summary>
        /// Evento que se ejecuta cuando pasa un tick del timer.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerDefault_Tick(object sender, EventArgs e)
        {

            UpdateDepSchedule();
        }

        private void FrmPrincipal_KeyPress(object sender, KeyPressEventArgs e)
        {
        }
   
    }
}
