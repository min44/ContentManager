using System;
using System.Globalization;
using System.Windows.Data;
using ContentManager.Utils;

namespace ContentManager.UI.Converters;

public class StringToDoubleValueConverter : IValueConverter
{
    public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value.ToString();
    }

    public object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var parsed = Double.TryParse(value.ToString(), out var num);
        if (parsed) return num;
        Logger.Debug($"Parsing Error: {value}");
        return null;
    }
}