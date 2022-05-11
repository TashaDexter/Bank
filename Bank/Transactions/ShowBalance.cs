using System;
using Bank.WorkingCards;
using Bank.WorkingDatabase;

namespace Bank.Transactions
{
    internal class ShowBalance : Transaction          //класс который предназначен для работы с формой просмотра баланса
    {
        public ShowBalance(IIdentification identification, decimal money)
        {
            Identification = identification;
            Money = money;
            var showBalance = new Views.ShowBalance();
            showBalance.Show();

            showBalance.labelBal.Text = "Ваш баланс составляет: "+ ((decimal)new ShowValuesDb().SetRequest("Card", "CurrentBalance", "Number", identification.Id.ToString())[0][0]).ToString("C");
            showBalance.labelNum.Text = "Номер карты: " + identification.Id.ToString();
            showBalance.labelDate.Text= "Дата создания: " + ((DateTime)new ShowValuesDb().SetRequest("Card", "DateRececing", "Number", identification.Id.ToString())[0][0]).ToLongDateString();
        }
    }
}
