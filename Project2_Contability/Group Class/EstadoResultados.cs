using Project2_Contability.Group_Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClaseEstadoResultados
{
    class EstadoResultados
    {
        public EstadoResultados()
        {

        }

        public List<ToShowER> GenerateEstadoResultados(List<Account> balanceSaldos, bool regimenISR, bool sociedad)
        {
            // regimen ISR == 0: 7%
            // regimen ISR == 1: 25%

            float isrp;

            if (regimenISR) isrp = 0.25f;
            else isrp = 0.07f;

            List<ToShowER> rows = new List<ToShowER>();
            float tmp, sumPart = 0;

            rows.Add(new ToShowER("", "", "ESTADO DE RESULTADOS", "", "%"));
            rows.Add(new ToShowER("", "", "", "", ""));

            sumPart = (float)FindByType(balanceSaldos, 6);

            rows.Add(new ToShowER("", "VENTAS", "", "Q " + sumPart, ""));


            tmp = (float)FindByType(balanceSaldos, 4);

            if (tmp == -1)
            {
                tmp = (float)FindByType(balanceSaldos, 7) + (float)FindByType(balanceSaldos, 8) - (float)FindByType(balanceSaldos, 9);
            }

            sumPart -= tmp;

            rows.Add(new ToShowER("MENOS", "COSTO VARIABLE", "Q " + tmp, "", ""));
            rows.Add(new ToShowER("IGUAL", "UTILIDAD BRUTA", "", "Q " + sumPart, ""));

            rows.Add(new ToShowER("MENOS", "GASTOS OPERATIVOS", "", "", ""));
            sumPart = 0;

            for (int idx = 0; idx < balanceSaldos.Count; idx++)
            {
                if (balanceSaldos[idx].Type1 == 3)
                {
                    sumPart += (float)balanceSaldos[idx].Credit + (float)balanceSaldos[idx].Debit;
                    rows.Add(new ToShowER("", balanceSaldos[idx].NameCuenta, "Q " + (balanceSaldos[idx].Credit + balanceSaldos[idx].Debit), "", ""));
                }
            }

            rows[rows.Count - 1].Col4 = "Q " + sumPart;
            rows.Add(new ToShowER("IGUAL", "UAII", "", "Q " + (FindInEstadoResultados(rows, "UTILIDAD BRUTA") - sumPart), ""));

            sumPart = 0;

            for (int idx = 0; idx < balanceSaldos.Count; idx++)
            {
                if (balanceSaldos[idx].Type1 == 10) // intereses
                {
                    if (sumPart == 0)
                    {
                        rows.Add(new ToShowER("MENOS", balanceSaldos[idx].NameCuenta, "Q " + (balanceSaldos[idx].Credit + balanceSaldos[idx].Debit), "", ""));
                    }
                    else
                    {
                        rows.Add(new ToShowER("", balanceSaldos[idx].NameCuenta, "Q " + (balanceSaldos[idx].Credit + balanceSaldos[idx].Debit), "", ""));
                    }
                    sumPart += (float)balanceSaldos[idx].Credit + (float)balanceSaldos[idx].Debit;
                }
            }

            rows[rows.Count - 1].Col4 = "Q " + sumPart;
            rows.Add(new ToShowER("IGUAL", "UAI", "", "Q " + (FindInEstadoResultados(rows, "UAII") - sumPart), ""));

            sumPart = 0;

            rows.Add(new ToShowER("MENOS", "ISR " + (isrp * 100) + "%", "", "Q " + (isrp * FindInEstadoResultados(rows, "UAI")), ""));
            rows.Add(new ToShowER("IGUAL", "UTILIDAD NETA", "", "Q " + (FindInEstadoResultados(rows, "UAI") - FindInEstadoResultados(rows, "ISR " + (isrp * 100) + "%")), ""));

            sumPart = 0;

            if (sociedad)
            {
                tmp = (float)FindByType(balanceSaldos, 12);
                if (tmp == -1) // reserva legal
                {
                    tmp = 0.05f * FindInEstadoResultados(rows, "UTILIDAD NETA");
                }
                sumPart += tmp;

                rows.Add(new ToShowER("MENOS", "RESERVA LEGAL", "Q " + tmp, "", ""));
            }

            tmp = (float)FindByType(balanceSaldos, 11);
            if (tmp == -1) // dividendos
            {
                tmp = 0.5f * FindInEstadoResultados(rows, "UTILIDAD NETA");
            }

            sumPart += tmp;

            rows.Add(new ToShowER("MENOS", "DIVIDENDOS", "Q " + tmp, "", ""));
            rows.Add(new ToShowER("IGUAL", "UTILIDAD RETENIDA", "", "Q " + (FindInEstadoResultados(rows, "UTILIDAD NETA") - sumPart), ""));

            for (int idx = 3; idx < rows.Count; idx++)
            {
                if (rows[idx].Col3.Length != 0)
                {
                    rows[idx].Col5 = Math.Round(((float)Convert.ToDecimal(rows[idx].Col3.Split(' ')[1]) * 10000) / FindByType(balanceSaldos, 6)) / 100 + " %";
                }
                else
                {
                    if (rows[idx].Col4.Length != 0)
                    {
                        rows[idx].Col5 = Math.Round(((float)Convert.ToDecimal(rows[idx].Col4.Split(' ')[1]) * 10000) / FindByType(balanceSaldos, 6)) / 100 + " %";
                    }
                }
            }

            return rows;
        }

        double FindByType(List<Account> balanceSaldos, int typeToFind)
        {
            for (int idx = 0; idx < balanceSaldos.Count; idx++)
            {
                if (balanceSaldos[idx].Type1 == typeToFind)
                {
                    return (double)balanceSaldos[idx].Credit + (double)balanceSaldos[idx].Debit;
                }
            }

            return -1;
        }

        float FindInEstadoResultados(List<ToShowER> rows, string nombre)
        {
            for (int idx = 0; idx < rows.Count; idx++)
            {
                if (rows[idx].Col2 == nombre)
                {
                    return (float)Convert.ToDouble(rows[idx].Col4.Split(' ')[1]);
                }
            }

            return -1;
        }
    }
}
