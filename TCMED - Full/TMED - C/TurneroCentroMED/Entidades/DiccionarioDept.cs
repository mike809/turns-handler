using System.Collections.Generic;

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
