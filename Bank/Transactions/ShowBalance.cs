﻿using System;
using Bank.Views;
using Bank.WorkingCards;
using Bank.WorkingDatabase;

namespace Bank.Transactions
{
    internal class ShowBalance : Transaction          //класс который предназначен для работы с формой просмотра баланса
    {
        public ShowBalance(IIdentification identification, Money money)
        {
            Identification = identification;
            Money = money;
            var showBalance = new Views.ShowBalance();
            showBalance.Show();

            showBalance.labelBal.Text = "Ваш баланс составляет: "+ ((decimal)new ShowValuesDb().SetRequest("Card", "CurrentBalance", "CardNumber",identification.Id.ToString())[0][0]).ToString("C");
            showBalance.labelNum.Text = "Номер карты: " + identification.Id.ToString();
            showBalance.labelDate.Text= "Дата создания: " + ((DateTime)new ShowValuesDb().SetRequest("Card", "DateRececing", "CardNumber", identification.Id.ToString())[0][0]).ToLongDateString();
        }
    }
}
