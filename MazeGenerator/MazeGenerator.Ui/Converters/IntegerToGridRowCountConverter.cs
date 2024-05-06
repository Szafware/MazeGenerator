using System.Globalization;

namespace MazeGenerator.Ui.Converters;

public class IntegerToGridRowCountConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        bool isValidInteger = int.TryParse(value.ToString(), out int rowCount);

        bool isPositiveInteger = rowCount >= 0;

        if (!isValidInteger && !isPositiveInteger)
        {
            throw new ArgumentException("Invalid row or column count.");
        }

        var rowDefinitions = Enumerable.Repeat(new RowDefinition(GridLength.Star), rowCount).ToArray();

        var rowDefinitionCollection = new RowDefinitionCollection(rowDefinitions);

        return rowDefinitionCollection;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
