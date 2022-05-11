using System.Windows.Forms;

namespace Bank.Transactions
{
    internal class Client : Transaction
    {
        public Client()
        {
            MessageBox.Show("Открывается окно информации об абоненте");
        }
        
    }
}