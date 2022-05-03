using System.Collections.Generic;
using System.Data.SqlClient;

namespace Bank.WorkingDatabase
{
    internal class InsertValueDb : MainWorkDb //класс который создает запрос на добавление данных в бд и обрабатывает.
    {
        public void SetRequest(string table, List<string> columns, List<string> values)
        {
            Action = () =>
            {
                var sqlExpression =
                    $"INSERT INTO {table} ({string.Join(",", columns)}) VALUES ('{string.Join("', '", values)}')";
                SqlCommand = new SqlCommand(sqlExpression, Connection);
                SqlCommand.ExecuteNonQuery();
            };
            Request();
        }
    }
}
