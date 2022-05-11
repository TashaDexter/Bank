using System;
using System.Linq;
using System.Windows.Forms;
using Bank.Transactions;
using Bank.WorkingCards;

namespace Bank.Views
{
    public partial class Operations : Form
    {
        private readonly Card _card;
        private readonly decimal _money;
        private Transaction _transaction;
        private readonly Serialization _serialization;

        public Operations(Card card, decimal money, Transaction transaction, Serialization serialization)
        {
            _serialization = serialization;
            _money = money;
            _card = card;
            _transaction = transaction;
            InitializeComponent();

            var cryptedId = GetCryptedId(_card.Id);
            Text += $": {cryptedId}";
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            switch (listView1.FocusedItem.Text)
            {
                case "Пополнить счёт":
                    _transaction = new Deposit(_card, _money);
                    break;
                case "Вывести наличные":
                    _transaction = new Transactions.Withdraw(_card, _money);
                    break;
                case "Посмотреть баланс":
                    _transaction = new Transactions.ShowBalance(_card, _money);
                    break;
                case "История транзакций":
                    _transaction = new Transactions.History(_card, _money);
                    break;
                case "Информация об абоненте":
                    _transaction = new Transactions.Client();
                    break;
            }

            _transaction.EMoney += TransactionsEMoney; //создания обработчика события для отображения наличных
        }

        private void TransactionsEMoney(OperationEnum operationEnum, bool isSuccess, decimal money)
        {
            var text = "";
            switch (operationEnum)
            {
                case OperationEnum.Withdraw:
                {
                    text = isSuccess
                        ? $"Операция снятия средств выполнена успешно. Со счета снято {money} руб."
                        : $"Операция снятия средств не была выполнена успешно. Возможно, сумма для снятия ({money} руб.) превышает количество имеющихся средств. Проверьте ваш баланс и попробуйте еще раз.";
                }
                    break;

                case OperationEnum.Deposit:
                {
                    text = isSuccess
                        ? $"Операция пополнения счета выполнена успешно. На счет поступило {money} руб."
                        : $"Операция пополнения счета не была выполнена успешно.";
                }
                    break;

                default:
                {

                }
                    break;
            }

            MessageBox.Show(text);

            _transaction.EMoney -= TransactionsEMoney;
        }

        private string GetCryptedId(long id)
        {
            var result = "";
            var digits = id.ToString().ToCharArray();
            var firstPart = digits.Take(4);

            result = firstPart.Aggregate("", (current, first) => current + first);

            result += " **** **** ";


            var descendingOrderDigits = digits.OrderByDescending(d=>d).ToArray();
            var lastPart = descendingOrderDigits.Take(4);
            result = lastPart.Aggregate(result, (current, last) => current + last);

            return result;
        }
    }
}
