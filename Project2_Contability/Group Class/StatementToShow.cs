using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2_Contability.Group_Class
{
    internal class StatementToShow
    {
        private string columna1;
        private string columna2;
        private string columna3;

        public string Columna1 { get => columna1; set => columna1 = value; }
        public string Columna2 { get => columna2; set => columna2 = value; }
        public string Columna3 { get => columna3; set => columna3 = value; }

        public StatementToShow(string c1, string c2, string c3)
        {
            columna1 = c1;
            columna2 = c2;
            columna3 = c3;
        }
    }
}
