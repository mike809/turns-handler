using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TurneroCentroMED.Entidades
{
    public class DiccionarioDept : Dictionary<string,int>
    {
        public DiccionarioDept()
        {
            Add("RAYO X", 0);
            Add("TOMOGRAFIA", 1);
            Add("SONOGRAFIA", 2);
            Add("RESONANCIA",3);
        }
    }

    public class DiccionarioTipoDato : Dictionary<Type, int>
    {
        public DiccionarioTipoDato()
        {
            Add(typeof (Data), 0);
            Add(typeof (ListaDepartamento), 1);
            Add(typeof (ListaPaciente), 2);
        }
    }
}
