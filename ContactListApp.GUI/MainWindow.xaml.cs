using System.Windows;
using ContactListApp.GUI.Views;
using ContactListApp.Library.Interfaces;

namespace ContactListApp.GUI
{
    public partial class MainWindow : Window
    {
        private readonly IContactService _contactService;

        public MainWindow(IContactService contactService)
        {
            InitializeComponent();
            _contactService = contactService;

            MainFrame.Navigate(new AllContactsPage(_contactService));
        }

        private void ShowAllContacts_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AllContactsPage(_contactService));
        }

        private void ShowCreateContact_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new CreateContactPage(_contactService));
        }
    }
}
