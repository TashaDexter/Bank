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

            var cryptedId = GetCryptedCardId(_card.Id.ToString());
            Text = $"Операции с картой: {cryptedId}";
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            switch (listView1.FocusedItem.Text)
            {
                case "Пополнение счета":
                    _transaction = new Deposit(_card, _money);
                    break;
                case "Вывод средств":
                    _transaction = new Withdraw(_card, _money);
                    break;
                case "Баланс карты":
                    _transaction = new Transactions.ShowBalance(_card, _money);
                    break;
                case "История транзакций":
                    _transaction = new Transactions.History(_card, _money);
                    break;
                case "Информация о клиенте":
                    _transaction = new Transactions.Client(_card.Client.Id);
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
                        ? $"Операция снятия средств выполнена успешно. С учетом начисления процентов со счета снято {Math.Round(money, 3)} руб."
                        : $"Операция снятия средств не была выполнена успешно. Возможно, сумма для снятия превышает количество имеющихся средств. Проверьте ваш баланс и попробуйте еще раз.";
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

        public static string GetCryptedCardId(string cardId)
        {
            var result = "";
            var digits = cardId.ToCharArray();
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
