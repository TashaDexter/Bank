using System;
using System.Collections.Generic;
using System.Globalization;
using Bank.Views;
using Bank.WorkingCards;
using Bank.WorkingDatabase;

namespace Bank.Transactions
{
    internal class WithdrawСash : Transaction //класс для работы с формой изьятия начичных
    {
        private readonly Views.WithdrawСash _withdraw;

        public WithdrawСash(IIdentification identification, Money money)
        {
            Identification = identification;
            Money = money;
            _withdraw = new Views.WithdrawСash();
            _withdraw.Show();
            _withdraw.buttonExecute.Click += ButtonExecute_Click;
        }

        private void ButtonExecute_Click(object sender, EventArgs e)
        {
            //получить поцент от банка к которому привязана карта
            var percent = new ShowValuesDb().SetRequest
                ("Bank", "Perent", "ID", new ShowValuesDb().SetRequest
                        ("Card", "IDBank", "CardNumber", Identification.Id.ToString())
                    [0][0].ToString())
                [0][0].ToString();

            //получить дату создания карты
            var dateCard = (DateTime)(new ShowValuesDb().SetRequest
                ("Card", "DateRececing", "CardNumber", Identification.Id.ToString())[0][0]);

            //получить сколько дней баланс хранится на счету
            var differenceDate = (DateTime.Today - dateCard).Days.ToString();

            //баланс с процентом начисления с учетом годовых
            var moneyReceived = (Convert.ToDecimal(_withdraw.textValue.Text) *
                                 (1 + (Convert.ToDecimal(differenceDate) * Convert.ToDecimal(percent) / 36000)));
            var moneyBd =
                Convert.ToDecimal(
                    new ShowValuesDb().SetRequest("Card", "CurrentBalance", "CardNumber", Identification.Id.ToString())
                        [0][0].ToString());
            moneyBd -= Convert.ToDecimal(_withdraw.textValue.Text);
            Money.Sum += moneyReceived; //получение баланса с процентом начисления
            new UpdateValueDb().SetRequest("Card", "CurrentBalance", moneyBd.ToString().Replace(",", "."), "CardNumber",
                Identification.Id.ToString());

            new InsertValueDb().SetRequest("Transactions",
                new List<string> { "IDClient", "IDService", "DateTransaction", "AmountPayment", "AccrualBank" },
                new List<string>
                {
                    new ShowValuesDb().SetRequest
                    ("Сlients", "ID", "СardAccount",
                        new ShowValuesDb().SetRequest
                            ("Card", "ID", "CardNumber", Identification.Id.ToString())[0][0].ToString()
                    )[0][0].ToString(),

                    "2", DateTime.Today.ToString(CultureInfo.InvariantCulture),
                    _withdraw.textValue.Text.Replace(",", "."),
                    (Convert.ToDecimal(differenceDate) * Convert.ToDecimal(percent)).ToString().Replace(",", ".")
                });

            _withdraw.Close();
            SendMoney("Операция вывода средств выполнена успешно", Money);
        }
    }
}
