using Project_Bank.WorkCards;
using Project_Bank.WorkingDatabase;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Bank.Views
{
    public partial class Registration : Form
    {
        Card card;                   
        Serialization serialization;
        Random random = new Random();


        public Registration(Card card, Serialization serialization)
        {                                            
            InitializeComponent();
            this.card = card;
            this.serialization = serialization;         

        }



        List<ArrayList> lisrArrays = new List<ArrayList>(); //список для получения данных из таблицы и отображения на комбобоксе

        string IDBank = "";
        string IDTypeCard = "";
     

        private void buttonReg_Click(object sender, EventArgs e)
        {
            int cardNumber = random.Next(100000, 999999);
            string cardCode = random.Next(100, 999).ToString();

            string type = new ShowValuesBD().SetRequest("TypeCard", "Name", "ID", IDTypeCard)[0][0].ToString();
            string category = new ShowValuesBD().SetRequest("CategoryCard", "Name", "ID",
                new ShowValuesBD().SetRequest("TypeCard", "CategoryCardID", "ID", IDTypeCard)[0][0].ToString()
                )[0][0].ToString();

            //Создание новой карты как объект;
            card = new Card { FirstName = textFirstName.Text, LastName = textLaastName.Text, Code = cardCode, ID = cardNumber, ParentName = textParentName.Text,Type=type, Category=category};
            
            //Сохранение объекта в фаил используя xml сериализацию 
            serialization.Seriaze<Card>(card, $"Cards\\ {card.ID} _ {card.FirstName} {card.LastName} {card.ParentName} _ {category} {type}.xml");

           
            //добавление новой карты в банк
            new InsertValueBD().SetRequest("Card",
                new List<string>{ "CardNumber", "СardСode", "CurrentBalance", "TypeCardID", "DateRececing", "IDBank" },
                new List<string>{cardNumber.ToString(), cardCode, "0", IDTypeCard, DateTime.Today.ToString(), IDBank });
            //добавление нового пользователя в банк
            new InsertValueBD().SetRequest("Сlients", 
                new List<string> {"СardAccount", "FirstName", "LastName", "ParentName" }, 
                new List<string> {
                    new ShowValuesBD().SetRequest("Card", "ID", "CardNumber", cardNumber.ToString())[0][0].ToString(), 
                    textFirstName.Text,textLaastName.Text,textParentName.Text 
                });

        }
      

        private void comboBank_DropDown(object sender, EventArgs e)
        {
           comboBank.Items.Clear();

            //Отображение всех банков
            lisrArrays = new List<ArrayList>();
            lisrArrays = new ShowValuesBD().SetRequest("Bank");         
            foreach (var arr in lisrArrays)
            {
               comboBank.Items.Add(arr[1].ToString());
            }
            
        }

        private void comboBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                IDBank = lisrArrays[comboBank.SelectedIndex][0].ToString();
            }
            catch (Exception ex) { MessageBox.Show("Банк не найден"); }
            lisrArrays.Clear();
        }
    

        private void comboTypeCard_DropDown(object sender, EventArgs e)      //отображение типов карт
        {

            comboTypeCard.Items.Clear();

            //Отображение всех банков
            lisrArrays = new List<ArrayList>();
            lisrArrays = new ShowValuesBD().SetRequest("TypeCard");    //SetRequest("TypeCard", "*", "CategoryCardID", "1");
            foreach (var arr in lisrArrays)
            {
                string str =new ShowValuesBD().SetRequest("CategoryCard", "Name", "ID", arr[2].ToString())[0][0].ToString() + " " + arr[1].ToString();             
                comboTypeCard.Items.Add(str);
 
            }
             
        }

        private void comboTypeCard_SelectedIndexChanged(object sender, EventArgs e)   //выыбор типа карт
        {
            try {
                IDTypeCard = lisrArrays[comboTypeCard.SelectedIndex][0].ToString();
               
      

            } 
            catch (Exception ex) { MessageBox.Show("Карта не найдена"); }
            lisrArrays.Clear();
        }
    }
}
