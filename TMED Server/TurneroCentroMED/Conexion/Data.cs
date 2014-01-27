using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Communication.Sockets.Core.Server;


namespace TurneroCentroMED.Entidades
{
    [Serializable] public class Data
    {
        #region Propiedades

        public ListaEstudios Estudios { get; set; }
        public ListaDepartamento Departamentos { get; set; }
        public ListaPaciente Pacientes { get; set; }
        #endregion

        #region Constructores
        public Data()
        {
           
        }
        public Data(ListaPaciente pacientes, ListaDepartamento departamento, ListaEstudios estudios)
        {
            Departamentos = departamento;
            Pacientes = pacientes;
            Estudios = estudios;
        }
        #endregion

        #region Metodos

        public byte[] DataToByteArray()
        {
            if (this == null)
                return null;
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
        public static void ByteArrayToData(byte[] arrBytes, ConnectedClient clienteConectado)
        {
            MemoryStream memStream = new MemoryStream();
            BinaryFormatter binForm = new BinaryFormatter();
            memStream.Write(arrBytes, 0, arrBytes.Length);
            memStream.Seek(0, SeekOrigin.Begin);

            FrmPrincipal.DataForClient = null;
            try
            {
                Data tmpData = (Data) binForm.Deserialize(memStream);

                if (tmpData.Departamentos != null)
                {
                    //FrmPrincipal.Depts.Clear();
                    //FrmPrincipal.Depts = tmpData.Departamentos;
                }
                if (tmpData.Pacientes != null)
                {
                    FrmPrincipal.tmpPacientes.Clear();
                    FrmPrincipal.tmpPacientes = tmpData.Pacientes;
                    FrmPrincipal.Agregar_Paciente();

                    FrmPrincipal.UpdateDepSchedule();
                    FrmPrincipal.DataForClient = new Data(FrmPrincipal.tmpPa, FrmPrincipal.Depts, null);
                    ServerTerminal.Broadcast(FrmPrincipal.DataForClient.DataToByteArray());
                    clienteConectado.Send(FrmPrincipal.DataForClient.DataToByteArray());
                }

                if(tmpData.Departamentos == null && tmpData.Estudios == null && tmpData.Pacientes == null)
                {
                    FrmPrincipal.DataForClient = new Data(null, FrmPrincipal.Depts, FrmPrincipal.EstudiosBDD);
                    clienteConectado.Send(FrmPrincipal.DataForClient.DataToByteArray());
                }
            }
            catch(Exception e)
            {
            }
        }

        #endregion
    }
}
