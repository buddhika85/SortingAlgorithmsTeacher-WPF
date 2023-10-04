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

                            Swap(sortedDataSet, i, i + 1, GetSwapInterval(speed));

                        }
                    }
                }
            });
        }

        private static void Swap(ObservableCollection<NumberModel> sortedDataSet, int left, int right, int swapInterval)
        {
            sortedDataSet[left].BackgroundColor = "#ADD8E6";                    // color what is about to be swapped
            sortedDataSet[right].BackgroundColor = "#ADD8E6";                   // color what is about to be swapped
            sortedDataSet[left].IsRightArrowVisible = true;                     // show arrow

            Thread.Sleep(swapInterval / 2);                                     // wait half of swap interval
            (sortedDataSet[left].Number, sortedDataSet[right].Number) =
                (sortedDataSet[right].Number, sortedDataSet[left].Number);      // swap
            sortedDataSet[left].IsRightArrowVisible = false;                    // hide arrow

            Thread.Sleep(swapInterval / 2);                                     // wait half of swap interval

            sortedDataSet[left].BackgroundColor = "Transparent";                // un color after swapping
            sortedDataSet[right].BackgroundColor = "Transparent";               // un color after swapping
        }

        private static int GetSwapInterval(SortSpeed speed)
        {
            return speed switch
            {
                SortSpeed.OneX => 5000,
                SortSpeed.TwoX => 4000,
                SortSpeed.FourX => 2000,
                SortSpeed.FiveX => 1000,
                SortSpeed.ThreeX => 3000,
                _ => 3000
            };
        }
    }
}
