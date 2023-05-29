using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Veritabanı_Yönetim_Ödevi.Services;

namespace Veritabanı_Yönetim_Ödevi.Forms
{
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();
        }

        private void loginForm_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void userName_TextChanged(object sender, EventArgs e)
        {
            if(userName.Text.Length > 0 && passwordBox.Text.Length > 0)
            {
                button1.Enabled = true;
            }
        }

        private void passwordBox_TextChanged(object sender, EventArgs e)
        {
            if (userName.Text.Length > 0 && passwordBox.Text.Length > 0)
            {
                button1.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dbServices dbServ = new dbServices();
            if (dbServ.isUserExist(userName.Text, passwordBox.Text))
            {
                mainForm _mainForm = new mainForm();
                _mainForm.Show();
                this.Hide();
                
            }
            else
                MessageBox.Show("Kullanici yok");
        }
    }
}
