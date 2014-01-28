using System;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Speech.Synthesis;
using Communication.Sockets.Core;
using Communication.Sockets.Core.Client;
using TurneroCentroMED.Conexion;
using TurneroCentroMED.Entidades;

namespace TurneroCentroMED
{
    public partial class FrmPrincipal : Form
    {
        #region Propiedades

        public static DiccionarioDept DP = new DiccionarioDept();
        public int Succeded;
        public ListaEstudios tmpList = new ListaEstudios();
        public static ListaDepartamento Depts = new ListaDepartamento();
        public static ListaPaciente Pacientes = new ListaPaciente();
        public static ListaPaciente tmpPacientes = new ListaPaciente();
        private Estudio tmpEstudio;
        private Paciente tmpPaciente;
        public static ListaEstudios EstudiosBDD { get; set; }
        public const int Puerto = 5656;
       
        delegate void ModificarGrid();

        public static ClientTerminal m_ClientTerminal = new ClientTerminal();
        public static SpeechSynthesizer reader = new SpeechSynthesizer();

        private PrintDialog MyPrintDialog;
        public static bool SoundOnOff = true;
        #endregion

        public FrmPrincipal(Accounts Usuario)
        {
            InitializeComponent();
            reader.GetInstalledVoices();
            reader.Volume = 100;
            EstudiosBDD = null;
            //m_ClientTerminal = Cliente;
            Depts = new ListaDepartamento();

            m_ClientTerminal.Connected += IniciarConexion;
            m_ClientTerminal.Disconncted += ConexionCaida;
            m_ClientTerminal.MessageRecived += MensajeRecibido;
            m_ClientTerminal.Connect(Program.ipAddress, Puerto);

            do
            {
                Succeded = 0;
                try
                {
                    FillTableDepts();
                    FillPatientList();
                    FillEstudiosBDD();
                    FillControlBox();
                }

                catch (Exception)
                {
                }

            } while (Succeded < 4);


            TimerDefault.Start();
            BOTON_Agregar.Enabled = false;
            DUD_OrdenarPor.SelectedItem = DUD_OrdenarPor.Items[0];
            
            if(SoundOnOff)
                reader.SpeakAsync("Welcome back" + Usuario.Nombre + " Like a Boss!");
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
            UpdateDepSchedule();
        }

        void IniciarConexion(Socket socket)
        {
            m_ClientTerminal.SendMessage(new Data(null, null, null, null).DataToByteArray());
            m_ClientTerminal.StartListen();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            FillEstudiosBDD();
            FillControlBox();
            UpdateDepSchedule();
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
            tmpPacientes.Clear();
            for (int i = 0; i < NUD_CantPacientes.Value; i++)
            {
                tmpPaciente = new Paciente(new ListaEstudios(tmpList), orden == 0 ? true : false);

                tmpPacientes.Add(tmpPaciente);
                Pacientes.Add(tmpPaciente);
                tmpPaciente = null;       
            }
            Pacientes.AbleToUpdate = false;
            //Mandamos tmpPacientes al servidor para que agregue los nuevos pacientes.
            Data tmpData = new Data(tmpPacientes, null, null,null);

            m_ClientTerminal.SendMessage(tmpData.DataToByteArray());

            Pacientes.AbleToUpdate = true; 
  
            Clean();
            //Ahora procedemos a mostrar cada cita de cada departamento en el RIGHT PANEL.
            do
            {
                Succeded = 0;
                try
                {
                    FillTableDepts();
                    FillPatientList();
                }
                catch (Exception)
                {
                }
            } while (Succeded < 2);
            
            
            UpdateDepSchedule();
            
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
            m_ClientTerminal.Close();
            //aqui se guarda el ultimo Id usado para guardar, la lista de pacientes y la lista de departamentos
            //SavedData Data = new SavedData(Depts,Pacientes,DateTime.Now);
        }

        private void Clean()
        {
            BOTON_Agregar.Enabled = false;
            LISTBOX_EstudiosSeleccionados.Items.Clear();
            tmpList.Clear();
            tmpPacientes.Clear();
            DUD_OrdenarPor.SelectedItem = DUD_OrdenarPor.Items[0];
        }

        public void UpdateDepSchedule()
        {
            foreach (var dept in FrmPrincipal.Depts)
            {
                if (dept.Estudios_En_Cola.Count != 0)
                {
                    dept.Estudios_En_Cola.ArrangeDeptSchedule();
                }
            }

            FillTableDepts();
            if (Pacientes.AbleToUpdate)//Si tiene la opcion de poder actualizarse, se actualizara. esto lo puse para
            {                          //que el tick del cliente no haga un toyo si le toca el tick mientras hay un Send-Receive.
                Pacientes.UpdatePatients();
            }
        }

        /// <summary>
        /// Se encarga de llenar los datagrid de los pacientes. 
        /// </summary>
        public void FillTableDepts()
        {
            if (DATAGRID_RAYOX.InvokeRequired)
            {
                ModificarGrid Modificar = FillTableDepts;
                DATAGRID_RAYOX.Invoke(Modificar);
                return;
            }
            if (DATAGRID_Resonancia.InvokeRequired)
            {
                ModificarGrid Modificar = FillTableDepts;
                DATAGRID_Resonancia.Invoke(Modificar);
                return;
            }
            if (DATAGRID_Sonografia.InvokeRequired)
            {
                ModificarGrid Modificar = FillTableDepts;
                DATAGRID_Sonografia.Invoke(Modificar);
                return;
            }
            if (DATAGRID_Tomografia.InvokeRequired)
            {
                ModificarGrid Modificar = FillTableDepts;
                DATAGRID_Tomografia.Invoke(Modificar);
                return;
            }
            DATAGRID_RAYOX.DataSource = null;
            DATAGRID_Resonancia.DataSource = null;
            DATAGRID_Sonografia.DataSource = null;
            DATAGRID_Tomografia.DataSource = null;

            DATAGRID_RAYOX.DataSource = FrmPrincipal.Depts[FrmPrincipal.DP["RAYO X"]].Estudios_En_Cola;
            DATAGRID_Resonancia.DataSource = FrmPrincipal.Depts[FrmPrincipal.DP["RESONANCIA"]].Estudios_En_Cola;
            DATAGRID_Sonografia.DataSource = FrmPrincipal.Depts[FrmPrincipal.DP["SONOGRAFIA"]].Estudios_En_Cola;
            DATAGRID_Tomografia.DataSource = FrmPrincipal.Depts[FrmPrincipal.DP["TOMOGRAFIA"]].Estudios_En_Cola;

            //Ya que agregamos los departamentos en los datagrids, procedemos a organizarlo.
            /*
             * 0 - Estudio Id
             * 1 - Estudio Nombre
             * 2 - Estudio Dept(not visible)
             * 3 - Estudio Duracion
             * 4 - Id Paciente
             * 5 - Ticket Paciente
             * 6 - Hora turno
             */
         
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

            Succeded++;
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
            DATAGRID_PacientesActuales.DataSource = null;
           
            DATAGRID_PacientesActuales.DataSource = Pacientes;

            DATAGRID_PacientesActuales.Columns[3].HeaderText = "Ticket Paciente";
            DATAGRID_PacientesActuales.Columns[3].ToolTipText = "Numero de ticket de el paciente (Turno).";
            DATAGRID_PacientesActuales.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DATAGRID_PacientesActuales.Columns[0].Visible = false;
            DATAGRID_PacientesActuales.Columns[1].Visible = false;
            DATAGRID_PacientesActuales.Columns[2].Visible = false;

            DATAGRID_PacientesActuales.Show();
        
            Succeded++;
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
                DATAGRID_SelectedPatient.DataSource = Pacientes[indice].Horario;// Pacientes[indice].Horario;
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
            UpdateDepSchedule();
            
            do
            {
                Succeded = 0;
                try
                {
                    FillPatientList();
                }
                catch (Exception)
                {
                }

            } while (Succeded < 1);
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
            if(DATAGRID_Estudios.InvokeRequired)
            {
                ModificarGrid Modificar = FillEstudiosBDD;
                DATAGRID_Estudios.Invoke(Modificar);
                return;
            }
            /*
             * 0 - Estudio Id
             * 1 - Estudio Nombre
             * 2 - Estudio Dept(not visible)
             * 3 - Estudio Duracion
             * */

            DATAGRID_Estudios.DataSource = EstudiosBDD;
            DATAGRID_Estudios.Columns[0].Width = 50;
            DATAGRID_Estudios.Columns[0].HeaderText = "Id";
            DATAGRID_Estudios.Columns[1].HeaderText = "Nombre";
            DATAGRID_Estudios.Columns[1].ToolTipText = "Nombre del estudio.";
            DATAGRID_Estudios.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DATAGRID_Estudios.Columns[2].HeaderText = "Departamento";
            DATAGRID_Estudios.Columns[2].ToolTipText = "Departamento al cual pertenece dicho estudio.";
            DATAGRID_Estudios.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DATAGRID_Estudios.Columns[3].Width = 60;
            DATAGRID_Estudios.Columns[3].HeaderText = "Duracion";
            DATAGRID_Estudios.Columns[3].ToolTipText = "Duracion del estudio en minutos.";
            DATAGRID_Estudios.Columns[4].Visible = false;//IdPaciente
            DATAGRID_Estudios.Columns[5].Visible = false;//TicketPaciente
            DATAGRID_Estudios.Columns[6].Visible = false;//HoraDeTurno
            DATAGRID_Estudios.Show();

            Succeded++;
        }

        public void FillControlBox()
        {
            if (CONTROLBOX_Estudios.InvokeRequired)
            {
                ModificarGrid Modificar = FillEstudiosBDD;
                CONTROLBOX_Estudios.Invoke(Modificar);
                return;
            }

            CONTROLBOX_Estudios.DataSource = EstudiosBDD;
            CONTROLBOX_Estudios.DisplayMember = "EstudioNombre";
            CONTROLBOX_Estudios.ValueMember = "EstudioNombre";
            CONTROLBOX_Estudios.Show();

            Succeded++;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Opt_About About = new Form_Opt_About();
            About.Show();
        }

        private void imprimirEstudiosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int indice = DATAGRID_PacientesActuales.CurrentCell.RowIndex;

            //Al RichTextBox que tenemos invisible pondremos los estudios del paciente seleccionado
            RTB_ImprimirEn.AppendText("Paciente " + Pacientes[indice].Ticket_Number + ", tiene " + Pacientes[indice].Estudios.Count + "estudios.\n\n");
            RTB_ImprimirEn.AppendText("NOMBRE ESTUDIO\tDEPARTAMENTO\tDURACION\tHORA CITA\n\n");
            for (int i = 0; i < Pacientes[indice].Estudios.Count ; i++)
            {
                RTB_ImprimirEn.AppendText(Pacientes[indice].Estudios[i].EstudioNombre + "\t" + Pacientes[indice].Estudios[i].EstudioDept + "\t" + Pacientes[indice].Estudios[i].EstudioDuracion + "\t" + Pacientes[indice].Estudios[i].Hora_de_turno + "\n");
            }


            //Aqui se imprimira los estudios del paciente seleccionado.
            MyPrintDialog = new PrintDialog();

            MyPrintDialog.AllowSomePages = true;
            MyPrintDialog.AllowSelection = true;
            MyPrintDialog.Document = PacienteImprimir;

            if (MyPrintDialog.ShowDialog() == DialogResult.OK)
            {
                StringReader reader = new StringReader(RTB_ImprimirEn.Text);
                PacienteImprimir.PrintPage += new PrintPageEventHandler(PacienteImprimir_PrintPage);
                PacienteImprimir.Print();
            }
        }

        private void PacienteImprimir_PrintPage(object sender, PrintPageEventArgs e)
        {
            StringReader reader = new StringReader(RTB_ImprimirEn.Text);
            float LinesPerPage = 0;
            float YPosition = 0;
            int Count = 0;
            float LeftMargin = e.MarginBounds.Left;
            float TopMargin = e.MarginBounds.Top;
            string Line = null;
            Font PrintFont = this.RTB_ImprimirEn.Font;
            SolidBrush PrintBrush = new SolidBrush(Color.Black);

            LinesPerPage = e.MarginBounds.Height / PrintFont.GetHeight(e.Graphics);

            while (Count < LinesPerPage && ((Line = reader.ReadLine()) != null))
            {
                YPosition = TopMargin + (Count * PrintFont.GetHeight(e.Graphics));
                e.Graphics.DrawString(Line, PrintFont, PrintBrush, LeftMargin, YPosition, new StringFormat());
                Count++;
            }

            if (Line != null)
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
            }
            PrintBrush.Dispose();
        }

        private void BOTON_SoundOnOFF_Click(object sender, EventArgs e)
        {
            if (BOTON_SoundOnOFF.ImageIndex == 0)
            {
                BOTON_SoundOnOFF.ImageIndex = 1;
                BOTON_SoundOnOFF.Text = "Sound: OFF";
                SoundOnOff = false;
            }
            else
            {
                BOTON_SoundOnOFF.ImageIndex = 0;
                BOTON_SoundOnOFF.Text = "Sound: ON";
                SoundOnOff = true;
            }
            
        }

        private void createNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_CreateNewUser Frm_NewUser = new Form_CreateNewUser();
            Frm_NewUser.Show();
        }
    }
}
