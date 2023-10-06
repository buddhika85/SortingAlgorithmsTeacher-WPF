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

        public static string GetTextColor(this SortLogMessageType sortLogMessageType)
        {
            switch (sortLogMessageType)
            {
                case SortLogMessageType.NormalMessage:
                    return "black";
                case SortLogMessageType.ComparisonMessage:
                    return "#4895ef";       // blue
                case SortLogMessageType.SwapMessage:
                    return "#f04a00";       // orange
                case SortLogMessageType.NonSwapMessage:
                    return "#33b864";       // green
                case SortLogMessageType.SortStartMessage:
                    return "#b43757";       // purple - hibiscus
                case SortLogMessageType.SortCompleteMessage:
                    return "#af69ee";       // purple - floral
                default:
                    throw new ArgumentOutOfRangeException(nameof(sortLogMessageType), sortLogMessageType, "Unidentified sort log message type");
            }
        }
    }
}
