using ContactApp.Services;
using ContactApp.ViewModels;
using ContactApp.Views;
using Microsoft.Extensions.Logging;

namespace ContactApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        // Register services
        builder.Services.AddSingleton<ContactService>();

        // Register ViewModels
        builder.Services.AddSingleton<AddContactViewModel>();
        builder.Services.AddSingleton<ContactsViewModel>();
        builder.Services.AddTransient<ContactDetailsViewModel>();

        // Register Views
        builder.Services.AddSingleton<AddContactPage>();
        builder.Services.AddSingleton<ContactsPage>();
        builder.Services.AddTransient<ContactDetailsPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}