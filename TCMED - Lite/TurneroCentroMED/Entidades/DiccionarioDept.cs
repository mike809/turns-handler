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
            this.Add("RAYO X", 0);
            this.Add("TOMOGRAFIA", 1);
            this.Add("SONOGRAFIA", 2);
            this.Add("RESONANCIA",3);
        }
    }
}
