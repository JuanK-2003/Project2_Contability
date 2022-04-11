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
        List<Account> partidas = new List<Account>();
        string partidasFile = "C:\\Users\\Public\\Partidas.json";

        public GeneralBalaceForm()
        {
            InitializeComponent();
        }

        private void GeneralBalanceForm_Load(object sender, EventArgs e)
        {
            if (validarArchivos())
            {
                using (StreamReader rs = new StreamReader(partidasFile))
                {
                    partidas = JsonConvert.DeserializeObject<List<Account>>(rs.ReadToEnd());
                    rs.Close();
                }

                if (partidas == null)
                {
                    partidas = new List<Account>();
                }
            }
            else
            {
                File.Create("C:\\Users\\Public\\Partidas.json");
            }

            GeneralBalance gb = new GeneralBalance();
            dataGridView1.DataSource = new BindingList<DataToGeneralBalance>(gb.GenerateGeneralBalance(partidas));
        }

        protected bool validarArchivos()
        {
            return
                File.Exists(partidasFile);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
