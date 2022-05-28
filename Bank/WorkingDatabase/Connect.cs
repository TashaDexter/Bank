namespace Bank.WorkingDatabase
{
    /// <summary>
    /// Класс для авторизации
    /// </summary>
    public class Connect : Authorization
    {
        public Connect(string server, string dbName, bool security, string login, string password)
        {
            Server = server;
            DbName = dbName;
            Security = security;
            Login = login;
            Password = password;
        }

        public static string Connection()
        {
            return
                $"Data Source={Server};Initial Catalog={DbName};Integrated Security={Security};User ID={Login};Password={Password};";
        }
    }
}
