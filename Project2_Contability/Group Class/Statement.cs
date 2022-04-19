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
            salir.Add(new StatementToShow("INDICE DE LIQUIDEZ", "", ""));
            salir.Add(new StatementToShow("PRUEBA ACIDA", "", ""));
            salir.Add(new StatementToShow("PRUEBA SEVERA", "", ""));
            salir.Add(new StatementToShow("", "", ""));
            salir.Add(new StatementToShow("", "RAZONES DE ACTIVIDAD", ""));
            salir.Add(new StatementToShow("", "", ""));
            salir.Add(new StatementToShow("ROTACION DE INVENTARIOS", "", ""));
            salir.Add(new StatementToShow("EDAD DE INVENTARIOS", "", ""));
            salir.Add(new StatementToShow("PERIODO DE COBRO", "", ""));
            salir.Add(new StatementToShow("ROTACION DE CITAS POR COBRAR", "", ""));
            salir.Add(new StatementToShow("ROTACION DE ACTIVOS", "", ""));
            salir.Add(new StatementToShow("", "", ""));
            salir.Add(new StatementToShow("", "RAZONES DE SOLVENCIA Y ENDEUDAMIENTO", ""));
            salir.Add(new StatementToShow("", "", ""));
            salir.Add(new StatementToShow("INDICE DE ENDEUDAMIENTO", "", ""));
            salir.Add(new StatementToShow("ESTRUCTURA DE CAPITAL", "", ""));
            salir.Add(new StatementToShow("CARGO DE INTERESES", "", ""));
            salir.Add(new StatementToShow("", "", ""));
            salir.Add(new StatementToShow("", "RAZONES DE RENTABILIDAD", ""));
            salir.Add(new StatementToShow("", "", ""));
            salir.Add(new StatementToShow("RENTABILIDAD SOBRE VENTAS", "", ""));
            salir.Add(new StatementToShow("RENTABILIDAD SOBRE ACTIVOS FIJOS", "", ""));
            salir.Add(new StatementToShow("RENTABILIDAD SOBRE CAPITAL INICIAL", "", ""));
            salir.Add(new StatementToShow("RENTABILIDAD SOBRE CAPITAL CONTABLE", "", ""));

            GeneralBalance gb = new GeneralBalance();
            EstadoResultados er = new EstadoResultados();

            List<DataToGeneralBalance> BalanceGeneral = gb.GenerateGeneralBalance(BalanceDeSaldos);
            List<ToShowER> EstadoResultados = er.GenerateEstadoResultados(BalanceDeSaldos, true, true);

            return salir;
        }
    }
}
