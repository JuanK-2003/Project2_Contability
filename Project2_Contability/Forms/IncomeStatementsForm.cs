using ClaseEstadoResultados;
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

            EstadoResultados er = new EstadoResultados();
            dataGridView1.DataSource = new BindingList<ToShowER>(er.GenerateEstadoResultados(balanceSaldos,checkBox2.Checked, checkBox1.Checked));
        }

        private void IncomeStatementsForm_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            EstadoResultados er = new EstadoResultados();
            dataGridView1.DataSource = new BindingList<ToShowER>(er.GenerateEstadoResultados(balanceSaldos, checkBox2.Checked, checkBox1.Checked));
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            EstadoResultados er = new EstadoResultados();
            dataGridView1.DataSource = new BindingList<ToShowER>(er.GenerateEstadoResultados(balanceSaldos, checkBox2.Checked, checkBox1.Checked));
        }
    }
}
