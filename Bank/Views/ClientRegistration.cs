using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Bank.WorkingDatabase;

namespace Bank.Views
{
    public partial class ClientRegistration : Form
    {
        public ClientRegistration()
        {
            InitializeComponent();
        }

        private void buttonReg_Click(object sender, EventArgs e)
        {
            var firstName = textBoxFirstName.Text;
            var lastName = textBoxLastName.Text;
            var parentName = textBoxParentName.Text;
            var address = textBoxAddress.Text;
            var phone = textBoxPhone.Text;
            
            if (!Regex.IsMatch(phone, @"\+37377\d\d{5}", RegexOptions.IgnoreCase))
            {
                MessageBox.Show("Ошибка ввода данных. Пожалуйста, введите номер телефона в формате: +37377******");
            }
            else
            {
                var columns = new List<string>
                    { "FirstName", "LastName", "ParentName", "Address", "Phone" };
                var values = new List<string>
                {
                    firstName, lastName, parentName, address, phone
                };
                new InsertValuesDb().SetRequest("Clients", columns, values);

                MessageBox.Show(@"Клиент добавлен успешно!");
                Close();
            }
        }
    }
}