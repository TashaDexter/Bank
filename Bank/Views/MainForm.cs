using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using Bank.Transactions;
using Bank.WorkingCards;
using Bank.WorkingDatabase;

namespace Bank.Views
{
    public partial class Form1 : Form
    {
        private Card _card = new Card(); //экземпляр дла карты   
        private readonly Money _money = new Money(); //экземпляр для наличных
        private readonly Serialization _serialization; //экземпляр для сериализации
        private Registration _registration; //экземпляр для формы регистрации карты
        private Operations _operations; //экземпляр для формы операии
        private readonly Transaction _transaction;
        private readonly List<string> _listCard = new List<string>();

        public Form1()
        {
            InitializeComponent();
            _serialization = new Serialization();
            UpdateCardComboBox();
        }

        private void CardMenu_Click(object sender, EventArgs e)
        {
            _registration = new Registration(_card, _serialization);
            _registration.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_card.Code == pinCodeTextBox.Text)
            {
                _operations = new Operations(_card, _money, _transaction, _serialization);
                _operations.Show();
            }
            else
            {
                MessageBox.Show("Ошибка! Вы ввели неправильный пин-код! Попробуйте еще раз.");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) //выбор карты
        {
            _card = _serialization.Deserialize(_card,
                _listCard[CardComboBox.SelectedIndex]); //получение данных карты из файла
        }

        private void ConnectionMenu_Click(object sender, EventArgs e)
        {
            try
            {
                var connect = new Connect(".\\SQLEXPRESS", "BankDb", true, "", "");
                using (var connection = new SqlConnection(Connect.Connection()))
                {
                    connection.Open();
                    MessageBox.Show(@"База данных успешно подключена!");
                    CardMenu.Enabled = true;
                    ConfirmButton.Enabled = true;
                    CardComboBox.Enabled = true;
                        
                    button0.Enabled = true;
                    button1.Enabled = true;
                    button2.Enabled = true;
                    button3.Enabled = true;
                    button4.Enabled = true;
                    button5.Enabled = true;
                    button6.Enabled = true;
                    button7.Enabled = true;
                    button8.Enabled = true;
                    button9.Enabled = true;
                    pinCodeTextBox.Enabled = true;
                    UpdateButton.Enabled = true;

                    CardComboBox.SelectedIndex = 0;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            pinCodeTextBox.Text += 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pinCodeTextBox.Text += 2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pinCodeTextBox.Text += 3;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pinCodeTextBox.Text += 4;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pinCodeTextBox.Text += 5;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            pinCodeTextBox.Text += 6;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            pinCodeTextBox.Text += 7;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            pinCodeTextBox.Text += 8;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            pinCodeTextBox.Text += 9;
        }

        private void button0_Click(object sender, EventArgs e)
        {
            pinCodeTextBox.Text += 0;
        }

        private void ExitMenu_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            UpdateCardComboBox();
        }

        private void UpdateCardComboBox()
        {
            //заполнение карт в CardComboBox
            CardComboBox.Items.Clear();
            _listCard.Clear();
            var path = "Cards";
            var dir = new DirectoryInfo(path); // папка с файлами 

            var files = dir.GetFiles();

            foreach (var file in files)
            {
                var card = _serialization.Deserialize(_card, file.FullName);
                CardComboBox.Items.Add(card.Id + " | " + card.Category + " - " + card.Type);
                _listCard.Add(file.FullName);
            }
        }
    }
}
