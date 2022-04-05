using Project_Bank.WorkCards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_Bank.Views;
using Project_Bank.WorkingDatabase;

namespace Project_Bank.BankTransactions
{
    class FormFindBalance : Transactions            //класс который предназначен для работы с формой просмотра баланса
    {
        FindBalance findBalance;

        public FormFindBalance(ICard card, Money money)
        {
            this.card = card;
            this.money = money;
            findBalance = new FindBalance();
            findBalance.Show();

            findBalance.labelBal.Text = "Ваш баланс составляет: "+ ((decimal)new ShowValuesBD().SetRequest("Card", "CurrentBalance", "CardNumber",card.ID.ToString())[0][0]).ToString("C");
            findBalance.labelNum.Text = "Номер карты: " + card.ID.ToString();
            findBalance.labelDate.Text= "Дата создания: " + ((DateTime)new ShowValuesBD().SetRequest("Card", "DateRececing", "CardNumber", card.ID.ToString())[0][0]).ToLongDateString();

            //    deposit.buttonExecute.Click += ButtonExecute_Click;
        }

        private void ButtonExecute_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
