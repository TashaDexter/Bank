using System.Data.SqlClient;
using System.Windows.Forms;
using Bank.WorkingCards;

namespace Bank.WorkingDatabase
{
    /// <summary>
    /// Класс для получения данных из БД и привязки к DataGridView
    /// </summary>
    internal class ShowTransactionDb : MainWorkDb
    {
        public void SetRequest(DataGridView dataGridView, IIdentification identification)
        {
            Action = () =>
            {
                SqlExpression = 
                    $"SELECT  cr.Number 'Номер карты', cl.LastName Фамилия, cl.FirstName Имя, cl.ParentName Отчество, b.Name 'Название банка', t.Date 'Дата транзакции', s.Name 'Вид услуги', t.Amount 'Сумма платежа', ctc.Name 'Категория', tc.Name 'Тип карты'" +
                    $"FROM Transactions t, Clients cl, Services s, Banks b, Cards cr, CategoryCard ctc, TypeCard tc " +
                    $" WHERE t.ClientId = cl.Id " +
                    $" AND cr.BankId=b.Id " +
                    $" AND t.ServiceId=s.Id " +
                    $" AND cr.TypeCardId=tc.Id " +
                    $" AND tc.CategoryCardId=ctc.Id " +
                    $" AND cr.Id=t.CardId " +
                    $" AND cr.Number={identification.Id.ToString()}; ";

                SqlDataAdapter = new SqlDataAdapter(SqlExpression, Connection);
                SqlDataAdapter.Fill(DataSet, "new");   
                dataGridView.DataSource = DataSet.Tables["new"];
            };
            Request();
        }
    }
}
