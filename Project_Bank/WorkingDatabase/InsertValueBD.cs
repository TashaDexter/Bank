using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Bank.WorkingDatabase
{
    class InsertValueBD:MainWorkBD    //класс который создает запрос на добавление данных в бд и обрабатывает.
    {
       

        public void SetRequest(string table, List<string> columns, List<string> values)
        {
            action = () =>
            {                                    
                string sqlExpression = $"INSERT INTO {table} ({string.Join(",", columns)}) VALUES ('{string.Join("', '", values)}')";
                sqlCommand = new SqlCommand(sqlExpression, connection);
                int number = sqlCommand.ExecuteNonQuery();            

            };
            Request();
           
        }
    }
}
