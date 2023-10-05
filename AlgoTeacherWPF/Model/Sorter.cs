using AlgoTeacherWPF.Model.Enums;
using AlgoTeacherWPF.ViewModel;
using System.Threading;
using System.Threading.Tasks;

namespace AlgoTeacherWPF.Model
{
    public class Sorter : ObservableModel
    {
        private const int SwapIntervalOneX = 4000;
        private const int SwapIntervalTwoX = 3000;
        private const int SwapIntervalThreeX = 2000;
        private const int SwapIntervalFourX = 1000;
        private const int SwapIntervalFiveX = 100;
        public async Task BubbleSort(AlgorithmDetailViewModel algorithmDetailViewModel)
        {
            await Task.Run(() =>
            {
                ResetSortResult(algorithmDetailViewModel);

                var swapInterval = GetSwapInterval(algorithmDetailViewModel.SortSpeed);
                for (var round = 0; round < algorithmDetailViewModel.SortedDataSet.Count - 1; round++)
                {
                    for (var i = 0; i < algorithmDetailViewModel.SortedDataSet.Count - round - 1; i++)
                    {
                        ++algorithmDetailViewModel.SortResultModel.Comparisons;
                        ++algorithmDetailViewModel.SortResultModel.TotalOperations;

                        if (algorithmDetailViewModel.SortedDataSet[i].Number > algorithmDetailViewModel.SortedDataSet[i + 1].Number)
                        {
                            Swap(algorithmDetailViewModel, i, i + 1, swapInterval);
                            ++algorithmDetailViewModel.SortResultModel.Swaps;
                            ++algorithmDetailViewModel.SortResultModel.TotalOperations;
                        }
                    }
                }
            });
        }

        private static void ResetSortResult(AlgorithmDetailViewModel algorithmDetailViewModel)
        {
            algorithmDetailViewModel.SortResultModel.Comparisons = 0;
            algorithmDetailViewModel.SortResultModel.Swaps = 0;
            algorithmDetailViewModel.SortResultModel.TotalOperations = 0;
        }

        private void Swap(AlgorithmDetailViewModel algorithmDetailViewModel, int left, int right, int swapInterval)
        {

            algorithmDetailViewModel.SortedDataSet[left].BackgroundColor = "#ADD8E6";                                               // color what is about to be swapped
            algorithmDetailViewModel.SortedDataSet[right].BackgroundColor = "#ADD8E6";                                              // color what is about to be swapped
            algorithmDetailViewModel.SortedDataSet[left].IsRightArrowVisible = true;                                                // show arrow

            Thread.Sleep(swapInterval / 2);                                                                                         // wait half of swap interval
            (algorithmDetailViewModel.SortedDataSet[left].Number, algorithmDetailViewModel.SortedDataSet[right].Number) =
                (algorithmDetailViewModel.SortedDataSet[right].Number, algorithmDetailViewModel.SortedDataSet[left].Number);        // swap
            algorithmDetailViewModel.SortedDataSet[left].IsRightArrowVisible = false;                                               // hide arrow

            Thread.Sleep(swapInterval / 2);                                                                                         // wait half of swap interval

            algorithmDetailViewModel.SortedDataSet[left].BackgroundColor = "Transparent";                                           // un color after swapping
            algorithmDetailViewModel.SortedDataSet[right].BackgroundColor = "Transparent";                                          // un color after swapping

            algorithmDetailViewModel.SetupSortVisualizationChartViewModel();
        }

        private static int GetSwapInterval(SortSpeed speed)
        {

            return speed switch
            {
                SortSpeed.OneX => SwapIntervalOneX,
                SortSpeed.TwoX => SwapIntervalTwoX,
                SortSpeed.FourX => SwapIntervalFourX,
                SortSpeed.FiveX => SwapIntervalFiveX,
                SortSpeed.ThreeX => SwapIntervalThreeX,
                _ => SwapIntervalThreeX
            };
        }
    }
}
