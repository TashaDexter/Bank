using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Bank.WorkingDatabase
{
    public class ShowValuesBD:MainWorkBD          //класс который предназначен для получения данных с бд в виде списка
    {
        List<ArrayList> listArray = new List<ArrayList>();
        public List<ArrayList> SetRequest(string table, string select = "*", string where = "", string text = "")
        {
            action = () =>
            {
                if (where != "")
                {
                    sqlExpression = $"SELECT {select} FROM {table} WHERE {where} LIKE '{text}'";   //если конкретный столбец известен
                }
                else
                {
                    sqlExpression = $"SELECT {select} FROM {table}";   //если не известен
                }
                sqlCommand = new SqlCommand(sqlExpression,connection);
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {                      
                    while (reader.Read()) // построчно считываем данные
                    {
                        int i = 0; int flag = 0;
                        ArrayList list = new ArrayList();
                        while (flag!=1)
                        {
                            try
                            {
                                list.Add(reader.GetValue(i));
                                i++;
                            }
                            catch (Exception ex) { flag = 1; break; }
                        }
                        listArray.Add(list);                      
                     
                    }
                }
            };
            Request();
            return listArray;
        }
    }
}
