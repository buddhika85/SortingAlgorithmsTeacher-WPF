using System;

namespace AlgoTeacherWPF.Model.Enums
{
    public static class EnumExtensions
    {
        public static string GetComplexityStr(this ComplexityCase complexityCase)
        {
            return complexityCase switch
            {
                ComplexityCase.WorstCase => "Worst Case",
                ComplexityCase.AverageCase => "Average Case",
                ComplexityCase.BestCase => "Best Case",
                _ => throw new ArgumentOutOfRangeException(nameof(complexityCase), complexityCase,
                    "Unidentified complexity case")
            };
        }
    }
}
