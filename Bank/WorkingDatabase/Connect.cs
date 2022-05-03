namespace Bank.WorkingDatabase
{
    public class Connect : Authorization //класс для создания авторизации
    {
        //передача данных через конструктор
        public Connect(string server, string dbName, bool security, string login, string password)
        {
            Server = server;
            DbName = dbName;
            Security = security;
            Login = login;
            Password = password;
        }

        public static string Connection() //создается строка подключения
        {
            return
                $"Data Source={Server};Initial Catalog={DbName};Integrated Security={Security};User ID={Login};Password={Password};";
        }
    }
}
