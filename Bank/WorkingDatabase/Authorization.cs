namespace Bank.WorkingDatabase
{
    public abstract class Authorization //базовый класс для данных авторизации в бд
    {
        protected static string Server { get; set; }
        protected static string DbName { get; set; }
        protected static string Login { get; set; }
        protected static string Password { get; set; }
        protected static bool Security { get; set; }
    }
}
