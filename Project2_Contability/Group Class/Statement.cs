using ClaseEstadoResultados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2_Contability.Group_Class
{

    internal class Statement
    {
        public Statement()
        {

        }

        public List<StatementToShow> GenerarRazones(List<Account> BalanceDeSaldos)
        {
            List<StatementToShow> salir = new List<StatementToShow>();

            salir.Add(new StatementToShow("", "RAZONES FINANCIERAS", ""));
            salir.Add(new StatementToShow("", "", ""));
            salir.Add(new StatementToShow("", "RAZONES DE LIQUIDEZ", ""));
            salir.Add(new StatementToShow("", "", ""));
            salir.Add(new StatementToShow("", "RAZONES DE ACTIVIDAD", ""));
            salir.Add(new StatementToShow("", "", ""));
            salir.Add(new StatementToShow("", "RAZONES DE SOLVENCIA Y ENDEUDAMIENTO", ""));
            salir.Add(new StatementToShow("", "", ""));
            salir.Add(new StatementToShow("", "RAZONES DE RENTABILIDAD", ""));

            GeneralBalance gb = new GeneralBalance();
            EstadoResultados er = new EstadoResultados();

            List<DataToGeneralBalance> BalanceGeneral = gb.GenerateGeneralBalance(BalanceDeSaldos);
            List<ToShowER> EstadoResultados = er.GenerateEstadoResultados(BalanceDeSaldos, true, true);

            return salir;
        }
    }
}
