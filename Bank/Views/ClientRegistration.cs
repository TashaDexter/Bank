using System.Windows.Forms;
using Bank.WorkingCards;

namespace Bank.Views
{
    public partial class ClientRegistration : Form
    {
        private readonly Serialization _serialization;
        public ClientRegistration(Serialization serialization)
        {
            _serialization = serialization;
            InitializeComponent();
            //todo сделать добавление клиентов
        }
    }
}