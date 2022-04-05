using Project_Bank.WorkingDatabase;
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

namespace Project_Bank.Views
{
    public partial class SettingsBD : Form
    {
        public SettingsBD()
        {
            InitializeComponent();
        }

      

        private void button1_Click(object sender, EventArgs e)     //подключение к бд
        {
            try
            {
                Connect connect = new Connect(textBox1.Text, textBox2.Text, checkBox1.Checked, textBox3.Text, textBox4.Text);
                using (SqlConnection connection = new SqlConnection(Connect.Connection()))
                {
                    connection.Open();
                    throw new Exception("Подключенo");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message.ToString());
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)  //смена режима 
        {
            if (checkBox1.Checked == true)
            {
                textBox3.Enabled = false;
                textBox4.Enabled = false;
            }
            else
            {
                textBox3.Enabled = true;
                textBox4.Enabled = true;
            }
        }
    }
}
