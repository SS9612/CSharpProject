using Moq;
using Xunit;
using ContactListApp.Library.Interfaces;
using ContactListApp.Library.Models;
using ContactListApp.GUI.Views;

namespace ContactListApp.Tests
{
    public class CreateContactPageTests
    {
        [Fact]
        public void SaveButton_ShouldAddContact()
        {
            var mockService = new Mock<IContactService>();
            var page = new CreateContactPage(mockService.Object);

            page.FirstNameTextBox.Text = "John";
            page.LastNameTextBox.Text = "Doe";
            page.EmailTextBox.Text = "john.doe@example.com";

            page.SaveButton_Click(null, null);

            mockService.Verify(service => service.AddContact(It.Is<Contact>(
                contact => contact.FirstName == "John" &&
                           contact.LastName == "Doe" &&
                           contact.Email == "john.doe@example.com"
            )), Times.Once);

            mockService.Verify(service => service.SaveContactsToFile(It.IsAny<string>()), Times.Once);
        }
    }
}
