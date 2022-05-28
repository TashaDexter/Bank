using System.Data.SqlClient;

namespace Bank.WorkingDatabase
{
    /// <summary>
    /// Класс для обновления данных в БД
    /// </summary>
    internal class UpdateValuesDb : MainWorkDb
    {
        public void SetRequest(string table, string column, string value, string whereColumn, string whereValue)
        {
            Action = () =>
            {
                var sqlExpression = $"UPDATE {table} SET {column}={value} WHERE {whereColumn}={whereValue}";
                SqlCommand = new SqlCommand(sqlExpression, Connection);
                SqlCommand.ExecuteNonQuery();
            };
            Request();
        }
    }
}
