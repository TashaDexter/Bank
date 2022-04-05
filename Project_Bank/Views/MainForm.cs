using Project_Bank.Views;
using Project_Bank.WorkCards;
using Project_Bank.WorkingDatabase;
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

namespace Project_Bank
{
    public partial class Form1 : Form
    {
        Card card=new Card();           //экземпляр дла карты   
        Money money = new Money();      //экземпляр для наличных
        Serialization serialization;     //экземпляр для сериализации
        SettingsBD settingsBD;            //экземпляр для формы настройки в бд
        Registration registration;         //экземпляр для фформы регистрации карты
        Operations operations;             //экземпляр для формы операии
      
        BankTransactions.Transactions transactions;
        public Form1()
        {
            InitializeComponent();
            serialization = new Serialization();
        }

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settingsBD = new SettingsBD();
            settingsBD.Show();
        }

        private void регистрацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            registration = new Registration(card, serialization);
            registration.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //money.Count = 1000;
            //serialization.Seriaze<Money>(money, $"moneys.xml");
            if (card.Category == "Visa")
            {
                money = serialization.Deseriaze<Money>(money, $"moneys.xml");
                operations = new Operations(card, money, transactions, serialization);
                operations.Show();
            }
            else
            {
                MessageBox.Show("В данном банкомате поддерживается только Visa");
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            Connect connect = new Connect(".\\SQLEXPRESS", "BD_Bank", true,"","");     //подключение по умолчанию
         
        }



        List<string> listCard = new List<string>();
        private void comboBox1_DropDown(object sender, EventArgs e)  //показываются все карты которые существуют у пользователя
        {
            comboBox1.Items.Clear();
            listCard.Clear();
            var dir = new DirectoryInfo("Cards"); // папка с файлами 

            foreach (FileInfo file in dir.GetFiles())
            {
                comboBox1.Items.Add(Path.GetFileNameWithoutExtension(file.FullName));
                listCard.Add(file.FullName);
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)      //выбор карты
        {
 
            card =serialization.Deseriaze<Card>(card, listCard[comboBox1.SelectedIndex]);        //получение данных карты из файла
            richTextBox1.Clear();
            richTextBox1.SelectedText = "Номер карты: " + card.ID+"\n";
            richTextBox1.SelectedText = $"ФИО: {card.FirstName} {card.LastName} {card.ParentName} \n";
            richTextBox1.SelectedText = "Тип карты: " + card.Type+"\n";
        }
    }
}
