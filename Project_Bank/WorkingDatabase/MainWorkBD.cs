using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Bank.WorkingDatabase
{
    public class MainWorkBD        //базовый класс для запросов в бд
    {

        protected string sqlExpression;
        protected SqlDataAdapter sqlDataAdapter;
        protected SqlCommand sqlCommand;
        protected DataSet dataSet = new DataSet();
        protected SqlConnection connection = new SqlConnection(Connect.Connection());
      
        protected Action action;
        protected void Request()     //метод как оболочка выполнения запросов в бд
        {
            try
            {

                connection.Open();
                action();    //задача в которой хранится запрос
                connection.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }
    }

}
