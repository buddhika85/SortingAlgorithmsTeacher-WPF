using AlgoTeacherWPF.Model.Enums;
using System;
using System.Globalization;
using System.Windows.Data;

namespace AlgoTeacherWPF.Converters
{
    public class ComplexityCaseToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((ComplexityCase)value).GetComplexityStr();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToString() switch
            {
                "Best Case" => ComplexityCase.BestCase,
                "Average Case" => ComplexityCase.AverageCase,
                "Worst Case" => ComplexityCase.WorstCase,
                _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unidentified complexity case")
            };
        }
    }
}
