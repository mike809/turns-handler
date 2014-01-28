using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace TurneroCentroMED.Entidades
{
    static class Funciones
    {
        #region BaseDeDatos

        /// <summary>
        /// Funcion que se encarga de buscar el SavedData.
        /// </summary>
        public static void GetSavedData()
        {
            string filepath = Application.StartupPath + "\\Resources\\BDD.dat";
            try
            {
                FileStream fileStream = new FileStream(filepath, FileMode.Open, FileAccess.Read);
                BinaryFormatter formatter = new BinaryFormatter();

                SavedData tData = (SavedData)formatter.Deserialize(fileStream);

                FrmPrincipal.Depts = tData.SavedDepts;
                FrmPrincipal.Pacientes = tData.SavedPacientes;
                Paciente.SetId();//Buscamos el ultimo Id Usado para almacenar un paciente..
            }
            catch (FileNotFoundException e)
            {
                //Significa que no se encontro el archivo para buscar la data.
                //En este caso no se hace nada.
                Paciente.iD_Setter = 1;
                Paciente.T_Num = 1;
            }
            catch(SerializationException )
            {
                //Significa que hubo un error en deserializacion del archivo binario.
                //No se pudo leer,porque no hubo nada.
                Paciente.iD_Setter = 1;
                Paciente.T_Num = 1;
            }
        }

        #endregion

        #region Estudios

        /// <summary>
        /// Esta Funcion se encarga de chequear si un estudio ya fue seleccionado previamente.
        /// </summary>
        /// <returns></returns>
        public static bool CheckIfAlreadyAdded(Estudio tmpEstudio, ListaEstudios Estudios)
        {
            for (int i = 0; i < Estudios.Count; i++)
            {
                if (tmpEstudio.EstudioId == Estudios[i].EstudioId)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion
    }
}
