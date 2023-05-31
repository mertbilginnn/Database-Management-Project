using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Veritabanı_Yönetim_Ödevi.Services;

namespace Veritabanı_Yönetim_Ödevi.Forms
{
    public partial class tableForm : Form
    {
        public tableForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void showTable(SqlDataReader answer)
        {
            dataGridView1.Columns.Clear(); // Mevcut sütunları temizle

            //Gelen datareader'in columnlarının bilgisini alıp tablo columnlarını olusturuyor.
            for (int i = 0; i < answer.FieldCount; i++)
            {
                string columnName = answer.GetName(i);
                dataGridView1.Columns.Add(i.ToString(), columnName);
            }
            //Gelen datareader'in row bilgisini alıp tablo rowlarını olusturuyor.
            while (answer.Read())
            {
                object[] values = new object[answer.FieldCount];
                answer.GetValues(values);
                dataGridView1.Rows.Add(values);

            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'mertemiDataSet.Admin' table. You can move, or remove it, as needed.
            //this.adminTableAdapter.Fill(this.mertemiDataSet.Admin);

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void customQueryButton_Click(object sender, EventArgs e)
        {
            //Dışarıdan aldığı query bilgisini dvService üzerinden yolluyor donen tablodaki bilgiyi parselayarak ekrana yazıyor.
            string _query = queryTextBox.Text;
            dbServices dbServ = new dbServices();
            SqlDataReader answer = dbServ.customQuery(_query);

            if(answer == null)
            {
                MessageBox.Show("Bozuk sorgu !");
            }
            else
            {
                if (!answer.HasRows)
                {
                    MessageBox.Show("Yanlış Sorgu");
                }
                else
                {
                    this.showTable(answer);
                    answer.Close();
                }
            }

            
        }


        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {


        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Secilen combobox elementine gore hazır 3 fonksiyondan birini calıstırır.
            dbServices dbServ = new dbServices();
            SqlDataReader answer;
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        answer = dbServ.mathCourseBuyers();
                        this.showTable(answer);
                        break;
                    case 1:
                        answer = dbServ.favCourseInfo();
                        this.showTable(answer);
                        break;
                    case 2:
                        answer = dbServ.richestCourserer();
                        this.showTable(answer);
                        break;
                    default:
                        break;
                }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
