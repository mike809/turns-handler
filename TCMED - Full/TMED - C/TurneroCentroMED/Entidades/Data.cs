using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TurneroCentroMED.Conexion;


namespace TurneroCentroMED.Entidades
{
    [Serializable]
    public class Data
    {
        #region Propiedades

        public ListaEstudios Estudios { get; set; }
        public ListaDepartamento Departamentos { get; set; }
        public ListaPaciente Pacientes { get; set; }
        public Accounts AccountToCheck { get; set; }
        #endregion

        #region Constructores
        public Data()
        {

        }
        public Data(ListaPaciente pacientes, ListaDepartamento departamento, ListaEstudios estudios, Accounts cuenta)
        {
            Departamentos = departamento;
            Pacientes = pacientes;
            Estudios = estudios;
            AccountToCheck = cuenta;
        }
        #endregion

        #region Metodos

             /// <summary>
        /// Convierte un objeto tipo ListaPaciente a byte array para poder enviar por la red.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public byte[] DataToByteArray()
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, this);
            return ms.ToArray();
        }

        /// <summary>
        /// Convierte el arreglo de bytes a ListaDepartamento
        /// </summary>
        /// <param name="arrBytes"></param>
        /// <returns></returns>
        public static void ByteArrayToData(byte[] arrBytes)
        {
            MemoryStream memStream = new MemoryStream();
            BinaryFormatter binForm = new BinaryFormatter();
            memStream.Write(arrBytes, 0, arrBytes.Length);
            memStream.Seek(0, SeekOrigin.Begin);

            Data tmpData = (Data)binForm.Deserialize(memStream);

            if (tmpData.Departamentos != null)
            {
                FrmPrincipal.Depts.Clear();
                FrmPrincipal.Depts = tmpData.Departamentos;   
            }
            if (tmpData.Pacientes != null)
            {
                foreach (Paciente paciente in tmpData.Pacientes)
                {
                    FrmPrincipal.tmpPacientes.Add(paciente);
                    //Si el paciente actual recibido fue uno que fue creado por este cliente, se agrega a
                    //la lista de pacientes del Cliente.
                    AssignPacientFields(paciente);
                }
                FrmPrincipal.Pacientes.UpdatePatients();
            }
            if (tmpData.Estudios != null)
            {
                FrmPrincipal.EstudiosBDD = tmpData.Estudios;
            }

            if (tmpData.AccountToCheck != null)
            {
                //Significa que la cuenta fue correcta.
                Form_Login.WasCorrect = true;
                Form_Login.tmpAccount = tmpData.AccountToCheck;

            }
            if (tmpData.Departamentos == null && tmpData.Estudios == null && tmpData.Pacientes == null && tmpData.AccountToCheck == null)
            {
                //el usuario se creo satisfactoriamente, se le informa al usuario actual.

                Program.UsuarioCreado = true;

            }

        }

        /// <summary>
        /// Asigna los campos con la data del servidor a los pacientes agregados en este cliente.
        /// </summary>
        /// <param name="_paciente"></param>
        public static void AssignPacientFields(Paciente _paciente)
        {
            for (int i = 0; i < FrmPrincipal.Pacientes.Count; i++)
            {
                if ((FrmPrincipal.Pacientes[i].WhoCreatedMe == _paciente.WhoCreatedMe))
                {
                    FrmPrincipal.Pacientes[i].HoraDisponible = _paciente.HoraDisponible;
                    FrmPrincipal.Pacientes[i].Horario = _paciente.Horario;
                    FrmPrincipal.Pacientes[i].Estudios = _paciente.Estudios;
                    FrmPrincipal.Pacientes[i].Ticket_Number = _paciente.Ticket_Number;
                }
            }
        }

        #endregion
    }
}
