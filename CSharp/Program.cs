using Microsoft.Extensions.DependencyInjection;
using ContactListApp.Library.Interfaces;
using ContactListApp.Library.Services;
using ContactListApp.Library.Models;
using ContactListApp.Services;

namespace ContactListApp
{
    class Program
    {
        private static IServiceProvider _serviceProvider;

        static void Main(string[] args)
        {
            ConfigureServices();

            var contactService = _serviceProvider.GetRequiredService<IContactService>();
            const string filePath = "contacts.json";

            contactService.LoadContactsFromFile(filePath);

            RunMenu(contactService, filePath);
        }

        private static void ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton<IContactService, ContactService>();

            _serviceProvider = services.BuildServiceProvider();
        }

        private static void RunMenu(IContactService contactService, string filePath)
        {
            while (true)
            {
                Console.WriteLine("1. Lista alla kontakter");
                Console.WriteLine("2. Lägg till ny kontakt");
                Console.WriteLine("3. Avsluta");
                Console.Write("Välj ett alternativ: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        var contacts = contactService.GetAllContacts();
                        if (contacts.Count == 0)
                        {
                            Console.WriteLine("Inga kontakter att visa.");
                        }
                        else
                        {
                            foreach (var contact in contacts)
                            {
                                Console.WriteLine($"ID: {contact.Id}");
                                Console.WriteLine($"Namn: {contact.FirstName} {contact.LastName}");
                                Console.WriteLine($"E-post: {contact.Email}");
                                Console.WriteLine($"Telefon: {contact.PhoneNumber}");
                                Console.WriteLine($"Adress: {contact.StreetAddress}, {contact.PostalCode} {contact.City}");
                                Console.WriteLine(new string('-', 20));
                            }
                        }
                        break;

                    case "2":
                        var newContact = new Contact();
                        Console.Write("Förnamn: ");
                        newContact.FirstName = Console.ReadLine();
                        Console.Write("Efternamn: ");
                        newContact.LastName = Console.ReadLine();
                        Console.Write("E-post: ");
                        newContact.Email = Console.ReadLine();
                        Console.Write("Telefonnummer: ");
                        newContact.PhoneNumber = Console.ReadLine();
                        Console.Write("Gatuadress: ");
                        newContact.StreetAddress = Console.ReadLine();
                        Console.Write("Postnummer: ");
                        newContact.PostalCode = Console.ReadLine();
                        Console.Write("Ort: ");
                        newContact.City = Console.ReadLine();

                        contactService.AddContact(newContact);
                        contactService.SaveContactsToFile(filePath);
                        Console.WriteLine("Kontakt tillagd!");
                        break;

                    case "3":
                        contactService.SaveContactsToFile(filePath);
                        Console.WriteLine("Avslutar programmet.");
                        return;

                    default:
                        Console.WriteLine("Ogiltigt val. Försök igen.");
                        break;
                }
            }
        }
    }
}

