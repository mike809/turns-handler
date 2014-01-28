using System;
using System.Collections.Generic;
using System.Windows.Forms;

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
        /// Buscaremos ahora un espacio de tiempo en el departamento para el estudio del paciente.
        /// </summary>
        /// <param name="paciente"> </param>
        /// <param name="estudio"> </param>
        private DateTime GetAppointment(Paciente paciente, Estudio estudio)  // This es la cola de estudios del departamento.
        {
            var tmpHe = paciente.HoraDisponible;
            var i = 0;

            for (i = 0; i < this.Count; i++)
            {   // La hora de el estudio (i) de la cola de estudios del departamento mas su duracion es mas tarde que la hora que tiene disponible el paciente?

                if (this[i].Hora_de_turno.AddMinutes(this[i].EstudioDuracion) >= paciente.HoraDisponible)  // Si la hora mas la duracion de el estudio en cuestiones igual a mayor que la que deseamos
                {                                                                                  // procedemos a verificar si nuesto estudio cabe entre este que encontramos y el siguiente.
                    if (i < (this.Count - 1)) // Siempre que no sea el ultimo estudio.
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
                    if (FrmPrincipal.SoundOnOff)
                        FrmPrincipal.reader.SpeakAsync(
                            string.Format("Patient with the ticket number {0}, please go to the department of {1}",
                                                     temporal[j + 1].TicketPaciente, temporal[j + 1].EstudioDept));
                    temporal.Remove(temporal[j]);
                }   
                else
                    break;
            }
            
            FrmPrincipal.Depts[dept].Estudios_En_Cola = temporal;
        }

        #endregion
    }
}
