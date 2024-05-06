using System.Globalization;

namespace MazeGenerator.Ui.Converters;

public class IntegerToGridColumnCountConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        bool isValidInteger = int.TryParse(value.ToString(), out int columnCount);

        bool isPositiveInteger = columnCount >= 0;

        if (!isValidInteger && !isPositiveInteger)
        {
            throw new ArgumentException("Invalid column count.");
        }

        var columnDefinitions = Enumerable.Repeat(new ColumnDefinition(GridLength.Star), columnCount).ToArray();

        var columnDefinitionCollection = new ColumnDefinitionCollection(columnDefinitions);

        return columnDefinitionCollection;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
