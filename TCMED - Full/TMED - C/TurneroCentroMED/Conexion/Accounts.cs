using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TurneroCentroMED.Conexion
{
    [Serializable]
    public class Accounts
    {
        #region Login

        public enum eTipoUser
        {
            Cajero = 0,
            Admin = 1,
            Developer = 2
        }

        #endregion

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

        public Accounts(string User, string Pass)
        {
            this.Username = User;
            this.Password = Pass;
            this.IsLoggedFlag = true;
        }

        public Accounts(string name, string lastname, string username, string pass, int tipo)
        {
            this.Nombre = name;
            this.Apellido = lastname;
            this.Username = username;
            this.Password = pass;
            this.IsLoggedFlag = false;
            this.TipoUsuario = (eTipoUser) tipo;
        }

        //public Accounts(DataGridView tabla)
        //{
        //    //DATAGRID_logins.SelectedRows[0].Cells[1].Value.ToString(); Username
        //    //DATAGRID_logins.SelectedRows[0].Cells[2].Value.ToString();     Password
        //    //DATAGRID_logins.SelectedRows[0].Cells[2].Value.ToString(); Tipo

        //    this.Username = tabla.SelectedRows[0].Cells[1].Value.ToString();
        //    this.Password = tabla.SelectedRows[0].Cells[2].Value.ToString();
        //    this.TipoUsuario = tabla.SelectedRows[0].Cells[2].Value.ToString();
        //    this.IsLoggedFlag = false;
        //}

        #endregion
    }
}
