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
                            (sortedDataSet[i].Number, sortedDataSet[i + 1].Number) =
                                (sortedDataSet[i + 1].Number, sortedDataSet[i].Number);

                            Thread.Sleep(2000);
                        }
                    }
                }
            });
        }

        private static void Swap(ObservableCollection<NumberModel> sortedDataSet, int left, int right)
        {
            (sortedDataSet[left].Number, sortedDataSet[right].Number) =
                (sortedDataSet[right].Number, sortedDataSet[left].Number);
        }
    }
}
