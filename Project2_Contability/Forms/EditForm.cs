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
    public partial class EditForm : Form
    {
        List<Account> balanceSaldos = new List<Account>();
        public string balanceSaldosNuevo = "";

        public EditForm()
        {
            InitializeComponent();
        }

        public void loadBalanceSaldos(string repr)
        {
            balanceSaldos = JsonConvert.DeserializeObject<List<Account>>(repr);
            dataGridView1.DataSource = new BindingList<Account>(balanceSaldos);
        }

        private void EditForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Account nuevaCuenta = new Account();
            nuevaCuenta.NameCuenta = textBoxNombre.Text;


            int jkl = comboBoxTipo.SelectedIndex;

            if (jkl <= 0 && jkl <= 6)
            {
                nuevaCuenta.Type1 = (int)(jkl / 3);
                nuevaCuenta.Type2 = jkl % 3;
            }
            else
            {
                nuevaCuenta.Type1 = jkl;
            }

            if (textBoxCredito.Text != "")
            {
                nuevaCuenta.Credit = (float)Convert.ToDecimal(textBoxCredito.Text);
                nuevaCuenta.Debit = 0;
            }
            else
            {
                nuevaCuenta.Credit = 0;
                nuevaCuenta.Debit = (float)Convert.ToDecimal(textBoxDebito.Text);
            }

            balanceSaldos.Add(nuevaCuenta);
            balanceSaldosNuevo = JsonConvert.SerializeObject(balanceSaldos);

            textBoxNombre.Text = "";
            comboBoxTipo.SelectedIndex = -1;
            textBoxCredito.Text = "";
            textBoxDebito.Text = "";

            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int table_idx = dataGridView1.SelectedCells[0].RowIndex;
                Account cuentaToEdit = balanceSaldos[table_idx];

                textBoxNombre.Text = cuentaToEdit.NameCuenta;

                if (cuentaToEdit.Type1 >= 0 && cuentaToEdit.Type1 <= 2)
                {
                    comboBoxTipo.SelectedIndex = cuentaToEdit.Type1 * 3 + cuentaToEdit.Type2;
                }
                else
                {
                    comboBoxTipo.SelectedIndex = cuentaToEdit.Type1;
                }


                if (cuentaToEdit.Credit != 0)
                {
                    textBoxCredito.Text = cuentaToEdit.Credit + "";
                    textBoxDebito.Text = "";

                    checkBox1.Checked = true;
                    checkBox2.Checked = false;

                    textBoxCredito.Enabled = true;
                }
                else
                {
                    textBoxCredito.Text = "";
                    textBoxDebito.Text = cuentaToEdit.Debit + "";

                    checkBox1.Checked = false;
                    checkBox2.Checked = true;

                    textBoxDebito.Enabled = true;
                }

                balanceSaldos.RemoveAt(table_idx);
            }
            catch
            {
                MessageBox.Show("No ha seleccionado una fila valida!");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBoxCredito.Enabled = true;
                checkBox2.Checked = false;
                textBoxDebito.Text = "";
                textBoxDebito.Enabled = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                textBoxDebito.Enabled = true;
                checkBox1.Checked = false;
                textBoxCredito.Text = "";
                textBoxCredito.Enabled = false;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
