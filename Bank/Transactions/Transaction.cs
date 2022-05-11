using Bank.WorkingCards;

namespace Bank.Transactions
{
    public abstract class Transaction
    {
        public delegate void DMoney(OperationEnum operationEnum, bool isSuccess, decimal money); //делегат для создания события    
        public event DMoney EMoney; //создание события
        protected IIdentification Identification;
        protected decimal Money;

        protected void PerformOperation(OperationEnum operationEnum, bool isSuccess, decimal money)
        {
            EMoney?.Invoke(operationEnum, isSuccess, money); //вызов события
        }
    }
}
