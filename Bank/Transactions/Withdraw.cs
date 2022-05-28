using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Bank.Views;
using Bank.WorkingCards;
using Bank.WorkingDatabase;

namespace Bank.Transactions
{
    /// <summary>
    /// Класс для работы с формой изьятия наличных
    /// </summary>
    internal class Withdraw : Transaction
    {
        private readonly WithdrawСash _withdraw;

        public Withdraw(IIdentification identification, decimal money)
        {
            Identification = identification;
            Money = money;
            _withdraw = new WithdrawСash();
            _withdraw.Show();
            _withdraw.buttonExecute.Click += ButtonExecute_Click;
        }

        private void ButtonExecute_Click(object sender, EventArgs e)
        {
            try
            {
//получить процент от банка к которому привязана карта
                var percent = new ShowValuesDb().SetRequest
                    ("Banks", "[Percent]", "Id", new ShowValuesDb().SetRequest
                            ("Cards", "BankId", "Number", Identification.Id.ToString())
                        [0][0].ToString())
                    [0][0].ToString();

                //получить дату создания карты
                var dateCard = (DateTime)(new ShowValuesDb().SetRequest
                    ("Cards", "DateRececing", "Number", Identification.Id.ToString())[0][0]);

                //получить сколько дней баланс хранится на счету
                var differenceDate = (DateTime.Today - dateCard).Days.ToString();

                //баланс с процентом начисления с учетом годовых
                var moneyReceived = (Convert.ToDecimal(_withdraw.textValue.Text) *
                                     (1 + (Convert.ToDecimal(differenceDate) * Convert.ToDecimal(percent) / 36000)));
                var moneyBd =
                    Convert.ToDecimal(
                        new ShowValuesDb().SetRequest("Cards", "CurrentBalance", "Number", Identification.Id.ToString())
                            [0][0].ToString());
                var moneyToWithDraw = Convert.ToDecimal(_withdraw.textValue.Text);

                if (moneyBd < moneyToWithDraw)
                {
                    _withdraw.Close();
                    PerformOperation(OperationEnum.Withdraw, false, moneyToWithDraw);
                }
                else
                {
                    moneyBd -= moneyToWithDraw;
                    Money += moneyReceived; //получение баланса с процентом начисления
                    new UpdateValuesDb().SetRequest("Cards", "CurrentBalance", moneyBd.ToString().Replace(",", "."),
                        "Number",
                        Identification.Id.ToString());

                    var card = new ShowValuesDb().SetRequest("Cards", "*", "Number", Identification.Id.ToString())
                        .First();

                    new InsertValuesDb().SetRequest("Transactions",
                        new List<string> { "CardId", "ClientId", "ServiceId", "Date", "Amount" },
                        new List<string>
                        {
                            card[0].ToString(),
                            card[2].ToString(),
                            "2",
                            DateTime.Today.ToString(CultureInfo.InvariantCulture),
                            _withdraw.textValue.Text.Replace(",", ".")
                        });

                    _withdraw.Close();
                    PerformOperation(OperationEnum.Withdraw, true, Money);
                }
            }
            catch (FormatException formatException)
            {
                MessageBox.Show(@"Ошибка ввода данных. Пожалуйста, введите целое число или десятичное число с разеделителем в виде точки.");
            }
            catch (Exception exception)
            {
                PerformOperation(OperationEnum.Withdraw, false, Money);
            }

        }
    }
}
