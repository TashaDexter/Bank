using System.Data.SqlClient;
using System.Windows.Forms;
using Bank.WorkingCards;

namespace Bank.WorkingDatabase
{
    public class
        ShowTransactionDb : MainWorkDb //Класс который предназначен для получения данных и привязки к DataGridView
    {
        public void SetRequest(DataGridView dataGridView, IIdentification identification)
        {
            Action = () =>
            {
                SqlExpression = 
                    $"SELECT  cr.Number 'Номер карты', cl.FirstName Фамилия, cl.LastName Имя, cl.ParentName Отчество, b.Name 'Название банка', t.Date 'Дата транзакции', s.Name 'Вид услуги', t.Amount 'Сумма платежа', ctc.Name 'Категория', tc.Name 'Тип карты'" +
                    $"FROM Transactions t, Clients cl, Service s, Bank b, Card cr, CategoryCard ctc, TypeCard tc " +
                    $" WHERE t.ClientId = cl.Id " +
                    $" AND cr.BankId=b.Id " +
                    $" AND t.ServiceId=s.Id " +
                    $" AND cr.TypeCardId=tc.Id " +
                    $" AND tc.CategoryCardId=ctc.Id " +
                    $" AND cr.Id=t.CardId " +
                    $" AND cr.Number={identification.Id.ToString()}; ";

                SqlDataAdapter = new SqlDataAdapter(SqlExpression, Connection);
                //Вторым параметром ты присваиваешь имя для текущей таблицы в датасете
                SqlDataAdapter.Fill(DataSet, "new");
                //Здесь указываешь имя нужной таблицы            
                dataGridView.DataSource = DataSet.Tables["new"];
            };
            Request();
        }
    }
}
