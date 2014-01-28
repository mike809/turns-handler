using System;
using System.Collections.Generic;

namespace TurneroCentroMED
{
    /// <summary>
    /// Esta sera la clase que se usara para visualizar la linea de carga en el RIGHT PANEL del form.
    /// </summary>
    [Serializable]public class Departamento
    {
        #region Propiedades
        public ListaEstudios Estudios_En_Cola { get; set; }
        public string NombreDept { get; set; }
        #endregion

        #region Constructores
        public Departamento(string Nombre)
        {
            this.NombreDept = Nombre;
        }
        #endregion
    }

    [Serializable]public class ListaDepartamento:List<Departamento>
    {
        #region Constructores
        public ListaDepartamento()
        {
            this.Add(new Departamento("RAYO X"));
            this.Add(new Departamento("TOMOGRAFIA"));
            this.Add(new Departamento("SONOGRAFIA"));
            this.Add(new Departamento("RESONANCIA"));

            foreach (Departamento tmpDept in this)
            {
                tmpDept.Estudios_En_Cola = new ListaEstudios();
            }
        }
        #endregion
    }
}
