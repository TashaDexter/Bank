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
    class FormWithdrawСash : Transactions   //класс для работы с формой изьятия начичных
    {
        WithdrawСash withdraw;

        public FormWithdrawСash(ICard card, Money money)
        {
            this.card = card;
            this.money = money;
            withdraw = new WithdrawСash();
            withdraw.Show();
            withdraw.buttonExecute.Click += ButtonExecute_Click;
        }

        private void ButtonExecute_Click(object sender, EventArgs e)
        {
            //получить поцент от банка к которому привязана карта
            string persent = new ShowValuesBD().SetRequest
                ("Bank", "Perent", "ID", new ShowValuesBD().SetRequest
                ("Card", "IDBank", "CardNumber", card.ID.ToString())
                [0][0].ToString())
                [0][0].ToString();

            //получить дату создания карты
            DateTime dateCard = (DateTime)(new ShowValuesBD().SetRequest
                ("Card", "DateRececing", "CardNumber", card.ID.ToString())[0][0]);

            //получить сколько дней баланс хранится на счету
            string differenceDate = (DateTime.Today - dateCard).Days.ToString();

            //баланс с процентом начисления с учетом годовых
            string moneyReceived = (Convert.ToDecimal(withdraw.textValue.Text) * (1 + (Convert.ToDecimal(differenceDate) * Convert.ToDecimal(persent) / 36000))).ToString();

          

        

            decimal moneyBD = Convert.ToDecimal(new ShowValuesBD().SetRequest("Card", "CurrentBalance", "CardNumber", card.ID.ToString())[0][0].ToString());
            moneyBD -= Convert.ToDecimal(withdraw.textValue.Text);
            money.Count += Convert.ToDecimal(moneyReceived);  //получение баланса с процентом начисления
            new UpdateValueBD().SetRequest("Card", "CurrentBalance", moneyBD.ToString().Replace(",", "."), "CardNumber", card.ID.ToString());

            new InsertValueBD().SetRequest("Transactions",
                new List<string> { "IDClient", "IDService", "DateTransaction", "AmountPayment", "AccrualBank" },
                new List<string> {
                new ShowValuesBD().SetRequest
                ("Сlients", "ID", "СardAccount",
                  new ShowValuesBD().SetRequest
                  ("Card", "ID", "CardNumber", card.ID.ToString())[0][0].ToString()
                )[0][0].ToString(),

                    "2", DateTime.Today.ToString(),withdraw.textValue.Text.Replace(",","."), (Convert.ToDecimal(differenceDate) * Convert.ToDecimal(persent)).ToString().Replace(",",".")
                });



            withdraw.Close();


            SendMoney(money);
        }
    }
}
