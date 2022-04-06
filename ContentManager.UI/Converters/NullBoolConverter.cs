using System;
using System.Globalization;
using System.Windows.Data;

namespace ContentManager.UI.Converters;

public class NullBoolConverter : IValueConverter
{
    public bool Invert { get; set; }
    
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return !Invert ? value is not null : value is null;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}