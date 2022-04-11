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
        AddAccountForm addAccountForm = new AddAccountForm(); // Agregan las cuentas y si se débita o acrédita billete :v 
        GeneralBalaceForm generalBalanceForm = new GeneralBalaceForm(); // Genera balance general
        FinancialStatementsForm finanacialStatementsForm = new FinancialStatementsForm(); // Muestra los Estados Financieros
        IncomeStatementsForm incomeStatementsForm = new IncomeStatementsForm(); // Muestra los Estados de Resultados

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
            createDataForm.ShowDialog();
            op = createDataForm.outList;
            button1.BackColor = Color.FromArgb(12, 61, 92);
        }

        string op;

        private void button2_Click(object sender, EventArgs e)
        {
            addAccountForm.RefreshCombo(op);
            addAccountForm.ShowDialog();
            button2.BackColor = Color.FromArgb(12, 61, 92);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            generalBalanceForm.LoadData(op);
            generalBalanceForm.ShowDialog();

            button3.BackColor = Color.FromArgb(12, 61, 92);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            finanacialStatementsForm.ShowDialog();
            button4.BackColor = Color.FromArgb(12, 61, 92);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            incomeStatementsForm.ShowDialog();
            button5.BackColor = Color.FromArgb(12, 61, 92);
        }
    }
}