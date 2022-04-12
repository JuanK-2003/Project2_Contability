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
    public partial class IncomeStatementsForm : Form
    {
        List<Account> balanceSaldos = new List<Account>();

        public IncomeStatementsForm()
        {
            InitializeComponent();
        }

        public void receiveBalanceSaldos(string repr)
        {
            balanceSaldos = JsonConvert.DeserializeObject<List<Account>>(repr);
            dataGridView1.DataSource = new BindingList<Account>(balanceSaldos);
        }

        private void IncomeStatementsForm_Load(object sender, EventArgs e)
        {

        }
    }
}
