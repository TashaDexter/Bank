using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Bank.WorkingDatabase
{
    /// <summary>
    /// Базовый класс для запросов в БД
    /// </summary>
    public class MainWorkDb 
    {
        protected string SqlExpression;
        protected SqlDataAdapter SqlDataAdapter;
        protected SqlCommand SqlCommand;
        protected readonly DataSet DataSet = new DataSet();
        protected readonly SqlConnection Connection = new SqlConnection(Connect.Connection());

        /// <summary>
        /// Задача, в которой хранится запрос
        /// </summary>
        protected Action Action;

        /// <summary>
        /// Метод как оболочка выполнения запросов в БД
        /// </summary>
        protected void Request() 
        {
            try
            {
                Connection.Open();
                Action(); 
                Connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
