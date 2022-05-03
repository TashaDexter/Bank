using System.Data.SqlClient;

namespace Bank.WorkingDatabase
{
    class UpdateValueDb : MainWorkDb //класс в котором создается запрос для обновления данных в бд
    {
        public void SetRequest(string table, string column, string value, string whereColum, string whereValue)
        {
            Action = () =>
            {
                var sqlExpression = $"UPDATE {table} SET {column}={value} WHERE {whereColum}={whereValue}";
                SqlCommand = new SqlCommand(sqlExpression, Connection);
                SqlCommand.ExecuteNonQuery();
            };
            Request();
        }
    }
}
