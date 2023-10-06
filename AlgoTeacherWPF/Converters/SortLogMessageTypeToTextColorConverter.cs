using AlgoTeacherWPF.Model.Enums;
using System;
using System.Globalization;
using System.Windows.Data;

namespace AlgoTeacherWPF.Converters
{
    public class SortLogMessageTypeToTextColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value is SortLogMessageType type ? type : SortLogMessageType.NormalMessage).GetTextColor();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return SortLogMessageType.NormalMessage;
        }
    }
}
