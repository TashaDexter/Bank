using Project_Bank.Views;
using Project_Bank.WorkCards;
using Project_Bank.WorkingDatabase;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Bank.BankTransactions
{
    class FormDepositCash : Transactions    //класс который предназначен чтоб обрабатывать логику пополнения баланса
    {                  
        DepositСash deposit;
        public FormDepositCash(ICard card, Money money)
        {
            this.card = card;
            this.money = money;
            deposit = new DepositСash();  //создается новая форма для депозита
            deposit.Show();                                 //открытие формы      
            deposit.buttonExecute.Click += ButtonExecute_Click;   //создается обработчик события нажатия на кнопку        
        }            

        private void ButtonExecute_Click(object sender, EventArgs e)
        {                      
           
      
            //запрашивается с БД текущий баланс
            decimal moneyBD=Convert.ToDecimal(new ShowValuesBD().SetRequest("Card", "CurrentBalance", "CardNumber", card.ID.ToString())[0][0].ToString());
            moneyBD += Convert.ToDecimal(deposit.textValue.Text);  // текущий баланс пополняется
            money.Count -= Convert.ToDecimal(deposit.textValue.Text); // изымается баланс с карты

            //обновление баланса в БД
            new UpdateValueBD().SetRequest("Card", "CurrentBalance", moneyBD.ToString().Replace(",", "."), "CardNumber", card.ID.ToString());


            //добавление записи в истории транзации
            new InsertValueBD().SetRequest("Transactions",
                new List<string> { "IDClient", "IDService", "DateTransaction", "AmountPayment" },
                new List<string> {
                new ShowValuesBD().SetRequest
                ("Сlients", "ID", "СardAccount",
                  new ShowValuesBD().SetRequest
                  ("Card", "ID", "CardNumber", card.ID.ToString())[0][0].ToString()
                )[0][0].ToString(),

                    "1", DateTime.Today.ToString(),deposit.textValue.Text.Replace(",",".")
                });



            deposit.Close(); //закрытие формы


            SendMoney(money);   //вызов метода в котором вызывается событие

         


        }

      
    }
}
