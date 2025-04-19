using ContactApp.Models;
using System.Collections.ObjectModel;

namespace ContactApp.Services
{
    public class ContactService
    {
        public ObservableCollection<ContactModel> Contacts { get; } = new ObservableCollection<ContactModel>();

        public ContactService()
        {
            // Add some sample data
            AddContact(new ContactModel
            {
                Name = "John Doe",
                Email = "john.doe@example.com",
                PhoneNumber = "555-123-4567",
                Description = "Work colleague"
            });

            AddContact(new ContactModel
            {
                Name = "Jane Smith",
                Email = "jane.smith@example.com",
                PhoneNumber = "555-987-6543",
                Description = "Project manager"
            });
        }

        public void AddContact(ContactModel contact)
        {
            Contacts.Add(contact);
        }

        public bool UpdateContact(ContactModel contact)
        {
            var existingContact = Contacts.FirstOrDefault(c => c.Id == contact.Id);
            if (existingContact != null)
            {
                int index = Contacts.IndexOf(existingContact);
                Contacts[index] = contact;
                return true;
            }
            return false;
        }
    }
}