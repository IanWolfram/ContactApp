using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ContactApp.Models;
using ContactApp.Services;
using ContactApp.Views;

namespace ContactApp.ViewModels
{
    public partial class AddContactViewModel : BaseViewModel
    {
        private readonly ContactService _contactService;

        [ObservableProperty]
        private string _name;

        [ObservableProperty]
        private string _email;

        [ObservableProperty]
        private string _phoneNumber;

        [ObservableProperty]
        private string _description;

        public AddContactViewModel(ContactService contactService)
        {
            _contactService = contactService;
            Title = "Add Contact";
        }

        [RelayCommand]
        private async Task SaveContact()
        {
            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Email))
            {
                await Shell.Current.DisplayAlert("Error", "Name and Email are required", "OK");
                return;
            }

            var contact = new ContactModel
            {
                Name = Name,
                Email = Email,
                PhoneNumber = PhoneNumber,
                Description = Description
            };

            _contactService.AddContact(contact);

            // Clear the form
            Name = string.Empty;
            Email = string.Empty;
            PhoneNumber = string.Empty;
            Description = string.Empty;

            // Navigate to Contacts page
            await Shell.Current.GoToAsync(nameof(ContactsPage));
        }
    }
}