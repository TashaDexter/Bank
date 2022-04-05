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
    class FormHistory : Transactions          //класс который предназачен для просмотра истории транзации через форму
    {
        History history;

        public FormHistory(ICard card, Money money)
        {
            this.card = card;
            this.money = money;

            history = new History();
            history.Show();

            ShowTransactionBD showTransaction = new ShowTransactionBD();
            showTransaction.SetRequest(history.dataGridViewHistory, card);



        }
    }
}
