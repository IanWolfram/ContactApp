using ContactApp.ViewModels;
using System.Windows.Input;

namespace ContactApp.Views;


public partial class ContactDetailsPage : ContentPage
{
    public ContactDetailsPage(ContactDetailsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}


// Custom converters for the DetailsPage
public class BoolToStringConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {

        bool isTrue = (bool)value;
        string[] options = parameter.ToString().Split('|');
        return isTrue ? options[0] : options[1];
    }

    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}


public class BoolToCommandConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        bool isTrue = (bool)value;
        var parameters = parameter.ToString().Split('|');

        if (parameter is string paramString)
        {
            var commands = paramString.Split('|');
            int index = isTrue ? 0 : 1;
            return commands[index];
        }

        return null;
    }

    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        throw new NotImplementedException();

    }
}