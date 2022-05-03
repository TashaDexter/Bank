using Bank.WorkingCards;

namespace Bank.Transactions
{
    public abstract class Transaction
    {
        public delegate void DMoney(string text, Money money); //делегат для создания события    
        public event DMoney EMoney; //создание события
        protected IIdentification Identification;
        protected Money Money;

        protected void SendMoney(string text, Money money)
        {
            EMoney?.Invoke(text, money); //вызов события
        }
    }
}
