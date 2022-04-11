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
    public partial class AddAccountForm : Form
    {
        List<Account> incommingAccountTypes;
        public string outcommingBalanceSaldos;

        public AddAccountForm()
        {
            
        }

        public void RefreshCombo(string iat)
        {
            incommingAccountTypes = JsonConvert.DeserializeObject < List<Account >> (iat);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
