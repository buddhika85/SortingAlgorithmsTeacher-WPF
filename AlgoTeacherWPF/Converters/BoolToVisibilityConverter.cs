using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace AlgoTeacherWPF.Converters
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is bool and true ? Visibility.Visible : Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is Visibility and Visibility.Visible;
        }
    }
}
