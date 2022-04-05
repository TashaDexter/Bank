using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Bank.WorkingDatabase
{
    public  class ShowTransactionBD : MainWorkBD       //Класс который предназначен для получения данных и привязки к DataGridView
    {
       
        public void SetRequest(DataGridView dataGridView, WorkCards.ICard card)
        {
            action = () =>
            {

                sqlExpression = $"SELECT  cl.СardAccount ЛС, cl.FirstName Фамилия, cl.LastName Имя,cl.ParentName Отчество, b.Name 'Название банка', t.DateTransaction 'Дата транзакции', s.Name 'Виды услуг', t.AmountPayment 'Сумма платежа', t.AccrualBank 'Начисление',ctc.Name 'Категория', tc.Name 'Тип карты'" +
                $"FROM Transactions t, Сlients cl, Service s, Bank b, Card cr, CategoryCard ctc, TypeCard tc " +
                $" WHERE t.IDClient = cl.ID " +
                $" AND cl.СardAccount=cr.ID " +
                $" AND cr.IDBank=b.ID " +
                $" AND t.IDService=s.ID " +

                $" AND cr.TypeCardID=tc.ID " +
                $" AND tc.CategoryCardID=ctc.ID " +

                $" AND cr.CardNumber={card.ID.ToString()}; ";

                
                
                sqlDataAdapter = new SqlDataAdapter(sqlExpression, connection);
                //Вторым параметром ты присваиваешь имя для текущей таблицы в датасете
                sqlDataAdapter.Fill(dataSet,"new");
                //Здесь указываешь имя нужной таблицы            
                dataGridView.DataSource = dataSet.Tables["new"];

            };
            Request();
        }
    }
}
