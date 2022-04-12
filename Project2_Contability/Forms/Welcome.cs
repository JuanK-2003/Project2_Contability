using Newtonsoft.Json;
using Project2_Contability.Group_Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project2_Contability.Forms
{
    public partial class Welcome : Form
    {
        List<Account> balanceSaldos = new List<Account>();
        List<Account> accountTypes = new List<Account>();

        public Welcome()
        {
            InitializeComponent();
        }

        /*
         * 
         *  1. Welcome
         *  2. CreateDataForm
         *  3. AddAccountForm
         *  4. GeneralBalaceForm
         *  5. FinancialStatementsForm
         *  6. IncomeStatementsForm
         * 
         */

        CreateDataForm createDataForm = new CreateDataForm(); // Se crean la cuentas
        FormCargarCuentaNuevo addAccountForm = new FormCargarCuentaNuevo(); // Agregan las cuentas y si se débita o acrédita billete :v 
        GeneralBalaceForm generalBalanceForm = new GeneralBalaceForm(); // Genera balance general
        FinancialStatementsForm finanacialStatementsForm = new FinancialStatementsForm(); // Muestra los Estados Financieros
        IncomeStatementsForm incomeStatementsForm = new IncomeStatementsForm(); // Muestra los Estados de Resultados
        EditForm editForm = new EditForm();

        /*private void OpenForm<OurForm>() where OurForm : Form, new ()
        {
            Form formulario;
            formulario = panel3.Controls.OfType<OurForm>().FirstOrDefault();

            if (formulario == null)
            {
                formulario = new OurForm();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;
                panel3.Controls.Add(formulario);
                panel3.Tag = formulario;
                formulario.Show();
                formulario.BringToFront();
                formulario.FormClosed += new FormClosedEventHandler(CloseForms);
            }
            else
            {
                formulario.BringToFront();
            }
        }*/

        /*private void CloseForms(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms["Welcome"] == null)
                button1.BackColor = Color.FromArgb(4, 41, 68);
            if (Application.OpenForms["AddAccountForm"] == null)
                button2.BackColor = Color.FromArgb(4, 41, 68);
            if (Application.OpenForms["CreateDataForm"] == null)
                button3.BackColor = Color.FromArgb(4, 41, 68);
            if (Application.OpenForms["GeneralBalanceForm"] == null)
                button3.BackColor = Color.FromArgb(4, 41, 68);
            if (Application.OpenForms["FinancialStatementsForm"] == null)
                button3.BackColor = Color.FromArgb(4, 41, 68);
            if (Application.OpenForms["IncomeStatementsForm"] == null)
                button3.BackColor = Color.FromArgb(4, 41, 68);
        }*/

        private void button1_Click(object sender, EventArgs e)
        {
            createDataForm.loadAccountTypes(JsonConvert.SerializeObject(accountTypes));
            createDataForm.ShowDialog();

            if (createDataForm.outAccountRepr != "")
            {
                accountTypes.Add( JsonConvert.DeserializeObject<Account>(createDataForm.outAccountRepr) );
                createDataForm.outAccountRepr = "";
            }

            button1.BackColor = Color.FromArgb(12, 61, 92);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addAccountForm.loadAccountTypes(JsonConvert.SerializeObject(accountTypes));
            addAccountForm.ShowDialog();

            if (addAccountForm.outAccount != "")
            {
                balanceSaldos.Add(JsonConvert.DeserializeObject<Account>(addAccountForm.outAccount));
                addAccountForm.outAccount = "";
            }

            button2.BackColor = Color.FromArgb(12, 61, 92);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            editForm.loadBalanceSaldos(JsonConvert.SerializeObject(balanceSaldos));
            editForm.ShowDialog();

            if (editForm.balanceSaldosNuevo != "")
            {
                balanceSaldos = JsonConvert.DeserializeObject<List<Account>>(editForm.balanceSaldosNuevo);
                editForm.balanceSaldosNuevo = "";
            }

            button6.BackColor = Color.FromArgb(13, 93, 142);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            generalBalanceForm.receiveBalanceSaldos(JsonConvert.SerializeObject(balanceSaldos));
            generalBalanceForm.ShowDialog();
            button3.BackColor = Color.FromArgb(12, 61, 92);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            finanacialStatementsForm.receiveBalanceSaldos(JsonConvert.SerializeObject(balanceSaldos));
            finanacialStatementsForm.ShowDialog();
            button4.BackColor = Color.FromArgb(12, 61, 92);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            incomeStatementsForm.receiveBalanceSaldos(JsonConvert.SerializeObject(balanceSaldos));
            incomeStatementsForm.ShowDialog();
            button5.BackColor = Color.FromArgb(12, 61, 92);
        }
    }
}