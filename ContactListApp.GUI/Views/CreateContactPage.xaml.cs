using System.Windows;
using System.Windows.Controls;
using ContactListApp.Library.Models;
using ContactListApp.Library.Interfaces;
using ContactListApp.Library.Utilities;

namespace ContactListApp.GUI.Views
{
    public partial class CreateContactPage : Page
    {
        private readonly IContactService _contactService;

        public CreateContactPage(IContactService contactService)
        {
            InitializeComponent();
            _contactService = contactService;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FirstNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(LastNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(EmailTextBox.Text))
            {
                MessageBox.Show("Alla fält måste fyllas i.");
                return;
            }

            var newContact = ContactFactory.CreateContact(
                FirstNameTextBox.Text,
                LastNameTextBox.Text,
                EmailTextBox.Text
            );

            _contactService.AddContact(newContact);
            _contactService.SaveContactsToFile("contacts.json");


