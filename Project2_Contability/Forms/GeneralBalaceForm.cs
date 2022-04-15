using Newtonsoft.Json;
using Project2_Contability.Group_Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project2_Contability.Forms
{
    public partial class GeneralBalaceForm : Form
    {
        List<Account> balanceSaldos = new List<Account>();

        public GeneralBalaceForm()
        {
            InitializeComponent();
        }

        public void receiveBalanceSaldos(string repr)
        {
            balanceSaldos = JsonConvert.DeserializeObject<List<Account>>(repr);
            GeneralBalance gb = new GeneralBalance();
            dataGridView1.DataSource = new BindingList<DataToGeneralBalance>(gb.GenerateGeneralBalance(balanceSaldos));
        }

        private void GeneralBalanceForm_Load(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
