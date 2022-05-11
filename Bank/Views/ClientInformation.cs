using System.Linq;
using System.Windows.Forms;
using Bank.WorkingDatabase;

namespace Bank.Views
{
    public partial class ClientInformation : Form
    {
        public ClientInformation(long clientId)
        {
            InitializeComponent();

            var client = new ShowValuesDb().SetRequest("Clients", "*", "Id", clientId.ToString()).First();
           
            listBox1.Items.Add($"Фамилия: {client[1]}");
            listBox1.Items.Add($"\nИмя: {client[2]}");
            listBox1.Items.Add($"\nОтчество: {client[3]}");
            listBox1.Items.Add($"\nАдрес: {client[4]}");
            listBox1.Items.Add($"\nНомер телефона: {client[5]}");

            var cards = new ShowValuesDb().SetRequest("Card", "*", "ClientId", clientId.ToString());
            foreach (var card in cards)
            {
                listBox1.Items.Add("");
                var bankName = new ShowValuesDb().SetRequest("Bank", "Name", "Id", card[1].ToString())[0][0].ToString();
                listBox1.Items.Add($"Номер карты: {Operations.GetCryptedCardId(card[3].ToString())}");
                listBox1.Items.Add($"Банк-эмитент: {bankName}");
                listBox1.Items.Add($"Пин-код: {card[4]}");
            }
        }
    }
}