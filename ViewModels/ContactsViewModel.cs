using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ContactApp.Models;
using ContactApp.Services;
using ContactApp.Views;
using System.Collections.ObjectModel;

namespace ContactApp.ViewModels
{
    public partial class ContactsViewModel : BaseViewModel
    {
        private readonly ContactService _contactService;

        public ObservableCollection<ContactModel> Contacts => _contactService.Contacts;

        [ObservableProperty]
        private ContactModel _selectedContact;

        public ContactsViewModel(ContactService contactService)
        {
            _contactService = contactService;
            Title = "Contacts";
        }

        [RelayCommand]
        private async Task GoToAddContact()
        {
            await Shell.Current.GoToAsync("///AddContactPage");
        }

        [RelayCommand]
        private async Task ContactSelected()
        {
            if (SelectedContact == null)
                return;

            var parameters = new Dictionary<string, object>
            {
                { "Contact", SelectedContact }
            };

            await Shell.Current.GoToAsync(nameof(ContactDetailsPage), parameters);

            // Reset selection
            SelectedContact = null;
        }
    }
}