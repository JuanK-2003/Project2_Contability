using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseEstadoResultados
{
    class ToShowER
    {
        string col1;
        string col2;
        string col3;
        string col4;
        string col5;

        public ToShowER()
        {

        }

        public ToShowER(string c1, string c2, string c3, string c4, string c5)
        {
            Col1 = c1;
            Col2 = c2;
            Col3 = c3;
            Col4 = c4;
            Col5 = c5;
        }

        public string Col1 { get => col1; set => col1 = value; }
        public string Col2 { get => col2; set => col2 = value; }
        public string Col3 { get => col3; set => col3 = value; }
        public string Col4 { get => col4; set => col4 = value; }
        public string Col5 { get => col5; set => col5 = value; }
    }
}
