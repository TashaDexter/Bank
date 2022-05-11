using System.Windows.Forms;
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

            DgvAppearance(history.dataGridViewHistory);
        }

        private void DgvAppearance(DataGridView dgv)
        {
            dgv.Columns[0].Width = 110;
            dgv.Columns[4].Width = 80;
            dgv.Columns[5].Width = 80;
            dgv.Columns[7].Width = 80;
            dgv.Columns[8].Width = 80;
            dgv.Columns[9].Width = 80;
        }
    }
}
