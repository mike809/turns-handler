using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Communication.Sockets.Core.Server;
using TurneroCentroMED.Conexion;
using TurneroCentroMED.ResourcesBDDDataSetTableAdapters;


namespace TurneroCentroMED.Entidades
{
    [Serializable] public class Data
    {
        #region Propiedades

        public ListaEstudios Estudios { get; set; }
        public ListaDepartamento Departamentos { get; set; }
        public ListaPaciente Pacientes { get; set; }
        //public ListaAccounts _Accounts { get; set; }
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
                    FrmPrincipal.Depts.Clear();
                    FrmPrincipal.Depts = tmpData.Departamentos;
                }
                if (tmpData.Pacientes != null)
                {
                    FrmPrincipal.tmpPacientes.Clear();
                    FrmPrincipal.tmpPacientes = tmpData.Pacientes;
                    FrmPrincipal.Agregar_Paciente();

                    FrmPrincipal.UpdateDepSchedule();
                    FrmPrincipal.DataForClient = new Data(FrmPrincipal.tmpPa, FrmPrincipal.Depts, null, null);
                    ServerTerminal.Broadcast(FrmPrincipal.DataForClient.DataToByteArray());
                    clienteConectado.Send(FrmPrincipal.DataForClient.DataToByteArray());
                }

                if(tmpData.Departamentos == null && tmpData.Estudios == null && tmpData.Pacientes == null && tmpData.AccountToCheck == null)
                {
                    FrmPrincipal.DataForClient = new Data(null, FrmPrincipal.Depts, FrmPrincipal.EstudiosBDD, null);
                    clienteConectado.Send(FrmPrincipal.DataForClient.DataToByteArray());
                }

                if (tmpData.Departamentos == null && tmpData.Estudios == null && tmpData.Pacientes == null && tmpData.AccountToCheck != null)
                {
                    if(tmpData.AccountToCheck.IsLoggedFlag)//para comprobar un login
                    {
                        GetSendLogins(tmpData.AccountToCheck, FrmPrincipal.tmpLoginsGrid);

                        FrmPrincipal.DataForClient = new Data(null, null, null, FrmPrincipal.tmpAccount);
                        clienteConectado.Send(FrmPrincipal.DataForClient.DataToByteArray());
                    }
                    else if (tmpData.AccountToCheck.IsLoggedFlag == false)//para agregar un usuario.
                    {
                        //Se agrega el usuario a la base de datos...
                        if (FrmPrincipal.AgregarNuevoUsuario(tmpData.AccountToCheck))
                        {
                            FrmPrincipal.DataForClient = new Data(null, null, null, null);
                            clienteConectado.Send(FrmPrincipal.DataForClient.DataToByteArray());
                        }
                    }
                    
                }
            }
            catch(Exception e)
            {
            }
        }

        public static void GetSendLogins(Accounts CuentaToCheck, DataGridView tmpLoginsBDD)
        {
            Accounts tmp;

            FrmPrincipal.ListAccounts.Clear();
            FrmPrincipal.ListAccounts.UserPassDictionary.Clear();
            for (int i = 0; i < tmpLoginsBDD.RowCount - 1; i++)
            {
                tmpLoginsBDD.Rows[i].Selected = true;

                //agregamos el user y password al diccionario;
                tmp = new Accounts(tmpLoginsBDD);

                FrmPrincipal.ListAccounts.Add(tmp);
                tmp = null;

                tmpLoginsBDD.Rows[i].Selected = false;
            }
            FrmPrincipal.ListAccounts.CreateDictionaries();//creamos los diccionarios respectivos

            //Aqui verificamos si el usuario que mando el cliente esta en la base de datos
            if (FrmPrincipal.ListAccounts.UserPassDictionary[CuentaToCheck.Username] == CuentaToCheck.Password)
            {
                foreach (Accounts account in FrmPrincipal.ListAccounts)
                {
                    if (account.Username == CuentaToCheck.Username)
                    {
                        FrmPrincipal.tmpAccount = null;
                        FrmPrincipal.tmpAccount = new Accounts(account);
                        break;
                    }
                }

            }
            else
            {
                FrmPrincipal.tmpAccount = null;
            }

            //luego le hacemos un clear nuestra lista de logins.
            FrmPrincipal.ListAccounts.Clear();
        }

        #endregion
    }
}
