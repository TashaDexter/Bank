using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Bank.WorkingCards;
using Bank.WorkingDatabase;

namespace Bank.Views
{
    public partial class CardRegistration : Form
    {
        private Card _card;
        private readonly Serialization _serialization;
        private readonly Random _random = new Random();

        public CardRegistration(Card card, Serialization serialization)
        {
            InitializeComponent();
            _card = card;
            _serialization = serialization;
            FillClients();
        }

        private List<ArrayList>
            _listArrays = new List<ArrayList>(); //список для получения данных из таблицы и отображения на комбобоксе

        private string _idBank = "";
        private string _idCategoryCard = "";
        private string _idTypeCard = "";

        private void buttonReg_Click(object sender, EventArgs e)
        {
            var number = _random.Next(1000, 9999).ToString() + _random.Next(1000, 9999).ToString() +
                         _random.Next(1000, 9999).ToString() + _random.Next(1000, 9999).ToString();
            var pinCode = _random.Next(1000, 9999).ToString();

            var type = new ShowValuesDb().SetRequest("TypeCard", "Name", "Id", _idTypeCard)[0][0].ToString();
            var category = new ShowValuesDb().SetRequest("CategoryCard", "Name", "Id",
                new ShowValuesDb().SetRequest("TypeCard", "CategoryCardId", "Id", _idTypeCard)[0][0].ToString()
            )[0][0].ToString();

            var clientParams = comboClient.SelectedItem.ToString().Split(' ');
            var clientId = clientParams.First();

            var client = new ShowValuesDb().SetRequest("Clients", "*", "Id", clientId).First();

            //добавление нового пользователя в банк
            if (client == null)
            {
                throw new Exception("Ошибка! Клиент не найден.");
            }

            //добавление новой карты в банк
            var cardColumns = new List<string>
            {
                "BankId",
                "ClientId",
                "Number",
                "PinСode",
                "DateRececing",
                "CurrentBalance",
                "CategoryCardId",
                "TypeCardId"
            };
            var cardValues = new List<string>
            {
                _idBank,
                clientId,
                number,
                pinCode,
                DateTime.Today.ToString(CultureInfo.InvariantCulture),
                "0",
                _idCategoryCard,
                _idTypeCard
            };
            new InsertValuesDb().SetRequest("Cards", cardColumns, cardValues);

            //Создание новой карты как объект;
            _card = new Card
            {
                Client = new Client()
                {
                    Id = Convert.ToInt64(client[0]),
                    FirstName = client[1].ToString(),
                    LastName = client[2].ToString(),
                    ParentName = client[3].ToString(),
                    Address = client[4].ToString(),
                    Phone = client[5].ToString()
                },
                PinCode = pinCode,
                Id = long.Parse(number),
                Type = type,
                Category = category
            };

            //Сохранение объекта в фаил используя xml сериализацию 
            _serialization.Serialize(_card,
                $"Cards\\ {_card.Id} _ {_card.Client.Id} _ {category} {type}.xml");

            var cardId = new ShowValuesDb().SetRequest("Cards", "Id", "Number", number)[0][0].ToString();
            new InsertValuesDb().SetRequest("Transactions",
                new List<string> { "CardId", "ClientId", "ServiceId", "Date", "Amount" },
                new List<string>
                {
                    cardId,
                    clientId,
                    "3",
                    DateTime.Today.ToString(CultureInfo.InvariantCulture),
                    "0"
                });

            MessageBox.Show("Карта успешно создана." +
                            "\nВаши данные:" +
                            $"\nНомер карты: {_card.Id}" +
                            $"\nПин-код: {_card.PinCode}" +
                            $"\nСохраните данные в надежном месте, для смены пин-кода или изменения других данных обратитесь к администратору.");
            Close();
        }

        private void comboBank_DropDown(object sender, EventArgs e)
        {
            comboBank.Items.Clear();

            //Отображение всех банков
            _listArrays = new List<ArrayList>();
            _listArrays = new ShowValuesDb().SetRequest("Banks");
            foreach (var arr in _listArrays)
            {
                comboBank.Items.Add(arr[1].ToString());
            }
        }

        private void comboBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _idBank = _listArrays[comboBank.SelectedIndex][0].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Банк не найден");
            }

            _listArrays.Clear();
        }


        private void comboTypeCard_DropDown(object sender, EventArgs e) //отображение типов карт
        {
            comboTypeCard.Items.Clear();

            //Отображение всех банков
            _listArrays = new List<ArrayList>();
            _listArrays =
                new ShowValuesDb().SetRequest("TypeCard"); //SetRequest("TypeCard", "*", "CategoryCardID", "1");
            foreach (var arr in _listArrays)
            {
                var str =
                    new ShowValuesDb().SetRequest("CategoryCard", "Name", "Id", arr[2].ToString())[0][0] +
                    " " + arr[1];
                comboTypeCard.Items.Add(str);
            }
        }

        private void comboTypeCard_SelectedIndexChanged(object sender, EventArgs e) //выыбор типа карт
        {
            try
            {
                _idTypeCard = _listArrays[comboTypeCard.SelectedIndex][0].ToString();
                _idCategoryCard = _listArrays[comboTypeCard.SelectedIndex][2].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Карта не найдена");
            }

            _listArrays.Clear();
        }

        private void FillClients()
        {
            var clients = new ShowValuesDb().SetRequest("Clients");
            foreach (var client in clients)
            {
                var textItem = "";
                foreach (var param in client)
                {
                    textItem += param.ToString().Trim() + " ";
                }

                comboClient.Items.Add(textItem);
            }
        }
    }
}
