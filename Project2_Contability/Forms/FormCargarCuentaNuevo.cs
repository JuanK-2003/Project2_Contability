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
using Newtonsoft.Json;

namespace Project2_Contability.Forms
{
    public partial class FormCargarCuentaNuevo : Form
    {
        List<Account> incommingAccountTypes;
        public string outAccount = "";

        public FormCargarCuentaNuevo()
        {
            InitializeComponent();
        }

        public void loadAccountTypes(string iat)
        {
            comboBox1.Items.Clear();

            incommingAccountTypes = JsonConvert.DeserializeObject<List<Account>>(iat);

            for (int idx = 0; idx < incommingAccountTypes.Count; idx++)
            {
                comboBox1.Items.Add(incommingAccountTypes[idx].NameCuenta);
            }
        }

        private void FormCargarCuentaNuevo_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Account outAcc = incommingAccountTypes[comboBox1.SelectedIndex];

            try
            {
                outAcc.Credit = (float)Convert.ToDecimal(textBox2.Text);
            }
            catch
            {
                outAcc.Credit = 0f;
            }
            
            try
            {
                outAcc.Debit = (float)Convert.ToDecimal(textBox3.Text);
            }
            catch
            {
                outAcc.Debit = 0f;
            }


            outAccount = JsonConvert.SerializeObject(outAcc);
            MessageBox.Show("Cuenta cargada con éxito!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            textBox2.Text = "";
            textBox3.Text = "";

            comboBox1.SelectedIndex = -1;

            this.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox2.Checked = false;
                textBox3.Enabled = false;
                textBox2.Enabled = true;

                textBox2.Text = "";
                textBox3.Text = "";
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox1.Checked = false;
                textBox3.Enabled = true;
                textBox2.Enabled = false;

                textBox2.Text = "";
                textBox3.Text = "";
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
