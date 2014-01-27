
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;

namespace TurneroCentroMED
{
    [Serializable]public class SavedData
    {
        #region Propiedades
        public ListaPaciente SavedPacientes { get; set; }
        public ListaDepartamento SavedDepts { get; set; }
        public DateTime LastTimeOpened { get; set; }
        #endregion

        #region Contructores
        public SavedData(ListaDepartamento Depts, ListaPaciente Pacientes, DateTime UltimaHora)
        {
            this.SavedPacientes = Pacientes;
            this.SavedDepts = Depts;
            this.LastTimeOpened = UltimaHora;
            SaveCurrentData(this);
        }

        #endregion

        #region Metodos & Funciones
        private static void SaveCurrentData(SavedData Data)
        {
            string filepath = Application.StartupPath + "//Resources//BDD.dat";
            BinaryFormatter formatter = new BinaryFormatter();
            Stream fileS = Stream.Null;
            try
            {
                fileS = new FileStream(filepath, FileMode.Create);
            }
            catch (FileNotFoundException exCeption)
            {
                //Significa que no se encontro el archivo
                fileS = new FileStream(filepath,FileMode.CreateNew);
            }
            finally
            {
                formatter.Serialize(fileS, Data);//enviamos la data.
            }
            
        }
        #endregion
    }
}
