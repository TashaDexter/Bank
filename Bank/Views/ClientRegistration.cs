using System;
using System.Collections.Generic;
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

            var columns = new List<string>
                { "FirstName", "LastName", "ParentName", "Address", "Phone" };
            var values = new List<string>
            {
                firstName, lastName, parentName, address, phone
            };
            new InsertValueDb().SetRequest("Clients", columns, values);

            MessageBox.Show(@"Клиент добавлен успешно!");
            Close();
        }
    }
}