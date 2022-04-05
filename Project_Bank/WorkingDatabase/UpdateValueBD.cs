using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Bank.WorkingDatabase
{
    class UpdateValueBD : MainWorkBD    //класс в котором создается запрос для обновления данных в бд
    {
        public void SetRequest(string table, string column, string value, string whereColum, string whereValue)
        {
            action = () =>
            {
                string sqlExpression = $"UPDATE {table} SET {column}={value} WHERE {whereColum}={whereValue}";
                sqlCommand = new SqlCommand(sqlExpression, connection);
                int number = sqlCommand.ExecuteNonQuery();

            };
            Request();

        }
    }
}
