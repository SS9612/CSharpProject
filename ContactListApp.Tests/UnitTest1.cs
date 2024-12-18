using System;
using System.Collections.Generic;
using ContactListApp.Models;
using ContactListApp.Services;
using Xunit;

namespace ContactListApp.Tests
{
    public class ContactServiceTests
    {
        [Fact]
        public void AddContact_ShouldAddContactToList()
        {
            var service = new ContactService();
            var contact = new Contact { FirstName = "Test", LastName = "User" };

            service.AddContact(contact);

            _ = Assert.Single(service.GetAllContacts());
        }

        [Fact]
        public void SaveAndLoadContacts_ShouldPersistContacts()
        {
            var service = new ContactService();
            var filePath = "test_contacts.json";
            var contact = new Contact { FirstName = "Test", LastName = "User" };
            service.AddContact(contact);

            service.SaveContactsToFile(filePath);
            service.LoadContactsFromFile(filePath);

            Assert.Single(collection: service.GetAllContacts());
        }
    }
}
