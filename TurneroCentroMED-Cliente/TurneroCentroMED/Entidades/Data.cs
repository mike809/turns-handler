using System;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;


namespace TurneroCentroMED.Entidades
{
    [Serializable]
    public class Data
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
             /// <summary>
        /// Convierte un objeto tipo ListaPaciente a byte array para poder enviar por la red.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public byte[] ObjectToByteArray()
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
        public static void ByteArrayToObject(byte[] arrBytes)
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
                }
            }
            if (tmpData.Estudios != null)
            {
                FrmPrincipal.EstudiosBDD = tmpData.Estudios;
            }

        }
        #endregion
    }
}
