using System.Windows;
using System.Windows.Controls;
using ContactListApp.Library.Interfaces;
using ContactListApp.Library.Models;

namespace ContactListApp.GUI.Views
{
    public partial class AllContactsPage : Page
    {
        private readonly IContactService _contactService;

        public AllContactsPage(IContactService contactService)
        {
            InitializeComponent();
            _contactService = contactService;

            ContactListView.ItemsSource = _contactService.GetAllContacts();
        }

        private void EditContact_Click(object sender, RoutedEventArgs e)
        {
            var selectedContact = (Contact)ContactListView.SelectedItem;
            if (selectedContact != null)
            {
                var editPage = new EditContactPage(_contactService, selectedContact);
                NavigationService.Navigate(editPage);
            }
            else
            {
                MessageBox.Show("Välj en kontakt att redigera.");
            }
        }

        private void DeleteContact_Click(object sender, RoutedEventArgs e)
        {
            var selectedContact = (Contact)ContactListView.SelectedItem;
            if (selectedContact != null)
            {
                var result = MessageBox.Show("Är du säker på att du vill ta bort denna kontakt?", "Bekräfta", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    _contactService.GetAllContacts().Remove(selectedContact);
                    _contactService.SaveContactsToFile("contacts.json");
                    ContactListView.ItemsSource = null;
                    ContactListView.ItemsSource = _contactService.GetAllContacts();
                    MessageBox.Show("Kontakt raderad.");
                }
            }
            else
            {
                MessageBox.Show("Välj en kontakt att ta bort.");
            }
        }
    }
}
