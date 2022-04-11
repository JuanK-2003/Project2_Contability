using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2_Contability.Group_Class
{
    class GeneralBalance
    {
        public List<DataToGeneralBalance> GenerateGeneralBalance(List<Account> cuentas)
        {
            // recibe una lista de cuentas con sus saldos e identificacion requeridas

            string[] type1Heading = { "Activo", "Pasivo", "Capital" };
            string[] type2Heading = { "Corriente", "No corriente", "Diferido" };
            double[] APCsum = { 0, 0, 0 };

            List<DataToGeneralBalance> dataToDisplay = new List<DataToGeneralBalance>();

            for (int type1idx = 0; type1idx <= 2; type1idx++) // recorre activo, pasivo y capital
            {
                double sum = 0;

                for (int type2idx = 0; type2idx <= 2; type2idx++) // recorre corriente, no corriente, diferido
                {
                    List<string> AcountNames = new List<string>();
                    List<double> AcountBalance = new List<double>();

                    for (int cidx = 0; cidx < cuentas.Count; cidx++)
                    {
                        if ((cuentas[cidx].Type1 == type1idx && cuentas[cidx].Type2 == type2idx) || (type1idx == 2 && cuentas[cidx].Type1 == 2))
                        {
                            int zidx = AcountNames.IndexOf(cuentas[cidx].NameCuenta);

                            if (zidx < 0) // no esta incluida
                            {
                                AcountNames.Add(cuentas[cidx].NameCuenta);
                                AcountBalance.Add(cuentas[cidx].Credit - cuentas[cidx].Debit);
                            }
                            else AcountBalance[zidx] = AcountBalance[zidx] + cuentas[cidx].Credit - cuentas[cidx].Debit;
                        }
                    }

                    for (int idxg = 0; idxg < AcountBalance.Count; idxg++)
                    {
                        AcountBalance[idxg] = Math.Abs(AcountBalance[idxg]);
                    }

                    if (AcountNames.Count > 0)
                    {
                        if (type1idx == 2) dataToDisplay.Add(new DataToGeneralBalance(type1Heading[type1idx]));
                        else dataToDisplay.Add(new DataToGeneralBalance(type1Heading[type1idx] + " " + type2Heading[type2idx]));

                        for (int kidx = 0; kidx < AcountNames.Count; kidx++)
                        {
                            if (kidx == AcountNames.Count - 1) dataToDisplay.Add(new DataToGeneralBalance(AcountNames[kidx], AcountBalance[kidx] + "", AcountBalance.Sum() + ""));
                            else dataToDisplay.Add(new DataToGeneralBalance(AcountNames[kidx], AcountBalance[kidx] + "", ""));
                        }

                        sum += AcountBalance.Sum();

                        dataToDisplay.Add(new DataToGeneralBalance(""));
                    }

                    if (type1idx == 2) break;
                }

                if (sum >= 0)
                {
                    APCsum[type1idx] = sum;
                    dataToDisplay.Add(new DataToGeneralBalance("SUMA TOTAL " + type1Heading[type1idx], "", sum + ""));
                    dataToDisplay.Add(new DataToGeneralBalance(""));
                }
            }

            dataToDisplay.Add(new DataToGeneralBalance("SUMA PASIVO + CAPITAL", "", (APCsum[1] + APCsum[2]) + ""));
            return dataToDisplay;
        }

        public string GeneralBalanceToText(List<DataToGeneralBalance> generalBalance)
        {
            string ret = "\tBALANCE GENERAL\t\n";

            for (int idx = 0; idx < generalBalance.Count; idx++)
            {
                ret += generalBalance[idx].ToString() + "\n";
            }

            return ret;
        }
    }
}
