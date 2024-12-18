using ContactListApp.Library.Models;

namespace ContactListApp.Library.Utilities
{
    public static class ContactFactory
    {
        public static Contact CreateContact(string firstName, string lastName, string email)
        {
            return new Contact
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email
            };
        }
    }
}
