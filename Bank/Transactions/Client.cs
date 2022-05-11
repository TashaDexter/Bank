namespace Bank.Transactions
{
    internal class Client : Transaction
    {
        public Client(long clientId)
        {
            var clientInformation = new Views.ClientInformation(clientId);
            clientInformation.Show();
        }
    }
}