using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Text;
using System.Windows.Forms;
using System.Windows.Input;
using System.Net;
using System.Net.Sockets;
using System.Speech.Synthesis;
using System.Runtime.Serialization.Formatters.Binary;
using Communication.Sockets.Core;
using Communication.Sockets.Core.Client;
using TurneroCentroMED.Entidades;

namespace TurneroCentroMED
{
    public partial class FrmPrincipal : Form
    {
        #region Propiedades
        
        ClientTerminal m_ClientTerminal = new ClientTerminal();
        
        public static DiccionarioDept DP = new DiccionarioDept();
        public static DiccionarioTipoDato DT = new DiccionarioTipoDato();
        ListaEstudios tmpList = new ListaEstudios();
        public static ListaDepartamento Depts = new ListaDepartamento();
        public static ListaPaciente Pacientes = new ListaPaciente();
        public static ListaPaciente tmpPacientes = new ListaPaciente();
        private Estudio tmpEstudio;
        private Paciente tmpPaciente;
        public static ListaEstudios EstudiosBDD { get; set; }
        public Data tmpData = new Data(null,null,null);

        
        delegate void ModificarGrid();

        public static SpeechSynthesizer reader = new SpeechSynthesizer();

        public Socket client { get; set; }
        public const int Puerto = 5656;
        public const string ServerHN = "localhost";//"192.168.1.2";

        public static IPHostEntry ipHostInfo = Dns.GetHostEntry(ServerHN);
        public static IPAddress ipAddress = ipHostInfo.AddressList[1];
        public  IPEndPoint ep = new IPEndPoint(ipAddress, Puerto);

        #endregion
        
        public FrmPrincipal()
        {
            InitializeComponent();
            reader.GetInstalledVoices();
            reader.Volume = 100;

            EstudiosBDD = null;

            InitializeComponent();
            m_ClientTerminal.Connected += IniciarConexion;
            m_ClientTerminal.Disconncted += ConexionCaida;
            m_ClientTerminal.MessageRecived += MensajeRecibido;
            m_ClientTerminal.Connect(ipAddress,Puerto);
               
            FillTableDepts();
            FillPatientList();
            TimerDefault.Start();
            BOTON_Agregar.Enabled = false;
            DUD_OrdenarPor.SelectedItem = DUD_OrdenarPor.Items[0];
            //Pacientes.UpdatePatients();
            reader.SpeakAsync("Welcome to the Durakuzz, Health Care Facility.");
        }

        void ConexionCaida(Socket socket)
        {
            BeginInvoke(new TCPTerminal_DisconnectDel(ConexionCaida), socket);
            return;
        }
        void MensajeRecibido(byte[] bytes)
        {
            Data.ByteArrayToObject(bytes);
        }
        void IniciarConexion(Socket socket)
        {
            m_ClientTerminal.SendMessage(new Data(null,null,null).ObjectToByteArray());
            m_ClientTerminal.StartListen();
        }

        public void ConnectCallback(IAsyncResult ar )
        {
            //Retrieve the socket from the state object.
            Socket client = (Socket) ar.AsyncState;

            //Completamos la conexion
            client.EndConnect(ar);

            //Send(client,Funciones.ObjectToByteArray(tmpData));
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'resourcesBDDDataSet.EstudiosMedicos' table. You can move, or remove it, as needed.
            this.estudiosMedicosTableAdapter.Fill(this.resourcesBDDDataSet.EstudiosMedicos);
            //// TODO: This line of code loads data into the 'resourcesBDDDataSet.RESONANCIA' table. You can move, or remove it, as needed.
            //this.rESONANCIATableAdapter.Fill(this.resourcesBDDDataSet.RESONANCIA);
            //// TODO: This line of code loads data into the 'resourcesBDDDataSet.TOMOGRAFIA' table. You can move, or remove it, as needed.
            //this.tOMOGRAFIATableAdapter.Fill(this.resourcesBDDDataSet.TOMOGRAFIA);
            //// TODO: This line of code loads data into the 'resourcesBDDDataSet.SONOGRAFIA' table. You can move, or remove it, as needed.
            //this.sONOGRAFIATableAdapter.Fill(this.resourcesBDDDataSet.SONOGRAFIA);
            //// TODO: This line of code loads data into the 'resourcesBDDDataSet.RAYO_X' table. You can move, or remove it, as needed.
            //this.rAYO_XTableAdapter.Fill(this.resourcesBDDDataSet.RAYO_X);
            // TODO: This line of code loads data into the 'resourcesBDDDataSet.EstudiosMedicos' table. You can move, or remove it, as needed.
            this.estudiosMedicosTableAdapter.Fill(this.resourcesBDDDataSet.EstudiosMedicos);
            
           // FillEstudiosBDD();
        }

        private void BOTON_AgregarEstudios_Click(object sender, EventArgs e)
        {
            //Aqui se va agregando los estudios mientras les voy dando a agregar estudios
            tmpEstudio = new Estudio(DATAGRID_Estudios);

            //Primero antes que nada hay que ver que no haya un estudio agregado dos veces...
            if(!Funciones.CheckIfAlreadyAdded(tmpEstudio, tmpList) && tmpList.Count <= 9)
            {
                tmpList.Add(new Estudio(DATAGRID_Estudios));
                LISTBOX_EstudiosSeleccionados.Items.Add(tmpEstudio.EstudioNombre);
            }

            BOTON_Agregar.Enabled = true;
            //Ya que agrego los estudios procedo a agregarlo a la lista de estudios seleccionados...
            LISTBOX_EstudiosSeleccionados.Show();
        }

        private void BOTON_Agregar_Click(object sender, EventArgs e)
        {
            //reader.SpeakAsync("You have just added a patient.");
            int orden = DUD_OrdenarPor.SelectedIndex;//True:Menos Duradero , False: Mas Duradero
            for (int i = 0; i < NUD_CantPacientes.Value; i++)
            {
                tmpPaciente = new Paciente(new ListaEstudios(tmpList), orden == 0 ? true : false);
                tmpPacientes.Add(tmpPaciente);
                tmpPaciente = null;       
            }
            
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            tmpData = new Data(tmpPacientes, null, null);
            client.BeginConnect(ep, new AsyncCallback(ConnectCallback), client);
            //WaitCallback sWaitCallback = new WaitCallback();
            Clean();
            //Ahora procedemos a mostrar cada cita de cada departamento en el RIGHT PANEL.
            FillTableDepts();
            FillPatientList();

        }

        private void BOTON_RemoveSelected_Click(object sender, EventArgs e)
        {
            //Borra un estudio de la lista, cuando ya esta seleccionado.
            int indice = LISTBOX_EstudiosSeleccionados.SelectedIndex;
            //procedemos a borrar ese estudio de la lista
            if (indice > 0)
            {
                LISTBOX_EstudiosSeleccionados.Items.Clear();
                if (tmpList.Count > 1)
                {
                    tmpList.Remove(tmpList[indice]);

                    //Agregamos los nuevos seleccionados.
                    for(int i = 0; i < tmpList.Count; i++)
                    {
                        tmpEstudio = tmpList[i];
                        LISTBOX_EstudiosSeleccionados.Items.Add(tmpEstudio.EstudioNombre);
                    }
                    LISTBOX_EstudiosSeleccionados.Show();
                }
            }
            else
            {
                //significa que solamente tenia un estudio seleccionado, por ende le hacemos un clear.
                LISTBOX_EstudiosSeleccionados.Items.Clear();
                tmpList.Clear();
                BOTON_Agregar.Enabled = false;
            }
            
        }

        private void CONTROLBOX_Estudios_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13 )//Si presiono enter
            {
                BOTON_AgregarEstudios.PerformClick();
            }
        }

        private void LISTBOX_EstudiosSeleccionados_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)//Si presiono enter
            {
                BOTON_RemoveSelected.PerformClick();
            }
        }

        private void BOTON_EliminarTodos_Click(object sender, EventArgs e)
        {
            if (LISTBOX_EstudiosSeleccionados.Items.Count > 0)
            {
                LISTBOX_EstudiosSeleccionados.Items.Clear();
                tmpList.Clear();
                LISTBOX_EstudiosSeleccionados.Show();
                BOTON_Agregar.Enabled = false;
            }
        }

        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            //aqui se guarda el ultimo Id usado para guardar, la lista de pacientes y la lista de departamentos
            //SavedData Data = new SavedData(Depts,Pacientes,DateTime.Now);
        }

        public void Clean()
        {
            ModificarGrid modificartmp = Clean;
            if(BOTON_Agregar.InvokeRequired)
            {  
                BOTON_Agregar.Invoke(modificartmp);
                return;
            }

            BOTON_Agregar.Enabled = false;

            if(LISTBOX_EstudiosSeleccionados.InvokeRequired)
            {
                LISTBOX_EstudiosSeleccionados.Invoke(modificartmp);
                return;
            }

            LISTBOX_EstudiosSeleccionados.Items.Clear();
            
            tmpList.Clear();
            tmpPacientes.Clear();
            DUD_OrdenarPor.SelectedItem = DUD_OrdenarPor.Items[0];

            FillTableDepts();
            FillPatientList();
        }

        private void UpdateDepSchedule()
        {
            foreach (var dept in FrmPrincipal.Depts)
            {
                if (dept.Estudios_En_Cola.Count != 0)
                {
                    dept.Estudios_En_Cola.ArrangeDeptSchedule();
                }
            }
            FillTableDepts();
            Pacientes.UpdatePatients();
     
        }

        /// <summary>
        /// Se encarga de llenar los datagrid de los pacientes. 
        /// </summary>
        public void FillTableDepts()
        {
            ModificarGrid modificatmp = FillTableDepts;

            if(DATAGRID_RAYOX.InvokeRequired)
            {
                DATAGRID_RAYOX.Invoke(modificatmp);
                return;
            }
            DATAGRID_RAYOX.DataSource = null;
            DATAGRID_RAYOX.DataSource = FrmPrincipal.Depts[FrmPrincipal.DP["RAYO X"]].Estudios_En_Cola;
            DATAGRID_RAYOX.Columns[0].Width = 50;
            DATAGRID_RAYOX.Columns[0].HeaderText = "Id";
            DATAGRID_RAYOX.Columns[0].ToolTipText = "Id del estudio actual.";
            DATAGRID_RAYOX.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DATAGRID_RAYOX.Columns[1].HeaderText = "Nombre de Estudio";
            DATAGRID_RAYOX.Columns[2].Visible = false;
            DATAGRID_RAYOX.Columns[3].Width = 60;
            DATAGRID_RAYOX.Columns[3].HeaderText = "Duracion";
            DATAGRID_RAYOX.Columns[3].ToolTipText = "Duracion del estudio. (Minutos)";
            DATAGRID_RAYOX.Columns[4].Visible = false;
            DATAGRID_RAYOX.Columns[5].HeaderText = "Ticket #";
            DATAGRID_RAYOX.Columns[5].ToolTipText = "Numero de ticket del turno del paciente.";
            DATAGRID_RAYOX.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DATAGRID_RAYOX.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DATAGRID_RAYOX.Columns[6].HeaderText = "Hora Cita";
            DATAGRID_RAYOX.Columns[6].ToolTipText = "Hora que le toca dicho estudio al paciente.";
            DATAGRID_RAYOX.Show();
           

            if (DATAGRID_Resonancia.InvokeRequired)
            {
                DATAGRID_Resonancia.Invoke(modificatmp);
                return;
            }
            DATAGRID_Resonancia.DataSource = null;
            DATAGRID_Resonancia.DataSource = FrmPrincipal.Depts[FrmPrincipal.DP["RESONANCIA"]].Estudios_En_Cola;

            DATAGRID_Resonancia.Columns[0].Width = 50;
            DATAGRID_Resonancia.Columns[0].HeaderText = "Id";
            DATAGRID_Resonancia.Columns[0].ToolTipText = "Id del estudio actual.";
            DATAGRID_Resonancia.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DATAGRID_Resonancia.Columns[1].HeaderText = "Nombre de Estudio";
            DATAGRID_Resonancia.Columns[2].Visible = false;
            DATAGRID_Resonancia.Columns[3].Width = 60;
            DATAGRID_Resonancia.Columns[3].HeaderText = "Duracion";
            DATAGRID_Resonancia.Columns[3].ToolTipText = "Duracion del estudio. (Minutos)";
            DATAGRID_Resonancia.Columns[4].Visible = false;
            DATAGRID_Resonancia.Columns[5].HeaderText = "Ticket #";
            DATAGRID_Resonancia.Columns[5].ToolTipText = "Numero de ticket del turno del paciente.";
            DATAGRID_Resonancia.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DATAGRID_Resonancia.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DATAGRID_Resonancia.Columns[6].HeaderText = "Hora Cita";
            DATAGRID_Resonancia.Columns[6].ToolTipText = "Hora que le toca dicho estudio al paciente.";
            DATAGRID_Resonancia.Show();
            

            if (DATAGRID_Sonografia.InvokeRequired)
            {
                DATAGRID_Sonografia.Invoke(modificatmp);
                return;
            }
            DATAGRID_Sonografia.DataSource = null;
            DATAGRID_Sonografia.DataSource = FrmPrincipal.Depts[FrmPrincipal.DP["SONOGRAFIA"]].Estudios_En_Cola;
            DATAGRID_Sonografia.Columns[0].Width = 50;
            DATAGRID_Sonografia.Columns[0].HeaderText = "Id";
            DATAGRID_Sonografia.Columns[0].ToolTipText = "Id del estudio actual.";
            DATAGRID_Sonografia.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DATAGRID_Sonografia.Columns[1].HeaderText = "Nombre de Estudio";
            DATAGRID_Sonografia.Columns[2].Visible = false;
            DATAGRID_Sonografia.Columns[3].Width = 60;
            DATAGRID_Sonografia.Columns[3].HeaderText = "Duracion";
            DATAGRID_Sonografia.Columns[3].ToolTipText = "Duracion del estudio. (Minutos)";
            DATAGRID_Sonografia.Columns[4].Visible = false;
            DATAGRID_Sonografia.Columns[5].HeaderText = "Ticket #";
            DATAGRID_Sonografia.Columns[5].ToolTipText = "Numero de ticket del turno del paciente.";
            DATAGRID_Sonografia.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DATAGRID_Sonografia.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DATAGRID_Sonografia.Columns[6].HeaderText = "Hora Cita";
            DATAGRID_Sonografia.Columns[6].ToolTipText = "Hora que le toca dicho estudio al paciente.";
            DATAGRID_Sonografia.Show();
            

            if (DATAGRID_Tomografia.InvokeRequired)
            {
                DATAGRID_Tomografia.Invoke(modificatmp);
                return;
            }
            DATAGRID_Tomografia.DataSource = null;
            DATAGRID_Tomografia.DataSource = FrmPrincipal.Depts[FrmPrincipal.DP["TOMOGRAFIA"]].Estudios_En_Cola;
            DATAGRID_Tomografia.Columns[0].Width = 50;
            DATAGRID_Tomografia.Columns[0].HeaderText = "Id";
            DATAGRID_Tomografia.Columns[0].ToolTipText = "Id del estudio actual.";
            DATAGRID_Tomografia.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DATAGRID_Tomografia.Columns[1].HeaderText = "Nombre de Estudio";
            DATAGRID_Tomografia.Columns[2].Visible = false;
            DATAGRID_Tomografia.Columns[3].Width = 60;
            DATAGRID_Tomografia.Columns[3].HeaderText = "Duracion";
            DATAGRID_Tomografia.Columns[3].ToolTipText = "Duracion del estudio. (Minutos)";
            DATAGRID_Tomografia.Columns[4].Visible = false;
            DATAGRID_Tomografia.Columns[5].HeaderText = "Ticket #";
            DATAGRID_Tomografia.Columns[5].ToolTipText = "Numero de ticket del turno del paciente.";
            DATAGRID_Tomografia.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DATAGRID_Tomografia.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DATAGRID_Tomografia.Columns[6].HeaderText = "Hora Cita";
            DATAGRID_Tomografia.Columns[6].ToolTipText = "Hora que le toca dicho estudio al paciente.";
            DATAGRID_Tomografia.Show();
        }

        /// <summary>
        /// Se encarga de llenar el datagrid de listas de pacientes
        /// </summary>
        public void FillPatientList()
        {
            /*
             * 0 - Patient Id
             * 1 - Orden Duradero
             * 2 - Hora Estudio
             */
            ModificarGrid modificartmp = FillPatientList;

            if(DATAGRID_PacientesActuales.InvokeRequired)
            {
                DATAGRID_PacientesActuales.Invoke(modificartmp);
                return;
            }

            DATAGRID_PacientesActuales.DataSource = null;
            try
            {
                DATAGRID_PacientesActuales.DataSource = tmpPacientes;// Pacientes;

                DATAGRID_PacientesActuales.Columns[3].HeaderText = "Ticket Paciente";
                DATAGRID_PacientesActuales.Columns[3].ToolTipText = "Numero de ticket de el paciente (Turno).";
                DATAGRID_PacientesActuales.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                DATAGRID_PacientesActuales.Columns[0].Visible = false;
                DATAGRID_PacientesActuales.Columns[1].Visible = false;
                DATAGRID_PacientesActuales.Columns[2].Visible = false;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                DATAGRID_PacientesActuales.DataSource = null;
            }
            
        }

        /// <summary>
        /// Se encarga de llenar los estudios del paciente seleccionado.
        /// </summary>
        /// <param name="indice"></param>
        public void FillSelectedPatientStudies(int indice)
        {
            //se encarga de llenar la tabla de estudio del paciente seleccionado.
            /*
             * 0 - Estudio Id
             * 1 - Estudio Nombre
             * 2 - Estudio Dept(not visible)
             * 3 - Estudio Duracion
             * 4 - Id Paciente
             * 5 - Ticket Number
             * 6 - Hora turno
             */

            DATAGRID_SelectedPatient.DataSource = null;
            try
            {
                DATAGRID_SelectedPatient.DataSource = tmpPacientes[indice].Horario;// Pacientes[indice].Horario;
                DATAGRID_SelectedPatient.Columns[0].Visible = false;
                DATAGRID_SelectedPatient.Columns[1].HeaderText = "Estudio";
                DATAGRID_SelectedPatient.Columns[1].ToolTipText = "Nombre del estudio.";
                DATAGRID_SelectedPatient.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                DATAGRID_SelectedPatient.Columns[2].Visible = false;
                DATAGRID_SelectedPatient.Columns[3].Visible = false;
                DATAGRID_SelectedPatient.Columns[4].Visible = false;
                DATAGRID_SelectedPatient.Columns[5].Visible = false;
                DATAGRID_SelectedPatient.Columns[6].HeaderText = "Hora";
                DATAGRID_SelectedPatient.Columns[6].ToolTipText = "Hora que toca dicho estudio.";
                DATAGRID_SelectedPatient.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                DATAGRID_SelectedPatient.Show();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                DATAGRID_SelectedPatient.DataSource = null;
            }           
        }

        /// <summary>
        /// Evento que se ejecuta cuando pasa un tick del timer.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerDefault_Tick(object sender, EventArgs e)
        {
            //FillEstudiosBDD();
            reader.SpeakAsync("Timer has been shot.");
            UpdateDepSchedule();
            FillPatientList();
        }

        /// <summary>
        /// Evento que se ejecuta cuando se selecciona un paciente diferente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DATAGRID_PacientesActuales_SelectionChanged(object sender, EventArgs e)
        {
            int indice;
            if (DATAGRID_PacientesActuales.DataSource != null)
            {
                indice = DATAGRID_PacientesActuales.CurrentCell.RowIndex;
                FillSelectedPatientStudies(indice);
            }
            else
            {
                DATAGRID_SelectedPatient.DataSource = null;
            }
        }

        private void tabControl1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if ((Keyboard.GetKeyStates(Key.F5) & KeyStates.Down) > 0)//Si presiono F5
            //{
            //    TimerDefault.Tick += new EventHandler(TimerDefault_Tick);
            //}
        }

        private void FrmPrincipal_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        public void FillEstudiosBDD()
        {
            DATAGRID_Estudios.DataSource = EstudiosBDD;
            CONTROLBOX_Estudios.DataSource = EstudiosBDD;

            CONTROLBOX_Estudios.DisplayMember = "EstudioNombre";
            CONTROLBOX_Estudios.ValueMember = "EstudioNombre";

            CONTROLBOX_Estudios.Show();
            DATAGRID_Estudios.Show();
        }
    }
}
