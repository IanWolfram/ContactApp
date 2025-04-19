using ContactApp.Views;

namespace ContactApp;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        // Register routes for navigation
        Routing.RegisterRoute(nameof(ContactsPage), typeof(ContactsPage));
        Routing.RegisterRoute(nameof(ContactDetailsPage), typeof(ContactDetailsPage));
    }
}