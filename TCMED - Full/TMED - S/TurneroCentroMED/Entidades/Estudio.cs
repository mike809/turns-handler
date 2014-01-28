using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TurneroCentroMED.Entidades;

namespace TurneroCentroMED
{
    [Serializable]public class Estudio
    {
        #region Propiedades

        public int EstudioId {get; set;}
        public string EstudioNombre { get; set;}
        public string EstudioDept { get; set; }
        public int EstudioDuracion { get; set; }
        public int IdPaciente { get; set; }
        public int TicketPaciente { get; set; }
        public DateTime Hora_de_turno { get; set; }

        #endregion

        #region Constructores
        public Estudio()
        {
            
        }

        public Estudio(DataGridView Tabla)
        {
            this.EstudioId = Convert.ToInt32(Tabla.SelectedRows[0].Cells[0].Value.ToString());//Id Estudio
            this.EstudioNombre = Tabla.SelectedRows[0].Cells[1].Value.ToString();//Nombre Estudio
            this.EstudioDept = Tabla.SelectedRows[0].Cells[2].Value.ToString();//Departamento
            this.EstudioDuracion = Convert.ToInt32(Tabla.SelectedRows[0].Cells[3].Value.ToString());//Duracion estudio

            //this.EstudioId = Convert.ToInt32(Tabla.CurrentRow.Cells[0].Value.ToString());
        }

        public Estudio(int Estudio_iD, string Estudio_nombre, string Departamento, DateTime Hora_de_Turno, int Persona_ID, int Duracion, int Ticket_Paciente)
        {
            this.EstudioId = Estudio_iD;
            this.EstudioDept = Departamento;
            this.Hora_de_turno = Hora_de_Turno;
            this.IdPaciente = Persona_ID;
            this.EstudioDuracion = Duracion;
            this.EstudioNombre = Estudio_nombre;

            this.TicketPaciente = Ticket_Paciente;
        }
        #endregion
    }

    [Serializable]public class ListaEstudios : List<Estudio>
    {
        #region "Constructores"
        public ListaEstudios()
        {
            
        }

        /// <summary>
        /// Constructor que iguala un estudio.
        /// </summary>
        /// <param name="tmplist"></param>
        public ListaEstudios(ListaEstudios tmplist)
        {
            foreach (Estudio listaEstudio in tmplist)
            {
                this.Add(listaEstudio);
            }
        }
        #endregion

        #region "Metodos & Funciones"

        /// <summary>
        /// Esta funcion te ordena los estudios de el paciente por duracion.
        /// </summary>
        /// <returns></returns>
        public ListaEstudios ArrangePatientSchedule(bool Menor)
        {
            ListaEstudios Temporal = new ListaEstudios();
            int max;
            int indice;

            while (this.Count != 0)
            {
                indice = -1;
                max = 0;

                for (int i = 0; i < this.Count; i++)
                {
                    if (this[i].EstudioDuracion > max)
                    {
                        max = this[i].EstudioDuracion;
                        indice = i;
                    }
                }

                Temporal.Add(this[indice]);
                this.Remove(this[indice]);

                if (this.Count == 1)
                {
                    Temporal.Add(this[0]);
                    this.Remove(this[0]);
                }
            }

            if (Menor)
                Temporal.Reverse();

            return Temporal;
        }

        /// <summary>
        /// Buscaremos ahora un espacio de tiempo en el departamento para el estudio del paciente.
        /// </summary>
        /// <param name="paciente"> </param>
        /// <param name="estudio"> </param>
        private DateTime GetAppointment(Paciente paciente, Estudio estudio)  // This es la cola de estudios del departamento.
        {
            var tmpHe = paciente.HoraDisponible;

            for (int i = 0; i < this.Count; i++)
            {   // La hora de el estudio (i) de la cola de estudios del departamento mas su duracion es mas tarde que la hora que tiene disponible el paciente?

                if (this[i].Hora_de_turno.AddMinutes(this[i].EstudioDuracion) > DateTime.Today.AddHours(18))
                {
                    paciente.HoraDisponible = DateTime.Today.AddDays(1).AddHours(8);
                }
                if (this[i].Hora_de_turno.AddMinutes(this[i].EstudioDuracion).DayOfWeek > DayOfWeek.Friday)
                {
                    paciente.HoraDisponible.AddDays(2);
                }

                tmpHe = paciente.HoraDisponible;

                if (this[i].Hora_de_turno.AddMinutes(this[i].EstudioDuracion) >= paciente.HoraDisponible)  // Si la hora mas la duracion de el estudio en cuestiones igual a mayor que la que deseamos
                {                                                                                   // procedemos a verificar si nuesto estudio cabe entre este que encontramos y el siguiente.
                    if (i < (Count - 1)) // Siempre que no sea el ultimo estudio.
                    {
                        if ((this[i + 1].Hora_de_turno - this[i].Hora_de_turno.AddMinutes(this[i].EstudioDuracion)).TotalMinutes >= estudio.EstudioDuracion)  // Hemos encontrado un espacio para el estudio.
                        {
                            tmpHe = this[i].Hora_de_turno.AddMinutes(this[i].EstudioDuracion);
                            break;
                        }
                    }
                    else
                    {
                        tmpHe = (this[0].Hora_de_turno - DateTime.Now).TotalMinutes >= estudio.EstudioDuracion
                                    ? DateTime.Now
                                    : this[i].Hora_de_turno.AddMinutes(this[i].EstudioDuracion);
                    }
                }
            }

            return tmpHe;
        }

        /// <summary>
        /// Con esta funcion ordenamos el horario del departamento ya que por los saltos de tiempo entre estudios puede uqe la lista no este en el mismo orden que los estudios.
        /// </summary>
        /// <returns></returns>
        public void ArrangeDeptSchedule()
        {
            var temporal = new ListaEstudios();
            int dept;

            if (this.Count != 0)
                dept = FrmPrincipal.DP[this[0].EstudioDept];
            else
                return;

            while (this.Count != 0)
            {
                var indice = 0;
                var max = this[0].Hora_de_turno;

                for (int i = 0; i < this.Count; i++)
                {
                    if (this[i].Hora_de_turno > max)
                    {
                        max = this[i].Hora_de_turno;
                        indice = i;
                    }
                }

                temporal.Add(this[indice]);
                this.Remove(this[indice]);

                if (this.Count == 1)
                {
                    temporal.Add(this[0]);
                    this.Remove(this[0]);
                }
            }

            temporal.Reverse();

            int j;
            for (j = 0; j < temporal.Count;)
            {
                if ((temporal[j].Hora_de_turno.AddMinutes(temporal[j].EstudioDuracion)) < DateTime.Now)
                {
                    temporal.Remove(temporal[j]);         
                }
                else
                    break;
                
            }
           
        FrmPrincipal.Depts[dept].Estudios_En_Cola = temporal;
        }

        /// <summary>
        /// Funcion que se encarga de buscar el iD del paciente.
        /// </summary>
        /// <param name="Id"></param>Id del paciente.
        /// <returns></returns>
        private static int GetPatient(int Id)
        {
            for (int i = 0; i < FrmPrincipal.Pacientes.Count; i++)
            {
                if (FrmPrincipal.Pacientes[i].P_Id == Id)
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Agregaremos la cita del paciente en el determinado departamento.
        /// </summary>
        /// <param name="estudio"></param>
        /// <param name="listaPaciente"></param>
        public void AddAppointment(Estudio estudio, ListaPaciente listaPaciente)
        {
            // Verificamos la hora a la que se desea el estudio.

            if (FrmPrincipal.Pacientes[estudio.IdPaciente].Horario.Count > 0) // Si el horario no esta vacio se procede a buscar la hora que el paciente tiene libre despues de su ultimo estudio. 
            {

                // La hora disponible del paciente es la hora de su ultimo estudio mas la duracion del mismo. 
                FrmPrincipal.Pacientes[estudio.IdPaciente].HoraDisponible =
                    FrmPrincipal.Pacientes[estudio.IdPaciente].Horario[
                        FrmPrincipal.Pacientes[estudio.IdPaciente].Horario.Count - 1].Hora_de_turno.AddMinutes(
                            FrmPrincipal.Pacientes[estudio.IdPaciente].Horario[
                                FrmPrincipal.Pacientes[estudio.IdPaciente].Horario.Count - 1].EstudioDuracion);
               
            }
            else // Si el horario esta vacio se toma la hora actual.
            {
                FrmPrincipal.Pacientes[estudio.IdPaciente].HoraDisponible = DateTime.Now;
            }

            var horaEstudio = FrmPrincipal.Depts[FrmPrincipal.DP[estudio.EstudioDept]].Estudios_En_Cola.GetAppointment(FrmPrincipal.Pacientes[estudio.IdPaciente], estudio);


            FrmPrincipal.Depts[FrmPrincipal.DP[estudio.EstudioDept]].Estudios_En_Cola.Add(new Estudio(estudio.EstudioId, estudio.EstudioNombre, estudio.EstudioDept, horaEstudio,
            FrmPrincipal.Pacientes[estudio.IdPaciente].P_Id, estudio.EstudioDuracion, FrmPrincipal.Pacientes[estudio.IdPaciente].Ticket_Number));

            FrmPrincipal.Pacientes[estudio.IdPaciente].Horario.Add(new Estudio(estudio.EstudioId, estudio.EstudioNombre, estudio.EstudioDept, horaEstudio,
            FrmPrincipal.Pacientes[estudio.IdPaciente].P_Id, estudio.EstudioDuracion, FrmPrincipal.Pacientes[estudio.IdPaciente].Ticket_Number));

            FrmPrincipal.Depts[FrmPrincipal.DP[estudio.EstudioDept]].Estudios_En_Cola.ArrangeDeptSchedule();
        }

        #endregion
    }
}
