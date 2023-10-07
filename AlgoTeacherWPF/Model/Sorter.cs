using AlgoTeacherWPF.Model.Enums;
using AlgoTeacherWPF.ViewModel;
using System.Linq;
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
                AddSortStartEndMessage(algorithmDetailViewModel, true);
                AddCurrentDataSetLogMessage(algorithmDetailViewModel);

                var swapInterval = GetSwapInterval(algorithmDetailViewModel.SortSpeed);
                for (var round = 0; round < algorithmDetailViewModel.SortedDataSet.Count - 1; round++)
                {
                    for (var i = 0; i < algorithmDetailViewModel.SortedDataSet.Count - round - 1; i++)
                    {
                        AddComparisonLogMessage(algorithmDetailViewModel, i);
                        ++algorithmDetailViewModel.SortResultModel.Comparisons;
                        ++algorithmDetailViewModel.SortResultModel.TotalOperations;

                        if (algorithmDetailViewModel.SortedDataSet[i].Number > algorithmDetailViewModel.SortedDataSet[i + 1].Number)
                        {
                            AddSwapLogMessage(algorithmDetailViewModel, i);
                            Swap(algorithmDetailViewModel, i, i + 1, swapInterval);
                            AddCurrentDataSetLogMessage(algorithmDetailViewModel);
                            ++algorithmDetailViewModel.SortResultModel.Swaps;
                            ++algorithmDetailViewModel.SortResultModel.TotalOperations;
                        }
                        else
                        {
                            // no swap 
                            AddNoSwapLogMessage(algorithmDetailViewModel, i);
                        }
                    }
                }

                AddSortStartEndMessage(algorithmDetailViewModel, false);
            });
        }

        public async Task SelectionSort(AlgorithmDetailViewModel algorithmDetailViewModel)
        {
            // To Do
        }

        #region helpers

        private void AddSortStartEndMessage(AlgorithmDetailViewModel algorithmDetailViewModel, bool isStart)
        {
            algorithmDetailViewModel.SortResultModel.AddLogMessage(new SortingLogMessage
            {
                IsSwap = false,
                IsComparison = false,
                SortLogMessageType = isStart ? SortLogMessageType.SortStartMessage : SortLogMessageType.SortCompleteMessage,
                Id = ++algorithmDetailViewModel.SortResultModel.LastLogMessageId,
                Message = isStart ?
                    $"{algorithmDetailViewModel.Algorithm.Name} Starts." :
                    $"{algorithmDetailViewModel.Algorithm.Name} Completed"

            });
        }

        private void AddCurrentDataSetLogMessage(AlgorithmDetailViewModel algorithmDetailViewModel)
        {
            algorithmDetailViewModel.SortResultModel.AddLogMessage(new SortingLogMessage
            {
                IsSwap = false,
                IsComparison = false,
                SortLogMessageType = SortLogMessageType.NormalMessage,
                Id = ++algorithmDetailViewModel.SortResultModel.LastLogMessageId,
                Message =
                    $"Now Data set looks like - {string.Join(", ", algorithmDetailViewModel.SortedDataSet.Select(x => x.Number))}"
            });
        }

        private void AddNoSwapLogMessage(AlgorithmDetailViewModel algorithmDetailViewModel, int left)
        {
            algorithmDetailViewModel.SortResultModel.AddLogMessage(new SortingLogMessage
            {
                IsSwap = false,
                IsComparison = false,
                SortLogMessageType = SortLogMessageType.NonSwapMessage,
                Id = ++algorithmDetailViewModel.SortResultModel.LastLogMessageId,
                Message =
                    $"No swap. Because  {algorithmDetailViewModel.SortedDataSet[left].Number} <= {algorithmDetailViewModel.SortedDataSet[left + 1].Number}"
            });
        }

        private void AddSwapLogMessage(AlgorithmDetailViewModel algorithmDetailViewModel, int left)
        {
            algorithmDetailViewModel.SortResultModel.AddLogMessage(new SortingLogMessage
            {
                IsSwap = true,
                IsComparison = false,
                SortLogMessageType = SortLogMessageType.SwapMessage,
                Id = ++algorithmDetailViewModel.SortResultModel.LastLogMessageId,
                Message =
                    $"Swapping {algorithmDetailViewModel.SortedDataSet[left].Number} and {algorithmDetailViewModel.SortedDataSet[left + 1].Number}," +
                    $"Because  {algorithmDetailViewModel.SortedDataSet[left].Number} > {algorithmDetailViewModel.SortedDataSet[left + 1].Number}"
            });
        }

        private static void AddComparisonLogMessage(AlgorithmDetailViewModel algorithmDetailViewModel, int index)
        {
            algorithmDetailViewModel.SortResultModel.AddLogMessage(new SortingLogMessage
            {
                IsComparison = true,
                IsSwap = false,
                SortLogMessageType = SortLogMessageType.ComparisonMessage,
                Id = ++algorithmDetailViewModel.SortResultModel.LastLogMessageId,
                Message =
                    $"Comparing {algorithmDetailViewModel.SortedDataSet[index].Number} and {algorithmDetailViewModel.SortedDataSet[index + 1].Number}"
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

        #endregion helpers

    }
}
