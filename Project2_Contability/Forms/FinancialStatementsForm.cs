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
    public partial class FinancialStatementsForm : Form
    {
        List<Account> balanceSaldos = new List<Account>();

        public FinancialStatementsForm()
        {
            InitializeComponent();
        }

        public void receiveBalanceSaldos(string repr)
        {
            balanceSaldos = JsonConvert.DeserializeObject<List<Account>>(repr);

            Statement RazonesFinancieras = new Statement();

            dataGridView1.DataSource = new BindingList<StatementToShow>(RazonesFinancieras.GenerarRazones(balanceSaldos));
        }

        private void FinancialStatementsForm_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
