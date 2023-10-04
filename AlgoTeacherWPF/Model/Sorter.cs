using AlgoTeacherWPF.Model.Enums;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;

namespace AlgoTeacherWPF.Model
{
    public static class Sorter
    {
        public static void BubbleSort(ObservableCollection<NumberModel> sortedDataSet, SortSpeed speed)
        {
            Task.Run(() =>
            {
                for (var round = 0; round < sortedDataSet.Count - 1; round++)
                {
                    for (var i = 0; i < sortedDataSet.Count - round - 1; i++)
                    {
                        if (sortedDataSet[i].Number > sortedDataSet[i + 1].Number)
                        {
                            //(sortedDataSet[i].Number, sortedDataSet[i + 1].Number) =
                            //    (sortedDataSet[i + 1].Number, sortedDataSet[i].Number);

                            Swap(sortedDataSet, i, i + 1);

                        }
                    }
                }
            });
        }

        private static void Swap(ObservableCollection<NumberModel> sortedDataSet, int left, int right)
        {
            sortedDataSet[left].BackgroundColor = "#ADD8E6";
            sortedDataSet[right].BackgroundColor = "#ADD8E6";
            sortedDataSet[left].IsRightArrowVisible = true;

            Thread.Sleep(2000);
            (sortedDataSet[left].Number, sortedDataSet[right].Number) =
                (sortedDataSet[right].Number, sortedDataSet[left].Number);

            sortedDataSet[left].IsRightArrowVisible = false;
            sortedDataSet[left].BackgroundColor = "Transparent";
            sortedDataSet[right].BackgroundColor = "Transparent";
        }
    }
}
