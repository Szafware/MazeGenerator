using System.Globalization;

namespace MazeGenerator.Ui.Converters;

public class BoolToVisibilityConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        bool isVisible = (bool)value;

        var visibility = isVisible ? Visibility.Visible : Visibility.Hidden;

        return visibility;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
