using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using Bank.WorkingCards;
using Bank.WorkingDatabase;

namespace Bank.Views
{
    public partial class Registration : Form
    {
        private Card _card;
        private readonly Serialization _serialization;
        private readonly Random _random = new Random();

        public Registration(Card card, Serialization serialization)
        {
            InitializeComponent();
            _card = card;
            _serialization = serialization;
        }

        private List<ArrayList>
            _listArrays = new List<ArrayList>(); //список для получения данных из таблицы и отображения на комбобоксе

        private string _idBank = "";
        private string _idTypeCard = "";

        private void buttonReg_Click(object sender, EventArgs e)
        {
            var cardNumber = _random.Next(1000, 9999).ToString() + _random.Next(1000, 9999).ToString() +
                             _random.Next(1000, 9999).ToString() + _random.Next(1000, 9999).ToString();
            var pinCode = _random.Next(1000, 9999).ToString();

            var type = new ShowValuesDb().SetRequest("TypeCard", "Name", "ID", _idTypeCard)[0][0].ToString();
            var category = new ShowValuesDb().SetRequest("CategoryCard", "Name", "ID",
                new ShowValuesDb().SetRequest("TypeCard", "CategoryCardID", "ID", _idTypeCard)[0][0].ToString()
            )[0][0].ToString();

            //Создание новой карты как объект;
            _card = new Card
            {
                FirstName = textFirstName.Text,
                LastName = textLastName.Text,
                Code = pinCode,
                Id = long.Parse(cardNumber),
                ParentName = textParentName.Text,
                Type = type,
                Category = category
            };
            
            //добавление новой карты в банк
            var cardColumns = new List<string>
                { "CardNumber", "СardСode", "CurrentBalance", "TypeCardID", "DateRececing", "IDBank" };
            var cardValues = new List<string>
            {
                cardNumber, pinCode, "0", _idTypeCard,
                DateTime.Today.ToString(CultureInfo.InvariantCulture), _idBank
            };
            new InsertValueDb().SetRequest("Card", cardColumns, cardValues);

            //добавление нового пользователя в банк
            //todo добавить проверку, существует ли
            var userColumns = new List<string> { "СardAccount", "FirstName", "LastName", "ParentName" };
            var userValues = new List<string>
            {
                new ShowValuesDb().SetRequest("Card", "ID", "CardNumber", cardNumber.ToString())[0][0].ToString(),
                textFirstName.Text, textLastName.Text, textParentName.Text
            };
            new InsertValueDb().SetRequest("Сlients", userColumns, userValues);
            
            //Сохранение объекта в фаил используя xml сериализацию 
            _serialization.Serialize(_card,
                $"Cards\\ {_card.Id} _ {_card.FirstName} {_card.LastName} {_card.ParentName} _ {category} {type}.xml");

            //todo проверка добавлен ли на самом деле
            MessageBox.Show("Карта успешно создана." +
                            "\nВаши данные:" +
                            $"\nНомер карты: {_card.Id}" +
                            $"\nПин-код: {_card.Code}" +
                            $"\nСохраните их в надежном месте, для смены пин-кода обратитесь к администратору.");
            Close();
        }

        private void comboBank_DropDown(object sender, EventArgs e)
        {
            comboBank.Items.Clear();

            //Отображение всех банков
            _listArrays = new List<ArrayList>();
            _listArrays = new ShowValuesDb().SetRequest("Bank");
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
                    new ShowValuesDb().SetRequest("CategoryCard", "Name", "ID", arr[2].ToString())[0][0].ToString() +
                    " " + arr[1];
                comboTypeCard.Items.Add(str);
            }
        }

        private void comboTypeCard_SelectedIndexChanged(object sender, EventArgs e) //выыбор типа карт
        {
            try
            {
                _idTypeCard = _listArrays[comboTypeCard.SelectedIndex][0].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Карта не найдена");
            }

            _listArrays.Clear();
        }
    }
}
