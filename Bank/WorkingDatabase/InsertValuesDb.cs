using System.Collections.Generic;
using System.Data.SqlClient;

namespace Bank.WorkingDatabase
{
    /// <summary>
    /// Класс для добавления данных в БД
    /// </summary>
    internal class InsertValuesDb : MainWorkDb
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
