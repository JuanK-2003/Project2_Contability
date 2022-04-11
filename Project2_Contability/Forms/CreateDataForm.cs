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
        List<Account> balanceSaldos = new List<Account>();
        public string outList = "";

        public CreateDataForm()
        {
            InitializeComponent();
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
            if(textBox1.Text != "")
            {
                if (this.comboBox2.SelectedIndex != -1)
                {
                    int jkl = comboBox2.SelectedIndex;

                    if (jkl <= 0 && jkl <= 6)
                    {
                        balanceSaldos.Add(new Account(nameCuenta: textBox1.Text, credit: 0f, debit: 0f, type1: (int)(jkl / 3), type2: jkl % 3) );
                    }
                    else
                    {
                        balanceSaldos.Add(new Account(nameCuenta: textBox1.Text, credit: 0f, debit: 0f, type1: jkl, type2: 0));
                    }

                    MessageBox.Show("Cuenta agregada con éxito!", "Excelente", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar un nombre de cuenta primero!", "ERROR 001", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            outList = JsonConvert.SerializeObject(balanceSaldos);
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
    }
}