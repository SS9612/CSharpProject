using System.Windows;
using System.Windows.Controls;
using ContactListApp.Library.Models;
using ContactListApp.Library.Interfaces;

namespace ContactListApp.GUI.Views
{
    public partial class EditContactPage : Page
    {
        private readonly IContactService _contactService;
        private readonly Contact _contactToEdit;

        public EditContactPage(IContactService contactService, Contact contactToEdit)
        {
            InitializeComponent();
            _contactService = contactService;
            _contactToEdit = contactToEdit;

            FirstNameTextBox.Text = _contactToEdit.FirstName;
            LastNameTextBox.Text = _contactToEdit.LastName;
            EmailTextBox.Text = _contactToEdit.Email;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            _contactToEdit.FirstName = FirstNameTextBox.Text;
            _contactToEdit.LastName = LastNameTextBox.Text;
            _contactToEdit.Email = EmailTextBox.Text;

            _contactService.SaveContactsToFile("contacts.json");
            MessageBox.Show("Kontakt uppdaterad!");
            NavigationService.GoBack();
        }
    }
}
