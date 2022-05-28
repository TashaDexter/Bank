using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Bank.WorkingDatabase
{
    /// <summary>
    /// Класс для получения данных из БД
    /// </summary>
    public class ShowValuesDb : MainWorkDb
    {
        private readonly List<ArrayList> _listArray = new List<ArrayList>();

        public List<ArrayList> SetRequest(string table, string select = "*", string where = "", string text = "")
        {
            Action = () =>
            {
                if (where != "")
                {
                    SqlExpression =
                        $"SELECT {select} FROM {table} WHERE {where} LIKE '{text}'"; //если конкретный столбец известен
                }
                else
                {
                    SqlExpression = $"SELECT {select} FROM {table}"; //если не известен
                }

                SqlCommand = new SqlCommand(SqlExpression, Connection);
                var reader = SqlCommand.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        var i = 0;
                        var flag = 0;
                        var list = new ArrayList();
                        while (flag != 1)
                        {
                            try
                            {
                                list.Add(reader.GetValue(i));
                                i++;
                            }
                            catch (Exception ex)
                            {
                                flag = 1;
                                break;
                            }
                        }

                        _listArray.Add(list);
                    }
                }
            };
            Request();
            return _listArray;
        }
    }
}
