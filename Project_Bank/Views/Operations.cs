using Project_Bank.BankTransactions;
using Project_Bank.WorkCards;
using Project_Bank.WorkingDatabase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Bank.Views
{
    public partial class Operations : Form
    {
        Card card;
        Money money;
        Transactions transactions;
        Serialization serialization;
        public Operations(Card card, Money money, Transactions transactions,  Serialization serialization)
        {
            this.serialization = serialization;
            this.card = card;
            this.money = money;
            this.transactions = transactions;              
            InitializeComponent();
                                  
        }             
                     

      

        private void listView1_Click(object sender, EventArgs e)
        {
            
            switch (listView1.FocusedItem.Text)
            {
                case "Пополнить счёт": transactions = new FormDepositCash(card, money);  break;
                case "Вывести наличные": transactions = new FormWithdrawСash(card, money); break;
                case "Посмотреть баланс": transactions = new FormFindBalance(card, money);break;
                case "История транзакции": transactions = new FormHistory(card, money); break;
            }
            transactions.Emoney += Transactions_Emoney; //создания обработчика события для отображения наличных
        }

        private void Transactions_Emoney(Money money)
        {
            stCountMoney.Text = money.Count.ToString("C");
            serialization.Seriaze<Money>(money, $"moneys.xml"); //сохраниение текущих финансов в фаил
            money = serialization.Deseriaze<Money>(money, $"moneys.xml");
            transactions.Emoney -= Transactions_Emoney;   //отписка
        }


        private void Operations_Load(object sender, EventArgs e)
        {
            stCountMoney.Text = money.Count.ToString("C");
        }

       
    }
}
