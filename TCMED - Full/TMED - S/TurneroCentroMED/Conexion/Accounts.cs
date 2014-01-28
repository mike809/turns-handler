using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TurneroCentroMED.Conexion
{
    #region Login

    public enum eTipoUser
    {
        Cajero = 0,
        DeptRayoX = 1,
        DeptRes = 2,
        DeptTomo = 3,
        DeptSono = 4,
        Admin = 5,
        Developer = 6
    }

    #endregion

    [Serializable]
    public class Accounts
    {
        #region Propiedades

        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsLoggedFlag { get; set; }
        public eTipoUser TipoUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        #endregion

        #region Constructores

        public Accounts()
        {

        }

        public Accounts(Accounts cuenta)
        {
            this.Nombre = cuenta.Nombre;
            this.Apellido = cuenta.Apellido;
            this.Username = cuenta.Username;
            this.Password = cuenta.Password;
            this.TipoUsuario = cuenta.TipoUsuario;
        }

        public Accounts(DataGridView tabla)
        {
            //DATAGRID_logins.SelectedRows[0].Cells[1].Value.ToString(); Nombre
            //DATAGRID_logins.SelectedRows[0].Cells[2].Value.ToString(); Apellido
            //DATAGRID_logins.SelectedRows[0].Cells[3].Value.ToString(); Username
            //DATAGRID_logins.SelectedRows[0].Cells[4].Value.ToString(); Password
            //DATAGRID_logins.SelectedRows[0].Cells[5].Value.ToString(); Tipo

            this.Nombre = tabla.SelectedRows[0].Cells[0].Value.ToString();
            this.Apellido = tabla.SelectedRows[0].Cells[1].Value.ToString();
            this.Username = tabla.SelectedRows[0].Cells[2].Value.ToString();
            this.Password = tabla.SelectedRows[0].Cells[3].Value.ToString();
            this.TipoUsuario = (eTipoUser)Convert.ToInt32(tabla.SelectedRows[0].Cells[4].Value.ToString());
            this.IsLoggedFlag = false;
        }
        #endregion
    }

    [Serializable]
    public class ListaAccounts : List<Accounts>
    {
        #region "Propiedades"

        public Dictionary<string, string> UserPassDictionary { get; set; }

        #endregion

        #region Constructores

        public ListaAccounts()
        {
            UserPassDictionary = new Dictionary<string, string>();
        }
        #endregion

        #region "Metodos & Funciones"
        public void CreateDictionaries()
        {
            //aqui se igualan y se agregan al diccionario.
            for (int i = 0; i < this.Count; i++)
            {
                UserPassDictionary.Add(this[i].Username, this[i].Password);
            }
        }

        #endregion

    }
}
