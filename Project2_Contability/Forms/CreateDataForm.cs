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
    public partial class CreateDataForm : Form
    {
        List<Account> accountTypes = new List<Account>();
        public string outAccountRepr = "";

        public CreateDataForm()
        {
            InitializeComponent();
        }

        public void loadAccountTypes(string repr)
        {
            accountTypes = JsonConvert.DeserializeObject<List<Account>>(repr);

        }

        protected void CreateDataForm_Load(object sender, EventArgs e)
        {

        }

        /*
         * 
         * 
         *  0 - Activo Corriente
            1 - Activo No Corriente
            2 - Activo Diferido
            3 - Pasivo Corriente
            4 - Pasivo No Corriente
            5 - Pasivo Diferido
            6 - Capital
            7 - Cuenta Gastos
            8 - Costo Variable
            9 - Descuento Mercaderia
            10 - Ventas del Periodo
            11 - Inventario Inicial
            12 - Cuenta Compras
            13 - Inventario Final
            14 - Cuenta Tipo Interes
            15 - Dividendos
            16 - Reserva Legal
         * 
         * 
         * 
         */

        private void button1_Click(object sender, EventArgs e)
        {
            Account outAccount = new Account();

            if(textBox1.Text != "")
            {
                if (this.comboBox2.SelectedIndex != -1)
                {
                    int jkl = comboBox2.SelectedIndex;

                    if (jkl <= 0 && jkl <= 6)
                    {
                        outAccount = new Account(nameCuenta: textBox1.Text, credit: 0f, debit: 0f, type1: (int)(jkl / 3), type2: jkl % 3);
                    }
                    else
                    {
                        outAccount = new Account(nameCuenta: textBox1.Text, credit: 0f, debit: 0f, type1: jkl-4, type2: 0);
                    }

                    textBox1.Text = "";
                    comboBox2.SelectedIndex = -1;

                    MessageBox.Show("Cuenta agregada con éxito!", "Excelente", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar un nombre de cuenta primero!", "ERROR 001", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            outAccountRepr = JsonConvert.SerializeObject(outAccount);
        }

        // JsonConvert.SerializeObject(cuentaDisponible)

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void CreateDataForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}