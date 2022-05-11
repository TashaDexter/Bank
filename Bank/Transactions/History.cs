using Bank.WorkingCards;
using Bank.WorkingDatabase;

namespace Bank.Transactions
{
    internal class History : Transaction          //класс который предназачен для просмотра истории транзации через форму
    {
        public History(IIdentification identification, decimal money)
        {
            Identification = identification;
            Money = money;

            var history = new Views.History();
            history.Show();

            var showTransaction = new ShowTransactionDb();
            showTransaction.SetRequest(history.dataGridViewHistory, identification);
        }
    }
}
