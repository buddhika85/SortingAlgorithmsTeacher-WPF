using System;
using System.Globalization;
using System.Windows.Data;

namespace AlgoTeacherWPF.Converters
{
    public class BoolToStringYesNoConverter : IValueConverter
    {
        private const string Yes = "Yes";
        private const string No = "No";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
                return Yes;
            return No;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((string)value).Equals(Yes);
        }
    }
}
