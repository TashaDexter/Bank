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
    /// класс который предназначен чтоб обрабатывать логику пополнения баланса
    /// </summary>
    internal class Deposit : Transaction
    {
        private readonly DepositСash _deposit;

        public Deposit(IIdentification identification, decimal money)
        {
            Identification = identification;
            Money = money;
            _deposit = new DepositСash(); //создается новая форма для депозита
            _deposit.Show(); //открытие формы      
            _deposit.buttonExecute.Click +=
                ButtonExecute_Click; //создается обработчик события нажатия на кнопку        
        }

        private void ButtonExecute_Click(object sender, EventArgs e)
        {
            //добавление записи в истории транзации
            try
            {
                //запрашивается с БД текущий баланс
                var moneyBd = Convert.ToDecimal(
                    new ShowValuesDb().SetRequest("Cards", "CurrentBalance", "Number", Identification.Id.ToString())[0]
                        [0]
                        .ToString());

                var moneyToDeposit = Convert.ToDecimal(_deposit.textValue.Text);
                moneyBd += moneyToDeposit; // текущий баланс пополняется
                Money += moneyToDeposit; // изымается баланс с карты

                //обновление баланса в БД
                new UpdateValuesDb().SetRequest("Cards", "CurrentBalance", moneyBd.ToString().Replace(",", "."),
                    "Number",
                    Identification.Id.ToString());

                var card = new ShowValuesDb().SetRequest("Cards", "*", "Number", Identification.Id.ToString()).First();

                new InsertValuesDb().SetRequest("Transactions",
                    new List<string> { "CardId", "ClientId", "ServiceId", "Date", "Amount" },
                    new List<string>
                    {
                        card[0].ToString(),
                        card[2].ToString(),
                        "1",
                        DateTime.Today.ToString(CultureInfo.InvariantCulture),
                        _deposit.textValue.Text.Replace(",", ".")
                    });

                _deposit.Close(); //закрытие формы
                PerformOperation(OperationEnum.Deposit, true, Money); //вызов метода в котором вызывается событие
            }
            catch (FormatException formatException)
            {
                MessageBox.Show(@"Ошибка ввода данных. Пожалуйста, введите целое число или десятичное число с разеделителем в виде точки.");
            }
            catch (Exception exception)
            {
                PerformOperation(OperationEnum.Deposit, false, Money);
            }
        }
    }
}
