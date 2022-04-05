using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Bank.WorkingDatabase
{
    public abstract class Autorization  //базовый класс для данных авторизации в бд
    {
        protected static string Server { get; set; }
        protected static string BDName { get; set; }
        protected static string Login { get; set; }
        protected static string Password { get; set; }
        protected static bool Security { get; set; }
        protected static string UserName { get; set; }
    }
}
