using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Bank.WorkingDatabase
{
    public class Connect : Autorization          //класс для создания авторизации
    {
        //передача данных через конструктор
        public Connect(string server, string bdname, bool security, string login, string password)
        {
            Server = server;
            BDName = bdname;
            Security = security;
            Login = login;
            Password = password;
        }

        public static string Connection()     //создается строка подключения
        {
            return $"Data Source={Server};Initial Catalog={BDName};Integrated Security={Security};User ID={Login};Password={Password};";
        }

     
    }
}
