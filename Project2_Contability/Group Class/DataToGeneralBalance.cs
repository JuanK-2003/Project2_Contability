using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2_Contability.Group_Class
{
    class DataToGeneralBalance
    {
        private string columna1, columna2, columna3;
        private double aux;

        public DataToGeneralBalance(string n1)
        {
            Columna1 = n1;
            Columna2 = "";
            Columna3 = "";
        }

        public DataToGeneralBalance(string n1, string n2, string n3)
        {
            Columna1 = n1;
            Columna2 = n2;
            Columna3 = n3;
        }

        override public string ToString()
        {
            return Columna1 + "\t" + Columna2 + "\t" + Columna3;
        }

        public string Columna1 { get => columna1; set => columna1 = value; }
        public string Columna2
        {
            get => columna2;
            set => columna2 = value.Length == 0 ? " " : "Q " + value;
        }
        public string Columna3
        {
            get => columna3;
            set => columna3 = value.Length == 0 ? " " : "Q " + value;
        }
    }
}
