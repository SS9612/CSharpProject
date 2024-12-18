using ContactListApp.Library.Interfaces;
using ContactListApp.Library.Models;
using ContactListApp.Library.Utilities;

namespace ContactListApp.Library.Services
{
    public class ContactService : IContactService
    {
        private List<Contact> _contacts = new List<Contact>();

        public void AddContact(Contact contact)
        {
            _contacts.Add(contact);
        }

        public List<Contact> GetAllContacts()
        {
            return _contacts;
        }

        public void SaveContactsToFile(string filePath)
        {
            JsonHelper.SaveToJsonFile(filePath, _contacts);
        }

        public void LoadContactsFromFile(string filePath)
        {
            _contacts = JsonHelper.LoadFromJsonFile<Contact>(filePath);
        }
    }
}
