using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ContactApp.Models;
using ContactApp.Services;

namespace ContactApp.ViewModels
{
    [QueryProperty(nameof(Contact), "Contact")]
    public partial class ContactDetailsViewModel : BaseViewModel
    {
        private readonly ContactService _contactService;

        [ObservableProperty]
        private ContactModel _contact;

        [ObservableProperty]
        private bool _isEditing;

        [ObservableProperty]
        private string _name;

        [ObservableProperty]
        private string _email;

        [ObservableProperty]
        private string _phoneNumber;

        [ObservableProperty]
        private string _description;

        public ContactDetailsViewModel(ContactService contactService)
        {
            _contactService = contactService;
            Title = "Contact Details";
        }

        partial void OnContactChanged(ContactModel value)
        {
            if (value != null)
            {
                Name = value.Name;
                Email = value.Email;
                PhoneNumber = value.PhoneNumber;
                Description = value.Description;
            }
        }

        [RelayCommand]
        private void ToggleEdit()
        {
            IsEditing = !IsEditing;
        }

        [RelayCommand]
        private async Task SaveChanges()
        {
            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Email))
            {
                await Shell.Current.DisplayAlert("Error", "Name and Email are required", "OK");
                return;
            }

            Contact.Name = Name;
            Contact.Email = Email;
            Contact.PhoneNumber = PhoneNumber;
            Contact.Description = Description;

            _contactService.UpdateContact(Contact);

            IsEditing = false;
            await Shell.Current.DisplayAlert("Success", "Contact updated successfully", "OK");
        }

        [RelayCommand]
        private async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}