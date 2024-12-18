using System.Collections.Generic;
using ContactListApp.Library.Models;
using ContactListApp.Models;

namespace ContactListApp.Library.Interfaces
{
    public interface IContactService
    {
        void AddContact(Contact contact);
        List<Contact> GetAllContacts();
        void SaveContactsToFile(string filePath);
        void LoadContactsFromFile(string filePath);
    }
}
